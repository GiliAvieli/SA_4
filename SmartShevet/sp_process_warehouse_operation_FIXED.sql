USE SmartShevet;
GO

-- Stored Procedure: sp_process_warehouse_operation (FIXED VERSION)
-- Purpose: Handle equipment issue and return operations with atomic transactions
-- Atomicity: All operations succeed or all rollback
-- Auto-Archive: Closes reservation when all items are fully resolved
-- FIX: Added issuedTold column with default value 'מדריך'

CREATE OR ALTER PROCEDURE sp_process_warehouse_operation
    @equipmentreservation_id INT,
    @operationsJson NVARCHAR(MAX)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRAN;

        -- =====================================================================
        -- GUARD 1: Validate reservation exists and is "Approved"
        -- =====================================================================
        IF NOT EXISTS (SELECT 1 FROM EquipmentReservation WHERE equipmentreservation_id = @equipmentreservation_id)
            THROW 50001, N'הזמנה לא קיימת', 1;

        DECLARE @CurrentStatus NVARCHAR(50);
        SELECT @CurrentStatus = reservationStatus FROM EquipmentReservation
        WHERE equipmentreservation_id = @equipmentreservation_id;

        IF @CurrentStatus != 'Approved'
            THROW 50002, N'הזמנה אינה במצב "Approved" להנפקה או החזרה', 1;

        -- =====================================================================
        -- GUARD 2: Validate JSON is not null/empty
        -- =====================================================================
        IF @operationsJson IS NULL OR LEN(@operationsJson) = 0
            THROW 50003, N'רשימת פעולות ריקה', 1;

        -- =====================================================================
        -- PROCESS EACH OPERATION
        -- =====================================================================
        DECLARE @Index INT = 0;
        DECLARE @Count INT;
        DECLARE @EquipmentId INT;
        DECLARE @DeliveredQty INT;
        DECLARE @ReturnedOkQty INT;
        DECLARE @LostQty INT;
        DECLARE @DamagedQty INT;
        DECLARE @ReservationDetailId INT;
        DECLARE @EquipmentIssueId INT;
        DECLARE @NextIssueId INT;

        -- Count items in JSON
        SELECT @Count = COUNT(*) FROM OPENJSON(@operationsJson);

        -- Get next EquipmentIssue ID
        SELECT @NextIssueId = ISNULL(MAX(equipmentissue_id), 0) + 1 FROM EquipmentIssue;

        WHILE @Index < @Count
        BEGIN
            -- Extract values from JSON array
            SELECT
                @EquipmentId = JSON_VALUE(@operationsJson, '$[' + CAST(@Index AS VARCHAR) + '].equipmentId'),
                @DeliveredQty = JSON_VALUE(@operationsJson, '$[' + CAST(@Index AS VARCHAR) + '].deliveredQty'),
                @ReturnedOkQty = JSON_VALUE(@operationsJson, '$[' + CAST(@Index AS VARCHAR) + '].returnedOkQty'),
                @LostQty = JSON_VALUE(@operationsJson, '$[' + CAST(@Index AS VARCHAR) + '].lostQty'),
                @DamagedQty = JSON_VALUE(@operationsJson, '$[' + CAST(@Index AS VARCHAR) + '].damagedQty');

            -- Set defaults to 0 if null
            SET @DeliveredQty = ISNULL(CAST(@DeliveredQty AS INT), 0);
            SET @ReturnedOkQty = ISNULL(CAST(@ReturnedOkQty AS INT), 0);
            SET @LostQty = ISNULL(CAST(@LostQty AS INT), 0);
            SET @DamagedQty = ISNULL(CAST(@DamagedQty AS INT), 0);

            -- GUARD 3: Validate equipment exists
            IF NOT EXISTS (SELECT 1 FROM Equipment WHERE equipment_id = @EquipmentId)
                THROW 50004, N'ציוד לא קיים במערכת', 1;

            -- GUARD 4: Find ReservationDetail for this equipment in this reservation
            SELECT @ReservationDetailId = reservationdetails_id
            FROM ReservationDetails
            WHERE equipmentId = @EquipmentId AND equipmentreservation_id = @equipmentreservation_id;

            IF @ReservationDetailId IS NULL
                THROW 50005, N'פריט לא נמצא בהזמנה זו', 1;

            -- =====================================================================
            -- ISSUE OPERATION: Create or update EquipmentIssue with delivered qty
            -- =====================================================================
            IF @DeliveredQty > 0
            BEGIN
                -- Check if EquipmentIssue already exists for this detail
                SELECT @EquipmentIssueId = equipmentissue_id
                FROM EquipmentIssue
                WHERE equipmentId = @EquipmentId AND reservation_detail_id = @ReservationDetailId;

                IF @EquipmentIssueId IS NULL
                BEGIN
                    -- Create new EquipmentIssue record
                    -- FIX: Include issuedTold column with default value 'מדריך'
                    INSERT INTO EquipmentIssue (equipmentissue_id, equipmentId, reservationId, reservation_detail_id, issued_qty, returned_ok_qty, lost_qty, damaged_qty, status, issueDate, issuedTold)
                    VALUES (@NextIssueId, @EquipmentId, @equipmentreservation_id, @ReservationDetailId, @DeliveredQty, 0, 0, 0, 'Active', GETDATE(), N'מדריך');
                    SET @NextIssueId = @NextIssueId + 1;
                END
                ELSE
                BEGIN
                    -- Update existing EquipmentIssue with issued qty
                    UPDATE EquipmentIssue
                    SET issued_qty = @DeliveredQty,
                        issueDate = GETDATE(),
                        status = 'Active'
                    WHERE equipmentissue_id = @EquipmentIssueId;
                END
            END

            -- =====================================================================
            -- RETURN OPERATIONS: Update EquipmentIssue with return data
            -- =====================================================================
            IF (@ReturnedOkQty + @LostQty + @DamagedQty) > 0
            BEGIN
                -- Verify EquipmentIssue exists (must have been issued first)
                SELECT @EquipmentIssueId = equipmentissue_id
                FROM EquipmentIssue
                WHERE equipmentId = @EquipmentId AND reservation_detail_id = @ReservationDetailId;

                IF @EquipmentIssueId IS NULL
                    THROW 50006, N'לא ניתן להחזיר פריט שלא הנפק', 1;

                -- Update EquipmentIssue with return quantities and mark as Completed
                UPDATE EquipmentIssue
                SET returned_ok_qty = @ReturnedOkQty,
                    lost_qty = @LostQty,
                    damaged_qty = @DamagedQty,
                    status = 'Completed',
                    returnDate = GETDATE(),
                    condition = CASE
                        WHEN @LostQty > 0 THEN 'lost'
                        WHEN @DamagedQty > 0 THEN 'damaged'
                        WHEN @ReturnedOkQty > 0 THEN 'good'
                        ELSE 'unknown'
                    END
                WHERE equipmentissue_id = @EquipmentIssueId;

                -- ADD RETURNED OK ITEMS BACK TO EQUIPMENT QUANTITY
                -- This restores inventory for items that came back in good condition
                IF @ReturnedOkQty > 0
                BEGIN
                    UPDATE Equipment
                    SET quantity = quantity + @ReturnedOkQty,
                        lastUpdated = GETDATE()
                    WHERE equipment_id = @EquipmentId;
                END

                -- MARK EQUIPMENT AS LOST if any items were lost
                -- Lost equipment is written off (quantity remains reduced)
                IF @LostQty > 0
                BEGIN
                    UPDATE Equipment
                    SET status = 'lost',
                        lastUpdated = GETDATE()
                    WHERE equipment_id = @EquipmentId;
                END

                -- MARK EQUIPMENT AS DAMAGED if any items were damaged
                -- Damaged equipment is flagged for repair (quantity remains reduced)
                IF @DamagedQty > 0
                BEGIN
                    UPDATE Equipment
                    SET status = 'damaged',
                        lastUpdated = GETDATE()
                    WHERE equipment_id = @EquipmentId;
                END
            END

            SET @Index = @Index + 1;
        END

        -- =====================================================================
        -- AUTO-ARCHIVE: Check if all items are fully resolved
        -- =====================================================================
        -- Count total items in this reservation
        DECLARE @TotalItems INT;
        SELECT @TotalItems = COUNT(*)
        FROM ReservationDetails
        WHERE equipmentreservation_id = @equipmentreservation_id;

        -- Count items with completed issues
        DECLARE @CompletedItems INT;
        SELECT @CompletedItems = COUNT(*)
        FROM EquipmentIssue ei
        INNER JOIN ReservationDetails rd ON ei.reservation_detail_id = rd.reservationdetails_id
        WHERE rd.equipmentreservation_id = @equipmentreservation_id
          AND ei.status = 'Completed';

        -- If all items are completed, close the reservation
        IF @TotalItems > 0 AND @CompletedItems = @TotalItems
        BEGIN
            UPDATE EquipmentReservation
            SET reservationStatus = 'Closed',
                activityDate = GETDATE()
            WHERE equipmentreservation_id = @equipmentreservation_id;
        END

        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRAN;
        THROW;
    END CATCH
END;
GO

PRINT 'sp_process_warehouse_operation FIXED created successfully!';

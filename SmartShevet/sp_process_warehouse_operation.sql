USE SmartShevet;
GO

-- Stored Procedure: sp_process_warehouse_operation
-- Purpose: Handle equipment issue and return operations with atomic transactions
-- Atomicity: All operations succeed or all rollback
-- Auto-Archive: Closes reservation when all items are fully resolved

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
        IF NOT EXISTS (SELECT 1 FROM EquipmentReservation WHERE equipment_reservation_id = @equipmentreservation_id)
            THROW 50001, N'הזמנה לא קיימת', 1;

        DECLARE @CurrentStatus NVARCHAR(50);
        SELECT @CurrentStatus = reservation_status FROM EquipmentReservation
        WHERE equipment_reservation_id = @equipmentreservation_id;

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
        SELECT @NextIssueId = ISNULL(MAX(equipment_issue_id), 0) + 1 FROM EquipmentIssue;

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
            SELECT @ReservationDetailId = reservation_detail_id
            FROM ReservationDetails
            WHERE equipment_id = @EquipmentId AND equipmentreservation_id = @equipmentreservation_id;

            IF @ReservationDetailId IS NULL
                THROW 50005, N'פריט לא נמצא בהזמנה זו', 1;

            -- =====================================================================
            -- ISSUE OPERATION: Create or update EquipmentIssue with delivered qty
            -- =====================================================================
            IF @DeliveredQty > 0
            BEGIN
                -- Check if EquipmentIssue already exists
                SELECT @EquipmentIssueId = equipment_issue_id
                FROM EquipmentIssue
                WHERE equipment_id = @EquipmentId AND reservation_detail_id = @ReservationDetailId;

                IF @EquipmentIssueId IS NULL
                BEGIN
                    -- Create new EquipmentIssue record
                    INSERT INTO EquipmentIssue (equipment_issue_id, equipment_id, reservation_detail_id, issued_qty, returned_ok_qty, lost_qty, damaged_qty, status, issue_date)
                    VALUES (@NextIssueId, @EquipmentId, @ReservationDetailId, @DeliveredQty, 0, 0, 0, 'Active', GETDATE());
                    SET @NextIssueId = @NextIssueId + 1;
                END
                ELSE
                BEGIN
                    -- Update existing EquipmentIssue with issued qty
                    UPDATE EquipmentIssue
                    SET issued_qty = @DeliveredQty,
                        issue_date = GETDATE(),
                        status = 'Active'
                    WHERE equipment_issue_id = @EquipmentIssueId;
                END
            END

            -- =====================================================================
            -- RETURN OPERATIONS: Update EquipmentIssue with return data
            -- =====================================================================
            IF (@ReturnedOkQty + @LostQty + @DamagedQty) > 0
            BEGIN
                -- Verify EquipmentIssue exists (must have been issued first)
                SELECT @EquipmentIssueId = equipment_issue_id
                FROM EquipmentIssue
                WHERE equipment_id = @EquipmentId AND reservation_detail_id = @ReservationDetailId;

                IF @EquipmentIssueId IS NULL
                    THROW 50006, N'לא ניתן להחזיר פריט שלא הנפק', 1;

                -- Update EquipmentIssue with return quantities and mark as Completed
                UPDATE EquipmentIssue
                SET returned_ok_qty = @ReturnedOkQty,
                    lost_qty = @LostQty,
                    damaged_qty = @DamagedQty,
                    status = 'Completed',
                    return_date = GETDATE()
                WHERE equipment_issue_id = @EquipmentIssueId;

                -- ADD RETURNED OK ITEMS BACK TO EQUIPMENT QUANTITY
                -- This restores inventory for items that came back in good condition
                IF @ReturnedOkQty > 0
                BEGIN
                    UPDATE Equipment
                    SET quantity = quantity + @ReturnedOkQty,
                        last_updated = GETDATE()
                    WHERE equipment_id = @EquipmentId;
                END

                -- MARK EQUIPMENT AS LOST if any items were lost
                -- Lost equipment is written off (quantity remains reduced)
                IF @LostQty > 0
                BEGIN
                    UPDATE Equipment
                    SET status = 'lost',
                        last_updated = GETDATE()
                    WHERE equipment_id = @EquipmentId;
                END

                -- MARK EQUIPMENT AS DAMAGED if any items were damaged
                -- Damaged equipment is flagged for repair (quantity remains reduced)
                IF @DamagedQty > 0
                BEGIN
                    UPDATE Equipment
                    SET status = 'damaged',
                        last_updated = GETDATE()
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
        INNER JOIN ReservationDetails rd ON ei.reservation_detail_id = rd.reservation_detail_id
        WHERE rd.equipmentreservation_id = @equipmentreservation_id
          AND ei.status = 'Completed';

        -- If all items are completed, close the reservation
        IF @TotalItems > 0 AND @CompletedItems = @TotalItems
        BEGIN
            UPDATE EquipmentReservation
            SET reservation_status = 'Closed',
                activity_date = GETDATE()
            WHERE equipment_reservation_id = @equipmentreservation_id;
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

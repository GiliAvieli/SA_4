USE SmartShevet;
GO

-- Process warehouse operations (issue and return of equipment)
-- Takes a reservation ID and JSON array of operations
-- Inserts or updates EquipmentIssue records WITHOUT deleting the reservation

CREATE OR ALTER PROCEDURE sp_process_warehouse_operation
    @equipmentreservation_id INT,
    @operationsJson NVARCHAR(MAX)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRAN;

        -- =====================================================================
        -- GUARD 1: Validate reservation exists
        -- =====================================================================
        IF NOT EXISTS (SELECT 1 FROM EquipmentReservation WHERE equipmentreservation_id = @equipmentreservation_id)
            THROW 50001, N'הזמנה לא קיימת', 1;

        -- =====================================================================
        -- GUARD 2: Validate JSON is not null/empty
        -- =====================================================================
        IF @operationsJson IS NULL OR LEN(@operationsJson) = 0
            THROW 50003, N'רשימת פעולות ריקה', 1;

        -- =====================================================================
        -- PROCESS EACH OPERATION (ISSUE OR RETURN)
        -- =====================================================================
        DECLARE @Index INT = 0;
        DECLARE @Count INT;
        DECLARE @EquipmentId INT;
        DECLARE @DeliveredQty INT;
        DECLARE @ReturnedOkQty INT;
        DECLARE @LostQty INT;
        DECLARE @DamagedQty INT;
        DECLARE @ReservationDetailId INT;
        DECLARE @ExistingIssueId INT;

        -- Count items in JSON
        SELECT @Count = COUNT(*) FROM OPENJSON(@operationsJson);

        WHILE @Index < @Count
        BEGIN
            -- Extract operation data from JSON
            SELECT
                @EquipmentId = JSON_VALUE(@operationsJson, '$[' + CAST(@Index AS VARCHAR) + '].equipmentId'),
                @DeliveredQty = JSON_VALUE(@operationsJson, '$[' + CAST(@Index AS VARCHAR) + '].deliveredQty'),
                @ReturnedOkQty = JSON_VALUE(@operationsJson, '$[' + CAST(@Index AS VARCHAR) + '].returnedOkQty'),
                @LostQty = JSON_VALUE(@operationsJson, '$[' + CAST(@Index AS VARCHAR) + '].lostQty'),
                @DamagedQty = JSON_VALUE(@operationsJson, '$[' + CAST(@Index AS VARCHAR) + '].damagedQty');

            SET @DeliveredQty = ISNULL(CAST(@DeliveredQty AS INT), 0);
            SET @ReturnedOkQty = ISNULL(CAST(@ReturnedOkQty AS INT), 0);
            SET @LostQty = ISNULL(CAST(@LostQty AS INT), 0);
            SET @DamagedQty = ISNULL(CAST(@DamagedQty AS INT), 0);

            -- GUARD 3: Validate equipment exists
            IF NOT EXISTS (SELECT 1 FROM Equipment WHERE equipment_id = @EquipmentId)
                THROW 50004, N'ציוד לא קיים במערכת', 1;

            -- Find the ReservationDetails for this equipment in this reservation
            SELECT @ReservationDetailId = reservationdetails_id
            FROM ReservationDetails
            WHERE equipmentreservation_id = @equipmentreservation_id
              AND equipmentId = @EquipmentId;

            IF @ReservationDetailId IS NULL
            BEGIN
                SET @Index = @Index + 1;
                CONTINUE;
            END;

            -- Check if EquipmentIssue already exists for this detail
            SELECT @ExistingIssueId = equipmentissue_id
            FROM EquipmentIssue
            WHERE reservation_detail_id = @ReservationDetailId;

            IF @ExistingIssueId IS NOT NULL
            BEGIN
                -- UPDATE existing EquipmentIssue record
                UPDATE EquipmentIssue
                SET issued_qty = @DeliveredQty,
                    returned_ok_qty = @ReturnedOkQty,
                    lost_qty = @LostQty,
                    damaged_qty = @DamagedQty,
                    last_updated = GETDATE()
                WHERE equipmentissue_id = @ExistingIssueId;
            END
            ELSE IF @DeliveredQty > 0 OR @ReturnedOkQty > 0 OR @LostQty > 0 OR @DamagedQty > 0
            BEGIN
                -- INSERT new EquipmentIssue record
                DECLARE @NextIssueId INT;
                SELECT @NextIssueId = ISNULL(MAX(equipmentissue_id), 0) + 1 FROM EquipmentIssue;

                INSERT INTO EquipmentIssue (
                    equipmentissue_id,
                    equipmentreservation_id,
                    reservation_detail_id,
                    equipment_id,
                    issued_qty,
                    returned_ok_qty,
                    lost_qty,
                    damaged_qty,
                    date_issued,
                    last_updated
                )
                VALUES (
                    @NextIssueId,
                    @equipmentreservation_id,
                    @ReservationDetailId,
                    @EquipmentId,
                    @DeliveredQty,
                    @ReturnedOkQty,
                    @LostQty,
                    @DamagedQty,
                    GETDATE(),
                    GETDATE()
                );
            END;

            SET @Index = @Index + 1;
        END;

        -- =====================================================================
        -- UPDATE RESERVATION STATUS: Only change status if ALL items fully returned
        -- Reservation stays "Approved" during partial returns, only completes when all returned
        -- =====================================================================
        DECLARE @TotalRequestedQty INT;
        DECLARE @TotalReturnedQty INT;

        SELECT @TotalRequestedQty = SUM(quantity)
        FROM ReservationDetails
        WHERE equipmentreservation_id = @equipmentreservation_id;

        SELECT @TotalReturnedQty = SUM(returned_ok_qty + lost_qty + damaged_qty)
        FROM EquipmentIssue
        WHERE equipmentreservation_id = @equipmentreservation_id;

        SET @TotalReturnedQty = ISNULL(@TotalReturnedQty, 0);

        -- Only mark as "Completed" if all equipment accounted for
        IF @TotalReturnedQty >= @TotalRequestedQty
        BEGIN
            UPDATE EquipmentReservation
            SET reservationStatus = 'Completed',
                last_updated = GETDATE()
            WHERE equipmentreservation_id = @equipmentreservation_id;
        END;

        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRAN;
        THROW;
    END CATCH
END;
GO

PRINT 'sp_process_warehouse_operation created successfully!';

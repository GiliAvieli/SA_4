USE SmartShevet;
GO

-- Updated sp_reserve_equipment to handle both consumable and reusable items
-- Consumable: Reduce Equipment.quantity
-- Reusable: Link specific EquipmentInstance records to the reservation

CREATE OR ALTER PROCEDURE sp_reserve_equipment
    @equipmentreservation_id INT,
    @requestDate DATETIME,
    @activityDate DATETIME,
    @requestedById INT,
    @itemsJson NVARCHAR(MAX)
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
            THROW 50002, N'הזמנה אינה במצב "Approved" להזמנה', 1;

        -- =====================================================================
        -- GUARD 2: Validate JSON is not null/empty
        -- =====================================================================
        IF @itemsJson IS NULL OR LEN(@itemsJson) = 0
            THROW 50003, N'רשימת פעולות ריקה', 1;

        -- =====================================================================
        -- PROCESS EACH ITEM (CONSUMABLE OR REUSABLE)
        -- =====================================================================
        DECLARE @Index INT = 0;
        DECLARE @Count INT;
        DECLARE @EquipmentId INT;
        DECLARE @RequestedQty INT;
        DECLARE @EquipmentType NVARCHAR(50);
        DECLARE @NextDetailsId INT;

        -- Count items in JSON
        SELECT @Count = COUNT(*) FROM OPENJSON(@itemsJson);

        -- Get next ReservationDetails ID
        SELECT @NextDetailsId = ISNULL(MAX(reservationdetails_id), 0) + 1 FROM ReservationDetails;

        WHILE @Index < @Count
        BEGIN
            -- Extract equipment ID and quantity from JSON
            SELECT
                @EquipmentId = JSON_VALUE(@itemsJson, '$[' + CAST(@Index AS VARCHAR) + '].equipmentId'),
                @RequestedQty = JSON_VALUE(@itemsJson, '$[' + CAST(@Index AS VARCHAR) + '].quantity');

            SET @RequestedQty = ISNULL(CAST(@RequestedQty AS INT), 0);

            -- GUARD 3: Validate equipment exists
            IF NOT EXISTS (SELECT 1 FROM Equipment WHERE equipment_id = @EquipmentId)
                THROW 50004, N'ציוד לא קיים במערכת', 1;

            -- Get equipment type (consumable or reusable)
            SELECT @EquipmentType = equipmentType FROM Equipment WHERE equipment_id = @EquipmentId;

            -- =====================================================================
            -- CONSUMABLE ITEM: Reduce quantity in Equipment table
            -- =====================================================================
            IF @EquipmentType = 'consumable'
            BEGIN
                -- GUARD 4: Check if sufficient quantity available
                IF (SELECT quantity FROM Equipment WHERE equipment_id = @EquipmentId) < @RequestedQty
                    THROW 50006, N'כמות לא מספקת של פריט זה', 1;

                -- Reduce Equipment quantity
                UPDATE Equipment
                SET quantity = quantity - @RequestedQty,
                    lastUpdated = GETDATE()
                WHERE equipment_id = @EquipmentId;

                -- Create ReservationDetails record (quantity-based)
                INSERT INTO ReservationDetails (reservationdetails_id, entry, quantity, equipmentId, equipmentreservation_id, addedEquipment)
                VALUES (@NextDetailsId, @Index + 1, @RequestedQty, @EquipmentId, @equipmentreservation_id, 0);
                SET @NextDetailsId = @NextDetailsId + 1;
            END

            -- =====================================================================
            -- REUSABLE ITEM: Link specific instances to the reservation
            -- =====================================================================
            ELSE IF @EquipmentType = 'reusable'
            BEGIN
                -- GUARD 5: Check if sufficient available instances exist
                DECLARE @AvailableCount INT;
                SELECT @AvailableCount = COUNT(*)
                FROM EquipmentInstance
                WHERE equipment_id = @EquipmentId AND status = 'available';

                IF @AvailableCount < @RequestedQty
                    THROW 50007, N'לא מספיק יחידות זמינות של פריט זה', 1;

                -- Create ReservationDetails record for this equipment type
                INSERT INTO ReservationDetails (reservationdetails_id, entry, quantity, equipmentId, equipmentreservation_id, addedEquipment)
                VALUES (@NextDetailsId, @Index + 1, @RequestedQty, @EquipmentId, @equipmentreservation_id, 0);

                -- Link specific available instances to this reservation
                DECLARE @InstanceCount INT = 0;
                DECLARE @InstanceId INT;

                DECLARE instance_cursor CURSOR FOR
                    SELECT TOP (@RequestedQty) equipment_instance_id
                    FROM EquipmentInstance
                    WHERE equipment_id = @EquipmentId AND status = 'available'
                    ORDER BY serial_number;

                OPEN instance_cursor;
                FETCH NEXT FROM instance_cursor INTO @InstanceId;

                WHILE @@FETCH_STATUS = 0
                BEGIN
                    -- Mark instance as 'reserved' and link to this ReservationDetails
                    UPDATE EquipmentInstance
                    SET status = 'reserved',
                        reservation_detail_id = @NextDetailsId,
                        last_updated = GETDATE()
                    WHERE equipment_instance_id = @InstanceId;

                    FETCH NEXT FROM instance_cursor INTO @InstanceId;
                END;

                CLOSE instance_cursor;
                DEALLOCATE instance_cursor;

                SET @NextDetailsId = @NextDetailsId + 1;
            END

            SET @Index = @Index + 1;
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

PRINT 'sp_reserve_equipment updated to handle consumable and reusable items!';

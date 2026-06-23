USE SmartShevet;
GO

-- Add reservation_detail_id column to track which reservation this instance is part of
ALTER TABLE EquipmentInstance
ADD reservation_detail_id INT NULL;

-- Add foreign key constraint
ALTER TABLE EquipmentInstance
ADD CONSTRAINT FK_EquipmentInstance_ReservationDetails
FOREIGN KEY (reservation_detail_id) REFERENCES ReservationDetails(reservationdetails_id);

GO

-- Update stored procedures to handle reservation tracking

CREATE OR ALTER PROCEDURE sp_equipmentinstance_update_reservation
    @equipment_instance_id INT,
    @status NVARCHAR(50),
    @reservation_detail_id INT = NULL
AS
BEGIN
    UPDATE EquipmentInstance
    SET status = @status,
        reservation_detail_id = @reservation_detail_id,
        last_updated = GETDATE()
    WHERE equipment_instance_id = @equipment_instance_id;
END;

GO

-- Get available instances for an equipment (not reserved/borrowed)
CREATE OR ALTER PROCEDURE sp_equipmentinstance_get_available
    @equipment_id INT
AS
BEGIN
    SELECT equipment_instance_id, equipment_id, serial_number, status, date_added, last_updated, reservation_detail_id
    FROM EquipmentInstance
    WHERE equipment_id = @equipment_id
      AND status = 'available'
    ORDER BY serial_number;
END;

GO

PRINT 'EquipmentInstance table updated successfully!';

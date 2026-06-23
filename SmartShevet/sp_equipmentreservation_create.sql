USE SmartShevet;
GO

-- Create stored procedure for inserting new EquipmentReservation records
CREATE OR ALTER PROCEDURE sp_equipmentreservation_create
    @equipmentreservation_id INT,
    @reservationStatus NVARCHAR(50),
    @requestDate DATETIME,
    @activityDate DATETIME,
    @requestedById INT
AS
BEGIN
    INSERT INTO EquipmentReservation (
        equipmentreservation_id,
        reservationStatus,
        requestDate,
        activityDate,
        requestedById
    )
    VALUES (
        @equipmentreservation_id,
        @reservationStatus,
        @requestDate,
        @activityDate,
        @requestedById
    );
END;
GO

PRINT 'sp_equipmentreservation_create created successfully!';

USE SmartShevet;
GO

-- Update existing EquipmentReservation record
CREATE OR ALTER PROCEDURE sp_equipmentreservation_update
    @equipmentreservation_id INT,
    @reservationStatus NVARCHAR(50),
    @requestDate DATETIME,
    @activityDate DATETIME,
    @requestedById INT
AS
BEGIN
    UPDATE EquipmentReservation
    SET reservationStatus = @reservationStatus,
        requestDate = @requestDate,
        activityDate = @activityDate,
        requestedById = @requestedById
    WHERE equipmentreservation_id = @equipmentreservation_id;
END;
GO

-- Delete EquipmentReservation record (and cascade to ReservationDetails)
CREATE OR ALTER PROCEDURE sp_equipmentreservation_delete
    @equipmentreservation_id INT
AS
BEGIN
    DELETE FROM EquipmentReservation
    WHERE equipmentreservation_id = @equipmentreservation_id;
END;
GO

-- Get all EquipmentReservation records
CREATE OR ALTER PROCEDURE sp_equipmentreservation_get_all
AS
BEGIN
    SELECT equipmentreservation_id, reservationStatus, requestDate, activityDate, requestedById
    FROM EquipmentReservation
    ORDER BY equipmentreservation_id DESC;
END;
GO

-- Approve a reservation (transition from pending to approved)
CREATE OR ALTER PROCEDURE sp_equipmentreservation_approve
    @equipmentreservation_id INT
AS
BEGIN
    UPDATE EquipmentReservation
    SET reservationStatus = 'approved'
    WHERE equipmentreservation_id = @equipmentreservation_id
      AND reservationStatus = 'pending';
END;
GO

PRINT 'Equipment Reservation CRUD stored procedures created successfully!';

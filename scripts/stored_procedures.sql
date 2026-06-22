USE SmartShevet;

-- ============================================================================
-- EQUIPMENT STORED PROCEDURES
-- ============================================================================

CREATE PROCEDURE sp_equipment_create
    @equipment_id INT,
    @name NVARCHAR(50),
    @category NVARCHAR(50),
    @description NVARCHAR(MAX),
    @equipmentType NVARCHAR(50),
    @containerType NVARCHAR(50),
    @quantity INT,
    @minimumQuantity INT,
    @status NVARCHAR(50),
    @lastUpdated DATETIME2,
    @notes NVARCHAR(MAX)
AS
BEGIN
    INSERT INTO Equipment (equipment_id, name, category, description, equipmentType, containerType, quantity, minimumQuantity, status, lastUpdated, notes)
    VALUES (@equipment_id, @name, @category, @description, @equipmentType, @containerType, @quantity, @minimumQuantity, @status, @lastUpdated, @notes);
END;
GO

CREATE PROCEDURE sp_equipment_update
    @equipment_id INT,
    @name NVARCHAR(50),
    @category NVARCHAR(50),
    @description NVARCHAR(MAX),
    @equipmentType NVARCHAR(50),
    @containerType NVARCHAR(50),
    @quantity INT,
    @minimumQuantity INT,
    @status NVARCHAR(50),
    @lastUpdated DATETIME2,
    @notes NVARCHAR(MAX)
AS
BEGIN
    UPDATE Equipment
    SET name = @name,
        category = @category,
        description = @description,
        equipmentType = @equipmentType,
        containerType = @containerType,
        quantity = @quantity,
        minimumQuantity = @minimumQuantity,
        status = @status,
        lastUpdated = @lastUpdated,
        notes = @notes
    WHERE equipment_id = @equipment_id;
END;
GO

CREATE PROCEDURE sp_equipment_delete
    @equipment_id INT
AS
BEGIN
    DELETE FROM Equipment WHERE equipment_id = @equipment_id;
END;
GO

CREATE PROCEDURE sp_equipment_get_all
AS
BEGIN
    SELECT * FROM Equipment ORDER BY equipment_id;
END;
GO

CREATE PROCEDURE sp_equipment_get_by_id
    @equipment_id INT
AS
BEGIN
    SELECT * FROM Equipment WHERE equipment_id = @equipment_id;
END;
GO

-- ============================================================================
-- SENIORSCOUT STORED PROCEDURES
-- ============================================================================

CREATE PROCEDURE sp_seniorscout_create
    @seniorscout_id INT,
    @name NVARCHAR(50),
    @grade NVARCHAR(20),
    @role NVARCHAR(50),
    @email NVARCHAR(50),
    @phoneNumber NVARCHAR(50),
    @password NVARCHAR(50)
AS
BEGIN
    INSERT INTO SeniorScout (seniorscout_id, name, grade, role, email, phoneNumber, password)
    VALUES (@seniorscout_id, @name, @grade, @role, @email, @phoneNumber, @password);
END;
GO

CREATE PROCEDURE sp_seniorscout_update
    @seniorscout_id INT,
    @name NVARCHAR(50),
    @grade NVARCHAR(20),
    @role NVARCHAR(50),
    @email NVARCHAR(50),
    @phoneNumber NVARCHAR(50),
    @password NVARCHAR(50)
AS
BEGIN
    UPDATE SeniorScout
    SET name = @name,
        grade = @grade,
        role = @role,
        email = @email,
        phoneNumber = @phoneNumber,
        password = @password
    WHERE seniorscout_id = @seniorscout_id;
END;
GO

CREATE PROCEDURE sp_seniorscout_delete
    @seniorscout_id INT
AS
BEGIN
    DELETE FROM SeniorScout WHERE seniorscout_id = @seniorscout_id;
END;
GO

CREATE PROCEDURE sp_seniorscout_get_all
AS
BEGIN
    SELECT * FROM SeniorScout ORDER BY seniorscout_id;
END;
GO

CREATE PROCEDURE sp_seniorscout_get_by_id
    @seniorscout_id INT
AS
BEGIN
    SELECT * FROM SeniorScout WHERE seniorscout_id = @seniorscout_id;
END;
GO

-- ============================================================================
-- WAREHOUSESTAFFMEMBER STORED PROCEDURES
-- ============================================================================

CREATE PROCEDURE sp_warehousestaffmember_create
    @warehousestaffmember_id INT
AS
BEGIN
    INSERT INTO WarehouseStaffMember (warehousestaffmember_id)
    VALUES (@warehousestaffmember_id);
END;
GO

CREATE PROCEDURE sp_warehousestaffmember_update
    @warehousestaffmember_id INT
AS
BEGIN
    -- No columns to update for this subclass (only PK/FK)
    SELECT 1;
END;
GO

CREATE PROCEDURE sp_warehousestaffmember_delete
    @warehousestaffmember_id INT
AS
BEGIN
    DELETE FROM WarehouseStaffMember WHERE warehousestaffmember_id = @warehousestaffmember_id;
END;
GO

CREATE PROCEDURE sp_warehousestaffmember_get_all
AS
BEGIN
    SELECT * FROM WarehouseStaffMember ORDER BY warehousestaffmember_id;
END;
GO

CREATE PROCEDURE sp_warehousestaffmember_get_by_id
    @warehousestaffmember_id INT
AS
BEGIN
    SELECT * FROM WarehouseStaffMember WHERE warehousestaffmember_id = @warehousestaffmember_id;
END;
GO

-- ============================================================================
-- SENIORCOORDINATOR STORED PROCEDURES
-- ============================================================================

CREATE PROCEDURE sp_seniorcoordinator_create
    @seniorcoordinator_id INT
AS
BEGIN
    INSERT INTO SeniorCoordinator (seniorcoordinator_id)
    VALUES (@seniorcoordinator_id);
END;
GO

CREATE PROCEDURE sp_seniorcoordinator_update
    @seniorcoordinator_id INT
AS
BEGIN
    -- No columns to update for this subclass (only PK/FK)
    SELECT 1;
END;
GO

CREATE PROCEDURE sp_seniorcoordinator_delete
    @seniorcoordinator_id INT
AS
BEGIN
    DELETE FROM SeniorCoordinator WHERE seniorcoordinator_id = @seniorcoordinator_id;
END;
GO

CREATE PROCEDURE sp_seniorcoordinator_get_all
AS
BEGIN
    SELECT * FROM SeniorCoordinator ORDER BY seniorcoordinator_id;
END;
GO

CREATE PROCEDURE sp_seniorcoordinator_get_by_id
    @seniorcoordinator_id INT
AS
BEGIN
    SELECT * FROM SeniorCoordinator WHERE seniorcoordinator_id = @seniorcoordinator_id;
END;
GO

-- ============================================================================
-- EQUIPMENTRESERVATION STORED PROCEDURES
-- ============================================================================

CREATE PROCEDURE sp_equipmentreservation_create
    @equipmentreservation_id INT,
    @reservationStatus NVARCHAR(20),
    @requestDate DATETIME2,
    @activityDate DATETIME2,
    @requestedById INT
AS
BEGIN
    INSERT INTO EquipmentReservation (equipmentreservation_id, reservationStatus, requestDate, activityDate, requestedById)
    VALUES (@equipmentreservation_id, @reservationStatus, @requestDate, @activityDate, @requestedById);
END;
GO

CREATE PROCEDURE sp_equipmentreservation_update
    @equipmentreservation_id INT,
    @reservationStatus NVARCHAR(20),
    @requestDate DATETIME2,
    @activityDate DATETIME2,
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

CREATE PROCEDURE sp_equipmentreservation_delete
    @equipmentreservation_id INT
AS
BEGIN
    DELETE FROM EquipmentReservation WHERE equipmentreservation_id = @equipmentreservation_id;
END;
GO

CREATE PROCEDURE sp_equipmentreservation_get_all
AS
BEGIN
    SELECT * FROM EquipmentReservation ORDER BY equipmentreservation_id;
END;
GO

CREATE PROCEDURE sp_equipmentreservation_get_by_id
    @equipmentreservation_id INT
AS
BEGIN
    SELECT * FROM EquipmentReservation WHERE equipmentreservation_id = @equipmentreservation_id;
END;
GO

-- ============================================================================
-- EQUIPMENTISSUE STORED PROCEDURES
-- ============================================================================

CREATE PROCEDURE sp_equipmentissue_create
    @equipmentissue_id INT,
    @issueDate DATETIME2,
    @returnDate DATETIME2,
    @equipmentId INT,
    @issuedToId INT,
    @reservationId INT,
    @status NVARCHAR(20),
    @condition NVARCHAR(20)
AS
BEGIN
    INSERT INTO EquipmentIssue (equipmentissue_id, issueDate, returnDate, equipmentId, issuedToId, reservationId, status, condition)
    VALUES (@equipmentissue_id, @issueDate, @returnDate, @equipmentId, @issuedToId, @reservationId, @status, @condition);
END;
GO

CREATE PROCEDURE sp_equipmentissue_update
    @equipmentissue_id INT,
    @issueDate DATETIME2,
    @returnDate DATETIME2,
    @equipmentId INT,
    @issuedToId INT,
    @reservationId INT,
    @status NVARCHAR(20),
    @condition NVARCHAR(20)
AS
BEGIN
    UPDATE EquipmentIssue
    SET issueDate = @issueDate,
        returnDate = @returnDate,
        equipmentId = @equipmentId,
        issuedToId = @issuedToId,
        reservationId = @reservationId,
        status = @status,
        condition = @condition
    WHERE equipmentissue_id = @equipmentissue_id;
END;
GO

CREATE PROCEDURE sp_equipmentissue_delete
    @equipmentissue_id INT
AS
BEGIN
    DELETE FROM EquipmentIssue WHERE equipmentissue_id = @equipmentissue_id;
END;
GO

CREATE PROCEDURE sp_equipmentissue_get_all
AS
BEGIN
    SELECT * FROM EquipmentIssue ORDER BY equipmentissue_id;
END;
GO

CREATE PROCEDURE sp_equipmentissue_get_by_id
    @equipmentissue_id INT
AS
BEGIN
    SELECT * FROM EquipmentIssue WHERE equipmentissue_id = @equipmentissue_id;
END;
GO

-- ============================================================================
-- RESERVATIONDETAILS STORED PROCEDURES
-- ============================================================================

CREATE PROCEDURE sp_reservationdetails_create
    @reservationdetails_id INT,
    @entry INT,
    @quantity INT,
    @equipmentId INT,
    @equipmentreservation_id INT,
    @addedEquipment BIT
AS
BEGIN
    INSERT INTO ReservationDetails (reservationdetails_id, entry, quantity, equipmentId, equipmentreservation_id, addedEquipment)
    VALUES (@reservationdetails_id, @entry, @quantity, @equipmentId, @equipmentreservation_id, @addedEquipment);
END;
GO

CREATE PROCEDURE sp_reservationdetails_update
    @reservationdetails_id INT,
    @entry INT,
    @quantity INT,
    @equipmentId INT,
    @equipmentreservation_id INT,
    @addedEquipment BIT
AS
BEGIN
    UPDATE ReservationDetails
    SET entry = @entry,
        quantity = @quantity,
        equipmentId = @equipmentId,
        equipmentreservation_id = @equipmentreservation_id,
        addedEquipment = @addedEquipment
    WHERE reservationdetails_id = @reservationdetails_id;
END;
GO

CREATE PROCEDURE sp_reservationdetails_delete
    @reservationdetails_id INT
AS
BEGIN
    DELETE FROM ReservationDetails WHERE reservationdetails_id = @reservationdetails_id;
END;
GO

CREATE PROCEDURE sp_reservationdetails_get_all
AS
BEGIN
    SELECT * FROM ReservationDetails ORDER BY reservationdetails_id;
END;
GO

CREATE PROCEDURE sp_reservationdetails_get_by_id
    @reservationdetails_id INT
AS
BEGIN
    SELECT * FROM ReservationDetails WHERE reservationdetails_id = @reservationdetails_id;
END;
GO

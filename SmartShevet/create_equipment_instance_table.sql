USE SmartShevet;
GO

-- Create EquipmentInstance table for reusable items
CREATE TABLE EquipmentInstance (
    equipment_instance_id INT NOT NULL PRIMARY KEY,
    equipment_id INT NOT NULL,
    serial_number NVARCHAR(100) NOT NULL UNIQUE,
    status NVARCHAR(50) NOT NULL DEFAULT 'available',  -- available, borrowed, damaged, lost, underRepair
    date_added DATETIME NOT NULL DEFAULT GETDATE(),
    last_updated DATETIME NOT NULL DEFAULT GETDATE(),
    CONSTRAINT FK_EquipmentInstance_Equipment FOREIGN KEY (equipment_id) REFERENCES Equipment(equipment_id)
);

GO

-- Stored Procedure: Get all instances for an equipment
CREATE OR ALTER PROCEDURE sp_equipmentinstance_get_by_equipment
    @equipment_id INT
AS
BEGIN
    SELECT equipment_instance_id, equipment_id, serial_number, status, date_added, last_updated
    FROM EquipmentInstance
    WHERE equipment_id = @equipment_id
    ORDER BY serial_number;
END;

GO

-- Stored Procedure: Get all instances
CREATE OR ALTER PROCEDURE sp_equipmentinstance_get_all
AS
BEGIN
    SELECT equipment_instance_id, equipment_id, serial_number, status, date_added, last_updated
    FROM EquipmentInstance
    ORDER BY equipment_id, serial_number;
END;

GO

-- Stored Procedure: Create new instance
CREATE OR ALTER PROCEDURE sp_equipmentinstance_create
    @equipment_instance_id INT,
    @equipment_id INT,
    @serial_number NVARCHAR(100),
    @status NVARCHAR(50)
AS
BEGIN
    INSERT INTO EquipmentInstance (equipment_instance_id, equipment_id, serial_number, status, date_added, last_updated)
    VALUES (@equipment_instance_id, @equipment_id, @serial_number, @status, GETDATE(), GETDATE());
END;

GO

-- Stored Procedure: Update instance status
CREATE OR ALTER PROCEDURE sp_equipmentinstance_update_status
    @equipment_instance_id INT,
    @status NVARCHAR(50)
AS
BEGIN
    UPDATE EquipmentInstance
    SET status = @status, last_updated = GETDATE()
    WHERE equipment_instance_id = @equipment_instance_id;
END;

GO

-- Stored Procedure: Delete instance
CREATE OR ALTER PROCEDURE sp_equipmentinstance_delete
    @equipment_instance_id INT
AS
BEGIN
    DELETE FROM EquipmentInstance
    WHERE equipment_instance_id = @equipment_instance_id;
END;

GO

PRINT 'EquipmentInstance table and stored procedures created successfully!';

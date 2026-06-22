USE SmartShevet;

-- MVP SCOPE: Equipment Management Module Only
-- Allowed Entities: Equipment, EquipmentReservation, ReservationDetails, EquipmentIssue, SeniorScout, WarehouseStaffMember, SeniorCoordinator

-- Base Entities (No FK Dependencies Among Themselves)

CREATE TABLE Equipment (
    equipment_id INT NOT NULL PRIMARY KEY,
    name NVARCHAR(50) NOT NULL,
    category NVARCHAR(50) NOT NULL,
    description NVARCHAR(MAX) NOT NULL,
    equipmentType NVARCHAR(50) NOT NULL CHECK (equipmentType IN ('consumable', 'reusable')),
    containerType NVARCHAR(50) NOT NULL CHECK (containerType IN ('kitchen', 'craft', 'camp', 'art')),
    quantity INT NOT NULL,
    minimumQuantity INT NULL, -- genuinely optional
    status NVARCHAR(50) NOT NULL CHECK (status IN ('borrowed', 'available', 'reserved', 'underRepair', 'lost', 'damaged')),
    lastUpdated DATETIME2 NOT NULL,
    notes NVARCHAR(MAX) NOT NULL
);

CREATE TABLE SeniorScout (
    seniorscout_id INT NOT NULL PRIMARY KEY,
    name NVARCHAR(50) NOT NULL,
    grade NVARCHAR(20) NOT NULL CHECK (grade IN ('4th Grade', '5th Grade', '6th Grade', '7th Grade', '8th Grade', '9th Grade', '10th Grade', '11th Grade', '12th Grade')),
    role NVARCHAR(50) NOT NULL CHECK (role IN ('logisticsTeamMember', 'guide', 'operationsTeamMember', 'prideTeamMember', 'communityTeamMember', 'juniorCoordinator', 'troopLeader', 'scoutingTeamMember', 'shevetTeamMember', 'shachbagTeamMember', 'seniorCoordinator')),
    email NVARCHAR(50) NOT NULL,
    phoneNumber NVARCHAR(50) NOT NULL,
    password NVARCHAR(50) NOT NULL
);

-- Subclasses of SeniorScout (Table-per-Subclass Pattern)

CREATE TABLE WarehouseStaffMember (
    warehousestaffmember_id INT NOT NULL PRIMARY KEY FOREIGN KEY REFERENCES SeniorScout(seniorscout_id) ON DELETE NO ACTION ON UPDATE NO ACTION
);

CREATE TABLE SeniorCoordinator (
    seniorcoordinator_id INT NOT NULL PRIMARY KEY FOREIGN KEY REFERENCES SeniorScout(seniorscout_id) ON DELETE NO ACTION ON UPDATE NO ACTION
);

-- Transactional Entities

CREATE TABLE EquipmentReservation (
    equipmentreservation_id INT NOT NULL PRIMARY KEY,
    reservationStatus NVARCHAR(20) NOT NULL CHECK (reservationStatus IN ('inProcess', 'approved', 'rejected', 'pendingApproval', 'needsModification', 'issued', 'completed', 'cancelled')),
    requestDate DATETIME2 NOT NULL,
    activityDate DATETIME2 NOT NULL,
    requestedById INT NOT NULL FOREIGN KEY REFERENCES SeniorScout(seniorscout_id) ON DELETE NO ACTION ON UPDATE NO ACTION
);

CREATE TABLE EquipmentIssue (
    equipmentissue_id INT NOT NULL PRIMARY KEY,
    issueDate DATETIME2 NOT NULL,
    returnDate DATETIME2 NULL, -- Nullable: equipment may not have been returned yet
    equipmentId INT NOT NULL FOREIGN KEY REFERENCES Equipment(equipment_id) ON DELETE NO ACTION ON UPDATE NO ACTION,
    issuedToId INT NOT NULL FOREIGN KEY REFERENCES SeniorScout(seniorscout_id) ON DELETE NO ACTION ON UPDATE NO ACTION,
    reservationId INT NOT NULL FOREIGN KEY REFERENCES EquipmentReservation(equipmentreservation_id) ON DELETE NO ACTION ON UPDATE NO ACTION,
    status NVARCHAR(20) NOT NULL CHECK (status IN ('issued', 'returned', 'partially_returned', 'not_returned')),
    condition NVARCHAR(20) NOT NULL CHECK (condition IN ('good', 'damaged', 'missing'))
);

-- Association Classes

CREATE TABLE ReservationDetails (
    reservationdetails_id INT NOT NULL PRIMARY KEY,
    entry INT NOT NULL,
    quantity INT NOT NULL,
    equipmentId INT NOT NULL FOREIGN KEY REFERENCES Equipment(equipment_id) ON DELETE NO ACTION ON UPDATE NO ACTION,
    equipmentreservation_id INT NOT NULL FOREIGN KEY REFERENCES EquipmentReservation(equipmentreservation_id) ON DELETE NO ACTION ON UPDATE NO ACTION,
    addedEquipment BIT NOT NULL
);

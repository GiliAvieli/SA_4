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

-- ============================================================================
-- STATE TRANSITION STORED PROCEDURES - EQUIPMENT
-- ============================================================================

CREATE PROCEDURE sp_equipment_reserve
    @equipment_id INT
AS
BEGIN
    BEGIN TRAN;
    BEGIN TRY
        UPDATE Equipment
        SET status = 'reserved', lastUpdated = GETDATE()
        WHERE equipment_id = @equipment_id AND status = 'available';

        IF @@ROWCOUNT = 0
            THROW 50001, 'Cannot reserve: equipment not in available status', 1;

        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
        THROW;
    END CATCH;
END;
GO

CREATE PROCEDURE sp_equipment_cancel_reservation
    @equipment_id INT
AS
BEGIN
    BEGIN TRAN;
    BEGIN TRY
        UPDATE Equipment
        SET status = 'available', lastUpdated = GETDATE()
        WHERE equipment_id = @equipment_id AND status = 'reserved';

        IF @@ROWCOUNT = 0
            THROW 50001, 'Cannot cancel: equipment not in reserved status', 1;

        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
        THROW;
    END CATCH;
END;
GO

CREATE PROCEDURE sp_equipment_issue
    @equipment_id INT
AS
BEGIN
    BEGIN TRAN;
    BEGIN TRY
        UPDATE Equipment
        SET status = 'borrowed', lastUpdated = GETDATE()
        WHERE equipment_id = @equipment_id AND status = 'reserved';

        IF @@ROWCOUNT = 0
            THROW 50001, 'Cannot issue: equipment not in reserved status', 1;

        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
        THROW;
    END CATCH;
END;
GO

CREATE PROCEDURE sp_equipment_return
    @equipment_id INT
AS
BEGIN
    BEGIN TRAN;
    BEGIN TRY
        UPDATE Equipment
        SET status = 'in_warehouse', lastUpdated = GETDATE()
        WHERE equipment_id = @equipment_id AND status = 'borrowed';

        IF @@ROWCOUNT = 0
            THROW 50001, 'Cannot return: equipment not in borrowed status', 1;

        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
        THROW;
    END CATCH;
END;
GO

CREATE PROCEDURE sp_equipment_confirm_condition
    @equipment_id INT
AS
BEGIN
    BEGIN TRAN;
    BEGIN TRY
        UPDATE Equipment
        SET status = 'available', lastUpdated = GETDATE()
        WHERE equipment_id = @equipment_id AND status = 'in_warehouse';

        IF @@ROWCOUNT = 0
            THROW 50001, 'Cannot confirm: equipment not in in_warehouse status', 1;

        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
        THROW;
    END CATCH;
END;
GO

CREATE PROCEDURE sp_equipment_report_damage
    @equipment_id INT
AS
BEGIN
    BEGIN TRAN;
    BEGIN TRY
        UPDATE Equipment
        SET status = 'damaged', lastUpdated = GETDATE()
        WHERE equipment_id = @equipment_id AND status = 'in_warehouse';

        IF @@ROWCOUNT = 0
            THROW 50001, 'Cannot report damage: equipment not in in_warehouse status', 1;

        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
        THROW;
    END CATCH;
END;
GO

CREATE PROCEDURE sp_equipment_submit_for_repair
    @equipment_id INT
AS
BEGIN
    BEGIN TRAN;
    BEGIN TRY
        UPDATE Equipment
        SET status = 'repair', lastUpdated = GETDATE()
        WHERE equipment_id = @equipment_id AND status = 'damaged';

        IF @@ROWCOUNT = 0
            THROW 50001, 'Cannot submit for repair: equipment not in damaged status', 1;

        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
        THROW;
    END CATCH;
END;
GO

CREATE PROCEDURE sp_equipment_completion_confirmed
    @equipment_id INT
AS
BEGIN
    BEGIN TRAN;
    BEGIN TRY
        UPDATE Equipment
        SET status = 'available', lastUpdated = GETDATE()
        WHERE equipment_id = @equipment_id AND status = 'repair';

        IF @@ROWCOUNT = 0
            THROW 50001, 'Cannot confirm completion: equipment not in repair status', 1;

        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
        THROW;
    END CATCH;
END;
GO

CREATE PROCEDURE sp_equipment_report_missing
    @equipment_id INT
AS
BEGIN
    BEGIN TRAN;
    BEGIN TRY
        UPDATE Equipment
        SET status = 'missing', lastUpdated = GETDATE()
        WHERE equipment_id = @equipment_id AND status = 'borrowed';

        IF @@ROWCOUNT = 0
            THROW 50001, 'Cannot report missing: equipment not in borrowed status', 1;

        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
        THROW;
    END CATCH;
END;
GO

CREATE PROCEDURE sp_equipment_item_found
    @equipment_id INT
AS
BEGIN
    BEGIN TRAN;
    BEGIN TRY
        UPDATE Equipment
        SET status = 'available', lastUpdated = GETDATE()
        WHERE equipment_id = @equipment_id AND status = 'missing';

        IF @@ROWCOUNT = 0
            THROW 50001, 'Cannot mark found: equipment not in missing status', 1;

        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
        THROW;
    END CATCH;
END;
GO

-- ============================================================================
-- STATE TRANSITION STORED PROCEDURES - EQUIPMENTRESERVATION
-- ============================================================================

CREATE PROCEDURE sp_equipmentreservation_approve
    @equipmentreservation_id INT
AS
BEGIN
    BEGIN TRAN;
    BEGIN TRY
        UPDATE EquipmentReservation
        SET reservationStatus = 'approved'
        WHERE equipmentreservation_id = @equipmentreservation_id AND reservationStatus = 'pending';

        IF @@ROWCOUNT = 0
            THROW 50001, 'Cannot approve: reservation not in pending status', 1;

        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
        THROW;
    END CATCH;
END;
GO

CREATE PROCEDURE sp_equipmentreservation_deny
    @equipmentreservation_id INT
AS
BEGIN
    BEGIN TRAN;
    BEGIN TRY
        UPDATE EquipmentReservation
        SET reservationStatus = 'denied'
        WHERE equipmentreservation_id = @equipmentreservation_id AND reservationStatus = 'pending';

        IF @@ROWCOUNT = 0
            THROW 50001, 'Cannot deny: reservation not in pending status', 1;

        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
        THROW;
    END CATCH;
END;
GO

CREATE PROCEDURE sp_equipmentreservation_cancel
    @equipmentreservation_id INT
AS
BEGIN
    BEGIN TRAN;
    BEGIN TRY
        UPDATE EquipmentReservation
        SET reservationStatus = 'cancelled'
        WHERE equipmentreservation_id = @equipmentreservation_id
        AND (reservationStatus = 'pending' OR reservationStatus = 'approved');

        IF @@ROWCOUNT = 0
            THROW 50001, 'Cannot cancel: reservation not in pending or approved status', 1;

        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
        THROW;
    END CATCH;
END;
GO

CREATE PROCEDURE sp_equipmentreservation_activate
    @equipmentreservation_id INT
AS
BEGIN
    BEGIN TRAN;
    BEGIN TRY
        UPDATE EquipmentReservation
        SET reservationStatus = 'active'
        WHERE equipmentreservation_id = @equipmentreservation_id AND reservationStatus = 'approved';

        IF @@ROWCOUNT = 0
            THROW 50001, 'Cannot activate: reservation not in approved status', 1;

        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
        THROW;
    END CATCH;
END;
GO

CREATE PROCEDURE sp_equipmentreservation_close
    @equipmentreservation_id INT
AS
BEGIN
    BEGIN TRAN;
    BEGIN TRY
        UPDATE EquipmentReservation
        SET reservationStatus = 'completed'
        WHERE equipmentreservation_id = @equipmentreservation_id AND reservationStatus = 'active';

        IF @@ROWCOUNT = 0
            THROW 50001, 'Cannot close: reservation not in active status', 1;

        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
        THROW;
    END CATCH;
END;
GO

CREATE PROCEDURE sp_equipmentreservation_partial_return
    @equipmentreservation_id INT
AS
BEGIN
    BEGIN TRAN;
    BEGIN TRY
        UPDATE EquipmentReservation
        SET reservationStatus = 'completed'
        WHERE equipmentreservation_id = @equipmentreservation_id AND reservationStatus = 'active';

        IF @@ROWCOUNT = 0
            THROW 50001, 'Cannot record partial return: reservation not in active status', 1;

        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
        THROW;
    END CATCH;
END;
GO

CREATE PROCEDURE sp_equipmentreservation_resubmit
    @equipmentreservation_id INT
AS
BEGIN
    BEGIN TRAN;
    BEGIN TRY
        UPDATE EquipmentReservation
        SET reservationStatus = 'pending'
        WHERE equipmentreservation_id = @equipmentreservation_id AND reservationStatus = 'denied';

        IF @@ROWCOUNT = 0
            THROW 50001, 'Cannot resubmit: reservation not in denied status', 1;

        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
        THROW;
    END CATCH;
END;
GO

-- ============================================================================
-- STATE TRANSITION STORED PROCEDURES - EQUIPMENTISSUE
-- ============================================================================

CREATE PROCEDURE sp_equipmentissue_issue
    @equipmentissue_id INT
AS
BEGIN
    BEGIN TRAN;
    BEGIN TRY
        UPDATE EquipmentIssue
        SET status = 'issued'
        WHERE equipmentissue_id = @equipmentissue_id;

        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
        THROW;
    END CATCH;
END;
GO

CREATE PROCEDURE sp_equipmentissue_return
    @equipmentissue_id INT,
    @allReturned BIT
AS
BEGIN
    BEGIN TRAN;
    BEGIN TRY
        DECLARE @newStatus NVARCHAR(50) = CASE WHEN @allReturned = 1 THEN 'returned' ELSE 'partially_returned' END;

        UPDATE EquipmentIssue
        SET status = @newStatus, returnDate = GETDATE()
        WHERE equipmentissue_id = @equipmentissue_id AND (status = 'issued' OR status = 'not_returned');

        IF @@ROWCOUNT = 0
            THROW 50001, 'Cannot return: equipment issue not in issued or not_returned status', 1;

        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
        THROW;
    END CATCH;
END;
GO

CREATE PROCEDURE sp_equipmentissue_report_missing
    @equipmentissue_id INT
AS
BEGIN
    BEGIN TRAN;
    BEGIN TRY
        UPDATE EquipmentIssue
        SET status = 'not_returned'
        WHERE equipmentissue_id = @equipmentissue_id AND status = 'issued';

        IF @@ROWCOUNT = 0
            THROW 50001, 'Cannot report missing: equipment issue not in issued status', 1;

        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
        THROW;
    END CATCH;
END;
GO

CREATE PROCEDURE sp_equipmentissue_finalize
    @equipmentissue_id INT
AS
BEGIN
    BEGIN TRAN;
    BEGIN TRY
        UPDATE EquipmentIssue
        SET status = 'completed'
        WHERE equipmentissue_id = @equipmentissue_id AND (status = 'returned' OR status = 'partially_returned');

        IF @@ROWCOUNT = 0
            THROW 50001, 'Cannot finalize: equipment issue not in returned or partially_returned status', 1;

        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
        THROW;
    END CATCH;
END;
GO

CREATE PROCEDURE sp_equipmentissue_item_found
    @equipmentissue_id INT
AS
BEGIN
    BEGIN TRAN;
    BEGIN TRY
        UPDATE EquipmentIssue
        SET status = 'returned', returnDate = GETDATE()
        WHERE equipmentissue_id = @equipmentissue_id AND status = 'not_returned';

        IF @@ROWCOUNT = 0
            THROW 50001, 'Cannot mark found: equipment issue not in not_returned status', 1;

        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
        THROW;
    END CATCH;
END;
GO

-- ============================================================================
-- ANNUAL INVENTORY FORECAST REPORT STORED PROCEDURE
-- ============================================================================

CREATE PROCEDURE sp_annual_inventory_forecast_report
    @startDate DATETIME2,
    @endDate DATETIME2,
    @categoryFilter NVARCHAR(100) = NULL,
    @includeOverdueOnly BIT = 0
AS
BEGIN
    DECLARE @monthsInPeriod INT = DATEDIFF(MONTH, @startDate, @endDate) + 1;
    DECLARE @overdueThreshold INT = 30;
    DECLARE @expectedReturnDays INT = 7;

    -- Result Set 1: Consumable Usage Analysis (Quantity Forecast)
    SELECT
        e.equipment_id AS 'מזהה ציוד',
        e.name AS 'שם ציוד',
        e.category AS 'קטגוריה',
        COUNT(ei.equipmentissue_id) AS 'סה"כ הנפקות בתקופה',
        CAST(COUNT(ei.equipmentissue_id) AS FLOAT) / NULLIF(@monthsInPeriod, 0) AS 'צריכה ממוצעת חודשית',
        CAST(COUNT(ei.equipmentissue_id) AS FLOAT) * (12.0 / NULLIF(@monthsInPeriod, 0)) AS 'צריכה משוערת שנתית',
        e.quantity AS 'כמות נוכחית'
    FROM Equipment e
    LEFT JOIN EquipmentIssue ei ON e.equipment_id = ei.equipmentId
        AND ei.issueDate BETWEEN @startDate AND @endDate
    WHERE e.equipmentType = 'consumable'
        AND ((@categoryFilter IS NULL) OR (e.category = @categoryFilter))
    GROUP BY e.equipment_id, e.name, e.category, e.quantity
    ORDER BY COUNT(ei.equipmentissue_id) DESC;

    -- Result Set 2: Unreturned Equipment Summary
    SELECT
        e.equipment_id AS 'מזהה ציוד',
        e.name AS 'שם ציוד',
        ei.issueDate AS 'תאריך הנפקה',
        DATEDIFF(DAY, DATEADD(DAY, @expectedReturnDays, ei.issueDate), GETDATE()) AS 'ימים באיחור',
        ss.name AS 'הונפק ל',
        ei.status AS 'סטטוס נוכחי',
        CASE
            WHEN DATEDIFF(DAY, DATEADD(DAY, @expectedReturnDays, ei.issueDate), GETDATE()) > 30 THEN 'דווח כאובד'
            WHEN DATEDIFF(DAY, DATEADD(DAY, @expectedReturnDays, ei.issueDate), GETDATE()) > 14 THEN 'צור קשר עם המשתמש'
            ELSE 'תזכורת'
        END AS 'פעולה מומלצת'
    FROM EquipmentIssue ei
    JOIN Equipment e ON ei.equipmentId = e.equipment_id
    JOIN SeniorScout ss ON ei.issuedToId = ss.seniorscout_id
    WHERE ei.returnDate IS NULL
        AND ei.issueDate BETWEEN @startDate AND @endDate
        AND ((@categoryFilter IS NULL) OR (e.category = @categoryFilter))
        AND ((@includeOverdueOnly = 0) OR (DATEDIFF(DAY, DATEADD(DAY, @expectedReturnDays, ei.issueDate), GETDATE()) > @overdueThreshold))
    ORDER BY DATEDIFF(DAY, DATEADD(DAY, @expectedReturnDays, ei.issueDate), GETDATE()) DESC;

    -- Result Set 3: Damaged/Missing Equipment Summary
    SELECT
        e.equipment_id AS 'מזהה ציוד',
        e.name AS 'שם ציוד',
        e.category AS 'קטגוריה',
        SUM(CASE WHEN e.status = 'damaged' THEN 1 ELSE 0 END) AS 'ציוד פגום',
        SUM(CASE WHEN e.status = 'lost' THEN 1 ELSE 0 END) AS 'ציוד אבוד',
        COUNT(DISTINCT ei.equipmentissue_id) AS 'הנפקות עם דמיון'
    FROM Equipment e
    LEFT JOIN EquipmentIssue ei ON e.equipment_id = ei.equipmentId
        AND ei.condition IN ('damaged', 'missing')
    WHERE e.status IN ('damaged', 'lost')
        AND e.lastUpdated BETWEEN @startDate AND @endDate
        AND ((@categoryFilter IS NULL) OR (e.category = @categoryFilter))
    GROUP BY e.equipment_id, e.name, e.category, e.status
    ORDER BY SUM(CASE WHEN e.status = 'damaged' THEN 1 ELSE 0 END) DESC;

    -- Result Set 4: Summary Totals
    SELECT
        'פריטים צריכים בקטגוריה צריכה' AS 'סיכום',
        (SELECT COUNT(DISTINCT e.equipment_id) FROM Equipment e
         WHERE e.equipmentType = 'consumable'
         AND ((@categoryFilter IS NULL) OR (e.category = @categoryFilter))) AS 'כמות'
    UNION ALL
    SELECT
        'ציוד שלא הוחזר מבעיר',
        COUNT(DISTINCT ei.equipmentissue_id)
    FROM EquipmentIssue ei
    WHERE ei.returnDate IS NULL
        AND ei.issueDate BETWEEN @startDate AND @endDate
    UNION ALL
    SELECT
        'ציוד פגום או אבוד',
        COUNT(DISTINCT e.equipment_id)
    FROM Equipment e
    WHERE e.status IN ('damaged', 'lost')
        AND ((@categoryFilter IS NULL) OR (e.category = @categoryFilter));

END;
GO

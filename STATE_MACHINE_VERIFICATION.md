# State Machine End-to-End Verification Plan

This document guides the verification of state machine transitions with before/after SQL queries.

---

## Test 1: Equipment State Transition — confirmCondition()

**Transition:** `in_warehouse` → `available`  
**Guard:** Current status must be 'in_warehouse'  
**Side Effects:** lastUpdated gets set to current timestamp

### BEFORE: Run this query

```sql
USE SmartShevet;
SELECT 
    equipment_id,
    name,
    status,
    lastUpdated,
    notes
FROM Equipment 
WHERE status = 'in_warehouse' 
ORDER BY equipment_id
LIMIT 1;
```

**Expected Result:** Equipment with `status = 'in_warehouse'` and a lastUpdated timestamp from earlier

### TRIGGER IN UI:
1. Open SmartShevet application
2. Go to EquipmentPanel (Manage Equipment)
3. Select the equipment from the query above (by ID or name)
4. Click the **"אישור מצב"** (Confirm Condition) button
5. Confirm success message appears

### AFTER: Run this query

```sql
USE SmartShevet;
SELECT 
    equipment_id,
    name,
    status,
    lastUpdated,
    notes
FROM Equipment 
WHERE equipment_id = [ID_FROM_BEFORE_QUERY];
```

**Expected Result:** 
- `status = 'available'` ✓ (state transitioned)
- `lastUpdated` timestamp is NOW (side effect) ✓
- All other fields unchanged ✓

---

## Test 2: EquipmentReservation State Transition — approveReservation()

**Transition:** `pending` → `approved`  
**Guard:** Current status must be 'pending'  
**Side Effects:** None directly in EquipmentReservation; Equipment items should transition to 'reserved'

### BEFORE: Run this query

```sql
USE SmartShevet;
-- Check reservation status
SELECT 
    equipmentreservation_id,
    reservationStatus,
    requestDate,
    activityDate,
    requestedById
FROM EquipmentReservation 
WHERE reservationStatus = 'pending' 
ORDER BY equipmentreservation_id
LIMIT 1;

-- Also check related equipment status
SELECT 
    e.equipment_id,
    e.name,
    e.status
FROM ReservationDetails rd
JOIN Equipment e ON rd.equipmentId = e.equipment_id
WHERE rd.equipmentreservation_id = [RESERVATION_ID_FROM_ABOVE];
```

**Expected Result:** 
- Reservation with `reservationStatus = 'pending'`
- Associated Equipment items with `status = 'available'`

### TRIGGER IN UI:
1. Open SmartShevet application
2. Go to EquipmentReservationPanel (Manage Reservations)
3. Select the reservation from the query above (by ID)
4. Click the **"אישור"** (Approve) button
5. Confirm success message appears

### AFTER: Run this query

```sql
USE SmartShevet;
-- Check reservation status changed
SELECT 
    equipmentreservation_id,
    reservationStatus,
    requestDate,
    activityDate
FROM EquipmentReservation 
WHERE equipmentreservation_id = [ID_FROM_BEFORE];

-- Check side effect: Equipment should now be 'reserved'
SELECT 
    e.equipment_id,
    e.name,
    e.status
FROM ReservationDetails rd
JOIN Equipment e ON rd.equipmentId = e.equipment_id
WHERE rd.equipmentreservation_id = [ID_FROM_BEFORE];
```

**Expected Result:**
- Reservation `reservationStatus = 'approved'` ✓ (state transitioned)
- Associated Equipment items `status = 'reserved'` ✓ (side effect: Equipment transitioned too)

---

## Test 3: EquipmentIssue State Transition — returnEquipment(true)

**Transition:** `issued` → `returned` (all items returned)  
**Guard:** Current status must be 'issued' or 'not_returned'  
**Side Effects:** 
- returnDate gets set to NOW
- Associated Equipment transitions from 'borrowed' → 'in_warehouse'
- Associated EquipmentReservation transitions to 'completed'

### BEFORE: Run this query

```sql
USE SmartShevet;
-- Check issue status
SELECT 
    equipmentissue_id,
    status,
    issueDate,
    returnDate,
    equipmentId,
    reservationId
FROM EquipmentIssue 
WHERE status = 'issued' 
ORDER BY equipmentissue_id
LIMIT 1;

-- Check equipment status (should be 'borrowed')
SELECT 
    equipment_id,
    name,
    status
FROM Equipment 
WHERE equipment_id = [EQUIPMENT_ID_FROM_ABOVE];

-- Check reservation status (should be 'active')
SELECT 
    equipmentreservation_id,
    reservationStatus
FROM EquipmentReservation 
WHERE equipmentreservation_id = [RESERVATION_ID_FROM_ABOVE];
```

**Expected Result:**
- Issue with `status = 'issued'` and `returnDate = NULL`
- Equipment with `status = 'borrowed'`
- Reservation with `reservationStatus = 'active'`

### TRIGGER IN UI:
1. Open SmartShevet application
2. Go to EquipmentIssuePanel (Give/Return Equipment)
3. Select the issue from the query above (by ID)
4. Click the **"קבלה מלאה"** (Full Return) button
5. Confirm success message appears

### AFTER: Run this query

```sql
USE SmartShevet;
-- Check issue status changed
SELECT 
    equipmentissue_id,
    status,
    issueDate,
    returnDate,
    equipmentId,
    reservationId
FROM EquipmentIssue 
WHERE equipmentissue_id = [ID_FROM_BEFORE];

-- Check side effect: Equipment transitioned
SELECT 
    equipment_id,
    name,
    status
FROM Equipment 
WHERE equipment_id = [EQUIPMENT_ID_FROM_BEFORE];

-- Check side effect: Reservation transitioned
SELECT 
    equipmentreservation_id,
    reservationStatus
FROM EquipmentReservation 
WHERE equipmentreservation_id = [RESERVATION_ID_FROM_BEFORE];
```

**Expected Result:**
- Issue `status = 'returned'` ✓ (state transitioned)
- Issue `returnDate = NOW` (not NULL) ✓ (side effect: timestamp added)
- Equipment `status = 'in_warehouse'` ✓ (side effect: cascaded transition)
- Reservation `reservationStatus = 'completed'` ✓ (side effect: cascaded transition)

---

## Verification Checklist

After running all three tests, verify:

- [ ] **Equipment confirmCondition():** status changed, lastUpdated updated
- [ ] **EquipmentReservation approveReservation():** reservation status changed, equipment cascaded to 'reserved'
- [ ] **EquipmentIssue returnEquipment(true):** issue status changed, returnDate set, equipment cascaded to 'in_warehouse', reservation cascaded to 'completed'

---

## Guard Violation Tests (Optional)

To test guard violations, try transitions from invalid states:

```sql
-- Try approveReservation on already-approved reservation (should fail)
-- Try confirmCondition on available equipment (should fail)
-- Try returnEquipment on equipment not in 'issued' state (should fail)

-- These should show error MessageBoxes in the UI without changing database state
```

---

## Notes

- All timestamps are stored as DATETIME2 in the database
- Side effects are cascading: changing one entity may trigger changes in related entities
- Guard validations happen in the C# layer (try-catch in button handlers)
- Failed transitions show Hebrew error messages but do NOT modify the database

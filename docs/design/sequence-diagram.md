# Sequence Diagrams

![sequence diagram](sequence-diagram.png)

## 1. Equipment Reservation Flow

### Participants

- **Senior Scout (Guide)** – Requests equipment
- **SmartShevet System** – Processes reservation
- **Warehouse Database** – Stores equipment data
- **Warehouse Staff Member** – Fulfills reservation

### Ordered Messages

1. **Senior Scout → SmartShevet System**: submitReservationRequest(equipmentList, activityDate)
   - Parameters: Equipment IDs, quantities, target activity date
   
2. **SmartShevet System → Warehouse Database**: checkAvailability(equipmentIds, date)
   - Query: Verify stock for each requested item
   
3. **Warehouse Database → SmartShevet System**: returnAvailabilityStatus(available[], unavailable[])
   - Response: List of available and unavailable items
   
4. **SmartShevet System → Senior Scout**: displayAvailabilityAlert()
   - If out-of-stock items exist: Show notification
   - If all items available: Proceed to confirmation
   
5. **[alt] Out of stock scenario:**
   - SmartShevet System → SmartShevet System: removeOutOfStockItems()
   - SmartShevet System → Senior Scout: removeItemFromRequest()

6. **[opt] Scout approves modified list:**
   - Senior Scout → SmartShevet System: confirmReservationRequest(approvedList)
   
7. **SmartShevet System → Warehouse Database**: createReservationRecord(reservationDetails)
   - Create reservation with "Approved" status
   
8. **Warehouse Database → SmartShevet System**: reservationConfirmed(reservationId)
   
9. **SmartShevet System → Senior Scout**: displayConfirmation()
   - Show reservation ID and expected delivery date

---

## 2. Equipment Issue and Return Flow

### Participants

- **Warehouse Staff Member** – Manages equipment
- **SmartShevet System** – Tracks equipment state
- **Warehouse Database** – Records transactions
- **Guide** – Receives and returns equipment

### Ordered Messages

1. **Warehouse Staff Member → SmartShevet System**: openEquipmentIssueScreen()
   
2. **SmartShevet System → Warehouse Database**: getPendingReservations()
   - Query: Get list of approved but not yet issued reservations
   
3. **Warehouse Database → SmartShevet System**: returnPendingList(reservations)
   
4. **SmartShevet System → Warehouse Staff Member**: displayPendingReservations()
   
5. **Warehouse Staff Member → SmartShevet System**: selectReservationForIssue(reservationId)
   
6. **SmartShevet System → Warehouse Database**: getReservationDetails(reservationId)
   
7. **SmartShevet System → Warehouse Staff Member**: displayEquipmentToIssue(itemList)
   
8. **Warehouse Staff Member → SmartShevet System**: confirmEquipmentIssue(guideId, timestamp)
   - Confirm that equipment was handed to guide
   
9. **SmartShevet System → Warehouse Database**: recordEquipmentIssue(issueRecord)
   - Status: "Borrowed"
   - Record guide and warehouse staff member identities
   
10. **Warehouse Database → SmartShevet System**: issueRecorded(issueId)
    
11. **[Later] At activity end:**
    
12. **Guide → SmartShevet System**: initiateEquipmentReturn()
    
13. **Warehouse Staff Member → SmartShevet System**: openReturnScreen()
    
14. **SmartShevet System → Warehouse Database**: getBorrowedEquipmentList(guideId)
    
15. **SmartShevet System → Warehouse Staff Member**: displayBorrowedItems()
    
16. **Warehouse Staff Member → SmartShevet System**: recordEquipmentReturn(issueId, itemsList, conditions)
    - Parameters: Which items returned, condition of each (good/damaged/missing)
    
17. **SmartShevet System → Warehouse Database**: updateEquipmentStatus(itemIds, statuses)
    - Update status to "In Warehouse" or "Damaged" as appropriate
    
18. **[alt] If damaged equipment:**
    - SmartShevet System → SmartShevet System: createMaintenanceTicket(equipmentId)
    - SmartShevet System → Warehouse Database**: recordDamageReport(ticketId)
    
19. **Warehouse Database → SmartShevet System**: returnUpdated()
    
20. **SmartShevet System → Warehouse Staff Member**: displayConfirmation()
    - Show returned items and their new status

---

## 3. Scout Attendance Recording Flow

### Participants

- **Guide** – Records attendance
- **SmartShevet System** – Processes submission
- **Attendance Database** – Stores records
- **Senior Coordinator** – Reviews patterns

### Ordered Messages

1. **Guide → SmartShevet System**: openAttendanceScreen(activityId)
   
2. **SmartShevet System → Attendance Database**: getScoutListForActivity(activityId)
   - Query: Retrieve all scouts participating in activity
   
3. **Attendance Database → SmartShevet System**: returnScoutList(scouts[])
   
4. **SmartShevet System → Guide**: displayAttendanceForm(scoutList)
   - Show form with scout names and attendance status options
   
5. **Guide → SmartShevet System**: recordAttendance(activityId, attendanceRecords[])
   - Parameters: Array of {scoutId, status (present/absent/late)}
   
6. **SmartShevet System → SmartShevet System**: validateSubmission()
   - Check: All scouts recorded, valid status values
   
7. **[opt] If validation fails:**
   - SmartShevet System → Guide: displayErrorMessage(validationErrors)
   - Guide → SmartShevet System: correctAndResubmit()
   
8. **SmartShevet System → Attendance Database**: saveAttendanceRecord(activityId, records[], timestamp)
   - Mark submission timestamp
   
9. **Attendance Database → SmartShevet System**: recordSaved(recordId)
   
10. **SmartShevet System → Guide**: displayConfirmation()
    - Show "Attendance submitted successfully"
    
11. **[Background] System analysis:**
    
12. **SmartShevet System → Attendance Database**: analyzeAttendancePatterns()
    - Query: Check for 3+ consecutive absences
    
13. **Attendance Database → SmartShevet System**: flaggedScouts(list)
    
14. **[alt] If at-risk scouts detected:**
    - SmartShevet System → SmartShevet System**: createAlert()
    - SmartShevet System → Senior Coordinator**: sendNotification(alertMessage)
    - Alert includes: Scout name, absence count, recommended intervention

---

## 4. Activity Review and Approval Flow

### Participants

- **Guide** – Writes and submits activity
- **SmartShevet System** – Manages workflow
- **Activity Database** – Stores plans
- **Troop Leader (RagShaGad)** – Reviews and approves

### Ordered Messages

1. **Guide → SmartShevet System**: openActivityEditor()
   
2. **SmartShevet System → Guide**: displayActivityForm()
   - Form includes: Title, description, date, goals, learning outcomes, etc.
   
3. **Guide → SmartShevet System**: writeActivityPlan(contentDocument)
   - Guide writes activity details in rich editor
   
4. **[opt] Save draft:**
   - Guide → SmartShevet System**: saveDraft(partialContent)
   - SmartShevet System → Activity Database**: updateDraft(activityId, content)
   
5. **Guide → SmartShevet System**: submitForApproval(completedActivity)
   - Status changes to "Submitted"
   
6. **SmartShevet System → Activity Database**: createActivityRecord(activity, status="Submitted")
   - Record submission timestamp and guide ID
   
7. **SmartShevet System → Troop Leader**: notifyNewSubmission(activityId, guideName)
   - Alert: New activity waiting review
   
8. **Troop Leader → SmartShevet System**: openActivityReview(activityId)
   
9. **SmartShevet System → Activity Database**: getActivityDetails(activityId)
   
10. **SmartShevet System → Troop Leader**: displayActivityForReview(content, readOnlyStatus)
    - Document in read-only view for review
    
11. **Troop Leader → SmartShevet System**: writeReviewNotes(comments, corrections)
    - Inline comments and general feedback
    
12. **SmartShevet System → Activity Database**: saveReviewNotes(activityId, notes, status="Reviewed")
    - Update status to "Reviewed"
    
13. **[alt] Decision point:**
    
14. **[opt] If approval needed:**
    - Troop Leader → SmartShevet System**: submitApproval(approvalStatus="approved")
    - SmartShevet System → Activity Database**: updateStatus(activityId, "Approved")
    - SmartShevet System → Troop Leader**: displayConfirmation("Activity approved")
    
15. **[opt] If revisions needed:**
    - SmartShevet System → Activity Database**: updateStatus(activityId, "Reviewed")
    - SmartShevet System → Guide**: notifyReviewComplete(activityId, notes)
    - Alert: Review complete, revisions requested
    
16. **Guide → SmartShevet System**: viewReviewNotes(activityId)
    
17. **SmartShevet System → Guide**: displayNotesWithHighlights()
    - Show comments with context
    
18. **Guide → SmartShevet System**: reviseAndResubmit(revisedContent)
    - Status resets to "Submitted"
    
19. **[loop] Repeat review cycle until approved**

---

## Legends

### Alt Fragment
Represents alternative flows based on a condition (if/else scenario)

### Opt Fragment
Represents optional interactions that may or may not occur

### Loop Fragment
Represents repeated interactions until a condition is met

### Ref Fragment
References another sequence diagram for complex sub-interactions

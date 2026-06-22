# Use Case Specifications

## Use Case 1: Recording Attendance per Activity

### Behavioral Spec (Technology-Neutral)

**Participants:** Guide, Troop Leader

**Preconditions:**
1. The guide is logged into the system with appropriate permissions
2. An activity plan has been uploaded to the system

**Main Flow:**

1. Guide enters the attendance recording screen for a specific activity
2. Guide records attendance data (present/absent/late) for each scout
3. System validates the submission
4. System marks the activity status as "Reviewed"
5. System records the submission timestamp
6. Guide receives confirmation of successful submission

**Extensions:**

1. If in step 2 the guide approves the activity without corrections: Guide confirms the activity
2. System updates the activity status to "Approved"
3. Guide cannot longer edit the activity

**Post-conditions:**

1. Attendance records are saved in the system
2. System records the timestamp and submission status for reporting

---

### Implementation Notes

TODO: Define validation rules for attendance data entry (e.g., valid status values, required fields)

---

## Use Case 2: View Total Tribal Attendance

### Behavioral Spec (Technology-Neutral)

**Participants:** Senior Coordinator (Troop Leader)

**Preconditions:**
1. Senior coordinator is logged into the system
2. Guides have submitted attendance records

**Main Flow:**

1. Senior coordinator accesses the attendance viewing screen for the troop level
2. System displays consolidated attendance data for scouts registered in the troop
3. System shows summary statistics and percentages of scout participation throughout the year

**Post-conditions:**

1. Senior coordinator has a comprehensive view of troop-level participation
2. Data supports decision-making on scout engagement and retention

---

### Implementation Notes

TODO: Define aggregation methods for calculating troop-level statistics (by troop, by age group, over different time periods)

---

## Use Case 3: Reserve Equipment

### Behavioral Spec (Technology-Neutral)

**Participants:** Senior Scout (Guide)

**Preconditions:**
1. Senior scout is logged into the system
2. Warehouse catalog is available and current
3. An upcoming activity exists

**Main Flow:**

1. Senior scout navigates to the equipment reservation screen
2. System displays approved equipment requests for the scout
3. Senior scout selects an activity to reserve equipment for (future activity date specified)
4. System displays the equipment catalog with availability information
5. Senior scout selects items to reserve (includes "Include" option to mark equipment status change)
6. System validates the reservation request
7. System confirms successful reservation

**Extensions:**

1. If in step 4 the system detects an out-of-stock item: System sends an out-of-stock alert
2. System removes the item from the request
3. Senior scout can add other items as needed

**Post-conditions:**

1. Equipment is marked as reserved in the system
2. Equipment availability is updated in inventory

---

### Implementation Notes

TODO: Define how "Include" status change works technically (database updates, equipment tracking)

---

## Use Case 4: Giving Equipment

### Behavioral Spec (Technology-Neutral)

**Participants:** Warehouse Staff Member

**Preconditions:**
1. Warehouse staff member is logged into the system
2. Equipment reservation requests exist
3. Equipment is available in warehouse

**Main Flow:**

1. Warehouse staff member enters the equipment distribution screen
2. System displays pending equipment requests
3. Warehouse staff member confirms the delivery of requested equipment to guides
4. System updates the loan status (status change to "Borrowed")
5. System logs the staff member and binding user

**Post-conditions:**

1. Inventory status is updated in real-time
2. Equipment accountability is recorded

---

### Implementation Notes

TODO: Define workflow for partial fulfillment (when only some requested items are available)

---

## Use Case 5: Return Equipment

### Behavioral Spec (Technology-Neutral)

**Participants:** Warehouse Staff Member

**Preconditions:**
1. Warehouse staff member is logged into the system
2. Equipment has been borrowed
3. Equipment is being returned

**Main Flow:**

1. Warehouse staff member enters the equipment return screen
2. System displays borrowed equipment awaiting return
3. Warehouse staff member receives returned equipment from guides
4. Warehouse staff member documents the return (including equipment status)
5. System verifies returned equipment against warehouse records
6. System updates equipment status to "In Warehouse"
7. System records that returned equipment was verified by warehouse staff

**Post-conditions:**

1. Equipment is confirmed as returned in the system
2. Inventory accuracy is maintained

---

### Implementation Notes

TODO: Define equipment condition assessment process (how to mark "damaged" vs "working")

---

## Use Case 6: Set Minimum Threshold

### Behavioral Spec (Technology-Neutral)

**Participants:** Senior Coordinator

**Preconditions:**
1. Senior coordinator is logged into the system
2. Consumable equipment items exist in the catalog

**Main Flow:**

1. Senior coordinator enters the inventory management screen
2. System displays a list of existing consumable items
3. Senior coordinator selects an item to update
4. System displays the item details, including the current minimum threshold
5. Senior coordinator enters a new value for the minimum threshold
6. System validates the input
7. System saves the minimum threshold in the database
8. System displays a success message: "The update was completed successfully"

**Extensions:**

1. If in step 6 the senior coordinator enters a non-numeric or negative value: System displays an error message: "Invalid value"
2. Senior coordinator corrects the data
3. Process returns to step 6

**Post-conditions:**

1. The item's minimum threshold is updated in the system with the new value
2. Data is saved in the database
3. System displays the updated data to future users

---

### Implementation Notes

TODO: Define alert mechanism for when inventory drops below threshold (SMS, email, dashboard notification)

---

## Use Case 7: Check Activity and Write Notes

### Behavioral Spec (Technology-Neutral)

**Participants:** Troop Leader

**Preconditions:**
1. Troop leader is logged into the system
2. Guide has uploaded an activity plan

**Main Flow:**

1. Troop leader enters the activity review screen
2. System displays a list of uploaded activity plans
3. Troop leader selects an activity plan to review
4. System displays the activity document
5. Troop leader reviews the activity details
6. Troop leader writes notes and required corrections
7. System saves the notes
8. System updates the activity status to "Reviewed"

**Extensions:**

1. If in step 6 the troop leader approves the activity without corrections: Troop leader confirms the activity
2. System updates the activity status to "Approved"
3. Guide can no longer edit the activity

**Post-conditions:**

1. Notes are saved in the system and the status is updated

---

### Implementation Notes

TODO: Define comment/annotation tool functionality (inline comments, tracked changes, formatting options)

---

## Use Case 8: View Annual Inventory Forecast Report

### Behavioral Spec (Technology-Neutral)

**Participants:** Senior Coordinator

**Preconditions:**
1. Senior coordinator is logged into the system
2. At least one full year of equipment transaction history exists (issues, returns, damage reports)
3. Equipment items are marked as consumable or reusable in the catalog

**Main Flow:**

1. Senior coordinator accesses the inventory forecast report screen
2. System displays a date range selector (default: past 12 months)
3. Senior coordinator optionally adjusts the date range or equipment filters
4. System calculates three aggregated views:
   - **Consumable Usage Analysis**: For each consumable item, total quantity issued and average monthly consumption rate
   - **Unreturned Equipment Summary**: Count and list of equipment items currently in "borrowed" status beyond expected return date
   - **Damaged Equipment Summary**: Count of items in "damaged" or "missing" status during the period
5. System generates forecast calculations:
   - For consumables: Extrapolate annual consumption based on monthly average
   - Calculate estimated reorder budget based on unit costs and projected consumption
   - Estimate replacement budget needed for damaged/missing items
6. System displays the report with summary totals and item-level breakdowns
7. Senior coordinator reviews the data and can export or print the report

**Extensions:**

1. If in step 3 the coordinator filters by equipment category: System recalculates all views for the selected category only
2. If in step 5 the system detects a consumable with zero consumption: System flags it as "low-use" for review
3. If in step 4 the system detects unreturned items overdue by more than 30 days: System highlights them in red and includes a recovery recommendation

**Post-conditions:**

1. Senior coordinator has a comprehensive forecast of inventory needs for budget planning
2. Report is available for export to support procurement decisions
3. Overdue/damaged items are flagged for follow-up action

---

### Implementation Notes

**Data Requirements:**
- Equipment table: equipment_id, name, category, is_consumable, unit_cost, status
- EquipmentIssue table: equipmentissue_id, equipmentId, issueDate, returnDate, status (issued, returned, not_returned, completed)
- Equipment transaction history grouped by:
  - Equipment ID
  - Issue/return date (for consumption rate calculation)
  - Status transitions (damaged, missing, returned, not_returned)

**Input Parameters:**
- `@startDate` (DATETIME2): Beginning of analysis period (default: 12 months ago)
- `@endDate` (DATETIME2): End of analysis period (default: TODAY)
- `@categoryFilter` (NVARCHAR, optional): Equipment category to restrict report scope (NULL = all categories)
- `@includeOverdueOnly` (BIT, optional): If 1, show only unreturned items overdue beyond 30 days

**Output Structure:**

**Section 1: Consumable Usage Analysis**
- Equipment ID, Equipment Name, Category
- Total Quantity Issued (sum of issued quantities in period)
- Average Monthly Consumption (total quantity / number of months in period)
- Projected Annual Consumption (monthly average × 12)
- Unit Cost
- Projected Annual Spend (projected annual consumption × unit cost)

**Section 2: Unreturned Equipment Summary**
- Equipment ID, Equipment Name
- Issue Date
- Days Overdue (TODAY - expected return date, if > 0)
- Issued To (guide/scout name)
- Status (currently "borrowed")
- Recovery Action (recommended action: contact guide, check warehouse, report as missing)

**Section 3: Damaged/Missing Equipment Summary**
- Equipment ID, Equipment Name, Category
- Count in "damaged" status during period
- Count in "missing" status during period
- Total Replacement Cost (count × unit cost)
- Average Condition Rating (if tracked)

**Section 4: Summary Totals**
- Total Projected Consumable Budget (sum of projected annual spend)
- Total Unreturned Equipment Value (count of items × average unit cost)
- Total Damaged/Missing Equipment Value (replacement cost)
- **Grand Total Estimated Budget Need** (sum of sections 1–3)

**Aggregation Rules:**
- All aggregations GROUP BY equipment_id, equipment name
- Consumable consumption calculated as: SUM(issued quantity) WHERE is_consumable=true AND issueDate BETWEEN @startDate AND @endDate
- Unreturned items: WHERE status='borrowed' AND expected return date < TODAY (or user-specified date)
- Damaged/missing: WHERE status IN ('damaged', 'missing') AND status change date BETWEEN @startDate AND @endDate
- Monthly average: total consumed / DATEDIFF(MONTH, @startDate, @endDate)

**Stored Procedure Specification:**
```
sp_inventory_forecast_report
  @startDate DATETIME2,
  @endDate DATETIME2,
  @categoryFilter NVARCHAR(100) = NULL,
  @includeOverdueOnly BIT = 0
```
Returns four result sets (one per section above) with all aggregations pre-calculated.

**UI Rendering:**
- Date range picker with preset options: "Last 3 months", "Last 6 months", "Last 12 months"
- Category dropdown (optional filter)
- Three separate table views (Consumables, Unreturned, Damaged/Missing)
- Summary dashboard showing grand total budget need prominently
- Export buttons (PDF, Excel) for each section
- Print-friendly layout with all sections on one or two pages

# CLAUDE.md — SmartShevet Project

## What This Project Is

SmartShevet is a management information system for Shevet Arayot (Lions Troop), a youth movement unit in Gederot, Israel. The troop serves approximately 550 youth members (ages 10-18) and operates through volunteer leaders, mentors, and senior scouts.

The initial implementation focuses exclusively on **Equipment & Logistics Management** — warehouse inventory, equipment reservations, tracking checkouts and returns, and inventory monitoring.

*(Future phases will add Activity Management and Personnel Management. The current scope is equipment domain only.)*

The system replaces fragmented manual processes for equipment tracking (WhatsApp, spreadsheets, paper forms) with a unified, role-based platform that enables real-time visibility into warehouse inventory and equipment workflows.

---

## Architecture Conventions

This project follows the shared SAD conventions documented in `PATTERNS.md` (inherited below). **This section inlines those conventions in full.**

### The Human vs. AI Distinction — Course-Wide Principle

This distinction is central to how you should approach work in this course. Do not blur it.

**Humans must do this** (AI cannot substitute, even though AI will later use the output):
- Organizational context: who the business is, what problem it has, why it matters
- Stakeholder identification and needs elicitation
- Problem statement and project scope
- Initial domain modeling: what entities exist, what relationships make sense
- Deciding which use cases exist and which don't (e.g., deciding Login is an NFR, not a UC)
- Prioritization and tradeoffs

**AI can accelerate this** (once the human thinking is done):
- Structuring requirements into user story format
- Writing VP18-style UC specs from a brief description
- Generating the UC diagram HTML from the spec data
- Generating entity classes, stored procedures, and panels from UC specs + implementation notes
- Checking consistency between artifacts (traceability)

Project artifacts are produced in this order: organization/problem context → requirements → UC specs → code. Each is input to the next.

---

## Architecture — Key Patterns

### Entity Pattern
Every entity class is self-contained. Each one owns:
- Private fields + getters/setters
- Constructor with `bool is_new` — if `true`, calls `getNextXYZId()` to assign a new PK, then calls `createXYZ()`, then adds to `Program.list`; if `false`, just sets fields (used during loading)
- `createXYZ()`, `updateXYZ()`, `deleteXYZ()` — each builds a `SqlCommand` with a stored procedure
- `static initXYZs()` — loads all records from DB into `Program.XYZs`, always calls constructor with `is_new = false`
- `static seekXYZ(id)` — searches `Program.XYZs` by ID
- `static getNextXYZId()` — returns `max(id) + 1` over `Program.XYZs` (or `1` if the list is empty). See "Primary Key Strategy" below.

### Primary Key Strategy
**Primary keys are assigned in C#, not by the database.**

- DDL: every PK is `INT NOT NULL PRIMARY KEY`. Do **not** use `IDENTITY(1,1)`.
- The entity class's `static getNextXYZId()` returns `max(id) + 1` over the in-memory list.
- The `is_new` constructor calls `getNextXYZId()` before `createXYZ()` to assign the new row's PK.
- Create stored procedures take the PK as the first parameter (`@<entity>_id`). They do **not** use `SCOPE_IDENTITY()` and do **not** return the new ID.

This is deliberate: students can read the full lifecycle of an ID in one place (the C# constructor), and DB writes are deterministic from the entity's state. Concurrency is not a concern in the single-user teaching context.

### In-Memory Lists
All data lives in `Program.*` static lists after startup. No DB calls during normal use except writes.

`initLists()` load order is strict: **base entities first, then entities with FK references, then association classes last.** Each project's CLAUDE.md states its own concrete order.

### DB Operations
All DB access goes through stored procedures. **No ad-hoc SQL strings in application code.** This is an NFR.

### Panel Navigation
Single-window model. All screens are `UserControl` panels. Navigation: `mainForm.showPanel(new XYZPanel())`. Every panel has a Back button. **No additional Forms or dialogs during normal operation.**

### Inheritance — Table-per-Subclass
When an entity has subtypes, use table-per-subclass: a base table for the parent + one table per subclass holding only the subclass's unique fields + a FK to the base table. Load with a LEFT JOIN and check for `DBNull.Value` to determine subtype. *(Sample project example: `Order` base with `DeliveryOrder` / `PickupOrder` subclasses.)*

### Association Class
When a many-to-many relationship has its own attributes, model it as an association class linking the two sides. In the C# class, both sides are stored as **object references, not IDs**. *(Sample project example: `OrderItem` linking `Order` ↔ `Product` with quantity and unit price.)*

### No Service Layer
Entity classes own their own DB methods. One file per entity. This is intentional for teaching — students see the full lifecycle of an entity in one place.

---

## UC Diagram — Conventions

The diagram is generated from inline JavaScript data and rendered by an external shared script. Rules:

- All data globals must use `var` (not `const`/`let`) so they become `window` properties
- Wireframes are embedded as `useCaseDocs[id].wireframe` HTML strings — **not** as separate files
- All wireframe visible text must be in Hebrew; all form fields use `disabled`; no `<script>` tags inside wireframes
- The `[hidden] { display: none !important; }` style override is required in `<head>` for tab switching to work
- **Login/authentication must never appear as a UC.** Note it only in the `assumptions` array.

### Two-Layer UC Spec Format
Each detailed UC has two sections:
1. **Formal spec** (analysis level) — behavioral, technology-neutral. No class names, SP names, or field names.
2. **Implementation Notes** (design level, clearly labelled) — maps behavioral steps to specific classes, methods, and stored procedures.

This separation is intentional and pedagogically important. Do not merge them.

---

## Language Conventions

| Context | Language |
|---|---|
| C# code (classes, methods, variables) | English |
| UI labels, button text, MessageBox text | Hebrew |
| DB text fields | Hebrew — use `NVARCHAR`, never `VARCHAR` |
| Student guide docs (`docs/*.md`) | Hebrew |
| Requirements and UC spec documents | English |
| UC diagram text (actor labels, UC names, flow steps) | Hebrew |

### RTL Layout for Hebrew UI

Every `Form` and `UserControl` with Hebrew visible text **must** be set up for right-to-left rendering:

- `RightToLeft = Yes` on the form/panel (mirrors text direction, button alignment, scrollbar position).
- `RightToLeftLayout = true` on the root form (mirrors the entire layout, including TabControl direction and DataGridView column order).
- Set these on the parent — children inherit unless overridden.

Generate panels with these properties set from the start. Retrofitting RTL onto LTR-built panels is painful — labels overlap, alignment breaks, the designer file fights you.

---

## Decisions Already Made — Do Not Revisit Without Discussion

These apply across all SAD projects:

- **Login is not a UC.** Authentication is an NFR precondition. A `LoginPanel` is a technical artifact. Do not add Login to UC diagrams or UC specs.
- **Wireframes belong inside the UC diagram modal**, not in separate files.
- **No ad-hoc SQL.** All DB operations use stored procedures.
- **No service layer.** Entity classes own their own DB methods.
- **Single window, panel navigation.** No additional forms or dialogs during normal operation.

---

## Document Map

| File | Purpose |
|---|---|
| `docs/org-analysis/01-organization.md` | Organization context: Shevet Ariות structure, current problems, stakeholders (Hebrew) |
| `docs/org-analysis/02-interviews.md` | Interview summaries from guides, coordinators, warehouse staff (Hebrew) |
| `docs/org-analysis/03-problems.md` | Problems table: 17 identified issues, root causes, desired solutions (Hebrew) |
| `docs/org-analysis/04-business-processes.md` | Three business processes with BPMN diagrams (Hebrew) |
| `docs/00-requirements.md` | User stories (26) + NFRs (6) + traceability matrix (English) |
| `docs/00e-use-cases.md` | VP18-style UC specs for 7 representative UCs with behavioral specs + implementation notes (English) |
| `docs/design/class-diagram.md` | Class diagram: 11 entities with attributes, methods, relationships, inheritance, association classes (English) |
| `docs/design/state-diagram.md` | State diagrams for Equipment, Activity, ReservationRequest, Attendance (English) |
| `docs/design/sequence-diagram.md` | Sequence diagrams for 4 key flows: equipment reservation, issue/return, attendance, activity review (English) |

---

## Domain Entities and Load Order

The in-memory list load order for this project is **strict**:

```
Equipment → Scout → SeniorScout → Troop → Activity →
Guide (subclass of SeniorScout) → WarehouseStaffMember (subclass of SeniorScout) → SeniorCoordinator (subclass of SeniorScout) →
EquipmentReservation, EquipmentIssue →
ReservationDetails (association class), Attendance (association class)
```

### Base Entities (No FK Dependencies Among Themselves)
- **Equipment** — warehouse items: name, category, type, quantity, status, minimum threshold
- **Scout** — youth members: name, level, parent contact, sensitivities (medical/dietary)
- **SeniorScout** (base class) — senior volunteer members (Shkab"g): name, service years, mentoring specialties, performance rating
- **Troop** — troop organization: name, location, member count
- **Activity** — planned events/outings: name, date, description, status, document

### Inheritance: Table-per-Subclass (All Inherit from SeniorScout)
- **Guide** — group leader/instructor (subclass)
- **WarehouseStaffMember** — warehouse staff (subclass)
- **SeniorCoordinator** — troop coordinator (subclass)

### Transactional Entities (Depend on Base Entities)
- **EquipmentReservation** — request to reserve equipment for an activity
- **EquipmentIssue** — record of equipment checkout/distribution to guides

### Association Classes (Depend on Transactional Entities)
- **ReservationDetails** — links EquipmentReservation ↔ Equipment with quantity and added-equipment flag
- **Attendance** — links Scout ↔ Activity with attendance status (present/absent/late) and recorded-by Guide reference

---

## Project-Specific Decisions

Beyond the cross-project decisions in PATTERNS.md:

### Initial Implementation Scope
**Equipment Domain Only.** The initial implementation focuses exclusively on equipment management, reservation, and logistics workflows. No other domain features are in scope.

Implemented Use Cases:

1. **Manage Equipment** (US1) — CRUD for warehouse inventory (create, view, update, delete equipment items with category, type, quantity, status)
2. **Reserve Equipment** (UC3) — guides request equipment for activities; automatic availability verification
3. **Edit Equipment Reservation** (US3) — modify pending reservation requests
4. **Giving Equipment** (UC4) — warehouse staff issue reserved equipment to guides; update equipment status to "Borrowed"
5. **Return Equipment** (UC5) — warehouse staff receive and document returned equipment; track condition status (good/damaged/missing)
6. **Manage Equipment Status** — view and change equipment status across the system (available, borrowed, damaged, missing, under repair)

**Explicitly Excluded from Initial Scope:**
- Scout attendance tracking (US17–US19)
- Activity management and approval workflows (US8–US10)
- Senior scout/staff management and performance tracking (US12–US15, US22)
- Competency scoring and reporting (US22–US23)
- Multi-user, concurrent access, and offline support (US24–US26)
- Audit trail and action history (NFR)
- Set Minimum Threshold will be implemented in Phase 2 after core inventory management is stable

**Rationale for Equipment-Only Scope:**
- Creates a coherent, self-contained business process with clear boundaries (reserve → issue → return)
- Allows validation of core architecture (Entity pattern, in-memory lists, panel navigation, CRUD panels)
- Manageable scope for initial development cycle with clear success criteria
- Equipment workflow is blocking other domains; solving it first unblocks Activity and Personnel features in later phases

### Inheritance Details
**SeniorScout** is the parent class for all volunteer roles. The three subclasses use table-per-subclass:
- `SeniorScout` base table: common fields (name, service years, etc.)
- `Guide` table: FK to SeniorScout, fields specific to group leaders
- `WarehouseStaffMember` table: FK to SeniorScout, fields specific to warehouse staff
- `SeniorCoordinator` table: FK to SeniorScout, fields specific to coordinators

Load all via LEFT JOIN; check for `DBNull.Value` to determine which subclass rows are present.

### Association Class Details
- **ReservationDetails**: links specific equipment (with quantity) to each reservation request. Stores as object references: `Equipment equipment` and `EquipmentReservation reservation`.
- **Attendance**: links scouts to activities with attendance status. Also stores guide who recorded the attendance (`Guide recordedBy`).

### Hebrew and RTL Requirements
- **UI Text**: All visible labels, buttons, messages, grid headers in Hebrew
- **RTL Layout**: Set `RightToLeft = Yes` and `RightToLeftLayout = true` on all panels with Hebrew text from the start
- **Database**: All text columns use `NVARCHAR`, never `VARCHAR`
- **Backend Code**: All C# code, entity classes, method names, variable names remain in English for consistency with SAD conventions

### Out-of-Scope for Phase 1 — Equipment Domain Only
The following are explicitly deferred and will NOT be implemented in this phase:

**Personnel & Management Features:**
- Senior scout (Shkab"g) management and profiling (US12–US15)
- Performance tracking and competency scoring (US22)
- Staff/instructor role assignment and placement workflows
- Mentor oversight and development tracking

**Activity Management:**
- Activity planning, creation, and CRUD (US8)
- Activity plan approval and review workflows (US9–US10)
- Document upload and version control for activity plans

**Scout Attendance & Tracking:**
- Attendance recording and verification (US17)
- Tribal attendance reporting (US18)
- Scout sensitivity/health information management (US19)
- At-risk scout identification based on attendance patterns

**Advanced Features:**
- Competency reports and budget forecasting (US22–US23)
- Multi-user concurrent access support (US24)
- Mobile/browser compatibility (US25)
- Offline data access (US26)
- Audit trail and action history (NFR)
- Set Minimum Threshold for automatic reorder (US5) — Phase 2

**Rationale:** Phase 1 is equipment-only. All other domains are deferred pending successful validation of the core equipment workflow architecture.

---

## Summary

**Phase 1: Equipment Domain Only**

SmartShevet is a single-window WinForms application that manages **equipment logistics exclusively** for an Israeli youth troop. It implements the SAD architecture pattern: entity-based CRUD, stored-procedure DB access, in-memory lists, and role-based panel navigation. The Hebrew-RTL UI is built on top of English backend code and architecture.

**Phase 1 Scope (Equipment Only):**
- Equipment CRUD and inventory management
- Equipment reservation requests (with availability checking)
- Equipment issue/distribution to guides
- Equipment return and condition tracking
- Equipment status management (available → borrowed → returned → damaged/missing)
- Warehouse staff and guide workflows

**Future Phases (Out of Scope for Phase 1):**
- Activity planning and approval workflows
- Scout attendance tracking
- Senior scout/staff management and performance tracking
- Competency scoring and reporting
- Multi-user and offline support

The equipment domain is cohesive, self-contained, and provides a clear validation path for the core architecture before expanding to other domains.

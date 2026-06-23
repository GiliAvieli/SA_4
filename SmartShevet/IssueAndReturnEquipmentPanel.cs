using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.SqlClient;

namespace SmartShevet
{
    public partial class IssueAndReturnEquipmentPanel : UserControl
    {
        private EquipmentReservation selectedOrder = null;

        public IssueAndReturnEquipmentPanel()
        {
            InitializeComponent();
            this.RightToLeft = RightToLeft.Yes;

            initializeMasterGrid();
            initializeDetailGrid();
            loadApprovedOrders();
        }

        private void initializeMasterGrid()
        {
            masterOrdersGridView.DataSource = null;
            masterOrdersGridView.Columns.Clear();

            // Column 1: Order ID
            DataGridViewTextBoxColumn orderIdCol = new DataGridViewTextBoxColumn();
            orderIdCol.Name = "מזהה הזמנה";
            orderIdCol.HeaderText = "מזהה הזמנה";
            orderIdCol.Width = 100;
            orderIdCol.ReadOnly = true;
            masterOrdersGridView.Columns.Add(orderIdCol);

            // Column 2: Activity Date
            DataGridViewTextBoxColumn activityDateCol = new DataGridViewTextBoxColumn();
            activityDateCol.Name = "תאריך פעילות";
            activityDateCol.HeaderText = "תאריך פעילות";
            activityDateCol.Width = 150;
            activityDateCol.ReadOnly = true;
            masterOrdersGridView.Columns.Add(activityDateCol);

            // Column 3: Requester Name
            DataGridViewTextBoxColumn requesterCol = new DataGridViewTextBoxColumn();
            requesterCol.Name = "מבקש";
            requesterCol.HeaderText = "מבקש";
            requesterCol.Width = 200;
            requesterCol.ReadOnly = true;
            masterOrdersGridView.Columns.Add(requesterCol);
        }

        private void initializeDetailGrid()
        {
            detailItemsGridView.DataSource = null;
            detailItemsGridView.Columns.Clear();

            // Column 1: Item Name (Read Only)
            DataGridViewTextBoxColumn itemNameCol = new DataGridViewTextBoxColumn();
            itemNameCol.Name = "שם פריט";
            itemNameCol.HeaderText = "שם פריט";
            itemNameCol.Width = 120;
            itemNameCol.ReadOnly = true;
            detailItemsGridView.Columns.Add(itemNameCol);

            // Column 2: Equipment Type (Read Only)
            DataGridViewTextBoxColumn typeCol = new DataGridViewTextBoxColumn();
            typeCol.Name = "סוג";
            typeCol.HeaderText = "סוג";
            typeCol.Width = 80;
            typeCol.ReadOnly = true;
            detailItemsGridView.Columns.Add(typeCol);

            // Column 3: Requested Qty (Read Only)
            DataGridViewTextBoxColumn requestedQtyCol = new DataGridViewTextBoxColumn();
            requestedQtyCol.Name = "כמות מבוקשת";
            requestedQtyCol.HeaderText = "כמות מבוקשת";
            requestedQtyCol.Width = 100;
            requestedQtyCol.ReadOnly = true;
            detailItemsGridView.Columns.Add(requestedQtyCol);

            // Column 4: Delivered Qty (Numeric Input)
            DataGridViewTextBoxColumn deliveredQtyCol = new DataGridViewTextBoxColumn();
            deliveredQtyCol.Name = "כמות שנמסרה";
            deliveredQtyCol.HeaderText = "כמות שנמסרה";
            deliveredQtyCol.Width = 100;
            detailItemsGridView.Columns.Add(deliveredQtyCol);

            // Column 5: Returned OK Qty (Numeric Input)
            DataGridViewTextBoxColumn returnedOkQtyCol = new DataGridViewTextBoxColumn();
            returnedOkQtyCol.Name = "כמות שהוחזרה תקינה";
            returnedOkQtyCol.HeaderText = "כמות שהוחזרה תקינה";
            returnedOkQtyCol.Width = 120;
            detailItemsGridView.Columns.Add(returnedOkQtyCol);

            // Column 6: Lost Qty (Numeric Input)
            DataGridViewTextBoxColumn lostQtyCol = new DataGridViewTextBoxColumn();
            lostQtyCol.Name = "כמות שאבדה";
            lostQtyCol.HeaderText = "כמות שאבדה";
            lostQtyCol.Width = 100;
            detailItemsGridView.Columns.Add(lostQtyCol);

            // Column 7: Damaged Qty (Numeric Input)
            DataGridViewTextBoxColumn damagedQtyCol = new DataGridViewTextBoxColumn();
            damagedQtyCol.Name = "כמות שנהרסה";
            damagedQtyCol.HeaderText = "כמות שנהרסה";
            damagedQtyCol.Width = 100;
            detailItemsGridView.Columns.Add(damagedQtyCol);
        }

        private void loadApprovedOrders()
        {
            masterOrdersGridView.Rows.Clear();

            foreach (EquipmentReservation reservation in Program.EquipmentReservations)
            {
                if (reservation.getReservationStatus().ToLower() == "approved")
                {
                    SeniorScout requester = reservation.getRequestedBy();
                    int rowIndex = masterOrdersGridView.Rows.Add(
                        reservation.getId(),
                        reservation.getActivityDate().ToString("yyyy-MM-dd"),
                        requester?.getName() ?? "Unknown"
                    );

                    masterOrdersGridView.Rows[rowIndex].Tag = reservation;
                }
            }
        }

        private void loadDetailItems()
        {
            detailItemsGridView.Rows.Clear();

            if (selectedOrder == null) return;

            foreach (ReservationDetails detail in Program.ReservationDetailsList)
            {
                if (detail.getReservation().getId() == selectedOrder.getId())
                {
                    Equipment equipment = detail.getEquipment();
                    if (equipment != null)
                    {
                        // Load existing EquipmentIssue values from database
                        var issueData = getEquipmentIssueData(detail.getId());

                        string deliveredQtyStr = issueData["issued_qty"];
                        string returnedOkQtyStr = issueData["returned_ok_qty"];
                        string lostQtyStr = issueData["lost_qty"];
                        string damagedQtyStr = issueData["damaged_qty"];

                        string typeDisplay = equipment.getEquipmentType().ToLower() == "consumable" ? "צריכה" : "שניתן לשימוש חוזר";

                        int rowIndex = detailItemsGridView.Rows.Add(
                            equipment.getName(),
                            typeDisplay,
                            detail.getQuantity().ToString(),
                            deliveredQtyStr,
                            returnedOkQtyStr,
                            lostQtyStr,
                            damagedQtyStr
                        );

                        detailItemsGridView.Rows[rowIndex].Tag = detail;
                    }
                }
            }
        }

        private Dictionary<string, string> getEquipmentIssueData(int reservationDetailId)
        {
            Dictionary<string, string> result = new Dictionary<string, string>
            {
                { "issued_qty", "0" },
                { "returned_ok_qty", "0" },
                { "lost_qty", "0" },
                { "damaged_qty", "0" }
            };

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"
                    SELECT issued_qty, returned_ok_qty, lost_qty, damaged_qty
                    FROM EquipmentIssue
                    WHERE reservation_detail_id = @detailId
                ";
                cmd.Parameters.AddWithValue("@detailId", reservationDetailId);

                SQL_CON SC = new SQL_CON();
                SqlDataReader reader = SC.execute_query(cmd);

                if (reader.Read())
                {
                    result["issued_qty"] = reader[0] == DBNull.Value ? "0" : reader[0].ToString();
                    result["returned_ok_qty"] = reader[1] == DBNull.Value ? "0" : reader[1].ToString();
                    result["lost_qty"] = reader[2] == DBNull.Value ? "0" : reader[2].ToString();
                    result["damaged_qty"] = reader[3] == DBNull.Value ? "0" : reader[3].ToString();
                }
            }
            catch
            {
                // If query fails, return defaults
            }

            return result;
        }

        private void masterOrdersGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (masterOrdersGridView.SelectedRows.Count > 0)
            {
                selectedOrder = masterOrdersGridView.SelectedRows[0].Tag as EquipmentReservation;
                loadDetailItems();
            }
            else
            {
                selectedOrder = null;
                detailItemsGridView.Rows.Clear();
            }
        }

        private void saveChangesButton_Click(object sender, EventArgs e)
        {
            if (selectedOrder == null)
            {
                MessageBox.Show("בחר הזמנה לשמירה", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int orderId = selectedOrder.getId();
                List<GridRowData> rowsWithData = readDetailGridData();

                if (rowsWithData.Count == 0)
                {
                    MessageBox.Show("הזן לפחות כמות הנפקה או החזרה אחת", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // ========== INVENTORY STATE TRANSITION LOGIC ==========
                // CRITICAL: Update Equipment quantities BEFORE persisting to database
                System.Diagnostics.Debug.WriteLine("[saveChangesButton_Click] Starting inventory state transitions");

                foreach (GridRowData row in rowsWithData)
                {
                    Equipment equipment = row.Equipment;
                    int deliveredQty = row.DeliveredQty;
                    int returnedOkQty = row.ReturnedOkQty;
                    int lostQty = row.LostQty;
                    int damagedQty = row.DamagedQty;

                    System.Diagnostics.Debug.WriteLine($"[saveChangesButton_Click] Processing {equipment.getName()}: Delivered={deliveredQty}, ReturnedOK={returnedOkQty}, Lost={lostQty}, Damaged={damagedQty}");

                    // CASE 1: ISSUING EQUIPMENT (Delivery)
                    // When equipment is issued from a reservation, it moves from "reserved" → "borrowed"
                    if (deliveredQty > 0)
                    {
                        System.Diagnostics.Debug.WriteLine($"[saveChangesButton_Click] ISSUING {deliveredQty} units of {equipment.getName()}");
                        // The equipment was reserved, now it's being delivered/borrowed
                        // Status changes: reserved → borrowed
                        // Update Equipment status to reflect the issued state
                        equipment.setStatus("borrowed");
                        equipment.setLastUpdated(DateTime.Now);
                        System.Diagnostics.Debug.WriteLine($"[saveChangesButton_Click] Status changed to 'borrowed'");
                    }

                    // CASE 2: RETURNING EQUIPMENT (Return)
                    // When equipment is returned, it moves from "borrowed" back to "available"
                    if (returnedOkQty > 0)
                    {
                        System.Diagnostics.Debug.WriteLine($"[saveChangesButton_Click] RETURNING {returnedOkQty} units (OK) of {equipment.getName()}");
                        // Equipment is being returned in good condition
                        // Increase available quantity
                        int currentQty = equipment.getQuantity();
                        int newQty = currentQty + returnedOkQty;
                        equipment.setQuantity(newQty);
                        equipment.setStatus("available");
                        equipment.setLastUpdated(DateTime.Now);
                        System.Diagnostics.Debug.WriteLine($"[saveChangesButton_Click] Quantity updated: {currentQty} → {newQty}, Status: available");
                    }

                    // CASE 3: LOST EQUIPMENT
                    if (lostQty > 0)
                    {
                        System.Diagnostics.Debug.WriteLine($"[saveChangesButton_Click] LOST {lostQty} units of {equipment.getName()}");
                        // Equipment was borrowed but never returned (lost/missing)
                        // Decrease available quantity (asset loss)
                        int currentQty = equipment.getQuantity();
                        int newQty = Math.Max(0, currentQty - lostQty);
                        equipment.setQuantity(newQty);
                        equipment.setStatus("lost");
                        equipment.setLastUpdated(DateTime.Now);
                        System.Diagnostics.Debug.WriteLine($"[saveChangesButton_Click] Quantity updated: {currentQty} → {newQty}, Status: lost");
                    }

                    // CASE 4: DAMAGED EQUIPMENT
                    if (damagedQty > 0)
                    {
                        System.Diagnostics.Debug.WriteLine($"[saveChangesButton_Click] DAMAGED {damagedQty} units of {equipment.getName()}");
                        // Equipment was returned but is damaged
                        // Decrease available quantity (asset impaired)
                        int currentQty = equipment.getQuantity();
                        int newQty = Math.Max(0, currentQty - damagedQty);
                        equipment.setQuantity(newQty);
                        equipment.setStatus("damaged");
                        equipment.setLastUpdated(DateTime.Now);
                        System.Diagnostics.Debug.WriteLine($"[saveChangesButton_Click] Quantity updated: {currentQty} → {newQty}, Status: damaged");
                    }

                    // CRITICAL: Persist updated Equipment to database
                    System.Diagnostics.Debug.WriteLine($"[saveChangesButton_Click] Persisting Equipment {equipment.getId()} to database");
                    equipment.updateEquipment();
                }

                System.Diagnostics.Debug.WriteLine("[saveChangesButton_Click] ✓ All inventory state transitions completed");

                // ========== PERSIST WAREHOUSE OPERATIONS ==========
                string operationsJson = buildOperationsJson(rowsWithData);
                executeWarehouseOperation(orderId, operationsJson);

                // ========== STATUS ROLLUP: Update Equipment based on Instance counts ==========
                System.Diagnostics.Debug.WriteLine("[saveChangesButton_Click] Starting instance status rollup");

                // Collect all distinct Equipment IDs affected in this transaction
                HashSet<int> affectedEquipmentIds = new HashSet<int>();
                foreach (GridRowData row in rowsWithData)
                {
                    affectedEquipmentIds.Add(row.Equipment.getId());
                }

                System.Diagnostics.Debug.WriteLine($"[saveChangesButton_Click] Rolling up {affectedEquipmentIds.Count} equipment items");

                // For each affected Equipment, count instances by status and update parent
                foreach (int equipmentId in affectedEquipmentIds)
                {
                    Equipment equipment = Equipment.seekEquipment(equipmentId);
                    if (equipment == null)
                    {
                        System.Diagnostics.Debug.WriteLine($"[saveChangesButton_Click] WARNING: Equipment {equipmentId} not found");
                        continue;
                    }

                    // Fetch all instances for this equipment
                    List<EquipmentInstance> allInstances = EquipmentInstance.getInstancesByEquipmentId(equipmentId);

                    // Count instances by status
                    int reservedCount = allInstances.Count(inst => inst.getStatus().ToLower() == "reserved");
                    int borrowedCount = allInstances.Count(inst => inst.getStatus().ToLower() == "borrowed");
                    int totalCount = allInstances.Count;
                    int availableCount = totalCount - reservedCount - borrowedCount;

                    System.Diagnostics.Debug.WriteLine($"[saveChangesButton_Click] Equipment {equipmentId} ({equipment.getName()}): Reserved={reservedCount}, Borrowed={borrowedCount}, Available={availableCount}, Total={totalCount}");

                    // Update Equipment's total quantity to match instance count (for reusable items)
                    // Instance statuses (reserved, borrowed, available, etc.) are tracked at instance level
                    equipment.setQuantity(totalCount);  // Total always equals instance count
                    equipment.setLastUpdated(DateTime.Now);

                    // Persist the updated Equipment to database
                    equipment.updateEquipment();
                    System.Diagnostics.Debug.WriteLine($"[saveChangesButton_Click] ✓ Updated Equipment {equipmentId} with instance counts");
                }

                System.Diagnostics.Debug.WriteLine("[saveChangesButton_Click] ✓ Status rollup completed");

                // ========== GOLDEN SYNCHRONIZATION: FORCE RELOAD FROM DATABASE ==========
                System.Diagnostics.Debug.WriteLine("[saveChangesButton_Click] FORCE RELOAD: Rebuilding in-memory lists from database");
                Equipment.initEquipments();
                EquipmentInstance.initEquipmentInstances();
                System.Diagnostics.Debug.WriteLine("[saveChangesButton_Click] ✓ In-memory lists rebuilt successfully");

                // ========== RELOAD & REFRESH ==========
                reloadAllInMemoryLists();
                refreshMasterGrid();
                clearDetailGrid();

                MessageBox.Show($"הזמנה #{orderId} עודכנה בהצלחה!", "הצלחה", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"שגיאה בשמירה: {ex.Message}", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Diagnostics.Debug.WriteLine($"[saveChangesButton_Click] ✗ Exception: {ex}");
                return;  // Exit immediately after error — do NOT show success message
            }
        }

        private class GridRowData
        {
            public Equipment Equipment { get; set; }
            public ReservationDetails Detail { get; set; }
            public int DeliveredQty { get; set; }
            public int ReturnedOkQty { get; set; }
            public int LostQty { get; set; }
            public int DamagedQty { get; set; }
        }

        private List<GridRowData> readDetailGridData()
        {
            List<GridRowData> result = new List<GridRowData>();

            foreach (DataGridViewRow gridRow in detailItemsGridView.Rows)
            {
                if (gridRow.IsNewRow) continue;

                string deliveredQtyStr = gridRow.Cells[3].Value?.ToString()?.Trim() ?? "";
                string returnedOkQtyStr = gridRow.Cells[4].Value?.ToString()?.Trim() ?? "";
                string lostQtyStr = gridRow.Cells[5].Value?.ToString()?.Trim() ?? "";
                string damagedQtyStr = gridRow.Cells[6].Value?.ToString()?.Trim() ?? "";

                if (string.IsNullOrEmpty(deliveredQtyStr)) deliveredQtyStr = "0";
                if (string.IsNullOrEmpty(returnedOkQtyStr)) returnedOkQtyStr = "0";
                if (string.IsNullOrEmpty(lostQtyStr)) lostQtyStr = "0";
                if (string.IsNullOrEmpty(damagedQtyStr)) damagedQtyStr = "0";

                if (!int.TryParse(deliveredQtyStr, out int deliveredQty))
                {
                    MessageBox.Show($"'כמות שנמסרה' חייבת להיות מספר שלם בשורה", "שגיאת קלט", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return new List<GridRowData>();
                }

                if (!int.TryParse(returnedOkQtyStr, out int returnedOkQty))
                {
                    MessageBox.Show($"'כמות שהוחזרה תקינה' חייבת להיות מספר שלם בשורה", "שגיאת קלט", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return new List<GridRowData>();
                }

                if (!int.TryParse(lostQtyStr, out int lostQty))
                {
                    MessageBox.Show($"'כמות שאבדה' חייבת להיות מספר שלם בשורה", "שגיאת קלט", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return new List<GridRowData>();
                }

                if (!int.TryParse(damagedQtyStr, out int damagedQty))
                {
                    MessageBox.Show($"'כמות שנהרסה' חייבת להיות מספר שלם בשורה", "שגיאת קלט", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return new List<GridRowData>();
                }

                if (deliveredQty == 0 && returnedOkQty == 0 && lostQty == 0 && damagedQty == 0)
                    continue;

                ReservationDetails detail = gridRow.Tag as ReservationDetails;
                if (detail == null) continue;

                Equipment equipment = detail.getEquipment();
                if (equipment == null) continue;

                result.Add(new GridRowData
                {
                    Equipment = equipment,
                    Detail = detail,
                    DeliveredQty = deliveredQty,
                    ReturnedOkQty = returnedOkQty,
                    LostQty = lostQty,
                    DamagedQty = damagedQty
                });
            }

            return result;
        }

        private string buildOperationsJson(List<GridRowData> rows)
        {
            System.Text.StringBuilder jsonBuilder = new System.Text.StringBuilder("[");

            for (int i = 0; i < rows.Count; i++)
            {
                GridRowData row = rows[i];

                if (i > 0) jsonBuilder.Append(",");

                jsonBuilder.Append("{");
                jsonBuilder.Append($"\"equipmentId\":{row.Equipment.getId()},");
                jsonBuilder.Append($"\"deliveredQty\":{row.DeliveredQty},");
                jsonBuilder.Append($"\"returnedOkQty\":{row.ReturnedOkQty},");
                jsonBuilder.Append($"\"lostQty\":{row.LostQty},");
                jsonBuilder.Append($"\"damagedQty\":{row.DamagedQty}");
                jsonBuilder.Append("}");
            }

            jsonBuilder.Append("]");
            return jsonBuilder.ToString();
        }

        private void executeWarehouseOperation(int reservationId, string operationsJson)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "EXECUTE sp_process_warehouse_operation @equipmentreservation_id, @operationsJson";
            cmd.Parameters.AddWithValue("@equipmentreservation_id", reservationId);
            cmd.Parameters.AddWithValue("@operationsJson", operationsJson);

            SQL_CON SC = new SQL_CON();
            SC.execute_non_query(cmd);
        }

        private void reloadAllInMemoryLists()
        {
            System.Diagnostics.Debug.WriteLine("[reloadAllInMemoryLists] Starting reload");

            EquipmentReservation.initEquipmentReservations();
            System.Diagnostics.Debug.WriteLine("[reloadAllInMemoryLists] EquipmentReservations reloaded");

            EquipmentIssue.initEquipmentIssues();
            System.Diagnostics.Debug.WriteLine("[reloadAllInMemoryLists] EquipmentIssues reloaded");

            Equipment.initEquipments();
            System.Diagnostics.Debug.WriteLine("[reloadAllInMemoryLists] Equipment reloaded");

            EquipmentInstance.initEquipmentInstances();
            System.Diagnostics.Debug.WriteLine("[reloadAllInMemoryLists] EquipmentInstances reloaded");

            System.Diagnostics.Debug.WriteLine("[reloadAllInMemoryLists] ✓ All in-memory lists reloaded");
        }

        private void refreshMasterGrid()
        {
            loadApprovedOrders();
        }

        private void clearDetailGrid()
        {
            detailItemsGridView.Rows.Clear();
            selectedOrder = null;
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            if (mainForm.previousPanel != null)
                mainForm.showPanel(mainForm.previousPanel);
            else
                mainForm.showPanel(new LoginPanel());
        }

        // ========== PUBLIC REFRESH METHOD FOR CROSS-PANEL SYNCHRONIZATION ==========
        // Call this when returning to this panel after other panels modify equipment
        public void RefreshAllData()
        {
            try
            {
                System.Diagnostics.Debug.WriteLine("[IssueReturn.RefreshAllData] Starting refresh");

                // Reload equipment and reservations from database
                reloadAllInMemoryLists();

                // Refresh the master grid with latest approved orders
                refreshMasterGrid();

                // Clear detail grid
                clearDetailGrid();

                System.Diagnostics.Debug.WriteLine("[IssueReturn.RefreshAllData] ✓ Refresh completed");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[IssueReturn.RefreshAllData] ✗ Exception: {ex}");
                MessageBox.Show($"שגיאה בטעינת נתונים: {ex.Message}", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

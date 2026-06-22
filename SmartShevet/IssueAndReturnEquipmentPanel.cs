using System;
using System.Windows.Forms;
using System.Collections.Generic;
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

            // Column 2: Requested Qty (Read Only) - CRITICAL
            DataGridViewTextBoxColumn requestedQtyCol = new DataGridViewTextBoxColumn();
            requestedQtyCol.Name = "כמות מבוקשת";
            requestedQtyCol.HeaderText = "כמות מבוקשת";
            requestedQtyCol.Width = 100;
            requestedQtyCol.ReadOnly = true;
            detailItemsGridView.Columns.Add(requestedQtyCol);

            // Column 3: Delivered Qty (Numeric Input)
            DataGridViewTextBoxColumn deliveredQtyCol = new DataGridViewTextBoxColumn();
            deliveredQtyCol.Name = "כמות שנמסרה";
            deliveredQtyCol.HeaderText = "כמות שנמסרה";
            deliveredQtyCol.Width = 100;
            detailItemsGridView.Columns.Add(deliveredQtyCol);

            // Column 4: Returned OK Qty (Numeric Input)
            DataGridViewTextBoxColumn returnedOkQtyCol = new DataGridViewTextBoxColumn();
            returnedOkQtyCol.Name = "כמות שהוחזרה תקינה";
            returnedOkQtyCol.HeaderText = "כמות שהוחזרה תקינה";
            returnedOkQtyCol.Width = 120;
            detailItemsGridView.Columns.Add(returnedOkQtyCol);

            // Column 5: Lost Qty (Numeric Input)
            DataGridViewTextBoxColumn lostQtyCol = new DataGridViewTextBoxColumn();
            lostQtyCol.Name = "כמות שאבדה";
            lostQtyCol.HeaderText = "כמות שאבדה";
            lostQtyCol.Width = 100;
            detailItemsGridView.Columns.Add(lostQtyCol);

            // Column 6: Damaged Qty (Numeric Input)
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

                    // Store reservation object in row Tag for later retrieval
                    masterOrdersGridView.Rows[rowIndex].Tag = reservation;
                }
            }
        }

        private void loadDetailItems()
        {
            detailItemsGridView.Rows.Clear();

            if (selectedOrder == null) return;

            // Find all ReservationDetails for this order
            foreach (ReservationDetails detail in Program.ReservationDetailsList)
            {
                if (detail.getReservation().getId() == selectedOrder.getId())
                {
                    Equipment equipment = detail.getEquipment();
                    if (equipment != null)
                    {
                        int rowIndex = detailItemsGridView.Rows.Add(
                            equipment.getName(),                    // שם פריט
                            detail.getQuantity().ToString(),        // כמות מבוקשת - READ ONLY
                            "0",                                    // כמות שנמסרה (delivered qty)
                            "0",                                    // כמות שהוחזרה תקינה (returned OK qty)
                            "0",                                    // כמות שאבדה (lost qty)
                            "0"                                     // כמות שנהרסה (damaged qty)
                        );

                        // Store detail in row Tag for save operation
                        detailItemsGridView.Rows[rowIndex].Tag = detail;
                    }
                }
            }
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
                // =====================================================================
                // READ GRID DATA AND BUILD JSON ARRAY
                // =====================================================================
                System.Text.StringBuilder jsonBuilder = new System.Text.StringBuilder("[");
                bool hasData = false;

                foreach (DataGridViewRow gridRow in detailItemsGridView.Rows)
                {
                    if (gridRow.IsNewRow) continue;

                    // Read quantities from grid columns
                    string deliveredQtyStr = gridRow.Cells[2].Value?.ToString() ?? "0";
                    string returnedOkQtyStr = gridRow.Cells[3].Value?.ToString() ?? "0";
                    string lostQtyStr = gridRow.Cells[4].Value?.ToString() ?? "0";
                    string damagedQtyStr = gridRow.Cells[5].Value?.ToString() ?? "0";

                    // Validate numeric input
                    if (!int.TryParse(deliveredQtyStr, out int deliveredQty) ||
                        !int.TryParse(returnedOkQtyStr, out int returnedOkQty) ||
                        !int.TryParse(lostQtyStr, out int lostQty) ||
                        !int.TryParse(damagedQtyStr, out int damagedQty))
                    {
                        MessageBox.Show("כל הכמויות חייבות להיות מספרים שלמים", "שגיאת קלט", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Skip rows with no operations
                    if (deliveredQty == 0 && returnedOkQty == 0 && lostQty == 0 && damagedQty == 0)
                        continue;

                    ReservationDetails detail = gridRow.Tag as ReservationDetails;
                    if (detail == null) continue;

                    Equipment equipment = detail.getEquipment();
                    if (equipment == null) continue;

                    // Build JSON object for this row
                    if (hasData) jsonBuilder.Append(",");
                    jsonBuilder.Append($"{{\"equipmentId\":{equipment.getId()},");
                    jsonBuilder.Append($"\"deliveredQty\":{deliveredQty},");
                    jsonBuilder.Append($"\"returnedOkQty\":{returnedOkQty},");
                    jsonBuilder.Append($"\"lostQty\":{lostQty},");
                    jsonBuilder.Append($"\"damagedQty\":{damagedQty}}}");
                    hasData = true;
                }

                jsonBuilder.Append("]");

                // Validate that at least one operation was entered (delivered qty OR return data)
                if (!hasData)
                {
                    MessageBox.Show("הזן לפחות כמות הנפקה או החזרה אחת", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Note: It's OK to have ONLY delivered qty (phase 1) or ONLY return data (phase 2)
                // The SP will handle both cases correctly

                // =====================================================================
                // CALL STORED PROCEDURE
                // =====================================================================
                string operationsJson = jsonBuilder.ToString();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "EXECUTE sp_process_warehouse_operation @equipmentreservation_id, @operationsJson";
                cmd.Parameters.AddWithValue("@equipmentreservation_id", selectedOrder.getId());
                cmd.Parameters.AddWithValue("@operationsJson", operationsJson);

                SQL_CON SC = new SQL_CON();
                SC.execute_non_query(cmd);

                // =====================================================================
                // REFRESH IN-MEMORY STATE FROM DATABASE
                // =====================================================================
                // SP updated the database, now reload affected entities from DB
                // This ensures the UI reflects the latest state
                EquipmentReservation.initEquipmentReservations();
                EquipmentIssue.initEquipmentIssues();
                Equipment.initEquipments();

                MessageBox.Show($"הזמנה #{selectedOrder.getId()} עודכנה בהצלחה!", "הצלחה", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadApprovedOrders();
                detailItemsGridView.Rows.Clear();
                selectedOrder = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"שגיאה בשמירה: {ex.Message}", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            if (mainForm.previousPanel != null)
                mainForm.showPanel(mainForm.previousPanel);
            else
                mainForm.showPanel(new LoginPanel());
        }
    }
}

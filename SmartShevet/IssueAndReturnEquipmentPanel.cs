using System;
using System.Windows.Forms;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace SmartShevet
{
    public partial class IssueAndReturnEquipmentPanel : UserControl
    {
        private EquipmentReservation selectedOrder = null;
        private Panel topPanel;
        private Button backButton;

        public IssueAndReturnEquipmentPanel()
        {
            InitializeComponent();
            this.RightToLeft = RightToLeft.Yes;

            // Create top panel with back button BEFORE other grids
            createTopPanel();

            // Reposition SplitContainer to be below TopPanel
            repositionSplitContainer();

            initializeMasterGrid();
            initializeDetailGrid();
            loadApprovedOrders();
        }

        // =====================================================================
        // Create TopPanel with Back Button
        // =====================================================================
        private void createTopPanel()
        {
            // Create top panel
            topPanel = new Panel();
            topPanel.Dock = DockStyle.Top;
            topPanel.Height = 60;
            topPanel.BackColor = System.Drawing.Color.LightGray;

            // Create back button
            backButton = new Button();
            backButton.Text = "חזרה";
            backButton.Location = new System.Drawing.Point(10, 10);
            backButton.Size = new System.Drawing.Size(100, 40);
            backButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            backButton.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
            backButton.ForeColor = System.Drawing.Color.White;
            backButton.Cursor = System.Windows.Forms.Cursors.Hand;
            backButton.Click += new System.EventHandler(this.backButton_Click);

            // Add button to top panel
            topPanel.Controls.Add(backButton);

            // Add top panel to form FIRST (before SplitContainer)
            this.Controls.Add(topPanel);
        }

        // =====================================================================
        // Reposition SplitContainer to Fill area below TopPanel
        // =====================================================================
        private void repositionSplitContainer()
        {
            // Find and reposition the split container from Designer
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is SplitContainer)
                {
                    ctrl.Dock = DockStyle.Fill;
                    // Bring it to back so TopPanel appears on top
                    ctrl.SendToBack();
                    break;
                }
            }
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

            // Column 2: Requested Qty (Read Only)
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

                        int rowIndex = detailItemsGridView.Rows.Add(
                            equipment.getName(),
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
                    result["issued_qty"] = reader[0].ToString();
                    result["returned_ok_qty"] = reader[1].ToString();
                    result["lost_qty"] = reader[2].ToString();
                    result["damaged_qty"] = reader[3].ToString();
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

                string operationsJson = buildOperationsJson(rowsWithData);
                executeWarehouseOperation(orderId, operationsJson);

                reloadAllInMemoryLists();
                refreshMasterGrid();
                clearDetailGrid();

                MessageBox.Show($"הזמנה #{orderId} עודכנה בהצלחה!", "הצלחה", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"שגיאה בשמירה: {ex.Message}", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                string deliveredQtyStr = gridRow.Cells[2].Value?.ToString()?.Trim() ?? "";
                string returnedOkQtyStr = gridRow.Cells[3].Value?.ToString()?.Trim() ?? "";
                string lostQtyStr = gridRow.Cells[4].Value?.ToString()?.Trim() ?? "";
                string damagedQtyStr = gridRow.Cells[5].Value?.ToString()?.Trim() ?? "";

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
            EquipmentReservation.initEquipmentReservations();
            EquipmentIssue.initEquipmentIssues();
            Equipment.initEquipments();
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
    }
}

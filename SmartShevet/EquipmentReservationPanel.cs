using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace SmartShevet
{
    public partial class EquipmentReservationPanel : UserControl
    {
        public EquipmentReservationPanel()
        {
            InitializeComponent();
            this.RightToLeft = RightToLeft.Yes;
            initializeCatalog();
        }

        private void initializeCatalog()
        {
            catalogGridView.DataSource = null;
            catalogGridView.Columns.Clear();

            // Column 1: Checkbox (Select)
            DataGridViewCheckBoxColumn selectCol = new DataGridViewCheckBoxColumn();
            selectCol.Name = "בחר";
            selectCol.HeaderText = "בחר";
            selectCol.Width = 50;
            catalogGridView.Columns.Add(selectCol);

            // Column 2: Equipment Name (Read-only)
            DataGridViewTextBoxColumn nameCol = new DataGridViewTextBoxColumn();
            nameCol.Name = "שם ציוד";
            nameCol.HeaderText = "שם ציוד";
            nameCol.Width = 200;
            nameCol.ReadOnly = true;
            catalogGridView.Columns.Add(nameCol);

            // Column 3: Available Quantity (Read-only)
            DataGridViewTextBoxColumn availableCol = new DataGridViewTextBoxColumn();
            availableCol.Name = "זמין במלאי";
            availableCol.HeaderText = "זמין במלאי";
            availableCol.Width = 100;
            availableCol.ReadOnly = true;
            catalogGridView.Columns.Add(availableCol);

            // Column 4: Requested Quantity (Editable)
            DataGridViewTextBoxColumn quantityCol = new DataGridViewTextBoxColumn();
            quantityCol.Name = "כמות מבוקשת";
            quantityCol.HeaderText = "כמות מבוקשת";
            quantityCol.Width = 100;
            catalogGridView.Columns.Add(quantityCol);

            // Populate with all available equipment
            foreach (Equipment eq in Program.Equipments)
            {
                if (eq.getStatus() == "available")
                {
                    int rowIndex = catalogGridView.Rows.Add(
                        false,                          // בחר (checkbox)
                        eq.getName(),                   // שם ציוד
                        eq.getQuantity().ToString(),    // זמין במלאי
                        "1"                             // כמות מבוקשת (default)
                    );
                    // Store Equipment object reference in row's Tag for later retrieval
                    catalogGridView.Rows[rowIndex].Tag = eq;
                }
            }

            // Make checkbox column first (RTL aware)
            catalogGridView.FirstDisplayedScrollingColumnIndex = 0;
        }

        private void finishOrderButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate activity date
                DateTime activityDate = activityDatePicker.Value;
                if (activityDate <= DateTime.Now)
                {
                    MessageBox.Show("תאריך הפעילות חייב להיות בעתיד", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Gather selected items from grid
                List<(int equipmentId, int quantity)> selectedItems = new List<(int, int)>();

                foreach (DataGridViewRow gridRow in catalogGridView.Rows)
                {
                    // Get Equipment object from row's Tag
                    Equipment eq = gridRow.Tag as Equipment;
                    if (eq == null) continue;

                    // Check if this row is selected (checkbox in column 0)
                    bool isSelected = false;
                    object checkboxValue = gridRow.Cells[0].Value;
                    if (checkboxValue != null && bool.TryParse(checkboxValue.ToString(), out bool isChecked))
                    {
                        isSelected = isChecked;
                    }

                    if (isSelected)
                    {
                        // Get requested quantity from column 3
                        object qtyValue = gridRow.Cells[3].Value;
                        if (!int.TryParse(qtyValue?.ToString() ?? "1", out int qty) || qty <= 0)
                        {
                            MessageBox.Show($"כמות לא תקינה לציוד: {eq.getName()}", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        selectedItems.Add((eq.getId(), qty));
                    }
                }

                // Validate that at least one item was selected
                if (selectedItems.Count == 0)
                {
                    MessageBox.Show("בחר לפחות ציוד אחד", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Get the requester (current user - for now, first SeniorScout)
                int requestedById = Program.SeniorScouts.Count > 0 ? Program.SeniorScouts[0].getId() : 1;

                // Call the atomic reservation method
                EquipmentReservation newReservation = EquipmentReservation.reserveEquipment(
                    DateTime.Now,
                    activityDate,
                    requestedById,
                    selectedItems
                );

                // Success message
                MessageBox.Show(
                    $"הזמנה #{newReservation.getId()} אושרה בהצלחה! סטטוס: {newReservation.getReservationStatus()}",
                    "הצלחה",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                // Reset catalog for new order
                activityDatePicker.Value = DateTime.Now.AddDays(1);
                initializeCatalog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "שגיאה בהזמנה", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

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
            nameCol.Width = 180;
            nameCol.ReadOnly = true;
            catalogGridView.Columns.Add(nameCol);

            // Column 3: Equipment Type (Read-only)
            DataGridViewTextBoxColumn typeCol = new DataGridViewTextBoxColumn();
            typeCol.Name = "סוג";
            typeCol.HeaderText = "סוג";
            typeCol.Width = 80;
            typeCol.ReadOnly = true;
            catalogGridView.Columns.Add(typeCol);

            // Column 4: Available Quantity/Instances (Read-only)
            DataGridViewTextBoxColumn availableCol = new DataGridViewTextBoxColumn();
            availableCol.Name = "זמין";
            availableCol.HeaderText = "זמין";
            availableCol.Width = 80;
            availableCol.ReadOnly = true;
            catalogGridView.Columns.Add(availableCol);

            // Column 5: Requested Quantity (Editable)
            DataGridViewTextBoxColumn quantityCol = new DataGridViewTextBoxColumn();
            quantityCol.Name = "כמות מבוקשת";
            quantityCol.HeaderText = "כמות מבוקשת";
            quantityCol.Width = 100;
            catalogGridView.Columns.Add(quantityCol);

            // Populate with all available equipment
            foreach (Equipment eq in Program.Equipments)
            {
                if (eq.getStatus().ToLower() == "available")
                {
                    // Calculate available quantity based on equipment type
                    int availableQty = 0;
                    string typeDisplay = eq.getEquipmentType();

                    if (eq.getEquipmentType().ToLower() == "consumable")
                    {
                        availableQty = eq.getQuantity();
                        typeDisplay = "צריכה";  // Consumable in Hebrew
                    }
                    else if (eq.getEquipmentType().ToLower() == "reusable")
                    {
                        availableQty = EquipmentInstance.getAvailableInstancesByEquipmentId(eq.getId()).Count;
                        typeDisplay = "שניתן לשימוש חוזר";  // Reusable in Hebrew
                    }

                    if (availableQty > 0 || eq.getEquipmentType().ToLower() == "reusable")
                    {
                        int rowIndex = catalogGridView.Rows.Add(
                            false,                          // בחר (checkbox)
                            eq.getName(),                   // שם ציוד
                            typeDisplay,                    // סוג (consumable/reusable)
                            availableQty.ToString(),        // זמין
                            "0"                             // כמות מבוקשת (default to 0)
                        );
                        // Store Equipment object reference in row's Tag for later retrieval
                        catalogGridView.Rows[rowIndex].Tag = eq;
                    }
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
                        // Get requested quantity from column 4 (updated: was column 3)
                        object qtyValue = gridRow.Cells[4].Value;
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

                // Get the requester (logged-in user)
                int requestedById = Program.LoggedInUserId;

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

                // Navigate back to role-based Main Menu
                if (mainForm.previousPanel != null)
                    mainForm.showPanel(mainForm.previousPanel);
                else
                    mainForm.showPanel(new LoginPanel());
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

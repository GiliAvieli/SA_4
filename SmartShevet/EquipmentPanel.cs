using System;
using System.Windows.Forms;

namespace SmartShevet
{
    public partial class EquipmentPanel : UserControl
    {
        private Equipment selectedEquipment = null;

        public EquipmentPanel()
        {
            InitializeComponent();
            this.RightToLeft = RightToLeft.Yes;
            loadEquipmentList();
        }

        private void loadEquipmentList()
        {
            equipmentListBox.Items.Clear();
            foreach (Equipment eq in Program.Equipments)
            {
                equipmentListBox.Items.Add($"ID: {eq.getId()} - {eq.getName()}");
            }
        }

        private void equipmentListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (equipmentListBox.SelectedIndex >= 0)
            {
                selectedEquipment = Program.Equipments[equipmentListBox.SelectedIndex];
                displayEquipmentDetails();
            }
        }

        private void displayEquipmentDetails()
        {
            if (selectedEquipment != null)
            {
                idTextBox.Text = selectedEquipment.getId().ToString();
                idTextBox.ReadOnly = true;
                nameTextBox.Text = selectedEquipment.getName();
                categoryTextBox.Text = selectedEquipment.getCategory();
                descriptionTextBox.Text = selectedEquipment.getDescription();
                equipmentTypeTextBox.Text = selectedEquipment.getEquipmentType();
                containerTypeTextBox.Text = selectedEquipment.getContainerType();
                quantityTextBox.Text = selectedEquipment.getQuantity().ToString();
                minimumQuantityTextBox.Text = selectedEquipment.getMinimumQuantity()?.ToString() ?? "";
                statusTextBox.Text = selectedEquipment.getStatus();
                lastUpdatedTextBox.Text = selectedEquipment.getLastUpdated().ToString();
                lastUpdatedTextBox.ReadOnly = true;
                notesTextBox.Text = selectedEquipment.getNotes();
            }
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(nameTextBox.Text))
                {
                    MessageBox.Show("שם הציוד חובה", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int newId = Equipment.getNextEquipmentId();
                string name = nameTextBox.Text;
                string category = categoryTextBox.Text;
                string description = descriptionTextBox.Text;
                string equipmentType = equipmentTypeTextBox.Text;
                string containerType = containerTypeTextBox.Text;
                int quantity = int.Parse(quantityTextBox.Text);
                int? minimumQuantity = string.IsNullOrEmpty(minimumQuantityTextBox.Text)
                    ? (int?)null
                    : (int?)int.Parse(minimumQuantityTextBox.Text);
                string status = statusTextBox.Text;
                string notes = notesTextBox.Text;

                Equipment newEquipment = new Equipment(
                    newId, name, category, description, equipmentType, containerType,
                    quantity, minimumQuantity, status, DateTime.Now, notes, true
                );

                loadEquipmentList();
                clearFields();
                MessageBox.Show("ציוד נוצר בהצלחה", "הצלחה", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"שגיאה: {ex.Message}", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void confirmConditionButton_Click(object sender, EventArgs e)
        {
            if (selectedEquipment == null)
            {
                MessageBox.Show("בחר ציוד לאישור מצב", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                selectedEquipment.confirmCondition();
                loadEquipmentList();
                clearFields();
                MessageBox.Show("מצב הציוד אושר - זמין שוב", "הצלחה", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"לא ניתן לאשר מצב: {ex.Message}", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void reportDamageButton_Click(object sender, EventArgs e)
        {
            if (selectedEquipment == null)
            {
                MessageBox.Show("בחר ציוד לדיווח נזק", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                selectedEquipment.reportDamage();
                loadEquipmentList();
                clearFields();
                MessageBox.Show("נזק דווח - ציוד בהמתנה לתיקון", "הצלחה", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"לא ניתן לדווח על נזק: {ex.Message}", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void submitForRepairButton_Click(object sender, EventArgs e)
        {
            if (selectedEquipment == null)
            {
                MessageBox.Show("בחר ציוד להגשה לתיקון", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                selectedEquipment.submitForRepair();
                loadEquipmentList();
                clearFields();
                MessageBox.Show("ציוד הוגש לתיקון", "הצלחה", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"לא ניתן להגיש לתיקון: {ex.Message}", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void completionConfirmedButton_Click(object sender, EventArgs e)
        {
            if (selectedEquipment == null)
            {
                MessageBox.Show("בחר ציוד לאישור השלמה", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                selectedEquipment.completionConfirmed();
                loadEquipmentList();
                clearFields();
                MessageBox.Show("תיקון הושלם - ציוד זמין שוב", "הצלחה", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"לא ניתן לאשר השלמה: {ex.Message}", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void reportMissingButton_Click(object sender, EventArgs e)
        {
            if (selectedEquipment == null)
            {
                MessageBox.Show("בחר ציוד לדיווח אובדן", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                selectedEquipment.reportMissing();
                loadEquipmentList();
                clearFields();
                MessageBox.Show("אובדן דווח - תחקור בעמדי", "הצלחה", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"לא ניתן לדווח על אובדן: {ex.Message}", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void itemFoundButton_Click(object sender, EventArgs e)
        {
            if (selectedEquipment == null)
            {
                MessageBox.Show("בחר ציוד למציאה", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                selectedEquipment.itemFound();
                loadEquipmentList();
                clearFields();
                MessageBox.Show("ציוד נמצא - חזר לאינוונטר", "הצלחה", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"לא ניתן לאשר מציאה: {ex.Message}", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (selectedEquipment == null)
            {
                MessageBox.Show("בחר ציוד למחיקה", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"האם אתה בטוח שברצונך למחוק את הציוד '{selectedEquipment.getName()}'?",
                "אישור מחיקה",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                try
                {
                    selectedEquipment.deleteEquipment();
                    loadEquipmentList();
                    clearFields();
                    MessageBox.Show("ציוד נמחק בהצלחה", "הצלחה", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"שגיאה: {ex.Message}", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void clearFields()
        {
            idTextBox.Clear();
            nameTextBox.Clear();
            categoryTextBox.Clear();
            descriptionTextBox.Clear();
            equipmentTypeTextBox.Clear();
            containerTypeTextBox.Clear();
            quantityTextBox.Clear();
            minimumQuantityTextBox.Clear();
            statusTextBox.Clear();
            lastUpdatedTextBox.Clear();
            notesTextBox.Clear();
            selectedEquipment = null;
            equipmentListBox.SelectedIndex = -1;
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

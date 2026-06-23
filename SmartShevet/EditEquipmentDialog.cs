using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SmartShevet
{
    public partial class EditEquipmentDialog : Form
    {
        private Equipment equipment;
        private int originalQuantity;

        public EditEquipmentDialog(Equipment eq)
        {
            InitializeComponent();
            this.RightToLeft = RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.equipment = eq;
            this.originalQuantity = eq.getQuantity();
            loadEquipmentData();
        }

        private void loadEquipmentData()
        {
            nameTextBox.Text = equipment.getName();
            nameTextBox.ReadOnly = true;

            typeTextBox.Text = equipment.getEquipmentType().ToLower() == "consumable" ? "צריכה" : "שניתן לשימוש חוזר";
            typeTextBox.ReadOnly = true;

            reasonComboBox.Items.Add("צריכה");
            reasonComboBox.Items.Add("הזמנה");
            reasonComboBox.Items.Add("בתיקון");
            reasonComboBox.Items.Add("אבדה");
            reasonComboBox.Items.Add("אחר");
            reasonComboBox.SelectedIndex = 0;

            if (equipment.getEquipmentType().ToLower() == "consumable")
            {
                quantityLabel.Text = "כמות נוכחית:";
                currentQtyLabel.Text = equipment.getQuantity().ToString();
                quantitySpinner.Minimum = 0;
                quantitySpinner.Maximum = 10000;
                quantitySpinner.Value = equipment.getQuantity();
            }
            else
            {
                int availCount = EquipmentInstance.getAvailableInstancesByEquipmentId(equipment.getId()).Count;
                int totalCount = EquipmentInstance.getInstancesByEquipmentId(equipment.getId()).Count;
                currentQtyLabel.Text = $"{availCount}/{totalCount}";
                quantitySpinner.Enabled = false;
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (equipment.getEquipmentType().ToLower() == "consumable")
                {
                    int newQty = (int)quantitySpinner.Value;

                    // Only update if quantity actually changed
                    if (newQty != originalQuantity)
                    {
                        // Update the Equipment object in memory
                        equipment.setQuantity(newQty);

                        // Persist to database
                        equipment.updateEquipment();

                        System.Diagnostics.Debug.WriteLine($"[EditEquipmentDialog] Updated {equipment.getName()}: {originalQuantity} -> {newQty}");
                    }
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"שגיאה בעדכון ציוד: {ex.Message}", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Diagnostics.Debug.WriteLine($"[EditEquipmentDialog] Save error: {ex}");
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}

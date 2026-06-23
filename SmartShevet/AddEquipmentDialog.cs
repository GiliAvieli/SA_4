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
    public partial class AddEquipmentDialog : Form
    {
        public AddEquipmentDialog()
        {
            InitializeComponent();
            this.RightToLeft = RightToLeft.Yes;
            this.RightToLeftLayout = true;
            initializeForm();
        }

        private void initializeForm()
        {
            typeComboBox.Items.Add("צריכה");
            typeComboBox.Items.Add("שניתן לשימוש חוזר");
            typeComboBox.SelectedIndex = 0;

            categoryComboBox.Items.Add("אוהלים");
            categoryComboBox.Items.Add("חבלים");
            categoryComboBox.Items.Add("ציוד כתיבה");
            categoryComboBox.Items.Add("כלים");
            categoryComboBox.Items.Add("אחר");
            categoryComboBox.SelectedIndex = 0;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nameTextBox.Text))
            {
                MessageBox.Show("אנא הזן שם ציוד", "שדה נדרש", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string name = nameTextBox.Text.Trim();
            string category = categoryComboBox.SelectedItem.ToString();
            string type = typeComboBox.SelectedIndex == 0 ? "consumable" : "reusable";
            int quantityToAdd = type == "consumable" ? (int)quantitySpinner.Value : 999;

            try
            {
                // Check if equipment with this NAME already exists - STRICT: Name only, any type
                foreach (Equipment eq in Program.Equipments)
                {
                    if (eq.getName().ToLower() == name.ToLower())
                    {
                        MessageBox.Show("ציוד זה כבר קיים במערכת. לעדכון כמויות, אנא השתמש בכפתור העריכה.", "ציוד קיים", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                // Equipment doesn't exist - proceed with INSERT only (no updates)
                int newId = Equipment.getNextEquipmentId();
                Equipment newEquipment = new Equipment(newId, name, category, "", type, "", quantityToAdd, null, "available", DateTime.Now, "", true);

                // If reusable, add initial instances
                if (type == "reusable" && (int)instanceCountSpinner.Value > 0)
                {
                    for (int i = 1; i <= (int)instanceCountSpinner.Value; i++)
                    {
                        string serial = $"{name.Substring(0, Math.Min(4, name.Length))}-{DateTime.Now.Year % 100:D2}-{i:D3}";
                        int instanceId = EquipmentInstance.getNextEquipmentInstanceId();
                        EquipmentInstance instance = new EquipmentInstance(instanceId, newEquipment.getId(), serial, "available", DateTime.Now, DateTime.Now, null, true);
                    }
                }

                // Single success message - OUTSIDE any loops
                MessageBox.Show("ציוד נוסף בהצלחה", "הצלחה", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"שגיאה בהוספת ציוד: {ex.Message}", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void typeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isReusable = typeComboBox.SelectedIndex == 1;
            quantityLabel.Visible = !isReusable;
            quantitySpinner.Visible = !isReusable;
            instanceCountLabel.Visible = isReusable;
            instanceCountSpinner.Visible = isReusable;
        }
    }
}

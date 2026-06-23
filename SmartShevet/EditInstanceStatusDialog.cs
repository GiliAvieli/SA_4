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
    public partial class EditInstanceStatusDialog : Form
    {
        private EquipmentInstance instance;

        public EditInstanceStatusDialog(EquipmentInstance inst)
        {
            InitializeComponent();
            this.RightToLeft = RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.instance = inst;
            loadInstanceData();
        }

        private void loadInstanceData()
        {
            serialNumberTextBox.Text = instance.getSerialNumber();
            serialNumberTextBox.ReadOnly = true;

            Equipment eq = Equipment.seekEquipment(instance.getEquipmentId());
            if (eq != null)
            {
                equipmentNameTextBox.Text = eq.getName();
                equipmentNameTextBox.ReadOnly = true;
            }

            statusComboBox.Items.Add("פנוי");
            statusComboBox.Items.Add("משוריין");
            statusComboBox.Items.Add("הושאל");
            statusComboBox.Items.Add("בתיקון");
            statusComboBox.Items.Add("אבוד");
            statusComboBox.Items.Add("תקול");

            string currentStatus = instance.getStatus();
            string displayStatus = currentStatus switch
            {
                "available" => "פנוי",
                "reserved" => "משוריין",
                "issued" => "הושאל",
                "repair" => "בתיקון",
                "lost" => "אבוד",
                "damaged" => "תקול",
                _ => currentStatus
            };

            statusComboBox.SelectedItem = displayStatus;

            datePickerLabel.Text = instance.getDateAdded().ToShortDateString();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                string displayStatus = statusComboBox.SelectedItem.ToString();
                string dbStatus = displayStatus switch
                {
                    "פנוי" => "available",
                    "משוריין" => "reserved",
                    "הושאל" => "issued",
                    "בתיקון" => "repair",
                    "אבוד" => "lost",
                    "תקול" => "damaged",
                    _ => "available"
                };

                instance.setStatus(dbStatus);
                instance.updateEquipmentInstance();

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"שגיאה בעדכון סטטוס: {ex.Message}", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}

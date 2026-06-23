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
    public partial class AddInstanceDialog : Form
    {
        private Equipment equipment;

        public AddInstanceDialog(Equipment eq)
        {
            InitializeComponent();
            this.RightToLeft = RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.equipment = eq;
            equipmentNameLabel.Text = eq.getName();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(serialNumberTextBox.Text))
            {
                MessageBox.Show("אנא הזן מס''ד", "שדה נדרש", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string serialNumber = serialNumberTextBox.Text.Trim();
                int instanceId = EquipmentInstance.getNextEquipmentInstanceId();
                EquipmentInstance instance = new EquipmentInstance(instanceId, equipment.getId(), serialNumber, "available", DateTime.Now, DateTime.Now, null, true);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"שגיאה בהוספת יחידה: {ex.Message}", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}

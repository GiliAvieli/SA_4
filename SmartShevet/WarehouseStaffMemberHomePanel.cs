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
    public partial class WarehouseStaffMemberHomePanel : UserControl
    {
        public WarehouseStaffMemberHomePanel()
        {
            InitializeComponent();
            this.RightToLeft = RightToLeft.Yes;
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            mainForm.showPanel(new LoginPanel());
        }

        private void manageEquipmentButton_Click(object sender, EventArgs e)
        {
            mainForm.showPanel(new EquipmentPanel());
        }

        private void issueAndReturnButton_Click(object sender, EventArgs e)
        {
            mainForm.showPanel(new IssueAndReturnEquipmentPanel());
        }

        private void manageStatusButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("TODO: ניהול סטטוס ציוד", "כניסה לתכונה", MessageBoxButtons.OK);
        }
    }
}

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
    public partial class SeniorCoordinatorHomePanel : UserControl
    {
        public SeniorCoordinatorHomePanel()
        {
            InitializeComponent();
            this.RightToLeft = RightToLeft.Yes;
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            mainForm.showPanel(new LoginPanel());
        }

        private void approveReservationsButton_Click(object sender, EventArgs e)
        {
            mainForm.showPanel(new EquipmentReservationPanel());
        }

        private void viewEquipmentStatusButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("TODO: ניהול סטטוס ציוד", "כניסה לתכונה", MessageBoxButtons.OK);
        }

        private void manageReservationsButton_Click(object sender, EventArgs e)
        {
            mainForm.showPanel(new EquipmentReservationPanel());
        }

        private void inventoryForecastButton_Click(object sender, EventArgs e)
        {
            mainForm.showPanel(new AnnualInventoryForecastReportPanel());
        }
    }
}

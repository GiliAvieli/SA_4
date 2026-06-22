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
    public partial class LoginPanel : UserControl
    {
        public LoginPanel()
        {
            InitializeComponent();
            this.RightToLeft = RightToLeft.Yes;
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string email = emailTextBox.Text.Trim();
            string password = passwordTextBox.Text;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("אנא הזן דוא\"ל וסיסמה", "שגיאה", MessageBoxButtons.OK);
                return;
            }

            // בדיקה רשימת WarehouseStaffMembers
            foreach (WarehouseStaffMember wsm in Program.WarehouseStaffMembers)
            {
                if (wsm.getEmail() == email && wsm.getPassword() == password)
                {
                    mainForm.showPanel(new WarehouseStaffMemberHomePanel());
                    return;
                }
            }

            // בדיקה רשימת SeniorCoordinators
            foreach (SeniorCoordinator sc in Program.SeniorCoordinators)
            {
                if (sc.getEmail() == email && sc.getPassword() == password)
                {
                    mainForm.showPanel(new SeniorCoordinatorHomePanel());
                    return;
                }
            }

            // בדיקה רשימת SeniorScouts (בסיס בלבד, לא subclasses)
            foreach (SeniorScout ss in Program.SeniorScouts)
            {
                if (ss.getEmail() == email && ss.getPassword() == password)
                {
                    // בדוק שהוא לא subclass
                    if (!(ss is WarehouseStaffMember) && !(ss is SeniorCoordinator))
                    {
                        mainForm.showPanel(new SeniorScoutHomePanel());
                        return;
                    }
                }
            }

            // אם לא נמצא — הצג שגיאה
            MessageBox.Show("דוא\"ל או סיסמה שגויים", "שגיאה", MessageBoxButtons.OK);
        }

        private void devShortcutButton_Click(object sender, EventArgs e)
        {
            // כניסת מפתח — עוקף אימות ופותח WarehouseStaffMemberHomePanel
            mainForm.showPanel(new WarehouseStaffMemberHomePanel());
        }
    }
}

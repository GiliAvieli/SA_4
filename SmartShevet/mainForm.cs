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
    /// <summary>
    /// הטופס הראשי — חלון יחיד שמחליף תוכן בתוכו.
    /// כל המסכים במערכת הם UserControl שנטענים לתוך panelMain.
    /// </summary>
    public partial class mainForm : Form
    {
        // הפניה סטטית לטופס הראשי — כדי שכל מסך יוכל לנווט
        private static mainForm instance;

        // Navigation history: store the previous panel so "Back" returns to the correct role menu
        public static UserControl previousPanel { get; set; } = null;

        public mainForm()
        {
            InitializeComponent();
            instance = this;
            this.RightToLeft = RightToLeft.Yes;
            this.RightToLeftLayout = true;
            // הצגת מסך הכניסה בהפעלה
            showPanel(new LoginPanel());
        }

        /// <summary>
        /// החלפת המסך הנוכחי במסך חדש.
        /// זו הדרך היחידה לנווט בין מסכים במערכת.
        ///
        /// שימוש: mainForm.showPanel(new MyPanel());
        /// </summary>
        public static void showPanel(UserControl panel)
        {
            // Save current panel as previous before clearing
            if (instance.panelMain.Controls.Count > 0)
            {
                previousPanel = (UserControl)instance.panelMain.Controls[0];
            }

            // ניקוי המסך הקודם
            instance.panelMain.Controls.Clear();
            // הוספת המסך החדש
            panel.Dock = DockStyle.Fill;
            instance.panelMain.Controls.Add(panel);
        }
    }
}

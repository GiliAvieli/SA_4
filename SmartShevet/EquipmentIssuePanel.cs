using System;
using System.Windows.Forms;

namespace SmartShevet
{
    public partial class EquipmentIssuePanel : UserControl
    {
        private EquipmentIssue selectedIssue = null;

        public EquipmentIssuePanel()
        {
            InitializeComponent();
            this.RightToLeft = RightToLeft.Yes;
            loadIssueList();
        }

        private void loadIssueList()
        {
            issueListBox.Items.Clear();
            foreach (EquipmentIssue ei in Program.EquipmentIssues)
            {
                issueListBox.Items.Add($"ID: {ei.getId()} - {ei.getStatus()}");
            }
        }

        private void issueListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (issueListBox.SelectedIndex >= 0)
            {
                selectedIssue = Program.EquipmentIssues[issueListBox.SelectedIndex];
                displayIssueDetails();
            }
        }

        private void displayIssueDetails()
        {
            if (selectedIssue != null)
            {
                idTextBox.Text = selectedIssue.getId().ToString();
                idTextBox.ReadOnly = true;
                issueDateTextBox.Text = selectedIssue.getIssueDate().ToString();
                issueDateTextBox.ReadOnly = true;
                returnDateTextBox.Text = selectedIssue.getReturnDate()?.ToString() ?? "";
                equipmentTextBox.Text = selectedIssue.getEquipment()?.getName() ?? "Unknown";
                equipmentTextBox.ReadOnly = true;
                issuedToTextBox.Text = selectedIssue.getIssuedTo()?.getName() ?? "Unknown";
                issuedToTextBox.ReadOnly = true;
                reservationTextBox.Text = selectedIssue.getReservation()?.getId().ToString() ?? "";
                reservationTextBox.ReadOnly = true;
                statusTextBox.Text = selectedIssue.getStatus();
                conditionTextBox.Text = selectedIssue.getCondition();
            }
        }

        private void issueButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(equipmentTextBox.Text) || equipmentTextBox.Text == "Unknown")
                {
                    MessageBox.Show("בחר ציוד להנפקה", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int newId = EquipmentIssue.getNextEquipmentIssueId();
                DateTime issueDate = DateTime.Now;
                int equipmentId = 1; // Would need a picker in real app
                int issuedToId = Program.SeniorScouts.Count > 0 ? Program.SeniorScouts[0].getId() : 1;
                int reservationId = string.IsNullOrEmpty(reservationTextBox.Text) ? 0 : int.Parse(reservationTextBox.Text);
                string status = statusTextBox.Text;
                string condition = conditionTextBox.Text;

                EquipmentIssue newIssue = new EquipmentIssue(
                    newId, issueDate, null, equipmentId, issuedToId, reservationId, status, condition, true
                );

                loadIssueList();
                clearFields();
                MessageBox.Show("הנפקה נוצרה בהצלחה", "הצלחה", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"שגיאה: {ex.Message}", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void returnButton_Click(object sender, EventArgs e)
        {
            if (selectedIssue == null)
            {
                MessageBox.Show("בחר הנפקה להחזרה", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                selectedIssue.setReturnDate(DateTime.Now);
                selectedIssue.setStatus("returned");
                selectedIssue.setCondition(conditionTextBox.Text);

                selectedIssue.updateEquipmentIssue();
                loadIssueList();
                MessageBox.Show("הציוד הוחזר בהצלחה", "הצלחה", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"שגיאה: {ex.Message}", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void returnFullButton_Click(object sender, EventArgs e)
        {
            if (selectedIssue == null)
            {
                MessageBox.Show("בחר הנפקה לקבלה מלאה", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                selectedIssue.returnEquipment(allItemsReturned: true);
                loadIssueList();
                clearFields();
                MessageBox.Show("קבלה מלאה רשומה בהצלחה", "הצלחה", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"לא ניתן לרשום קבלה: {ex.Message}", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void returnPartialButton_Click(object sender, EventArgs e)
        {
            if (selectedIssue == null)
            {
                MessageBox.Show("בחר הנפקה לקבלה חלקית", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                selectedIssue.returnEquipment(allItemsReturned: false);
                loadIssueList();
                clearFields();
                MessageBox.Show("קבלה חלקית רשומה בהצלחה", "הצלחה", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"לא ניתן לרשום קבלה חלקית: {ex.Message}", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void reportMissingButton_Click(object sender, EventArgs e)
        {
            if (selectedIssue == null)
            {
                MessageBox.Show("בחר הנפקה לדיווח אובדן", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                selectedIssue.reportMissing();
                loadIssueList();
                clearFields();
                MessageBox.Show("אובדן דווח בהצלחה", "הצלחה", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"לא ניתן לדווח על אובדן: {ex.Message}", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void finalizeButton_Click(object sender, EventArgs e)
        {
            if (selectedIssue == null)
            {
                MessageBox.Show("בחר הנפקה לסיום", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                selectedIssue.finalizeReturn();
                loadIssueList();
                clearFields();
                MessageBox.Show("הנפקה סגורה בהצלחה", "הצלחה", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"לא ניתן לסיים הנפקה: {ex.Message}", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void itemFoundButton_Click(object sender, EventArgs e)
        {
            if (selectedIssue == null)
            {
                MessageBox.Show("בחר הנפקה למציאה", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                selectedIssue.itemLocated();
                loadIssueList();
                clearFields();
                MessageBox.Show("פריט נמצא בהצלחה", "הצלחה", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"לא ניתן לאשר מציאה: {ex.Message}", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (selectedIssue == null)
            {
                MessageBox.Show("בחר הנפקה למחיקה", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"האם אתה בטוח שברצונך למחוק את ההנפקה '{selectedIssue.getId()}'?",
                "אישור מחיקה",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                try
                {
                    selectedIssue.deleteEquipmentIssue();
                    loadIssueList();
                    clearFields();
                    MessageBox.Show("הנפקה נמחקה בהצלחה", "הצלחה", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            issueDateTextBox.Clear();
            returnDateTextBox.Clear();
            equipmentTextBox.Clear();
            issuedToTextBox.Clear();
            reservationTextBox.Clear();
            statusTextBox.Clear();
            conditionTextBox.Clear();
            selectedIssue = null;
            issueListBox.SelectedIndex = -1;
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            mainForm.showPanel(new WarehouseStaffMemberHomePanel());
        }
    }
}

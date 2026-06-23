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
    public partial class EquipmentManagementPanel : UserControl
    {
        private Equipment selectedEquipment = null;

        public EquipmentManagementPanel()
        {
            InitializeComponent();
            this.RightToLeft = RightToLeft.Yes;
            initializeGrids();
            loadEquipmentData();
        }

        private void initializeGrids()
        {
            // BULLETPROOF: Master grid configuration for reliable row selection
            masterGrid.ColumnCount = 3;
            masterGrid.Columns[0].Name = "שם";
            masterGrid.Columns[1].Name = "סוג";
            masterGrid.Columns[2].Name = "זמין";

            masterGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            masterGrid.AllowUserToAddRows = false;
            masterGrid.AllowUserToDeleteRows = false;
            masterGrid.AllowUserToResizeRows = false;
            masterGrid.BorderStyle = BorderStyle.Fixed3D;
            masterGrid.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            masterGrid.GridColor = Color.LightGray;

            // CRITICAL: FullRowSelect mode for reliable selection
            masterGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            masterGrid.MultiSelect = false;
            masterGrid.RowHeadersVisible = false;
            masterGrid.ReadOnly = true;
            masterGrid.EnableHeadersVisualStyles = false;

            // CRITICAL: Wire up SelectionChanged AFTER all properties set
            masterGrid.SelectionChanged += masterGrid_SelectionChanged;

            // Detail grid - same robust configuration
            detailGrid.ColumnCount = 3;
            detailGrid.Columns[0].Name = "מס''ד";
            detailGrid.Columns[1].Name = "סטטוס";
            detailGrid.Columns[2].Name = "הוכנס בתאריך";

            detailGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            detailGrid.AllowUserToAddRows = false;
            detailGrid.AllowUserToDeleteRows = false;
            detailGrid.AllowUserToResizeRows = false;
            detailGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            detailGrid.MultiSelect = false;
            detailGrid.RowHeadersVisible = false;
            detailGrid.ReadOnly = true;
            detailGrid.EnableHeadersVisualStyles = false;
        }

        private void loadEquipmentData()
        {
            masterGrid.Rows.Clear();
            foreach (Equipment eq in Program.Equipments)
            {
                string typeDisplay = eq.getEquipmentType().ToLower() == "consumable" ? "צריכה" : "שניתן לשימוש חוזר";
                string availDisplay = "";
                if (eq.getEquipmentType().ToLower() == "consumable")
                {
                    availDisplay = eq.getQuantity().ToString();
                }
                else
                {
                    int availCount = EquipmentInstance.getAvailableInstancesByEquipmentId(eq.getId()).Count;
                    int totalCount = EquipmentInstance.getInstancesByEquipmentId(eq.getId()).Count;
                    availDisplay = $"{availCount}/{totalCount}";
                }

                // Only 3 columns: Name, Type, Available (removed Status and Actions)
                masterGrid.Rows.Add(eq.getName(), typeDisplay, availDisplay);
                masterGrid.Rows[masterGrid.Rows.Count - 1].Tag = eq;
            }
        }

        private void loadInstanceData()
        {
            detailGrid.Rows.Clear();
            if (selectedEquipment == null || selectedEquipment.getEquipmentType().ToLower() == "consumable")
            {
                detailPanel.Visible = false;
                return;
            }

            detailPanel.Visible = true;
            List<EquipmentInstance> instances = EquipmentInstance.getInstancesByEquipmentId(selectedEquipment.getId());
            foreach (EquipmentInstance inst in instances)
            {
                string statusDisplay = getStatusDisplay(inst.getStatus());
                detailGrid.Rows.Add(inst.getSerialNumber(), statusDisplay, inst.getDateAdded().ToShortDateString());
                detailGrid.Rows[detailGrid.Rows.Count - 1].Tag = inst;
            }
        }

        private string getStatusDisplay(string status)
        {
            return status switch
            {
                "available" => "פנוי",
                "reserved" => "משוריין",
                "issued" => "הושאל",
                "repair" => "בתיקון",
                "lost" => "אבוד",
                "damaged" => "תקול",
                _ => status
            };
        }

        private void masterGrid_SelectionChanged(object sender, EventArgs e)
        {
            if (masterGrid.SelectedRows.Count > 0)
            {
                selectedEquipment = (Equipment)masterGrid.SelectedRows[0].Tag;
                loadInstanceData();
            }
            else
            {
                selectedEquipment = null;
                detailPanel.Visible = false;
            }
        }

        private void addEquipmentButton_Click(object sender, EventArgs e)
        {
            AddEquipmentDialog dialog = new AddEquipmentDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                loadEquipmentData();
            }
        }

        private void editEquipmentButton_Click(object sender, EventArgs e)
        {
            try
            {
                // BULLETPROOF: Multiple selection detection methods for redundancy
                int selectedRowCount = masterGrid.SelectedRows.Count;

                // Debug output to console
                System.Diagnostics.Debug.WriteLine($"[EditEquipmentButton] SelectedRows.Count: {selectedRowCount}");
                System.Diagnostics.Debug.WriteLine($"[EditEquipmentButton] selectedEquipment is null: {selectedEquipment == null}");

                // Method 1: Check field set by SelectionChanged event
                if (selectedEquipment == null)
                {
                    // Method 2: Fallback - check SelectedRows directly
                    if (masterGrid.SelectedRows.Count > 0 && masterGrid.SelectedRows[0].Tag != null)
                    {
                        try
                        {
                            selectedEquipment = (Equipment)masterGrid.SelectedRows[0].Tag;
                            System.Diagnostics.Debug.WriteLine("[EditEquipmentButton] Recovered selectedEquipment from SelectedRows");
                        }
                        catch (Exception castEx)
                        {
                            throw new InvalidOperationException($"Failed to cast Tag to Equipment: {castEx.Message}");
                        }
                    }
                    else
                    {
                        MessageBox.Show("אנא בחר ציוד לעריכה בעזרת לחיצה על שורה בטבלה", "בחירה נדרשת", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

                // BULLETPROOF: Validate equipment object before opening form
                if (selectedEquipment == null)
                {
                    MessageBox.Show("שגיאה: אובייקט הציוד אינו תקין", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (selectedEquipment.getId() <= 0)
                {
                    MessageBox.Show("שגיאה: מזהה ציוד לא תקין", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Open the edit form with error handling
                EquipmentEditForm editForm = null;
                try
                {
                    editForm = new EquipmentEditForm(selectedEquipment);
                }
                catch (Exception formCreationEx)
                {
                    throw new Exception($"Failed to create EquipmentEditForm: {formCreationEx.Message}", formCreationEx);
                }

                if (editForm != null && editForm.ShowDialog() == DialogResult.OK)
                {
                    loadEquipmentData();
                    loadInstanceData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"שגיאה בעריכת ציוד:\n\n{ex.Message}\n\nStack:\n{ex.StackTrace}", "שגיאה קריטית", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Diagnostics.Debug.WriteLine($"[EditEquipmentButton] Exception: {ex}");
            }
        }

        private void addInstanceButton_Click(object sender, EventArgs e)
        {
            if (selectedEquipment == null || selectedEquipment.getEquipmentType().ToLower() == "consumable")
            {
                MessageBox.Show("אנא בחר ציוד שניתן לשימוש חוזר לתוספת יחידה", "בחירה שגויה", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            AddInstanceDialog dialog = new AddInstanceDialog(selectedEquipment);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                loadInstanceData();
                loadEquipmentData();
            }
        }

        private void editInstanceStatusButton_Click(object sender, EventArgs e)
        {
            if (detailGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("אנא בחר יחידה לעריכת סטטוס", "בחירה נדרשת", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            EquipmentInstance instance = (EquipmentInstance)detailGrid.SelectedRows[0].Tag;
            EditInstanceStatusDialog dialog = new EditInstanceStatusDialog(instance);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                loadInstanceData();
                loadEquipmentData();
            }
        }

        // ========== PUBLIC REFRESH METHOD FOR CROSS-PANEL SYNCHRONIZATION ==========
        // Call this from other panels (like IssueAndReturnEquipmentPanel) after they modify equipment
        public void RefreshAllData()
        {
            try
            {
                System.Diagnostics.Debug.WriteLine("[RefreshAllData] Starting full refresh of inventory data");

                // STEP 1: Reload all data from database into in-memory lists
                System.Diagnostics.Debug.WriteLine("[RefreshAllData] Reloading Equipment from database");
                Equipment.initEquipments();

                System.Diagnostics.Debug.WriteLine("[RefreshAllData] Reloading EquipmentInstances from database");
                EquipmentInstance.initEquipmentInstances();

                // STEP 2: Clear and rebuild all UI grids
                System.Diagnostics.Debug.WriteLine("[RefreshAllData] Reloading equipment grid");
                loadEquipmentData();

                System.Diagnostics.Debug.WriteLine("[RefreshAllData] Reloading instance data for selected equipment");
                if (selectedEquipment != null)
                {
                    loadInstanceData();
                }

                System.Diagnostics.Debug.WriteLine("[RefreshAllData] ✓ Full refresh completed successfully");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[RefreshAllData] ✗ Exception: {ex}");
                MessageBox.Show($"שגיאה בטעינת נתונים: {ex.Message}", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void deleteInstanceButton_Click(object sender, EventArgs e)
        {
            if (detailGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("אנא בחר יחידה למחיקה", "בחירה נדרשת", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            EquipmentInstance instance = (EquipmentInstance)detailGrid.SelectedRows[0].Tag;
            if (instance.getStatus() != "available")
            {
                MessageBox.Show("לא ניתן למחוק יחידה שאינה בסטטוס 'פנוי'", "לא מותר", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("האם אתה בטוח שברצונך למחוק יחידה זו?", "אישור מחיקה", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                instance.deleteEquipmentInstance();
                Program.EquipmentInstances.Remove(instance);
                loadInstanceData();
                loadEquipmentData();
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            if (mainForm.previousPanel != null && mainForm.previousPanel != this)
            {
                mainForm.showPanel(mainForm.previousPanel);
            }
            else
            {
                mainForm.showPanel(new WarehouseStaffMemberHomePanel());
            }
        }
    }
}

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
    public partial class EquipmentEditForm : Form
    {
        private Equipment equipment;
        private bool isReusable;
        private int originalQuantity;

        public EquipmentEditForm(Equipment eq)
        {
            try
            {
                System.Diagnostics.Debug.WriteLine("[EquipmentEditForm.Constructor] Starting");

                if (eq == null)
                {
                    throw new ArgumentNullException(nameof(eq), "Equipment object cannot be null");
                }

                InitializeComponent();
                System.Diagnostics.Debug.WriteLine("[EquipmentEditForm.Constructor] InitializeComponent completed");

                this.RightToLeft = RightToLeft.Yes;
                this.RightToLeftLayout = true;
                this.equipment = eq;
                this.originalQuantity = eq.getQuantity();
                this.isReusable = eq.getEquipmentType().ToLower() == "reusable";

                System.Diagnostics.Debug.WriteLine($"[EquipmentEditForm.Constructor] Equipment ID: {eq.getId()}, Name: {eq.getName()}, IsReusable: {isReusable}");

                // Load equipment data into form fields
                loadEquipmentData();
                System.Diagnostics.Debug.WriteLine("[EquipmentEditForm.Constructor] loadEquipmentData completed");

                // Load instances for reusable items
                if (isReusable)
                {
                    loadInstanceGrid();
                    System.Diagnostics.Debug.WriteLine("[EquipmentEditForm.Constructor] loadInstanceGrid completed");
                }
                else
                {
                    var instancePanelControl = this.Controls.OfType<Panel>().FirstOrDefault(p => p.Name == "instancePanel");
                    if (instancePanelControl != null)
                    {
                        instancePanelControl.Visible = false;
                    }
                }

                System.Diagnostics.Debug.WriteLine("[EquipmentEditForm.Constructor] Completed successfully");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[EquipmentEditForm.Constructor] Exception: {ex}");
                MessageBox.Show($"שגיאה בטעינת טופס העריכה:\n\n{ex.Message}\n\nType: {ex.GetType().Name}\n\nStack:\n{ex.StackTrace}", "שגיאה קריטית", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void loadEquipmentData()
        {
            try
            {
                System.Diagnostics.Debug.WriteLine("[loadEquipmentData] Starting");

                if (equipment == null)
                {
                    System.Diagnostics.Debug.WriteLine("[loadEquipmentData] Equipment is null, returning");
                    return;
                }

                nameTextBox.Text = equipment.getName() ?? "";
                System.Diagnostics.Debug.WriteLine($"[loadEquipmentData] Name: {equipment.getName()}");

                string equipCategory = equipment.getCategory();
                if (!string.IsNullOrEmpty(equipCategory) && categoryComboBox.Items.Contains(equipCategory))
                {
                    categoryComboBox.SelectedItem = equipCategory;
                    System.Diagnostics.Debug.WriteLine($"[loadEquipmentData] Category set: {equipCategory}");
                }
                else
                {
                    if (categoryComboBox.Items.Count > 0)
                        categoryComboBox.SelectedIndex = 0;
                    System.Diagnostics.Debug.WriteLine($"[loadEquipmentData] Category not found or null, using default");
                }

                descriptionTextBox.Text = equipment.getDescription() ?? "";

                string equipType = equipment.getEquipmentType();
                System.Diagnostics.Debug.WriteLine($"[loadEquipmentData] Equipment type from DB: '{equipType}'");

                if (equipType != null && equipType.ToLower() == "consumable")
                {
                    if (typeComboBox.Items.Contains("צריכה"))
                        typeComboBox.SelectedItem = "צריכה";
                }
                else if (equipType != null && equipType.ToLower() == "reusable")
                {
                    if (typeComboBox.Items.Contains("שניתן לשימוש חוזר"))
                        typeComboBox.SelectedItem = "שניתן לשימוש חוזר";
                }
                else
                {
                    if (typeComboBox.Items.Count > 0)
                        typeComboBox.SelectedIndex = 0;
                }

                containerTypeTextBox.Text = equipment.getContainerType() ?? "";

                int qty = equipment.getQuantity();
                quantitySpinner.Value = Math.Max((decimal)quantitySpinner.Minimum, Math.Min((decimal)qty, quantitySpinner.Maximum));
                System.Diagnostics.Debug.WriteLine($"[loadEquipmentData] Quantity set: {qty}");

                if (equipment.getMinimumQuantity().HasValue)
                {
                    int minQty = equipment.getMinimumQuantity().Value;
                    minimumQuantitySpinner.Value = Math.Max((decimal)minimumQuantitySpinner.Minimum, Math.Min((decimal)minQty, minimumQuantitySpinner.Maximum));
                    System.Diagnostics.Debug.WriteLine($"[loadEquipmentData] MinQuantity set: {minQty}");
                }
                else
                {
                    minimumQuantitySpinner.Value = 0;
                }

                System.Diagnostics.Debug.WriteLine("[loadEquipmentData] Completed successfully");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[loadEquipmentData] Exception: {ex}");
                throw new Exception($"Error loading equipment data: {ex.Message}", ex);
            }
        }

        private void loadInstanceGrid()
        {
            try
            {
                System.Diagnostics.Debug.WriteLine("[loadInstanceGrid] Starting");

                instanceGrid.Rows.Clear();

                if (equipment == null)
                {
                    System.Diagnostics.Debug.WriteLine("[loadInstanceGrid] Equipment is null, returning");
                    return;
                }

                int equipmentId = equipment.getId();
                System.Diagnostics.Debug.WriteLine($"[loadInstanceGrid] Fetching instances for equipment ID: {equipmentId}");

                List<EquipmentInstance> instances = EquipmentInstance.getInstancesByEquipmentId(equipmentId);
                System.Diagnostics.Debug.WriteLine($"[loadInstanceGrid] Retrieved {instances?.Count ?? 0} instances");

                if (instances == null || instances.Count == 0)
                {
                    System.Diagnostics.Debug.WriteLine("[loadInstanceGrid] No instances found or list is null");
                    return;
                }

                foreach (EquipmentInstance inst in instances)
                {
                    if (inst == null)
                    {
                        System.Diagnostics.Debug.WriteLine("[loadInstanceGrid] Skipping null instance");
                        continue;
                    }

                    try
                    {
                        string serial = inst.getSerialNumber() ?? "N/A";
                        string statusDisplay = getStatusDisplay(inst.getStatus());
                        string dateStr = inst.getDateAdded().ToShortDateString();

                        instanceGrid.Rows.Add(serial, statusDisplay, dateStr);
                        instanceGrid.Rows[instanceGrid.Rows.Count - 1].Tag = inst;

                        System.Diagnostics.Debug.WriteLine($"[loadInstanceGrid] Added instance: {serial}, Status: {statusDisplay}");
                    }
                    catch (Exception rowEx)
                    {
                        System.Diagnostics.Debug.WriteLine($"[loadInstanceGrid] Error adding row for instance: {rowEx}");
                    }
                }

                System.Diagnostics.Debug.WriteLine($"[loadInstanceGrid] Completed successfully with {instanceGrid.Rows.Count} rows");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[loadInstanceGrid] Exception: {ex}");
                throw new Exception($"Error loading equipment instances: {ex.Message}", ex);
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
                "lost" => "אבוד/תקול",
                "damaged" => "אבוד/תקול",
                _ => status
            };
        }

        private string getStatusDbValue(string display)
        {
            return display switch
            {
                "פנוי" => "available",
                "משוריין" => "reserved",
                "הושאל" => "issued",
                "בתיקון" => "repair",
                "אבוד/תקול" => "lost",
                _ => "available"
            };
        }

        // ========== SAVE BUTTON - BULLETPROOF FORCE-RELOAD PATTERN ==========
        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Debug.WriteLine("[saveButton_Click] ========== SAVE OPERATION START ==========");

                // VALIDATION
                if (string.IsNullOrWhiteSpace(nameTextBox.Text))
                {
                    MessageBox.Show("אנא הזן שם ציוד", "שדה נדרש", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // ========== UPDATE COMMON EQUIPMENT PROPERTIES ==========
                System.Diagnostics.Debug.WriteLine("[saveButton_Click] Updating base Equipment properties");
                equipment.setName(nameTextBox.Text.Trim());
                equipment.setCategory(categoryComboBox.SelectedItem?.ToString() ?? "");
                equipment.setDescription(descriptionTextBox.Text?.Trim() ?? "");
                equipment.setContainerType(containerTypeTextBox.Text?.Trim() ?? "");
                equipment.setMinimumQuantity((int?)minimumQuantitySpinner.Value);
                equipment.setLastUpdated(DateTime.Now);

                int newQuantity = (int)quantitySpinner.Value;
                int quantityDifference = newQuantity - originalQuantity;

                // ========== CASE 1: CONSUMABLE EQUIPMENT ==========
                if (!isReusable)
                {
                    System.Diagnostics.Debug.WriteLine($"[saveButton_Click] CONSUMABLE: Quantity {originalQuantity} → {newQuantity}");
                    equipment.setQuantity(newQuantity);
                    equipment.updateEquipment();
                    System.Diagnostics.Debug.WriteLine("[saveButton_Click] ✓ Consumable equipment persisted");
                }

                // ========== CASE 2: REUSABLE EQUIPMENT ==========
                else
                {
                    System.Diagnostics.Debug.WriteLine($"[saveButton_Click] REUSABLE: Quantity diff = {quantityDifference}");

                    // SUBCASE 2A: INCREASING QUANTITY - CREATE NEW INSTANCES
                    if (quantityDifference > 0)
                    {
                        System.Diagnostics.Debug.WriteLine($"[saveButton_Click] INCREASING: Creating {quantityDifference} new instances");

                        for (int i = 0; i < quantityDifference; i++)
                        {
                            try
                            {
                                int nextInstanceId = EquipmentInstance.getNextEquipmentInstanceId();
                                int parentEquipmentId = equipment.getId();

                                // Auto-generate unique SerialNumber: EquipmentId_RandomGuid (8 chars)
                                string serialNumber = $"{parentEquipmentId}_{Guid.NewGuid().ToString().Substring(0, 8)}";

                                System.Diagnostics.Debug.WriteLine($"[saveButton_Click] Creating instance #{i + 1}: ID={nextInstanceId}, Equipment={parentEquipmentId}, Serial={serialNumber}");

                                // Create new EquipmentInstance with ALL mandatory fields explicitly set
                                EquipmentInstance newInstance = new EquipmentInstance(
                                    nextInstanceId,              // instance_id
                                    parentEquipmentId,           // equipment_id (CRITICAL)
                                    serialNumber,                // serial_number (CRITICAL: Unique)
                                    "available",                 // status (CRITICAL)
                                    DateTime.Now,                // date_added
                                    DateTime.Now,                // last_updated
                                    null,                        // notes
                                    is_new: true                 // Persists to DB immediately via constructor
                                );

                                System.Diagnostics.Debug.WriteLine($"[saveButton_Click] ✓ Created and persisted instance #{i + 1}: {serialNumber}");
                            }
                            catch (Exception ex)
                            {
                                System.Diagnostics.Debug.WriteLine($"[saveButton_Click] ✗ Failed to create instance #{i + 1}: {ex.Message}\nStack: {ex.StackTrace}");
                                throw new Exception($"Failed to create equipment instance #{i + 1}: {ex.Message}", ex);
                            }
                        }

                        equipment.setQuantity(newQuantity);
                        equipment.updateEquipment();
                        System.Diagnostics.Debug.WriteLine($"[saveButton_Click] ✓ Created {quantityDifference} instances, Equipment quantity updated: {newQuantity}");
                    }

                    // SUBCASE 2B: DECREASING QUANTITY - DELETE AVAILABLE INSTANCES
                    else if (quantityDifference < 0)
                    {
                        int instancesToDelete = Math.Abs(quantityDifference);
                        System.Diagnostics.Debug.WriteLine($"[saveButton_Click] DECREASING: Deleting {instancesToDelete} instances");

                        List<EquipmentInstance> availableInstances = EquipmentInstance.getAvailableInstancesByEquipmentId(equipment.getId());
                        System.Diagnostics.Debug.WriteLine($"[saveButton_Click] Available instances: {availableInstances.Count}");

                        // ERROR CHECK: Insufficient available instances
                        if (availableInstances.Count < instancesToDelete)
                        {
                            int inUse = instanceGrid.Rows.Count - availableInstances.Count;
                            MessageBox.Show(
                                $"לא ניתן להקטין את הכמות.\n\nיחידות זמינות: {availableInstances.Count}\nיחידות למחיקה: {instancesToDelete}\nיחידות בשימוש: {inUse}",
                                "שגיאה: יחידות בשימוש",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error
                            );
                            System.Diagnostics.Debug.WriteLine($"[saveButton_Click] ✗ Insufficient available instances. Aborting.");
                            return;  // ABORT SAVE
                        }

                        // Delete instances from database
                        for (int i = 0; i < instancesToDelete; i++)
                        {
                            try
                            {
                                EquipmentInstance instanceToDelete = availableInstances[i];
                                System.Diagnostics.Debug.WriteLine($"[saveButton_Click] Deleting instance #{i + 1}: {instanceToDelete.getSerialNumber()}");
                                instanceToDelete.deleteEquipmentInstance();
                                System.Diagnostics.Debug.WriteLine($"[saveButton_Click] ✓ Instance #{i + 1} deleted from DB");
                            }
                            catch (Exception ex)
                            {
                                System.Diagnostics.Debug.WriteLine($"[saveButton_Click] ✗ Failed to delete instance #{i + 1}: {ex.Message}");
                                throw new Exception($"Failed to delete equipment instance: {ex.Message}", ex);
                            }
                        }

                        equipment.setQuantity(newQuantity);
                        equipment.updateEquipment();
                        System.Diagnostics.Debug.WriteLine($"[saveButton_Click] ✓ Equipment quantity updated: {newQuantity}");
                    }

                    // SUBCASE 2C: QUANTITY UNCHANGED - JUST UPDATE EQUIPMENT
                    else
                    {
                        System.Diagnostics.Debug.WriteLine("[saveButton_Click] Quantity unchanged, updating equipment metadata only");
                        equipment.setQuantity(newQuantity);
                        equipment.updateEquipment();
                    }
                }

                // ========== GOLDEN SYNCHRONIZATION: FORCE RELOAD FROM DATABASE ==========
                System.Diagnostics.Debug.WriteLine("[saveButton_Click] FORCE RELOAD: Rebuilding in-memory lists from database");
                System.Diagnostics.Debug.WriteLine("[saveButton_Click] Calling Equipment.initEquipments()");
                Equipment.initEquipments();

                System.Diagnostics.Debug.WriteLine("[saveButton_Click] Calling EquipmentInstance.initEquipmentInstances()");
                EquipmentInstance.initEquipmentInstances();

                System.Diagnostics.Debug.WriteLine("[saveButton_Click] ✓ In-memory lists rebuilt successfully");

                // ========== SUCCESS - CLOSE FORM ==========
                System.Diagnostics.Debug.WriteLine("[saveButton_Click] ========== SAVE OPERATION COMPLETE ==========");
                MessageBox.Show("ציוד עודכן בהצלחה", "הצלחה", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[saveButton_Click] ✗✗✗ EXCEPTION: {ex.Message}");
                System.Diagnostics.Debug.WriteLine($"[saveButton_Click] Stack: {ex.StackTrace}");
                MessageBox.Show(
                    $"שגיאה בעדכון ציוד:\n\n{ex.Message}",
                    "שגיאה קריטית",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // ========== CANCEL BUTTON ==========
        private void cancelButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("[cancelButton_Click] Cancel pressed");
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // ========== EDIT INSTANCE STATUS BUTTON ==========
        private void editInstanceStatusButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("[editInstanceStatusButton_Click] Button clicked");
            if (instanceGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("אנא בחר יחידה לעריכת סטטוס", "בחירה נדרשת", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            EquipmentInstance instance = (EquipmentInstance)instanceGrid.SelectedRows[0].Tag;
            EditInstanceStatusDialog dialog = new EditInstanceStatusDialog(instance);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                loadInstanceGrid();
                System.Diagnostics.Debug.WriteLine("[editInstanceStatusButton_Click] Instance status updated");
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            System.Diagnostics.Debug.WriteLine("[OnShown] Form is now visible");
        }

        private void EquipmentEditForm_Load(object sender, EventArgs e)
        {
        }
    }
}

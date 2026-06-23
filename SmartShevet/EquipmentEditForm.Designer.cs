namespace SmartShevet
{
    partial class EquipmentEditForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label categoryLabel;
        private System.Windows.Forms.ComboBox categoryComboBox;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.Label typeLabel;
        private System.Windows.Forms.ComboBox typeComboBox;
        private System.Windows.Forms.Label containerTypeLabel;
        private System.Windows.Forms.TextBox containerTypeTextBox;
        private System.Windows.Forms.Label quantityLabel;
        private System.Windows.Forms.NumericUpDown quantitySpinner;
        private System.Windows.Forms.Label minimumQuantityLabel;
        private System.Windows.Forms.NumericUpDown minimumQuantitySpinner;
        private System.Windows.Forms.Panel instancePanel;
        private System.Windows.Forms.Label instanceLabel;
        private System.Windows.Forms.DataGridView instanceGrid;
        private System.Windows.Forms.Button editInstanceStatusButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.titleLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.categoryLabel = new System.Windows.Forms.Label();
            this.categoryComboBox = new System.Windows.Forms.ComboBox();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.typeLabel = new System.Windows.Forms.Label();
            this.typeComboBox = new System.Windows.Forms.ComboBox();
            this.containerTypeLabel = new System.Windows.Forms.Label();
            this.containerTypeTextBox = new System.Windows.Forms.TextBox();
            this.quantityLabel = new System.Windows.Forms.Label();
            this.quantitySpinner = new System.Windows.Forms.NumericUpDown();
            this.minimumQuantityLabel = new System.Windows.Forms.Label();
            this.minimumQuantitySpinner = new System.Windows.Forms.NumericUpDown();
            this.instancePanel = new System.Windows.Forms.Panel();
            this.instanceLabel = new System.Windows.Forms.Label();
            this.instanceGrid = new System.Windows.Forms.DataGridView();
            this.editInstanceStatusButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();

            ((System.ComponentModel.ISupportInitialize)(this.quantitySpinner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minimumQuantitySpinner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.instanceGrid)).BeginInit();
            this.instancePanel.SuspendLayout();

            // titleLabel - Modern Typography
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.titleLabel.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39);  // #111827
            this.titleLabel.Location = new System.Drawing.Point(350, 15);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(100, 25);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "ערוך ציוד";

            // nameLabel & TextBox - Modern Styling
            this.nameLabel.AutoSize = false;
            this.nameLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.nameLabel.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39);  // #111827
            this.nameLabel.Location = new System.Drawing.Point(550, 70);
            this.nameLabel.Size = new System.Drawing.Size(160, 20);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.nameLabel.Text = "שם:";
            this.nameTextBox.Location = new System.Drawing.Point(350, 70);
            this.nameTextBox.Width = 180;
            this.nameTextBox.Height = 25;
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.BackColor = System.Drawing.Color.White;
            this.nameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nameTextBox.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);

            // categoryLabel & ComboBox - Modern Styling
            this.categoryLabel.AutoSize = false;
            this.categoryLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.categoryLabel.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39);  // #111827
            this.categoryLabel.Location = new System.Drawing.Point(550, 110);
            this.categoryLabel.Size = new System.Drawing.Size(160, 20);
            this.categoryLabel.Name = "categoryLabel";
            this.categoryLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.categoryLabel.Text = "קטגוריה:";
            this.categoryComboBox.Location = new System.Drawing.Point(350, 110);
            this.categoryComboBox.Width = 180;
            this.categoryComboBox.Height = 25;
            this.categoryComboBox.Name = "categoryComboBox";
            this.categoryComboBox.BackColor = System.Drawing.Color.White;
            this.categoryComboBox.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.categoryComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.categoryComboBox.Items.AddRange(new object[] { "אוהלים", "חבלים", "ציוד כתיבה", "כלים", "אחר" });

            // descriptionLabel & TextBox - Modern Styling
            this.descriptionLabel.AutoSize = false;
            this.descriptionLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.descriptionLabel.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39);  // #111827
            this.descriptionLabel.Location = new System.Drawing.Point(550, 150);
            this.descriptionLabel.Size = new System.Drawing.Size(160, 20);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.descriptionLabel.Text = "תיאור:";
            this.descriptionTextBox.Location = new System.Drawing.Point(350, 150);
            this.descriptionTextBox.Width = 180;
            this.descriptionTextBox.Height = 25;
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.BackColor = System.Drawing.Color.White;
            this.descriptionTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.descriptionTextBox.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);

            // typeLabel & ComboBox - Modern Styling
            this.typeLabel.AutoSize = false;
            this.typeLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.typeLabel.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39);  // #111827
            this.typeLabel.Location = new System.Drawing.Point(550, 190);
            this.typeLabel.Size = new System.Drawing.Size(160, 20);
            this.typeLabel.Name = "typeLabel";
            this.typeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.typeLabel.Text = "סוג ציוד:";
            this.typeComboBox.Location = new System.Drawing.Point(350, 190);
            this.typeComboBox.Width = 180;
            this.typeComboBox.Height = 25;
            this.typeComboBox.Name = "typeComboBox";
            this.typeComboBox.BackColor = System.Drawing.Color.White;
            this.typeComboBox.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.typeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typeComboBox.Items.AddRange(new object[] { "צריכה", "שניתן לשימוש חוזר" });
            this.typeComboBox.Enabled = false;

            // containerTypeLabel & TextBox - Modern Styling
            this.containerTypeLabel.AutoSize = false;
            this.containerTypeLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.containerTypeLabel.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39);  // #111827
            this.containerTypeLabel.Location = new System.Drawing.Point(550, 230);
            this.containerTypeLabel.Size = new System.Drawing.Size(160, 20);
            this.containerTypeLabel.Name = "containerTypeLabel";
            this.containerTypeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.containerTypeLabel.Text = "סוג מכולה:";
            this.containerTypeTextBox.Location = new System.Drawing.Point(350, 230);
            this.containerTypeTextBox.Width = 180;
            this.containerTypeTextBox.Height = 25;
            this.containerTypeTextBox.Name = "containerTypeTextBox";
            this.containerTypeTextBox.BackColor = System.Drawing.Color.White;
            this.containerTypeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.containerTypeTextBox.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);

            // quantityLabel & Spinner - Modern Styling
            this.quantityLabel.AutoSize = false;
            this.quantityLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.quantityLabel.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39);  // #111827
            this.quantityLabel.Location = new System.Drawing.Point(550, 270);
            this.quantityLabel.Size = new System.Drawing.Size(160, 20);
            this.quantityLabel.Name = "quantityLabel";
            this.quantityLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.quantityLabel.Text = "כמות:";
            this.quantitySpinner.Location = new System.Drawing.Point(350, 270);
            this.quantitySpinner.Width = 180;
            this.quantitySpinner.Height = 25;
            this.quantitySpinner.Name = "quantitySpinner";
            this.quantitySpinner.BackColor = System.Drawing.Color.White;
            this.quantitySpinner.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.quantitySpinner.Minimum = 0;
            this.quantitySpinner.Maximum = 10000;

            // minimumQuantityLabel & Spinner - Modern Styling
            this.minimumQuantityLabel.AutoSize = false;
            this.minimumQuantityLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.minimumQuantityLabel.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39);  // #111827
            this.minimumQuantityLabel.Location = new System.Drawing.Point(550, 310);
            this.minimumQuantityLabel.Size = new System.Drawing.Size(160, 20);
            this.minimumQuantityLabel.Name = "minimumQuantityLabel";
            this.minimumQuantityLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.minimumQuantityLabel.Text = "כמות מינימום:";
            this.minimumQuantitySpinner.Location = new System.Drawing.Point(350, 310);
            this.minimumQuantitySpinner.Width = 180;
            this.minimumQuantitySpinner.Height = 25;
            this.minimumQuantitySpinner.Name = "minimumQuantitySpinner";
            this.minimumQuantitySpinner.BackColor = System.Drawing.Color.White;
            this.minimumQuantitySpinner.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.minimumQuantitySpinner.Minimum = 0;
            this.minimumQuantitySpinner.Maximum = 10000;

            // instancePanel (for reusables only) - Modern Card Style
            this.instancePanel.Location = new System.Drawing.Point(20, 370);
            this.instancePanel.Width = 700;
            this.instancePanel.Height = 200;
            this.instancePanel.Name = "instancePanel";
            this.instancePanel.BackColor = System.Drawing.Color.White;
            this.instancePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.instancePanel.Padding = new System.Windows.Forms.Padding(15);
            this.instancePanel.Visible = false;

            // instanceLabel - Modern Typography
            this.instanceLabel.AutoSize = true;
            this.instanceLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.instanceLabel.ForeColor = System.Drawing.Color.FromArgb(128, 0, 32);  // #800020 (Burgundy)
            this.instanceLabel.Location = new System.Drawing.Point(20, 15);
            this.instanceLabel.Name = "instanceLabel";
            this.instanceLabel.Text = "יחידות (שניתן לשימוש חוזר)";

            // instanceGrid - MODERN STYLING
            this.instanceGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.instanceGrid.ColumnHeadersHeight = 35;
            this.instanceGrid.RowTemplate.Height = 30;
            this.instanceGrid.Location = new System.Drawing.Point(20, 40);
            this.instanceGrid.Name = "instanceGrid";
            this.instanceGrid.ReadOnly = true;
            this.instanceGrid.Width = 660;
            this.instanceGrid.Height = 100;
            this.instanceGrid.TabIndex = 1;
            this.instanceGrid.ColumnCount = 3;
            this.instanceGrid.Columns[0].Name = "מס''ד";
            this.instanceGrid.Columns[1].Name = "סטטוס";
            this.instanceGrid.Columns[2].Name = "תאריך הוספה";
            this.instanceGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.instanceGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.instanceGrid.BackgroundColor = System.Drawing.Color.White;  // #FFFFFF
            this.instanceGrid.GridColor = System.Drawing.Color.FromArgb(229, 231, 235);  // #E5E7EB (row dividers)
            this.instanceGrid.EnableHeadersVisualStyles = false;  // CRITICAL for custom header colors
            this.instanceGrid.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(128, 0, 32);  // #800020 (Burgundy)
            this.instanceGrid.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.instanceGrid.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.instanceGrid.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.instanceGrid.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39);  // #111827
            this.instanceGrid.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.instanceGrid.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(255, 243, 224);  // Light peach
            this.instanceGrid.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(17, 24, 39);
            this.instanceGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            // editInstanceStatusButton - PRIMARY ACTION
            this.editInstanceStatusButton.Location = new System.Drawing.Point(600, 150);
            this.editInstanceStatusButton.Width = 80;
            this.editInstanceStatusButton.Height = 30;
            this.editInstanceStatusButton.Name = "editInstanceStatusButton";
            this.editInstanceStatusButton.Text = "עריכה";
            this.editInstanceStatusButton.BackColor = System.Drawing.Color.FromArgb(128, 0, 32);  // #800020
            this.editInstanceStatusButton.ForeColor = System.Drawing.Color.White;
            this.editInstanceStatusButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editInstanceStatusButton.FlatAppearance.BorderSize = 0;
            this.editInstanceStatusButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.editInstanceStatusButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.editInstanceStatusButton.Click += new System.EventHandler(this.editInstanceStatusButton_Click);

            this.instancePanel.Controls.Add(this.instanceLabel);
            this.instancePanel.Controls.Add(this.instanceGrid);
            this.instancePanel.Controls.Add(this.editInstanceStatusButton);

            // ========== SAVE BUTTON - FRESH CREATION, EXPLICITLY ADDED TO FORM ==========
            this.saveButton = new System.Windows.Forms.Button();
            this.saveButton.Location = new System.Drawing.Point(30, 400);
            this.saveButton.Size = new System.Drawing.Size(100, 40);
            this.saveButton.Name = "btnSave";
            this.saveButton.Text = "שמירה";
            this.saveButton.BackColor = System.Drawing.Color.FromArgb(128, 0, 32);  // #800020 (Burgundy)
            this.saveButton.ForeColor = System.Drawing.Color.White;
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveButton.FlatAppearance.BorderSize = 0;
            this.saveButton.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.saveButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.saveButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            this.Controls.Add(this.saveButton);
            this.saveButton.BringToFront();

            // ========== CANCEL BUTTON - FRESH CREATION, EXPLICITLY ADDED TO FORM ==========
            this.cancelButton = new System.Windows.Forms.Button();
            this.cancelButton.Location = new System.Drawing.Point(150, 400);
            this.cancelButton.Size = new System.Drawing.Size(100, 40);
            this.cancelButton.Name = "btnCancel";
            this.cancelButton.Text = "ביטול";
            this.cancelButton.BackColor = System.Drawing.Color.White;
            this.cancelButton.ForeColor = System.Drawing.Color.FromArgb(128, 0, 32);  // #800020
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(128, 0, 32);  // #800020
            this.cancelButton.FlatAppearance.BorderSize = 2;
            this.cancelButton.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.cancelButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cancelButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            this.Controls.Add(this.cancelButton);
            this.cancelButton.BringToFront();

            // ========== FORM CONFIGURATION - MODERN DESIGN ==========
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(250, 249, 246);  // #FAF9F6 (Off-white)
            this.ClientSize = new System.Drawing.Size(740, 640);

            // ========== ADD ALL CONTROLS TO FORM ==========
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.categoryLabel);
            this.Controls.Add(this.categoryComboBox);
            this.Controls.Add(this.descriptionLabel);
            this.Controls.Add(this.descriptionTextBox);
            this.Controls.Add(this.typeLabel);
            this.Controls.Add(this.typeComboBox);
            this.Controls.Add(this.containerTypeLabel);
            this.Controls.Add(this.containerTypeTextBox);
            this.Controls.Add(this.quantityLabel);
            this.Controls.Add(this.quantitySpinner);
            this.Controls.Add(this.minimumQuantityLabel);
            this.Controls.Add(this.minimumQuantitySpinner);
            this.Controls.Add(this.instancePanel);

            // ========== KEYBOARD SHORTCUTS ==========
            this.AcceptButton = this.saveButton;    // Enter key triggers Save
            this.CancelButton = this.cancelButton;  // Esc key triggers Cancel

            // ========== FORM PROPERTIES ==========
            this.Name = "EquipmentEditForm";
            this.Text = "ערוך ציוד";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;

            ((System.ComponentModel.ISupportInitialize)(this.quantitySpinner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minimumQuantitySpinner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.instanceGrid)).EndInit();
            this.instancePanel.ResumeLayout(false);
            this.instancePanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

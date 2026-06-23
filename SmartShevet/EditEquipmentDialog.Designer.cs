namespace SmartShevet
{
    partial class EditEquipmentDialog
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Panel inputCardPanel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label typeLabel;
        private System.Windows.Forms.TextBox typeTextBox;
        private System.Windows.Forms.Label currentQtyDisplayLabel;
        private System.Windows.Forms.Label currentQtyLabel;
        private System.Windows.Forms.Label quantityLabel;
        private System.Windows.Forms.NumericUpDown quantitySpinner;
        private System.Windows.Forms.Label reasonLabel;
        private System.Windows.Forms.ComboBox reasonComboBox;
        private System.Windows.Forms.Label notesLabel;
        private System.Windows.Forms.TextBox notesTextBox;
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
            this.inputCardPanel = new System.Windows.Forms.Panel();
            this.nameLabel = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.typeLabel = new System.Windows.Forms.Label();
            this.typeTextBox = new System.Windows.Forms.TextBox();
            this.currentQtyDisplayLabel = new System.Windows.Forms.Label();
            this.currentQtyLabel = new System.Windows.Forms.Label();
            this.quantityLabel = new System.Windows.Forms.Label();
            this.quantitySpinner = new System.Windows.Forms.NumericUpDown();
            this.reasonLabel = new System.Windows.Forms.Label();
            this.reasonComboBox = new System.Windows.Forms.ComboBox();
            this.notesLabel = new System.Windows.Forms.Label();
            this.notesTextBox = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();

            ((System.ComponentModel.ISupportInitialize)(this.quantitySpinner)).BeginInit();
            this.inputCardPanel.SuspendLayout();

            // titleLabel - Modern Typography
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.titleLabel.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39);  // #111827
            this.titleLabel.Location = new System.Drawing.Point(280, 12);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(100, 32);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "ערוך ציוד";

            // inputCardPanel - Modern Card Style
            this.inputCardPanel.BackColor = System.Drawing.Color.White;  // #FFFFFF
            this.inputCardPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inputCardPanel.Location = new System.Drawing.Point(15, 55);
            this.inputCardPanel.Name = "inputCardPanel";
            this.inputCardPanel.Size = new System.Drawing.Size(390, 170);
            this.inputCardPanel.TabIndex = 1;
            this.inputCardPanel.Padding = new System.Windows.Forms.Padding(12);

            // nameLabel - Modern Styling
            this.nameLabel.AutoSize = false;
            this.nameLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.nameLabel.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39);  // #111827
            this.nameLabel.Location = new System.Drawing.Point(210, 8);
            this.nameLabel.Size = new System.Drawing.Size(120, 18);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.TabIndex = 2;
            this.nameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.nameLabel.Text = "שם:";

            // nameTextBox - Modern Styling
            this.nameTextBox.Location = new System.Drawing.Point(15, 8);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(190, 18);
            this.nameTextBox.TabIndex = 3;
            this.nameTextBox.BackColor = System.Drawing.Color.White;
            this.nameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nameTextBox.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular);
            this.nameTextBox.ReadOnly = true;

            // typeLabel - Modern Styling
            this.typeLabel.AutoSize = false;
            this.typeLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.typeLabel.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39);  // #111827
            this.typeLabel.Location = new System.Drawing.Point(210, 28);
            this.typeLabel.Size = new System.Drawing.Size(120, 18);
            this.typeLabel.Name = "typeLabel";
            this.typeLabel.TabIndex = 4;
            this.typeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.typeLabel.Text = "סוג:";

            // typeTextBox - Modern Styling
            this.typeTextBox.Location = new System.Drawing.Point(15, 28);
            this.typeTextBox.Name = "typeTextBox";
            this.typeTextBox.Size = new System.Drawing.Size(190, 18);
            this.typeTextBox.TabIndex = 5;
            this.typeTextBox.BackColor = System.Drawing.Color.White;
            this.typeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.typeTextBox.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular);
            this.typeTextBox.ReadOnly = true;

            // currentQtyDisplayLabel - Modern Styling
            this.currentQtyDisplayLabel.AutoSize = false;
            this.currentQtyDisplayLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.currentQtyDisplayLabel.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39);  // #111827
            this.currentQtyDisplayLabel.Location = new System.Drawing.Point(210, 48);
            this.currentQtyDisplayLabel.Size = new System.Drawing.Size(120, 18);
            this.currentQtyDisplayLabel.Name = "currentQtyDisplayLabel";
            this.currentQtyDisplayLabel.TabIndex = 6;
            this.currentQtyDisplayLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.currentQtyDisplayLabel.Text = "כמות נוכחית:";

            // currentQtyLabel - Modern Styling
            this.currentQtyLabel.AutoSize = false;
            this.currentQtyLabel.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular);
            this.currentQtyLabel.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39);  // #111827
            this.currentQtyLabel.Location = new System.Drawing.Point(15, 48);
            this.currentQtyLabel.Size = new System.Drawing.Size(190, 18);
            this.currentQtyLabel.Name = "currentQtyLabel";
            this.currentQtyLabel.TabIndex = 7;
            this.currentQtyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.currentQtyLabel.Text = "0";

            // quantityLabel - Modern Styling
            this.quantityLabel.AutoSize = false;
            this.quantityLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.quantityLabel.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39);  // #111827
            this.quantityLabel.Location = new System.Drawing.Point(210, 68);
            this.quantityLabel.Size = new System.Drawing.Size(120, 18);
            this.quantityLabel.Name = "quantityLabel";
            this.quantityLabel.TabIndex = 8;
            this.quantityLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.quantityLabel.Text = "כמות חדשה:";

            // quantitySpinner - Modern Styling
            this.quantitySpinner.Location = new System.Drawing.Point(15, 68);
            this.quantitySpinner.Name = "quantitySpinner";
            this.quantitySpinner.Size = new System.Drawing.Size(190, 18);
            this.quantitySpinner.TabIndex = 9;
            this.quantitySpinner.BackColor = System.Drawing.Color.White;
            this.quantitySpinner.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular);

            // reasonLabel - Modern Styling
            this.reasonLabel.AutoSize = false;
            this.reasonLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.reasonLabel.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39);  // #111827
            this.reasonLabel.Location = new System.Drawing.Point(210, 88);
            this.reasonLabel.Size = new System.Drawing.Size(120, 18);
            this.reasonLabel.Name = "reasonLabel";
            this.reasonLabel.TabIndex = 10;
            this.reasonLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.reasonLabel.Text = "סיבה:";

            // reasonComboBox - Modern Styling
            this.reasonComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.reasonComboBox.Location = new System.Drawing.Point(15, 88);
            this.reasonComboBox.Name = "reasonComboBox";
            this.reasonComboBox.Size = new System.Drawing.Size(190, 20);
            this.reasonComboBox.TabIndex = 11;
            this.reasonComboBox.BackColor = System.Drawing.Color.White;
            this.reasonComboBox.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular);

            // notesLabel - Modern Styling
            this.notesLabel.AutoSize = false;
            this.notesLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.notesLabel.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39);  // #111827
            this.notesLabel.Location = new System.Drawing.Point(210, 108);
            this.notesLabel.Size = new System.Drawing.Size(120, 18);
            this.notesLabel.Name = "notesLabel";
            this.notesLabel.TabIndex = 12;
            this.notesLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.notesLabel.Text = "הערות:";

            // notesTextBox - Modern Styling
            this.notesTextBox.Location = new System.Drawing.Point(15, 108);
            this.notesTextBox.Name = "notesTextBox";
            this.notesTextBox.Size = new System.Drawing.Size(190, 30);
            this.notesTextBox.Multiline = true;
            this.notesTextBox.TabIndex = 13;
            this.notesTextBox.BackColor = System.Drawing.Color.White;
            this.notesTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.notesTextBox.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular);

            // Add all input controls to the panel
            this.inputCardPanel.Controls.Add(this.nameLabel);
            this.inputCardPanel.Controls.Add(this.nameTextBox);
            this.inputCardPanel.Controls.Add(this.typeLabel);
            this.inputCardPanel.Controls.Add(this.typeTextBox);
            this.inputCardPanel.Controls.Add(this.currentQtyDisplayLabel);
            this.inputCardPanel.Controls.Add(this.currentQtyLabel);
            this.inputCardPanel.Controls.Add(this.quantityLabel);
            this.inputCardPanel.Controls.Add(this.quantitySpinner);
            this.inputCardPanel.Controls.Add(this.reasonLabel);
            this.inputCardPanel.Controls.Add(this.reasonComboBox);
            this.inputCardPanel.Controls.Add(this.notesLabel);
            this.inputCardPanel.Controls.Add(this.notesTextBox);

            // saveButton - PRIMARY ACTION (Burgundy CTA)
            this.saveButton.Location = new System.Drawing.Point(185, 245);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 32);
            this.saveButton.TabIndex = 14;
            this.saveButton.Text = "שמור";
            this.saveButton.BackColor = System.Drawing.Color.FromArgb(128, 0, 32);  // #800020
            this.saveButton.ForeColor = System.Drawing.Color.White;  // #FFFFFF
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveButton.FlatAppearance.BorderSize = 0;
            this.saveButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.saveButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);

            // cancelButton - SECONDARY ACTION (White with Burgundy Border)
            this.cancelButton.Location = new System.Drawing.Point(100, 245);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 32);
            this.cancelButton.TabIndex = 15;
            this.cancelButton.Text = "ביטול";
            this.cancelButton.BackColor = System.Drawing.Color.White;  // #FFFFFF
            this.cancelButton.ForeColor = System.Drawing.Color.FromArgb(128, 0, 32);  // #800020
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(128, 0, 32);  // #800020
            this.cancelButton.FlatAppearance.BorderSize = 1;
            this.cancelButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.cancelButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);

            // EditEquipmentDialog - Modern Design
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(250, 249, 246);  // #FAF9F6 (Off-white)
            this.ClientSize = new System.Drawing.Size(420, 300);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.inputCardPanel);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.cancelButton);
            this.Name = "EditEquipmentDialog";
            this.Text = "ערוך ציוד";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;

            ((System.ComponentModel.ISupportInitialize)(this.quantitySpinner)).EndInit();
            this.inputCardPanel.ResumeLayout(false);
            this.inputCardPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

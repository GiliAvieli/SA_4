namespace SmartShevet
{
    partial class AddEquipmentDialog
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label categoryLabel;
        private System.Windows.Forms.ComboBox categoryComboBox;
        private System.Windows.Forms.Label typeLabel;
        private System.Windows.Forms.ComboBox typeComboBox;
        private System.Windows.Forms.Label quantityLabel;
        private System.Windows.Forms.NumericUpDown quantitySpinner;
        private System.Windows.Forms.Label instanceCountLabel;
        private System.Windows.Forms.NumericUpDown instanceCountSpinner;
        private System.Windows.Forms.Button addButton;
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
            this.typeLabel = new System.Windows.Forms.Label();
            this.typeComboBox = new System.Windows.Forms.ComboBox();
            this.quantityLabel = new System.Windows.Forms.Label();
            this.quantitySpinner = new System.Windows.Forms.NumericUpDown();
            this.instanceCountLabel = new System.Windows.Forms.Label();
            this.instanceCountSpinner = new System.Windows.Forms.NumericUpDown();
            this.addButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();

            ((System.ComponentModel.ISupportInitialize)(this.quantitySpinner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.instanceCountSpinner)).BeginInit();

            // titleLabel - Modern Typography
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.titleLabel.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39);  // #111827
            this.titleLabel.Location = new System.Drawing.Point(360, 20);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(150, 37);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "הוסף ציוד חדש";

            // nameLabel - Modern Styling
            this.nameLabel.AutoSize = false;
            this.nameLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.nameLabel.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39);  // #111827
            this.nameLabel.Location = new System.Drawing.Point(360, 80);
            this.nameLabel.Size = new System.Drawing.Size(80, 25);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.TabIndex = 1;
            this.nameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.nameLabel.Text = "שם:";

            // nameTextBox - Modern Styling
            this.nameTextBox.Location = new System.Drawing.Point(90, 80);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(260, 25);
            this.nameTextBox.TabIndex = 2;
            this.nameTextBox.BackColor = System.Drawing.Color.White;
            this.nameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nameTextBox.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);

            // categoryLabel - Modern Styling
            this.categoryLabel.AutoSize = false;
            this.categoryLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.categoryLabel.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39);  // #111827
            this.categoryLabel.Location = new System.Drawing.Point(360, 125);
            this.categoryLabel.Size = new System.Drawing.Size(80, 25);
            this.categoryLabel.Name = "categoryLabel";
            this.categoryLabel.TabIndex = 3;
            this.categoryLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.categoryLabel.Text = "קטגוריה:";

            // categoryComboBox - Modern Styling
            this.categoryComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.categoryComboBox.Location = new System.Drawing.Point(90, 125);
            this.categoryComboBox.Name = "categoryComboBox";
            this.categoryComboBox.Size = new System.Drawing.Size(260, 25);
            this.categoryComboBox.TabIndex = 4;
            this.categoryComboBox.BackColor = System.Drawing.Color.White;
            this.categoryComboBox.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);

            // typeLabel - Modern Styling
            this.typeLabel.AutoSize = false;
            this.typeLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.typeLabel.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39);  // #111827
            this.typeLabel.Location = new System.Drawing.Point(360, 170);
            this.typeLabel.Size = new System.Drawing.Size(80, 25);
            this.typeLabel.Name = "typeLabel";
            this.typeLabel.TabIndex = 5;
            this.typeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.typeLabel.Text = "סוג:";

            // typeComboBox - Modern Styling
            this.typeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typeComboBox.Location = new System.Drawing.Point(90, 170);
            this.typeComboBox.Name = "typeComboBox";
            this.typeComboBox.Size = new System.Drawing.Size(260, 25);
            this.typeComboBox.TabIndex = 6;
            this.typeComboBox.BackColor = System.Drawing.Color.White;
            this.typeComboBox.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.typeComboBox.SelectedIndexChanged += new System.EventHandler(this.typeComboBox_SelectedIndexChanged);

            // quantityLabel - Modern Styling
            this.quantityLabel.AutoSize = false;
            this.quantityLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.quantityLabel.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39);  // #111827
            this.quantityLabel.Location = new System.Drawing.Point(360, 215);
            this.quantityLabel.Size = new System.Drawing.Size(80, 25);
            this.quantityLabel.Name = "quantityLabel";
            this.quantityLabel.TabIndex = 7;
            this.quantityLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.quantityLabel.Text = "כמות התחלתית:";

            // quantitySpinner - Modern Styling
            this.quantitySpinner.Location = new System.Drawing.Point(90, 215);
            this.quantitySpinner.Name = "quantitySpinner";
            this.quantitySpinner.Size = new System.Drawing.Size(260, 25);
            this.quantitySpinner.TabIndex = 8;
            this.quantitySpinner.BackColor = System.Drawing.Color.White;
            this.quantitySpinner.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.quantitySpinner.Minimum = 0;
            this.quantitySpinner.Maximum = 1000;
            this.quantitySpinner.Value = 1;

            // instanceCountLabel - Modern Styling
            this.instanceCountLabel.AutoSize = false;
            this.instanceCountLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.instanceCountLabel.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39);  // #111827
            this.instanceCountLabel.Location = new System.Drawing.Point(360, 215);
            this.instanceCountLabel.Size = new System.Drawing.Size(80, 25);
            this.instanceCountLabel.Name = "instanceCountLabel";
            this.instanceCountLabel.TabIndex = 9;
            this.instanceCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.instanceCountLabel.Text = "מספר יחידות ראשוני:";
            this.instanceCountLabel.Visible = false;

            // instanceCountSpinner - Modern Styling
            this.instanceCountSpinner.Location = new System.Drawing.Point(90, 215);
            this.instanceCountSpinner.Name = "instanceCountSpinner";
            this.instanceCountSpinner.Size = new System.Drawing.Size(260, 25);
            this.instanceCountSpinner.TabIndex = 10;
            this.instanceCountSpinner.BackColor = System.Drawing.Color.White;
            this.instanceCountSpinner.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.instanceCountSpinner.Minimum = 0;
            this.instanceCountSpinner.Maximum = 100;
            this.instanceCountSpinner.Value = 1;
            this.instanceCountSpinner.Visible = false;

            // addButton - PRIMARY ACTION (Burgundy CTA)
            this.addButton.Location = new System.Drawing.Point(220, 280);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(80, 35);
            this.addButton.TabIndex = 11;
            this.addButton.Text = "הוסף";
            this.addButton.BackColor = System.Drawing.Color.FromArgb(128, 0, 32);  // #800020 (Burgundy)
            this.addButton.ForeColor = System.Drawing.Color.White;
            this.addButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addButton.FlatAppearance.BorderSize = 0;
            this.addButton.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.addButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);

            // cancelButton - SECONDARY ACTION (White with Burgundy Border)
            this.cancelButton.Location = new System.Drawing.Point(120, 280);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(80, 35);
            this.cancelButton.TabIndex = 12;
            this.cancelButton.Text = "ביטול";
            this.cancelButton.BackColor = System.Drawing.Color.White;
            this.cancelButton.ForeColor = System.Drawing.Color.FromArgb(128, 0, 32);  // #800020
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(128, 0, 32);  // #800020
            this.cancelButton.FlatAppearance.BorderSize = 2;
            this.cancelButton.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.cancelButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);

            // AddEquipmentDialog - Modern Design
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(250, 249, 246);  // #FAF9F6 (Off-white)
            this.ClientSize = new System.Drawing.Size(480, 340);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.categoryLabel);
            this.Controls.Add(this.categoryComboBox);
            this.Controls.Add(this.typeLabel);
            this.Controls.Add(this.typeComboBox);
            this.Controls.Add(this.quantityLabel);
            this.Controls.Add(this.quantitySpinner);
            this.Controls.Add(this.instanceCountLabel);
            this.Controls.Add(this.instanceCountSpinner);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.cancelButton);
            this.Name = "AddEquipmentDialog";
            this.Text = "הוסף ציוד";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;

            ((System.ComponentModel.ISupportInitialize)(this.quantitySpinner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.instanceCountSpinner)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

namespace SmartShevet
{
    partial class EditInstanceStatusDialog
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label serialNumberLabel;
        private System.Windows.Forms.TextBox serialNumberTextBox;
        private System.Windows.Forms.Label equipmentNameLabel;
        private System.Windows.Forms.TextBox equipmentNameTextBox;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.ComboBox statusComboBox;
        private System.Windows.Forms.Label dateLabel;
        public System.Windows.Forms.Label datePickerLabel;
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
            this.serialNumberLabel = new System.Windows.Forms.Label();
            this.serialNumberTextBox = new System.Windows.Forms.TextBox();
            this.equipmentNameLabel = new System.Windows.Forms.Label();
            this.equipmentNameTextBox = new System.Windows.Forms.TextBox();
            this.statusLabel = new System.Windows.Forms.Label();
            this.statusComboBox = new System.Windows.Forms.ComboBox();
            this.dateLabel = new System.Windows.Forms.Label();
            this.datePickerLabel = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // titleLabel
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.titleLabel.Location = new System.Drawing.Point(200, 20);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(150, 19);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "ערוך סטטוס יחידה";

            // serialNumberLabel
            this.serialNumberLabel.AutoSize = true;
            this.serialNumberLabel.Location = new System.Drawing.Point(350, 70);
            this.serialNumberLabel.Name = "serialNumberLabel";
            this.serialNumberLabel.Size = new System.Drawing.Size(50, 13);
            this.serialNumberLabel.TabIndex = 1;
            this.serialNumberLabel.Text = "מס''ד:";

            // serialNumberTextBox
            this.serialNumberTextBox.Location = new System.Drawing.Point(200, 70);
            this.serialNumberTextBox.Name = "serialNumberTextBox";
            this.serialNumberTextBox.Size = new System.Drawing.Size(140, 20);
            this.serialNumberTextBox.TabIndex = 2;
            this.serialNumberTextBox.ReadOnly = true;

            // equipmentNameLabel
            this.equipmentNameLabel.AutoSize = true;
            this.equipmentNameLabel.Location = new System.Drawing.Point(350, 110);
            this.equipmentNameLabel.Name = "equipmentNameLabel";
            this.equipmentNameLabel.Size = new System.Drawing.Size(60, 13);
            this.equipmentNameLabel.TabIndex = 3;
            this.equipmentNameLabel.Text = "ציוד:";

            // equipmentNameTextBox
            this.equipmentNameTextBox.Location = new System.Drawing.Point(200, 110);
            this.equipmentNameTextBox.Name = "equipmentNameTextBox";
            this.equipmentNameTextBox.Size = new System.Drawing.Size(140, 20);
            this.equipmentNameTextBox.TabIndex = 4;
            this.equipmentNameTextBox.ReadOnly = true;

            // statusLabel
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(350, 150);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(40, 13);
            this.statusLabel.TabIndex = 5;
            this.statusLabel.Text = "סטטוס:";

            // statusComboBox
            this.statusComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.statusComboBox.Location = new System.Drawing.Point(200, 150);
            this.statusComboBox.Name = "statusComboBox";
            this.statusComboBox.Size = new System.Drawing.Size(140, 21);
            this.statusComboBox.TabIndex = 6;

            // dateLabel
            this.dateLabel.AutoSize = true;
            this.dateLabel.Location = new System.Drawing.Point(350, 190);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(100, 13);
            this.dateLabel.TabIndex = 7;
            this.dateLabel.Text = "הוכנס בתאריך:";

            // datePickerLabel
            this.datePickerLabel.AutoSize = true;
            this.datePickerLabel.Location = new System.Drawing.Point(200, 190);
            this.datePickerLabel.Name = "datePickerLabel";
            this.datePickerLabel.Size = new System.Drawing.Size(100, 13);
            this.datePickerLabel.TabIndex = 8;
            this.datePickerLabel.Text = "";

            // saveButton
            this.saveButton.Location = new System.Drawing.Point(270, 240);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(70, 25);
            this.saveButton.TabIndex = 9;
            this.saveButton.Text = "שמור";
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);

            // cancelButton
            this.cancelButton.Location = new System.Drawing.Point(190, 240);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(70, 25);
            this.cancelButton.TabIndex = 10;
            this.cancelButton.Text = "ביטול";
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);

            // EditInstanceStatusDialog
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 290);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.serialNumberLabel);
            this.Controls.Add(this.serialNumberTextBox);
            this.Controls.Add(this.equipmentNameLabel);
            this.Controls.Add(this.equipmentNameTextBox);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.statusComboBox);
            this.Controls.Add(this.dateLabel);
            this.Controls.Add(this.datePickerLabel);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.cancelButton);
            this.Name = "EditInstanceStatusDialog";
            this.Text = "ערוך סטטוס";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

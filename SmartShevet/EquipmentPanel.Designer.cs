namespace SmartShevet
{
    partial class EquipmentPanel
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.ListBox equipmentListBox;
        private System.Windows.Forms.Label listLabel;
        private System.Windows.Forms.Label idLabel;
        private System.Windows.Forms.TextBox idTextBox;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label categoryLabel;
        private System.Windows.Forms.TextBox categoryTextBox;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.Label equipmentTypeLabel;
        private System.Windows.Forms.TextBox equipmentTypeTextBox;
        private System.Windows.Forms.Label containerTypeLabel;
        private System.Windows.Forms.TextBox containerTypeTextBox;
        private System.Windows.Forms.Label quantityLabel;
        private System.Windows.Forms.TextBox quantityTextBox;
        private System.Windows.Forms.Label minimumQuantityLabel;
        private System.Windows.Forms.TextBox minimumQuantityTextBox;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.TextBox statusTextBox;
        private System.Windows.Forms.Label lastUpdatedLabel;
        private System.Windows.Forms.TextBox lastUpdatedTextBox;
        private System.Windows.Forms.Label notesLabel;
        private System.Windows.Forms.TextBox notesTextBox;
        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.Button confirmConditionButton;
        private System.Windows.Forms.Button reportDamageButton;
        private System.Windows.Forms.Button submitForRepairButton;
        private System.Windows.Forms.Button completionConfirmedButton;
        private System.Windows.Forms.Button reportMissingButton;
        private System.Windows.Forms.Button itemFoundButton;
        private System.Windows.Forms.Button deleteButton;

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
            this.backButton = new System.Windows.Forms.Button();
            this.equipmentListBox = new System.Windows.Forms.ListBox();
            this.listLabel = new System.Windows.Forms.Label();
            this.idLabel = new System.Windows.Forms.Label();
            this.idTextBox = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.categoryLabel = new System.Windows.Forms.Label();
            this.categoryTextBox = new System.Windows.Forms.TextBox();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.equipmentTypeLabel = new System.Windows.Forms.Label();
            this.equipmentTypeTextBox = new System.Windows.Forms.TextBox();
            this.containerTypeLabel = new System.Windows.Forms.Label();
            this.containerTypeTextBox = new System.Windows.Forms.TextBox();
            this.quantityLabel = new System.Windows.Forms.Label();
            this.quantityTextBox = new System.Windows.Forms.TextBox();
            this.minimumQuantityLabel = new System.Windows.Forms.Label();
            this.minimumQuantityTextBox = new System.Windows.Forms.TextBox();
            this.statusLabel = new System.Windows.Forms.Label();
            this.statusTextBox = new System.Windows.Forms.TextBox();
            this.lastUpdatedLabel = new System.Windows.Forms.Label();
            this.lastUpdatedTextBox = new System.Windows.Forms.TextBox();
            this.notesLabel = new System.Windows.Forms.Label();
            this.notesTextBox = new System.Windows.Forms.TextBox();
            this.createButton = new System.Windows.Forms.Button();
            this.confirmConditionButton = new System.Windows.Forms.Button();
            this.reportDamageButton = new System.Windows.Forms.Button();
            this.submitForRepairButton = new System.Windows.Forms.Button();
            this.completionConfirmedButton = new System.Windows.Forms.Button();
            this.reportMissingButton = new System.Windows.Forms.Button();
            this.itemFoundButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.SuspendLayout();

            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.titleLabel.Location = new System.Drawing.Point(700, 10);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(80, 22);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "ניהול ציוד";

            this.backButton.Location = new System.Drawing.Point(20, 10);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(75, 23);
            this.backButton.TabIndex = 1;
            this.backButton.Text = "חזרה";
            this.backButton.Click += new System.EventHandler(this.backButton_Click);

            this.listLabel.AutoSize = true;
            this.listLabel.Location = new System.Drawing.Point(700, 50);
            this.listLabel.Name = "listLabel";
            this.listLabel.Size = new System.Drawing.Size(60, 13);
            this.listLabel.TabIndex = 2;
            this.listLabel.Text = "רשימת ציוד";

            this.equipmentListBox.FormattingEnabled = true;
            this.equipmentListBox.Location = new System.Drawing.Point(480, 70);
            this.equipmentListBox.Name = "equipmentListBox";
            this.equipmentListBox.Size = new System.Drawing.Size(290, 500);
            this.equipmentListBox.TabIndex = 3;
            this.equipmentListBox.SelectedIndexChanged += new System.EventHandler(this.equipmentListBox_SelectedIndexChanged);

            int y = 50;
            int labelX = 380;
            int textBoxX = 20;

            this.idLabel.AutoSize = true;
            this.idLabel.Location = new System.Drawing.Point(labelX, y);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(20, 13);
            this.idLabel.TabIndex = 4;
            this.idLabel.Text = "מזהה";

            this.idTextBox.Location = new System.Drawing.Point(textBoxX, y);
            this.idTextBox.Name = "idTextBox";
            this.idTextBox.Size = new System.Drawing.Size(150, 20);
            this.idTextBox.TabIndex = 5;

            y += 30;

            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(labelX, y);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(20, 13);
            this.nameLabel.TabIndex = 6;
            this.nameLabel.Text = "שם";

            this.nameTextBox.Location = new System.Drawing.Point(textBoxX, y);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(150, 20);
            this.nameTextBox.TabIndex = 7;

            y += 30;

            this.categoryLabel.AutoSize = true;
            this.categoryLabel.Location = new System.Drawing.Point(labelX, y);
            this.categoryLabel.Name = "categoryLabel";
            this.categoryLabel.Size = new System.Drawing.Size(50, 13);
            this.categoryLabel.TabIndex = 8;
            this.categoryLabel.Text = "קטגוריה";

            this.categoryTextBox.Location = new System.Drawing.Point(textBoxX, y);
            this.categoryTextBox.Name = "categoryTextBox";
            this.categoryTextBox.Size = new System.Drawing.Size(150, 20);
            this.categoryTextBox.TabIndex = 9;

            y += 30;

            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Location = new System.Drawing.Point(labelX, y);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(40, 13);
            this.descriptionLabel.TabIndex = 10;
            this.descriptionLabel.Text = "תיאור";

            this.descriptionTextBox.Location = new System.Drawing.Point(textBoxX, y);
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(150, 20);
            this.descriptionTextBox.TabIndex = 11;

            y += 30;

            this.equipmentTypeLabel.AutoSize = true;
            this.equipmentTypeLabel.Location = new System.Drawing.Point(labelX, y);
            this.equipmentTypeLabel.Name = "equipmentTypeLabel";
            this.equipmentTypeLabel.Size = new System.Drawing.Size(50, 13);
            this.equipmentTypeLabel.TabIndex = 12;
            this.equipmentTypeLabel.Text = "סוג ציוד";

            this.equipmentTypeTextBox.Location = new System.Drawing.Point(textBoxX, y);
            this.equipmentTypeTextBox.Name = "equipmentTypeTextBox";
            this.equipmentTypeTextBox.Size = new System.Drawing.Size(150, 20);
            this.equipmentTypeTextBox.TabIndex = 13;

            y += 30;

            this.containerTypeLabel.AutoSize = true;
            this.containerTypeLabel.Location = new System.Drawing.Point(labelX, y);
            this.containerTypeLabel.Name = "containerTypeLabel";
            this.containerTypeLabel.Size = new System.Drawing.Size(60, 13);
            this.containerTypeLabel.TabIndex = 14;
            this.containerTypeLabel.Text = "סוג מכולה";

            this.containerTypeTextBox.Location = new System.Drawing.Point(textBoxX, y);
            this.containerTypeTextBox.Name = "containerTypeTextBox";
            this.containerTypeTextBox.Size = new System.Drawing.Size(150, 20);
            this.containerTypeTextBox.TabIndex = 15;

            y += 30;

            this.quantityLabel.AutoSize = true;
            this.quantityLabel.Location = new System.Drawing.Point(labelX, y);
            this.quantityLabel.Name = "quantityLabel";
            this.quantityLabel.Size = new System.Drawing.Size(50, 13);
            this.quantityLabel.TabIndex = 16;
            this.quantityLabel.Text = "כמות";

            this.quantityTextBox.Location = new System.Drawing.Point(textBoxX, y);
            this.quantityTextBox.Name = "quantityTextBox";
            this.quantityTextBox.Size = new System.Drawing.Size(150, 20);
            this.quantityTextBox.TabIndex = 17;

            y += 30;

            this.minimumQuantityLabel.AutoSize = true;
            this.minimumQuantityLabel.Location = new System.Drawing.Point(labelX, y);
            this.minimumQuantityLabel.Name = "minimumQuantityLabel";
            this.minimumQuantityLabel.Size = new System.Drawing.Size(70, 13);
            this.minimumQuantityLabel.TabIndex = 18;
            this.minimumQuantityLabel.Text = "כמות מינימום";

            this.minimumQuantityTextBox.Location = new System.Drawing.Point(textBoxX, y);
            this.minimumQuantityTextBox.Name = "minimumQuantityTextBox";
            this.minimumQuantityTextBox.Size = new System.Drawing.Size(150, 20);
            this.minimumQuantityTextBox.TabIndex = 19;

            y += 30;

            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(labelX, y);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(40, 13);
            this.statusLabel.TabIndex = 20;
            this.statusLabel.Text = "סטטוס";

            this.statusTextBox.Location = new System.Drawing.Point(textBoxX, y);
            this.statusTextBox.Name = "statusTextBox";
            this.statusTextBox.Size = new System.Drawing.Size(150, 20);
            this.statusTextBox.TabIndex = 21;

            y += 30;

            this.lastUpdatedLabel.AutoSize = true;
            this.lastUpdatedLabel.Location = new System.Drawing.Point(labelX, y);
            this.lastUpdatedLabel.Name = "lastUpdatedLabel";
            this.lastUpdatedLabel.Size = new System.Drawing.Size(60, 13);
            this.lastUpdatedLabel.TabIndex = 22;
            this.lastUpdatedLabel.Text = "עדכון אחרון";

            this.lastUpdatedTextBox.Location = new System.Drawing.Point(textBoxX, y);
            this.lastUpdatedTextBox.Name = "lastUpdatedTextBox";
            this.lastUpdatedTextBox.Size = new System.Drawing.Size(150, 20);
            this.lastUpdatedTextBox.TabIndex = 23;

            y += 30;

            this.notesLabel.AutoSize = true;
            this.notesLabel.Location = new System.Drawing.Point(labelX, y);
            this.notesLabel.Name = "notesLabel";
            this.notesLabel.Size = new System.Drawing.Size(40, 13);
            this.notesLabel.TabIndex = 24;
            this.notesLabel.Text = "הערות";

            this.notesTextBox.Location = new System.Drawing.Point(textBoxX, y);
            this.notesTextBox.Name = "notesTextBox";
            this.notesTextBox.Size = new System.Drawing.Size(150, 60);
            this.notesTextBox.Multiline = true;
            this.notesTextBox.TabIndex = 25;

            y += 90;

            this.createButton.Location = new System.Drawing.Point(20, y);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(75, 30);
            this.createButton.TabIndex = 26;
            this.createButton.Text = "יצור";
            this.createButton.Click += new System.EventHandler(this.createButton_Click);

            this.confirmConditionButton.Location = new System.Drawing.Point(100, y);
            this.confirmConditionButton.Name = "confirmConditionButton";
            this.confirmConditionButton.Size = new System.Drawing.Size(85, 30);
            this.confirmConditionButton.TabIndex = 27;
            this.confirmConditionButton.Text = "אישור מצב";
            this.confirmConditionButton.Click += new System.EventHandler(this.confirmConditionButton_Click);

            this.reportDamageButton.Location = new System.Drawing.Point(190, y);
            this.reportDamageButton.Name = "reportDamageButton";
            this.reportDamageButton.Size = new System.Drawing.Size(85, 30);
            this.reportDamageButton.TabIndex = 28;
            this.reportDamageButton.Text = "דיווח נזק";
            this.reportDamageButton.Click += new System.EventHandler(this.reportDamageButton_Click);

            this.submitForRepairButton.Location = new System.Drawing.Point(280, y);
            this.submitForRepairButton.Name = "submitForRepairButton";
            this.submitForRepairButton.Size = new System.Drawing.Size(85, 30);
            this.submitForRepairButton.TabIndex = 29;
            this.submitForRepairButton.Text = "הגשה לתיקון";
            this.submitForRepairButton.Click += new System.EventHandler(this.submitForRepairButton_Click);

            y += 35;

            this.completionConfirmedButton.Location = new System.Drawing.Point(20, y);
            this.completionConfirmedButton.Name = "completionConfirmedButton";
            this.completionConfirmedButton.Size = new System.Drawing.Size(85, 30);
            this.completionConfirmedButton.TabIndex = 30;
            this.completionConfirmedButton.Text = "השלמה";
            this.completionConfirmedButton.Click += new System.EventHandler(this.completionConfirmedButton_Click);

            this.reportMissingButton.Location = new System.Drawing.Point(110, y);
            this.reportMissingButton.Name = "reportMissingButton";
            this.reportMissingButton.Size = new System.Drawing.Size(85, 30);
            this.reportMissingButton.TabIndex = 31;
            this.reportMissingButton.Text = "דיווח אובדן";
            this.reportMissingButton.Click += new System.EventHandler(this.reportMissingButton_Click);

            this.itemFoundButton.Location = new System.Drawing.Point(200, y);
            this.itemFoundButton.Name = "itemFoundButton";
            this.itemFoundButton.Size = new System.Drawing.Size(85, 30);
            this.itemFoundButton.TabIndex = 32;
            this.itemFoundButton.Text = "מציאה";
            this.itemFoundButton.Click += new System.EventHandler(this.itemFoundButton_Click);

            this.deleteButton.Location = new System.Drawing.Point(290, y);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 30);
            this.deleteButton.TabIndex = 33;
            this.deleteButton.Text = "מחק";
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.equipmentListBox);
            this.Controls.Add(this.listLabel);
            this.Controls.Add(this.idLabel);
            this.Controls.Add(this.idTextBox);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.categoryLabel);
            this.Controls.Add(this.categoryTextBox);
            this.Controls.Add(this.descriptionLabel);
            this.Controls.Add(this.descriptionTextBox);
            this.Controls.Add(this.equipmentTypeLabel);
            this.Controls.Add(this.equipmentTypeTextBox);
            this.Controls.Add(this.containerTypeLabel);
            this.Controls.Add(this.containerTypeTextBox);
            this.Controls.Add(this.quantityLabel);
            this.Controls.Add(this.quantityTextBox);
            this.Controls.Add(this.minimumQuantityLabel);
            this.Controls.Add(this.minimumQuantityTextBox);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.statusTextBox);
            this.Controls.Add(this.lastUpdatedLabel);
            this.Controls.Add(this.lastUpdatedTextBox);
            this.Controls.Add(this.notesLabel);
            this.Controls.Add(this.notesTextBox);
            this.Controls.Add(this.createButton);
            this.Controls.Add(this.confirmConditionButton);
            this.Controls.Add(this.reportDamageButton);
            this.Controls.Add(this.submitForRepairButton);
            this.Controls.Add(this.completionConfirmedButton);
            this.Controls.Add(this.reportMissingButton);
            this.Controls.Add(this.itemFoundButton);
            this.Controls.Add(this.deleteButton);
            this.Name = "EquipmentPanel";
            this.Size = new System.Drawing.Size(800, 600);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

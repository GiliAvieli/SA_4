namespace SmartShevet
{
    partial class EquipmentIssuePanel
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.ListBox issueListBox;
        private System.Windows.Forms.Label listLabel;
        private System.Windows.Forms.Label idLabel;
        private System.Windows.Forms.TextBox idTextBox;
        private System.Windows.Forms.Label issueDateLabel;
        private System.Windows.Forms.TextBox issueDateTextBox;
        private System.Windows.Forms.Label returnDateLabel;
        private System.Windows.Forms.TextBox returnDateTextBox;
        private System.Windows.Forms.Label equipmentLabel;
        private System.Windows.Forms.TextBox equipmentTextBox;
        private System.Windows.Forms.Label issuedToLabel;
        private System.Windows.Forms.TextBox issuedToTextBox;
        private System.Windows.Forms.Label reservationLabel;
        private System.Windows.Forms.TextBox reservationTextBox;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.TextBox statusTextBox;
        private System.Windows.Forms.Label conditionLabel;
        private System.Windows.Forms.TextBox conditionTextBox;
        private System.Windows.Forms.Button issueButton;
        private System.Windows.Forms.Button returnFullButton;
        private System.Windows.Forms.Button returnPartialButton;
        private System.Windows.Forms.Button reportMissingButton;
        private System.Windows.Forms.Button finalizeButton;
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
            this.issueListBox = new System.Windows.Forms.ListBox();
            this.listLabel = new System.Windows.Forms.Label();
            this.idLabel = new System.Windows.Forms.Label();
            this.idTextBox = new System.Windows.Forms.TextBox();
            this.issueDateLabel = new System.Windows.Forms.Label();
            this.issueDateTextBox = new System.Windows.Forms.TextBox();
            this.returnDateLabel = new System.Windows.Forms.Label();
            this.returnDateTextBox = new System.Windows.Forms.TextBox();
            this.equipmentLabel = new System.Windows.Forms.Label();
            this.equipmentTextBox = new System.Windows.Forms.TextBox();
            this.issuedToLabel = new System.Windows.Forms.Label();
            this.issuedToTextBox = new System.Windows.Forms.TextBox();
            this.reservationLabel = new System.Windows.Forms.Label();
            this.reservationTextBox = new System.Windows.Forms.TextBox();
            this.statusLabel = new System.Windows.Forms.Label();
            this.statusTextBox = new System.Windows.Forms.TextBox();
            this.conditionLabel = new System.Windows.Forms.Label();
            this.conditionTextBox = new System.Windows.Forms.TextBox();
            this.issueButton = new System.Windows.Forms.Button();
            this.returnFullButton = new System.Windows.Forms.Button();
            this.returnPartialButton = new System.Windows.Forms.Button();
            this.reportMissingButton = new System.Windows.Forms.Button();
            this.finalizeButton = new System.Windows.Forms.Button();
            this.itemFoundButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.SuspendLayout();

            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.titleLabel.Location = new System.Drawing.Point(700, 10);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(100, 22);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "הנפקות וחזרות";

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
            this.listLabel.Text = "רשימת הנפקות";

            this.issueListBox.FormattingEnabled = true;
            this.issueListBox.Location = new System.Drawing.Point(480, 70);
            this.issueListBox.Name = "issueListBox";
            this.issueListBox.Size = new System.Drawing.Size(290, 500);
            this.issueListBox.TabIndex = 3;
            this.issueListBox.SelectedIndexChanged += new System.EventHandler(this.issueListBox_SelectedIndexChanged);

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

            this.issueDateLabel.AutoSize = true;
            this.issueDateLabel.Location = new System.Drawing.Point(labelX, y);
            this.issueDateLabel.Name = "issueDateLabel";
            this.issueDateLabel.Size = new System.Drawing.Size(50, 13);
            this.issueDateLabel.TabIndex = 6;
            this.issueDateLabel.Text = "תאריך הנפקה";

            this.issueDateTextBox.Location = new System.Drawing.Point(textBoxX, y);
            this.issueDateTextBox.Name = "issueDateTextBox";
            this.issueDateTextBox.Size = new System.Drawing.Size(150, 20);
            this.issueDateTextBox.TabIndex = 7;

            y += 30;

            this.returnDateLabel.AutoSize = true;
            this.returnDateLabel.Location = new System.Drawing.Point(labelX, y);
            this.returnDateLabel.Name = "returnDateLabel";
            this.returnDateLabel.Size = new System.Drawing.Size(50, 13);
            this.returnDateLabel.TabIndex = 8;
            this.returnDateLabel.Text = "תאריך החזרה";

            this.returnDateTextBox.Location = new System.Drawing.Point(textBoxX, y);
            this.returnDateTextBox.Name = "returnDateTextBox";
            this.returnDateTextBox.Size = new System.Drawing.Size(150, 20);
            this.returnDateTextBox.TabIndex = 9;

            y += 30;

            this.equipmentLabel.AutoSize = true;
            this.equipmentLabel.Location = new System.Drawing.Point(labelX, y);
            this.equipmentLabel.Name = "equipmentLabel";
            this.equipmentLabel.Size = new System.Drawing.Size(30, 13);
            this.equipmentLabel.TabIndex = 10;
            this.equipmentLabel.Text = "ציוד";

            this.equipmentTextBox.Location = new System.Drawing.Point(textBoxX, y);
            this.equipmentTextBox.Name = "equipmentTextBox";
            this.equipmentTextBox.Size = new System.Drawing.Size(150, 20);
            this.equipmentTextBox.TabIndex = 11;

            y += 30;

            this.issuedToLabel.AutoSize = true;
            this.issuedToLabel.Location = new System.Drawing.Point(labelX, y);
            this.issuedToLabel.Name = "issuedToLabel";
            this.issuedToLabel.Size = new System.Drawing.Size(50, 13);
            this.issuedToLabel.TabIndex = 12;
            this.issuedToLabel.Text = "מונפק ל";

            this.issuedToTextBox.Location = new System.Drawing.Point(textBoxX, y);
            this.issuedToTextBox.Name = "issuedToTextBox";
            this.issuedToTextBox.Size = new System.Drawing.Size(150, 20);
            this.issuedToTextBox.TabIndex = 13;

            y += 30;

            this.reservationLabel.AutoSize = true;
            this.reservationLabel.Location = new System.Drawing.Point(labelX, y);
            this.reservationLabel.Name = "reservationLabel";
            this.reservationLabel.Size = new System.Drawing.Size(40, 13);
            this.reservationLabel.TabIndex = 14;
            this.reservationLabel.Text = "הזמנה";

            this.reservationTextBox.Location = new System.Drawing.Point(textBoxX, y);
            this.reservationTextBox.Name = "reservationTextBox";
            this.reservationTextBox.Size = new System.Drawing.Size(150, 20);
            this.reservationTextBox.TabIndex = 15;

            y += 30;

            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(labelX, y);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(40, 13);
            this.statusLabel.TabIndex = 16;
            this.statusLabel.Text = "סטטוס";

            this.statusTextBox.Location = new System.Drawing.Point(textBoxX, y);
            this.statusTextBox.Name = "statusTextBox";
            this.statusTextBox.Size = new System.Drawing.Size(150, 20);
            this.statusTextBox.TabIndex = 17;

            y += 30;

            this.conditionLabel.AutoSize = true;
            this.conditionLabel.Location = new System.Drawing.Point(labelX, y);
            this.conditionLabel.Name = "conditionLabel";
            this.conditionLabel.Size = new System.Drawing.Size(40, 13);
            this.conditionLabel.TabIndex = 18;
            this.conditionLabel.Text = "מצב";

            this.conditionTextBox.Location = new System.Drawing.Point(textBoxX, y);
            this.conditionTextBox.Name = "conditionTextBox";
            this.conditionTextBox.Size = new System.Drawing.Size(150, 20);
            this.conditionTextBox.TabIndex = 19;

            y += 50;

            this.issueButton.Location = new System.Drawing.Point(20, y);
            this.issueButton.Name = "issueButton";
            this.issueButton.Size = new System.Drawing.Size(75, 30);
            this.issueButton.TabIndex = 20;
            this.issueButton.Text = "הנפק";
            this.issueButton.Click += new System.EventHandler(this.issueButton_Click);

            this.returnFullButton.Location = new System.Drawing.Point(100, y);
            this.returnFullButton.Name = "returnFullButton";
            this.returnFullButton.Size = new System.Drawing.Size(80, 30);
            this.returnFullButton.TabIndex = 21;
            this.returnFullButton.Text = "קבלה מלאה";
            this.returnFullButton.Click += new System.EventHandler(this.returnFullButton_Click);

            this.returnPartialButton.Location = new System.Drawing.Point(185, y);
            this.returnPartialButton.Name = "returnPartialButton";
            this.returnPartialButton.Size = new System.Drawing.Size(80, 30);
            this.returnPartialButton.TabIndex = 22;
            this.returnPartialButton.Text = "קבלה חלקית";
            this.returnPartialButton.Click += new System.EventHandler(this.returnPartialButton_Click);

            y += 35;

            this.reportMissingButton.Location = new System.Drawing.Point(20, y);
            this.reportMissingButton.Name = "reportMissingButton";
            this.reportMissingButton.Size = new System.Drawing.Size(85, 30);
            this.reportMissingButton.TabIndex = 23;
            this.reportMissingButton.Text = "דיווח אובדן";
            this.reportMissingButton.Click += new System.EventHandler(this.reportMissingButton_Click);

            this.finalizeButton.Location = new System.Drawing.Point(110, y);
            this.finalizeButton.Name = "finalizeButton";
            this.finalizeButton.Size = new System.Drawing.Size(75, 30);
            this.finalizeButton.TabIndex = 24;
            this.finalizeButton.Text = "סיום";
            this.finalizeButton.Click += new System.EventHandler(this.finalizeButton_Click);

            this.itemFoundButton.Location = new System.Drawing.Point(190, y);
            this.itemFoundButton.Name = "itemFoundButton";
            this.itemFoundButton.Size = new System.Drawing.Size(75, 30);
            this.itemFoundButton.TabIndex = 25;
            this.itemFoundButton.Text = "מציאה";
            this.itemFoundButton.Click += new System.EventHandler(this.itemFoundButton_Click);

            this.deleteButton.Location = new System.Drawing.Point(270, y);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 30);
            this.deleteButton.TabIndex = 26;
            this.deleteButton.Text = "מחק";
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.issueListBox);
            this.Controls.Add(this.listLabel);
            this.Controls.Add(this.idLabel);
            this.Controls.Add(this.idTextBox);
            this.Controls.Add(this.issueDateLabel);
            this.Controls.Add(this.issueDateTextBox);
            this.Controls.Add(this.returnDateLabel);
            this.Controls.Add(this.returnDateTextBox);
            this.Controls.Add(this.equipmentLabel);
            this.Controls.Add(this.equipmentTextBox);
            this.Controls.Add(this.issuedToLabel);
            this.Controls.Add(this.issuedToTextBox);
            this.Controls.Add(this.reservationLabel);
            this.Controls.Add(this.reservationTextBox);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.statusTextBox);
            this.Controls.Add(this.conditionLabel);
            this.Controls.Add(this.conditionTextBox);
            this.Controls.Add(this.issueButton);
            this.Controls.Add(this.returnFullButton);
            this.Controls.Add(this.returnPartialButton);
            this.Controls.Add(this.reportMissingButton);
            this.Controls.Add(this.finalizeButton);
            this.Controls.Add(this.itemFoundButton);
            this.Controls.Add(this.deleteButton);
            this.Name = "EquipmentIssuePanel";
            this.Size = new System.Drawing.Size(800, 600);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

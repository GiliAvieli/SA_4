namespace SmartShevet
{
    partial class AddInstanceDialog
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label equipmentLabel;
        public System.Windows.Forms.Label equipmentNameLabel;
        private System.Windows.Forms.Label serialNumberLabel;
        private System.Windows.Forms.TextBox serialNumberTextBox;
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
            this.equipmentLabel = new System.Windows.Forms.Label();
            this.equipmentNameLabel = new System.Windows.Forms.Label();
            this.serialNumberLabel = new System.Windows.Forms.Label();
            this.serialNumberTextBox = new System.Windows.Forms.TextBox();
            this.addButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // titleLabel
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.titleLabel.Location = new System.Drawing.Point(200, 20);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(150, 19);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "הוסף יחידה חדשה";

            // equipmentLabel
            this.equipmentLabel.AutoSize = true;
            this.equipmentLabel.Location = new System.Drawing.Point(320, 70);
            this.equipmentLabel.Name = "equipmentLabel";
            this.equipmentLabel.Size = new System.Drawing.Size(60, 13);
            this.equipmentLabel.TabIndex = 1;
            this.equipmentLabel.Text = "ציוד:";

            // equipmentNameLabel
            this.equipmentNameLabel.AutoSize = true;
            this.equipmentNameLabel.Location = new System.Drawing.Point(200, 70);
            this.equipmentNameLabel.Name = "equipmentNameLabel";
            this.equipmentNameLabel.Size = new System.Drawing.Size(100, 13);
            this.equipmentNameLabel.TabIndex = 2;
            this.equipmentNameLabel.Text = "";

            // serialNumberLabel
            this.serialNumberLabel.AutoSize = true;
            this.serialNumberLabel.Location = new System.Drawing.Point(320, 110);
            this.serialNumberLabel.Name = "serialNumberLabel";
            this.serialNumberLabel.Size = new System.Drawing.Size(50, 13);
            this.serialNumberLabel.TabIndex = 3;
            this.serialNumberLabel.Text = "מס''ד:";

            // serialNumberTextBox
            this.serialNumberTextBox.Location = new System.Drawing.Point(200, 110);
            this.serialNumberTextBox.Name = "serialNumberTextBox";
            this.serialNumberTextBox.Size = new System.Drawing.Size(110, 20);
            this.serialNumberTextBox.TabIndex = 4;

            // addButton
            this.addButton.Location = new System.Drawing.Point(240, 160);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(70, 25);
            this.addButton.TabIndex = 5;
            this.addButton.Text = "הוסף";
            this.addButton.Click += new System.EventHandler(this.addButton_Click);

            // cancelButton
            this.cancelButton.Location = new System.Drawing.Point(160, 160);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(70, 25);
            this.cancelButton.TabIndex = 6;
            this.cancelButton.Text = "ביטול";
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);

            // AddInstanceDialog
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 210);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.equipmentLabel);
            this.Controls.Add(this.equipmentNameLabel);
            this.Controls.Add(this.serialNumberLabel);
            this.Controls.Add(this.serialNumberTextBox);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.cancelButton);
            this.Name = "AddInstanceDialog";
            this.Text = "הוסף יחידה";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

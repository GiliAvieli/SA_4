namespace SmartShevet
{
    partial class WarehouseStaffMemberHomePanel
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button manageEquipmentButton;
        private System.Windows.Forms.Button giveEquipmentButton;
        private System.Windows.Forms.Button returnEquipmentButton;
        private System.Windows.Forms.Button manageStatusButton;

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
            this.manageEquipmentButton = new System.Windows.Forms.Button();
            this.giveEquipmentButton = new System.Windows.Forms.Button();
            this.returnEquipmentButton = new System.Windows.Forms.Button();
            this.manageStatusButton = new System.Windows.Forms.Button();
            this.SuspendLayout();

            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.titleLabel.Location = new System.Drawing.Point(200, 20);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(100, 22);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "צוות מחסן";

            this.backButton.Location = new System.Drawing.Point(20, 20);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(75, 23);
            this.backButton.TabIndex = 1;
            this.backButton.Text = "חזרה";
            this.backButton.Click += new System.EventHandler(this.backButton_Click);

            this.manageEquipmentButton.Location = new System.Drawing.Point(200, 100);
            this.manageEquipmentButton.Name = "manageEquipmentButton";
            this.manageEquipmentButton.Size = new System.Drawing.Size(150, 40);
            this.manageEquipmentButton.TabIndex = 2;
            this.manageEquipmentButton.Text = "ניהול ציוד";
            this.manageEquipmentButton.Click += new System.EventHandler(this.manageEquipmentButton_Click);

            this.giveEquipmentButton.Location = new System.Drawing.Point(200, 160);
            this.giveEquipmentButton.Name = "giveEquipmentButton";
            this.giveEquipmentButton.Size = new System.Drawing.Size(150, 40);
            this.giveEquipmentButton.TabIndex = 3;
            this.giveEquipmentButton.Text = "הנפקת ציוד";
            this.giveEquipmentButton.Click += new System.EventHandler(this.giveEquipmentButton_Click);

            this.returnEquipmentButton.Location = new System.Drawing.Point(200, 220);
            this.returnEquipmentButton.Name = "returnEquipmentButton";
            this.returnEquipmentButton.Size = new System.Drawing.Size(150, 40);
            this.returnEquipmentButton.TabIndex = 4;
            this.returnEquipmentButton.Text = "החזרת ציוד";
            this.returnEquipmentButton.Click += new System.EventHandler(this.returnEquipmentButton_Click);

            this.manageStatusButton.Location = new System.Drawing.Point(200, 280);
            this.manageStatusButton.Name = "manageStatusButton";
            this.manageStatusButton.Size = new System.Drawing.Size(150, 40);
            this.manageStatusButton.TabIndex = 5;
            this.manageStatusButton.Text = "ניהול סטטוס";
            this.manageStatusButton.Click += new System.EventHandler(this.manageStatusButton_Click);

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.manageEquipmentButton);
            this.Controls.Add(this.giveEquipmentButton);
            this.Controls.Add(this.returnEquipmentButton);
            this.Controls.Add(this.manageStatusButton);
            this.Name = "WarehouseStaffMemberHomePanel";
            this.Size = new System.Drawing.Size(800, 600);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

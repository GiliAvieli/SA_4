namespace SmartShevet
{
    partial class SeniorCoordinatorHomePanel
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button approveReservationsButton;
        private System.Windows.Forms.Button viewEquipmentStatusButton;
        private System.Windows.Forms.Button manageReservationsButton;
        private System.Windows.Forms.Button inventoryForecastButton;

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
            this.approveReservationsButton = new System.Windows.Forms.Button();
            this.viewEquipmentStatusButton = new System.Windows.Forms.Button();
            this.manageReservationsButton = new System.Windows.Forms.Button();
            this.inventoryForecastButton = new System.Windows.Forms.Button();
            this.SuspendLayout();

            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.titleLabel.Location = new System.Drawing.Point(200, 20);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(150, 22);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "קואורדינטור בכיר";

            this.backButton.Location = new System.Drawing.Point(20, 20);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(75, 23);
            this.backButton.TabIndex = 1;
            this.backButton.Text = "חזרה";
            this.backButton.Click += new System.EventHandler(this.backButton_Click);

            this.approveReservationsButton.Location = new System.Drawing.Point(200, 100);
            this.approveReservationsButton.Name = "approveReservationsButton";
            this.approveReservationsButton.Size = new System.Drawing.Size(150, 40);
            this.approveReservationsButton.TabIndex = 2;
            this.approveReservationsButton.Text = "אישור הזמנות";
            this.approveReservationsButton.Click += new System.EventHandler(this.approveReservationsButton_Click);

            this.viewEquipmentStatusButton.Location = new System.Drawing.Point(200, 160);
            this.viewEquipmentStatusButton.Name = "viewEquipmentStatusButton";
            this.viewEquipmentStatusButton.Size = new System.Drawing.Size(150, 40);
            this.viewEquipmentStatusButton.TabIndex = 3;
            this.viewEquipmentStatusButton.Text = "ניהול סטטוס ציוד";
            this.viewEquipmentStatusButton.Click += new System.EventHandler(this.viewEquipmentStatusButton_Click);

            this.manageReservationsButton.Location = new System.Drawing.Point(200, 220);
            this.manageReservationsButton.Name = "manageReservationsButton";
            this.manageReservationsButton.Size = new System.Drawing.Size(150, 40);
            this.manageReservationsButton.TabIndex = 4;
            this.manageReservationsButton.Text = "ניהול הזמנות";
            this.manageReservationsButton.Click += new System.EventHandler(this.manageReservationsButton_Click);

            this.inventoryForecastButton.Location = new System.Drawing.Point(200, 280);
            this.inventoryForecastButton.Name = "inventoryForecastButton";
            this.inventoryForecastButton.Size = new System.Drawing.Size(150, 40);
            this.inventoryForecastButton.TabIndex = 5;
            this.inventoryForecastButton.Text = "דוח ניבוי מלאי";
            this.inventoryForecastButton.Click += new System.EventHandler(this.inventoryForecastButton_Click);

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.approveReservationsButton);
            this.Controls.Add(this.viewEquipmentStatusButton);
            this.Controls.Add(this.manageReservationsButton);
            this.Controls.Add(this.inventoryForecastButton);
            this.Name = "SeniorCoordinatorHomePanel";
            this.Size = new System.Drawing.Size(800, 600);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

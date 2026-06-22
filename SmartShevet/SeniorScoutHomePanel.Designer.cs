namespace SmartShevet
{
    partial class SeniorScoutHomePanel
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button requestEquipmentButton;

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
            this.requestEquipmentButton = new System.Windows.Forms.Button();
            this.SuspendLayout();

            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.titleLabel.Location = new System.Drawing.Point(200, 20);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(100, 22);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "סקאוט בכיר";

            this.backButton.Location = new System.Drawing.Point(20, 20);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(75, 23);
            this.backButton.TabIndex = 1;
            this.backButton.Text = "חזרה";
            this.backButton.Click += new System.EventHandler(this.backButton_Click);

            this.requestEquipmentButton.Location = new System.Drawing.Point(200, 100);
            this.requestEquipmentButton.Name = "requestEquipmentButton";
            this.requestEquipmentButton.Size = new System.Drawing.Size(150, 40);
            this.requestEquipmentButton.TabIndex = 2;
            this.requestEquipmentButton.Text = "בקשת ציוד";
            this.requestEquipmentButton.Click += new System.EventHandler(this.requestEquipmentButton_Click);

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.requestEquipmentButton);
            this.Name = "SeniorScoutHomePanel";
            this.Size = new System.Drawing.Size(800, 600);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

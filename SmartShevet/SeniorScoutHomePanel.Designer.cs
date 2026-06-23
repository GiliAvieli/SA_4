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

            // titleLabel - Modern Dashboard Style
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.titleLabel.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39);  // #111827
            this.titleLabel.Location = new System.Drawing.Point(480, 25);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(300, 40);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "צופה בוגר";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;

            // backButton - Secondary Action
            this.backButton.Location = new System.Drawing.Point(20, 25);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(80, 32);
            this.backButton.TabIndex = 1;
            this.backButton.Text = "חזרה";
            this.backButton.BackColor = System.Drawing.Color.White;
            this.backButton.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39);  // #111827
            this.backButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(229, 231, 235);  // #E5E7EB
            this.backButton.FlatAppearance.BorderSize = 1;
            this.backButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.backButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);

            // requestEquipmentButton - Navigation Tile
            this.requestEquipmentButton.Location = new System.Drawing.Point(260, 150);
            this.requestEquipmentButton.Name = "requestEquipmentButton";
            this.requestEquipmentButton.Size = new System.Drawing.Size(280, 55);
            this.requestEquipmentButton.TabIndex = 2;
            this.requestEquipmentButton.Text = "בקשת ציוד";
            this.requestEquipmentButton.BackColor = System.Drawing.Color.White;  // #FFFFFF
            this.requestEquipmentButton.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39);  // #111827
            this.requestEquipmentButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.requestEquipmentButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(128, 0, 32);  // #800020 Burgundy
            this.requestEquipmentButton.FlatAppearance.BorderSize = 2;
            this.requestEquipmentButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.requestEquipmentButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.requestEquipmentButton.Click += new System.EventHandler(this.requestEquipmentButton_Click);

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(250, 249, 246);  // #FAF9F6 (Off-white)
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

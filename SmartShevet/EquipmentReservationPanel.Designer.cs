namespace SmartShevet
{
    partial class EquipmentReservationPanel
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Label activityDateLabel;
        private System.Windows.Forms.DateTimePicker activityDatePicker;
        private System.Windows.Forms.Label catalogLabel;
        private System.Windows.Forms.DataGridView catalogGridView;
        private System.Windows.Forms.Button finishOrderButton;

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
            this.activityDateLabel = new System.Windows.Forms.Label();
            this.activityDatePicker = new System.Windows.Forms.DateTimePicker();
            this.catalogLabel = new System.Windows.Forms.Label();
            this.catalogGridView = new System.Windows.Forms.DataGridView();
            this.finishOrderButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.catalogGridView)).BeginInit();
            this.SuspendLayout();

            // Title - Modern Typography (Larger for Visual Hierarchy)
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.titleLabel.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39);  // #111827 (Dark Gray)
            this.titleLabel.Location = new System.Drawing.Point(680, 15);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(100, 25);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "הזמנת ציוד";

            // Back Button - Modern Flat Style
            this.backButton.Location = new System.Drawing.Point(20, 15);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(75, 30);
            this.backButton.TabIndex = 1;
            this.backButton.Text = "חזרה";
            this.backButton.BackColor = System.Drawing.Color.White;
            this.backButton.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39);  // #111827
            this.backButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(229, 231, 235);  // #E5E7EB
            this.backButton.FlatAppearance.BorderSize = 1;
            this.backButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.backButton.Click += new System.EventHandler(this.backButton_Click);

            // Activity Date Label - Modern Typography
            this.activityDateLabel.AutoSize = true;
            this.activityDateLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.activityDateLabel.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39);  // #111827
            this.activityDateLabel.Location = new System.Drawing.Point(650, 60);
            this.activityDateLabel.Name = "activityDateLabel";
            this.activityDateLabel.Size = new System.Drawing.Size(120, 17);
            this.activityDateLabel.TabIndex = 2;
            this.activityDateLabel.Text = "תאריך פעילות:";

            // Activity Date Picker - White Background
            this.activityDatePicker.Location = new System.Drawing.Point(450, 58);
            this.activityDatePicker.Name = "activityDatePicker";
            this.activityDatePicker.Size = new System.Drawing.Size(180, 20);
            this.activityDatePicker.TabIndex = 3;
            this.activityDatePicker.Value = System.DateTime.Now.AddDays(1);
            this.activityDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.activityDatePicker.BackColor = System.Drawing.Color.White;
            this.activityDatePicker.CalendarForeColor = System.Drawing.Color.FromArgb(17, 24, 39);

            // Catalog Label - Modern Typography
            this.catalogLabel.AutoSize = true;
            this.catalogLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.catalogLabel.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39);  // #111827
            this.catalogLabel.Location = new System.Drawing.Point(700, 95);
            this.catalogLabel.Name = "catalogLabel";
            this.catalogLabel.Size = new System.Drawing.Size(80, 17);
            this.catalogLabel.TabIndex = 4;
            this.catalogLabel.Text = "קטלוג ציוד:";

            // Catalog Grid View - MODERN STYLING
            this.catalogGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.catalogGridView.ColumnHeadersHeight = 35;  // Increased header height
            this.catalogGridView.RowTemplate.Height = 30;  // Increased row height for padding
            this.catalogGridView.Location = new System.Drawing.Point(20, 120);
            this.catalogGridView.Name = "catalogGridView";
            this.catalogGridView.Size = new System.Drawing.Size(760, 350);
            this.catalogGridView.TabIndex = 5;
            this.catalogGridView.BackgroundColor = System.Drawing.Color.White;  // #FFFFFF
            this.catalogGridView.GridColor = System.Drawing.Color.FromArgb(229, 231, 235);  // #E5E7EB (row dividers)
            this.catalogGridView.EnableHeadersVisualStyles = false;  // CRITICAL for custom header colors
            this.catalogGridView.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(114, 47, 55);  // #722F37 (Rich Burgundy)
            this.catalogGridView.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.catalogGridView.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.catalogGridView.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.catalogGridView.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39);  // #111827
            this.catalogGridView.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.catalogGridView.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(255, 243, 224);  // Light peach
            this.catalogGridView.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(17, 24, 39);
            this.catalogGridView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.catalogGridView.RightToLeft = System.Windows.Forms.RightToLeft.Yes;

            // Finish Order Button - PRIMARY ACTION (Red CTA)
            this.finishOrderButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.finishOrderButton.Location = new System.Drawing.Point(300, 490);
            this.finishOrderButton.Name = "finishOrderButton";
            this.finishOrderButton.Size = new System.Drawing.Size(200, 40);
            this.finishOrderButton.TabIndex = 6;
            this.finishOrderButton.Text = "סיים הזמנה";
            this.finishOrderButton.BackColor = System.Drawing.Color.FromArgb(114, 47, 55);  // #722F37 (Rich Burgundy)
            this.finishOrderButton.ForeColor = System.Drawing.Color.White;  // #FFFFFF
            this.finishOrderButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.finishOrderButton.FlatAppearance.BorderSize = 0;
            this.finishOrderButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.finishOrderButton.Click += new System.EventHandler(this.finishOrderButton_Click);

            // Panel Properties - Lighter, Airier Off-White Background
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(250, 249, 246);  // #FAF9F6 (Lighter, airier off-white)
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.activityDateLabel);
            this.Controls.Add(this.activityDatePicker);
            this.Controls.Add(this.catalogLabel);
            this.Controls.Add(this.catalogGridView);
            this.Controls.Add(this.finishOrderButton);
            this.Name = "EquipmentReservationPanel";
            this.Size = new System.Drawing.Size(800, 550);
            ((System.ComponentModel.ISupportInitialize)(this.catalogGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

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

            // Title
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.titleLabel.Location = new System.Drawing.Point(680, 15);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(100, 25);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "הזמנת ציוד";

            // Back Button
            this.backButton.Location = new System.Drawing.Point(20, 15);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(75, 30);
            this.backButton.TabIndex = 1;
            this.backButton.Text = "חזרה";
            this.backButton.Click += new System.EventHandler(this.backButton_Click);

            // Activity Date Label
            this.activityDateLabel.AutoSize = true;
            this.activityDateLabel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.activityDateLabel.Location = new System.Drawing.Point(650, 60);
            this.activityDateLabel.Name = "activityDateLabel";
            this.activityDateLabel.Size = new System.Drawing.Size(120, 17);
            this.activityDateLabel.TabIndex = 2;
            this.activityDateLabel.Text = "תאריך פעילות:";

            // Activity Date Picker
            this.activityDatePicker.Location = new System.Drawing.Point(450, 58);
            this.activityDatePicker.Name = "activityDatePicker";
            this.activityDatePicker.Size = new System.Drawing.Size(180, 20);
            this.activityDatePicker.TabIndex = 3;
            this.activityDatePicker.Value = System.DateTime.Now.AddDays(1);
            this.activityDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;

            // Catalog Label
            this.catalogLabel.AutoSize = true;
            this.catalogLabel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.catalogLabel.Location = new System.Drawing.Point(700, 95);
            this.catalogLabel.Name = "catalogLabel";
            this.catalogLabel.Size = new System.Drawing.Size(80, 17);
            this.catalogLabel.TabIndex = 4;
            this.catalogLabel.Text = "קטלוג ציוד:";

            // Catalog Grid View
            this.catalogGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.catalogGridView.Location = new System.Drawing.Point(20, 120);
            this.catalogGridView.Name = "catalogGridView";
            this.catalogGridView.Size = new System.Drawing.Size(760, 350);
            this.catalogGridView.TabIndex = 5;
            this.catalogGridView.RightToLeft = System.Windows.Forms.RightToLeft.Yes;

            // Finish Order Button
            this.finishOrderButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.finishOrderButton.Location = new System.Drawing.Point(300, 490);
            this.finishOrderButton.Name = "finishOrderButton";
            this.finishOrderButton.Size = new System.Drawing.Size(200, 40);
            this.finishOrderButton.TabIndex = 6;
            this.finishOrderButton.Text = "סיים הזמנה";
            this.finishOrderButton.Click += new System.EventHandler(this.finishOrderButton_Click);

            // Panel Properties
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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

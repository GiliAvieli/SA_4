namespace SmartShevet
{
    partial class AnnualInventoryForecastReportPanel
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Label startDateLabel;
        private System.Windows.Forms.DateTimePicker startDatePicker;
        private System.Windows.Forms.Label endDateLabel;
        private System.Windows.Forms.DateTimePicker endDatePicker;
        private System.Windows.Forms.Label categoryLabel;
        private System.Windows.Forms.ComboBox categoryComboBox;
        private System.Windows.Forms.Button generateReportButton;
        private System.Windows.Forms.Label consumablesLabel;
        private System.Windows.Forms.DataGridView consumablesDataGridView;
        private System.Windows.Forms.Label unretrurnedLabel;
        private System.Windows.Forms.DataGridView unretrurnedDataGridView;
        private System.Windows.Forms.Label damagedLabel;
        private System.Windows.Forms.DataGridView damagedDataGridView;
        private System.Windows.Forms.Label totalsLabel;
        private System.Windows.Forms.DataGridView totalsDataGridView;
        private System.Windows.Forms.Button exportButton;

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
            this.startDateLabel = new System.Windows.Forms.Label();
            this.startDatePicker = new System.Windows.Forms.DateTimePicker();
            this.endDateLabel = new System.Windows.Forms.Label();
            this.endDatePicker = new System.Windows.Forms.DateTimePicker();
            this.categoryLabel = new System.Windows.Forms.Label();
            this.categoryComboBox = new System.Windows.Forms.ComboBox();
            this.generateReportButton = new System.Windows.Forms.Button();
            this.consumablesLabel = new System.Windows.Forms.Label();
            this.consumablesDataGridView = new System.Windows.Forms.DataGridView();
            this.unretrurnedLabel = new System.Windows.Forms.Label();
            this.unretrurnedDataGridView = new System.Windows.Forms.DataGridView();
            this.damagedLabel = new System.Windows.Forms.Label();
            this.damagedDataGridView = new System.Windows.Forms.DataGridView();
            this.totalsLabel = new System.Windows.Forms.Label();
            this.totalsDataGridView = new System.Windows.Forms.DataGridView();
            this.exportButton = new System.Windows.Forms.Button();
            this.SuspendLayout();

            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.titleLabel.Location = new System.Drawing.Point(680, 10);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(100, 22);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "דוח ניבוי מלאי";

            this.backButton.Location = new System.Drawing.Point(20, 10);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(75, 23);
            this.backButton.TabIndex = 1;
            this.backButton.Text = "חזרה";
            this.backButton.Click += new System.EventHandler(this.backButton_Click);

            int y = 50;
            int labelX = 680;
            int controlX = 400;

            this.startDateLabel.AutoSize = true;
            this.startDateLabel.Location = new System.Drawing.Point(labelX, y);
            this.startDateLabel.Name = "startDateLabel";
            this.startDateLabel.Size = new System.Drawing.Size(60, 13);
            this.startDateLabel.TabIndex = 2;
            this.startDateLabel.Text = "תאריך התחלה";

            this.startDatePicker.Location = new System.Drawing.Point(controlX, y);
            this.startDatePicker.Name = "startDatePicker";
            this.startDatePicker.Size = new System.Drawing.Size(200, 20);
            this.startDatePicker.TabIndex = 3;

            y += 30;

            this.endDateLabel.AutoSize = true;
            this.endDateLabel.Location = new System.Drawing.Point(labelX, y);
            this.endDateLabel.Name = "endDateLabel";
            this.endDateLabel.Size = new System.Drawing.Size(50, 13);
            this.endDateLabel.TabIndex = 4;
            this.endDateLabel.Text = "תאריך סיום";

            this.endDatePicker.Location = new System.Drawing.Point(controlX, y);
            this.endDatePicker.Name = "endDatePicker";
            this.endDatePicker.Size = new System.Drawing.Size(200, 20);
            this.endDatePicker.TabIndex = 5;

            y += 30;

            this.categoryLabel.AutoSize = true;
            this.categoryLabel.Location = new System.Drawing.Point(labelX, y);
            this.categoryLabel.Name = "categoryLabel";
            this.categoryLabel.Size = new System.Drawing.Size(40, 13);
            this.categoryLabel.TabIndex = 6;
            this.categoryLabel.Text = "קטגוריה";

            this.categoryComboBox.Location = new System.Drawing.Point(controlX, y);
            this.categoryComboBox.Name = "categoryComboBox";
            this.categoryComboBox.Size = new System.Drawing.Size(200, 20);
            this.categoryComboBox.TabIndex = 7;

            y += 30;

            this.generateReportButton.Location = new System.Drawing.Point(controlX, y);
            this.generateReportButton.Name = "generateReportButton";
            this.generateReportButton.Size = new System.Drawing.Size(100, 30);
            this.generateReportButton.TabIndex = 8;
            this.generateReportButton.Text = "דור דוח";
            this.generateReportButton.Click += new System.EventHandler(this.generateReportButton_Click);

            this.exportButton.Location = new System.Drawing.Point(controlX + 110, y);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(100, 30);
            this.exportButton.TabIndex = 9;
            this.exportButton.Text = "ייצוא";
            this.exportButton.Enabled = false;

            y += 50;

            this.consumablesLabel.AutoSize = true;
            this.consumablesLabel.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.consumablesLabel.Location = new System.Drawing.Point(labelX, y);
            this.consumablesLabel.Name = "consumablesLabel";
            this.consumablesLabel.Size = new System.Drawing.Size(120, 16);
            this.consumablesLabel.TabIndex = 10;
            this.consumablesLabel.Text = "ניתוח צריכת צריך";

            y += 25;

            this.consumablesDataGridView.Location = new System.Drawing.Point(20, y);
            this.consumablesDataGridView.Name = "consumablesDataGridView";
            this.consumablesDataGridView.Size = new System.Drawing.Size(760, 100);
            this.consumablesDataGridView.TabIndex = 11;

            y += 110;

            this.unretrurnedLabel.AutoSize = true;
            this.unretrurnedLabel.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.unretrurnedLabel.Location = new System.Drawing.Point(labelX, y);
            this.unretrurnedLabel.Name = "unretrurnedLabel";
            this.unretrurnedLabel.Size = new System.Drawing.Size(130, 16);
            this.unretrurnedLabel.TabIndex = 12;
            this.unretrurnedLabel.Text = "ציוד שלא הוחזר";

            y += 25;

            this.unretrurnedDataGridView.Location = new System.Drawing.Point(20, y);
            this.unretrurnedDataGridView.Name = "unretrurnedDataGridView";
            this.unretrurnedDataGridView.Size = new System.Drawing.Size(760, 100);
            this.unretrurnedDataGridView.TabIndex = 13;

            y += 110;

            this.damagedLabel.AutoSize = true;
            this.damagedLabel.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.damagedLabel.Location = new System.Drawing.Point(labelX, y);
            this.damagedLabel.Name = "damagedLabel";
            this.damagedLabel.Size = new System.Drawing.Size(100, 16);
            this.damagedLabel.TabIndex = 14;
            this.damagedLabel.Text = "ציוד פגום/אבוד";

            y += 25;

            this.damagedDataGridView.Location = new System.Drawing.Point(20, y);
            this.damagedDataGridView.Name = "damagedDataGridView";
            this.damagedDataGridView.Size = new System.Drawing.Size(760, 80);
            this.damagedDataGridView.TabIndex = 15;

            y += 90;

            this.totalsLabel.AutoSize = true;
            this.totalsLabel.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.totalsLabel.Location = new System.Drawing.Point(labelX, y);
            this.totalsLabel.Name = "totalsLabel";
            this.totalsLabel.Size = new System.Drawing.Size(100, 16);
            this.totalsLabel.TabIndex = 16;
            this.totalsLabel.Text = "סה\"כ תקציב";

            y += 25;

            this.totalsDataGridView.Location = new System.Drawing.Point(20, y);
            this.totalsDataGridView.Name = "totalsDataGridView";
            this.totalsDataGridView.Size = new System.Drawing.Size(760, 80);
            this.totalsDataGridView.TabIndex = 17;

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.startDateLabel);
            this.Controls.Add(this.startDatePicker);
            this.Controls.Add(this.endDateLabel);
            this.Controls.Add(this.endDatePicker);
            this.Controls.Add(this.categoryLabel);
            this.Controls.Add(this.categoryComboBox);
            this.Controls.Add(this.generateReportButton);
            this.Controls.Add(this.exportButton);
            this.Controls.Add(this.consumablesLabel);
            this.Controls.Add(this.consumablesDataGridView);
            this.Controls.Add(this.unretrurnedLabel);
            this.Controls.Add(this.unretrurnedDataGridView);
            this.Controls.Add(this.damagedLabel);
            this.Controls.Add(this.damagedDataGridView);
            this.Controls.Add(this.totalsLabel);
            this.Controls.Add(this.totalsDataGridView);
            this.Name = "AnnualInventoryForecastReportPanel";
            this.Size = new System.Drawing.Size(800, 900);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

namespace SmartShevet
{
    partial class AnnualInventoryForecastReportPanel
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Panel filterPanel;
        private System.Windows.Forms.Label startDateLabel;
        private System.Windows.Forms.DateTimePicker startDatePicker;
        private System.Windows.Forms.Label endDateLabel;
        private System.Windows.Forms.DateTimePicker endDatePicker;
        private System.Windows.Forms.Label categoryLabel;
        private System.Windows.Forms.ComboBox categoryComboBox;
        private System.Windows.Forms.Button generateReportButton;
        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.Panel consumablesCardPanel;
        private System.Windows.Forms.Label consumablesLabel;
        private System.Windows.Forms.DataGridView consumablesDataGridView;
        private System.Windows.Forms.Panel unretrurnedCardPanel;
        private System.Windows.Forms.Label unretrurnedLabel;
        private System.Windows.Forms.DataGridView unretrurnedDataGridView;
        private System.Windows.Forms.Panel damagedCardPanel;
        private System.Windows.Forms.Label damagedLabel;
        private System.Windows.Forms.DataGridView damagedDataGridView;
        private System.Windows.Forms.Panel totalsCardPanel;
        private System.Windows.Forms.Label totalsLabel;
        public System.Windows.Forms.DataGridView totalsDataGridView;

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
            this.filterPanel = new System.Windows.Forms.Panel();
            this.startDateLabel = new System.Windows.Forms.Label();
            this.startDatePicker = new System.Windows.Forms.DateTimePicker();
            this.endDateLabel = new System.Windows.Forms.Label();
            this.endDatePicker = new System.Windows.Forms.DateTimePicker();
            this.categoryLabel = new System.Windows.Forms.Label();
            this.categoryComboBox = new System.Windows.Forms.ComboBox();
            this.generateReportButton = new System.Windows.Forms.Button();
            this.exportButton = new System.Windows.Forms.Button();
            this.consumablesCardPanel = new System.Windows.Forms.Panel();
            this.consumablesLabel = new System.Windows.Forms.Label();
            this.consumablesDataGridView = new System.Windows.Forms.DataGridView();
            this.unretrurnedCardPanel = new System.Windows.Forms.Panel();
            this.unretrurnedLabel = new System.Windows.Forms.Label();
            this.unretrurnedDataGridView = new System.Windows.Forms.DataGridView();
            this.damagedCardPanel = new System.Windows.Forms.Panel();
            this.damagedLabel = new System.Windows.Forms.Label();
            this.damagedDataGridView = new System.Windows.Forms.DataGridView();
            this.totalsCardPanel = new System.Windows.Forms.Panel();
            this.totalsLabel = new System.Windows.Forms.Label();
            this.totalsDataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.consumablesDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.unretrurnedDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.damagedDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.totalsDataGridView)).BeginInit();
            this.filterPanel.SuspendLayout();
            this.consumablesCardPanel.SuspendLayout();
            this.unretrurnedCardPanel.SuspendLayout();
            this.damagedCardPanel.SuspendLayout();
            this.totalsCardPanel.SuspendLayout();
            this.SuspendLayout();

            // ========== HEADER ROW (Title & Back Button) ==========
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.titleLabel.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39);
            this.titleLabel.Location = new System.Drawing.Point(680, 10);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Text = "דוח ניבוי מלאי";
            this.titleLabel.TabIndex = 0;

            this.backButton.Location = new System.Drawing.Point(20, 10);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(75, 30);
            this.backButton.Text = "חזרה";
            this.backButton.BackColor = System.Drawing.Color.White;
            this.backButton.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39);
            this.backButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(229, 231, 235);
            this.backButton.FlatAppearance.BorderSize = 1;
            this.backButton.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.backButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.backButton.TabIndex = 1;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);

            // ========== FILTER PANEL (TOP CONTAINER) ==========
            this.filterPanel.BackColor = System.Drawing.Color.White;
            this.filterPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.filterPanel.Location = new System.Drawing.Point(20, 50);
            this.filterPanel.Name = "filterPanel";
            this.filterPanel.Size = new System.Drawing.Size(780, 140);
            this.filterPanel.TabIndex = 2;
            this.filterPanel.Padding = new System.Windows.Forms.Padding(15);
            this.filterPanel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.filterPanel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;

            // FILTER CONTROLS - RIGHT SIDE
            this.startDateLabel.AutoSize = false;
            this.startDateLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.startDateLabel.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39);
            this.startDateLabel.Location = new System.Drawing.Point(650, 15);
            this.startDateLabel.Size = new System.Drawing.Size(100, 23);
            this.startDateLabel.Text = "תאריך התחלה";
            this.startDateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.startDateLabel.TabIndex = 2;

            this.startDatePicker.BackColor = System.Drawing.Color.White;
            this.startDatePicker.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.startDatePicker.Location = new System.Drawing.Point(350, 15);
            this.startDatePicker.Size = new System.Drawing.Size(280, 25);
            this.startDatePicker.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.startDatePicker.TabIndex = 3;

            this.endDateLabel.AutoSize = false;
            this.endDateLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.endDateLabel.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39);
            this.endDateLabel.Location = new System.Drawing.Point(650, 50);
            this.endDateLabel.Size = new System.Drawing.Size(100, 23);
            this.endDateLabel.Text = "תאריך סיום";
            this.endDateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.endDateLabel.TabIndex = 4;

            this.endDatePicker.BackColor = System.Drawing.Color.White;
            this.endDatePicker.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.endDatePicker.Location = new System.Drawing.Point(350, 50);
            this.endDatePicker.Size = new System.Drawing.Size(280, 25);
            this.endDatePicker.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.endDatePicker.TabIndex = 5;

            this.categoryLabel.AutoSize = false;
            this.categoryLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.categoryLabel.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39);
            this.categoryLabel.Location = new System.Drawing.Point(650, 85);
            this.categoryLabel.Size = new System.Drawing.Size(100, 23);
            this.categoryLabel.Text = "קטגוריה";
            this.categoryLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.categoryLabel.TabIndex = 6;

            this.categoryComboBox.BackColor = System.Drawing.Color.White;
            this.categoryComboBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.categoryComboBox.Location = new System.Drawing.Point(420, 85);
            this.categoryComboBox.Size = new System.Drawing.Size(210, 23);
            this.categoryComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.categoryComboBox.TabIndex = 7;

            // ACTION BUTTONS - LEFT SIDE
            this.generateReportButton.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.generateReportButton.Location = new System.Drawing.Point(50, 30);
            this.generateReportButton.Size = new System.Drawing.Size(120, 40);
            this.generateReportButton.Text = "צור דוח";
            this.generateReportButton.BackColor = System.Drawing.Color.FromArgb(128, 0, 32);
            this.generateReportButton.ForeColor = System.Drawing.Color.White;
            this.generateReportButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.generateReportButton.FlatAppearance.BorderSize = 0;
            this.generateReportButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.generateReportButton.TabIndex = 8;
            this.generateReportButton.Click += new System.EventHandler(this.generateReportButton_Click);

            this.exportButton.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.exportButton.Location = new System.Drawing.Point(185, 30);
            this.exportButton.Size = new System.Drawing.Size(120, 40);
            this.exportButton.Text = "ייצוא";
            this.exportButton.BackColor = System.Drawing.Color.White;
            this.exportButton.ForeColor = System.Drawing.Color.FromArgb(128, 0, 32);
            this.exportButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exportButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(128, 0, 32);
            this.exportButton.FlatAppearance.BorderSize = 2;
            this.exportButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exportButton.Enabled = false;
            this.exportButton.TabIndex = 9;

            // Add filter controls to filterPanel
            this.filterPanel.Controls.Add(this.startDateLabel);
            this.filterPanel.Controls.Add(this.startDatePicker);
            this.filterPanel.Controls.Add(this.endDateLabel);
            this.filterPanel.Controls.Add(this.endDatePicker);
            this.filterPanel.Controls.Add(this.categoryLabel);
            this.filterPanel.Controls.Add(this.categoryComboBox);
            this.filterPanel.Controls.Add(this.generateReportButton);
            this.filterPanel.Controls.Add(this.exportButton);

            // ========== TABLE 1: CONSUMABLES (ניתוח צריכת מלאי) ==========
            this.consumablesCardPanel.BackColor = System.Drawing.Color.White;
            this.consumablesCardPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.consumablesCardPanel.Location = new System.Drawing.Point(20, 200);
            this.consumablesCardPanel.Name = "consumablesCardPanel";
            this.consumablesCardPanel.Size = new System.Drawing.Size(780, 170);
            this.consumablesCardPanel.Padding = new System.Windows.Forms.Padding(15);
            this.consumablesCardPanel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.consumablesCardPanel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.consumablesCardPanel.TabIndex = 10;

            this.consumablesLabel.AutoSize = false;
            this.consumablesLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.consumablesLabel.ForeColor = System.Drawing.Color.FromArgb(128, 0, 32);
            this.consumablesLabel.Location = new System.Drawing.Point(20, 10);
            this.consumablesLabel.Size = new System.Drawing.Size(740, 21);
            this.consumablesLabel.Text = "ניתוח צריכת מלאי";
            this.consumablesLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.consumablesLabel.TabIndex = 10;

            this.consumablesDataGridView.Location = new System.Drawing.Point(15, 35);
            this.consumablesDataGridView.Name = "consumablesDataGridView";
            this.consumablesDataGridView.Size = new System.Drawing.Size(750, 120);
            this.consumablesDataGridView.ReadOnly = true;
            this.consumablesDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.consumablesDataGridView.GridColor = System.Drawing.Color.FromArgb(229, 231, 235);
            this.consumablesDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.consumablesDataGridView.EnableHeadersVisualStyles = false;
            this.consumablesDataGridView.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(128, 0, 32);
            this.consumablesDataGridView.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.consumablesDataGridView.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.consumablesDataGridView.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.consumablesDataGridView.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39);
            this.consumablesDataGridView.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.consumablesDataGridView.TabIndex = 11;

            this.consumablesCardPanel.Controls.Add(this.consumablesLabel);
            this.consumablesCardPanel.Controls.Add(this.consumablesDataGridView);

            // ========== TABLE 2: UNRETURNED (ציוד שלא הוחזר) ==========
            this.unretrurnedCardPanel.BackColor = System.Drawing.Color.White;
            this.unretrurnedCardPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.unretrurnedCardPanel.Location = new System.Drawing.Point(20, 380);
            this.unretrurnedCardPanel.Name = "unretrurnedCardPanel";
            this.unretrurnedCardPanel.Size = new System.Drawing.Size(780, 170);
            this.unretrurnedCardPanel.Padding = new System.Windows.Forms.Padding(15);
            this.unretrurnedCardPanel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.unretrurnedCardPanel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.unretrurnedCardPanel.TabIndex = 12;

            this.unretrurnedLabel.AutoSize = false;
            this.unretrurnedLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.unretrurnedLabel.ForeColor = System.Drawing.Color.FromArgb(128, 0, 32);
            this.unretrurnedLabel.Location = new System.Drawing.Point(20, 10);
            this.unretrurnedLabel.Size = new System.Drawing.Size(740, 21);
            this.unretrurnedLabel.Text = "ציוד שלא הוחזר";
            this.unretrurnedLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.unretrurnedLabel.TabIndex = 12;

            this.unretrurnedDataGridView.Location = new System.Drawing.Point(15, 35);
            this.unretrurnedDataGridView.Name = "unretrurnedDataGridView";
            this.unretrurnedDataGridView.Size = new System.Drawing.Size(750, 120);
            this.unretrurnedDataGridView.ReadOnly = true;
            this.unretrurnedDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.unretrurnedDataGridView.GridColor = System.Drawing.Color.FromArgb(229, 231, 235);
            this.unretrurnedDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.unretrurnedDataGridView.EnableHeadersVisualStyles = false;
            this.unretrurnedDataGridView.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(128, 0, 32);
            this.unretrurnedDataGridView.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.unretrurnedDataGridView.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.unretrurnedDataGridView.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.unretrurnedDataGridView.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39);
            this.unretrurnedDataGridView.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.unretrurnedDataGridView.TabIndex = 13;

            this.unretrurnedCardPanel.Controls.Add(this.unretrurnedLabel);
            this.unretrurnedCardPanel.Controls.Add(this.unretrurnedDataGridView);

            // ========== TABLE 3: DAMAGED/MISSING (ציוד פגום/אבוד) ==========
            this.damagedCardPanel.BackColor = System.Drawing.Color.White;
            this.damagedCardPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.damagedCardPanel.Location = new System.Drawing.Point(20, 560);
            this.damagedCardPanel.Name = "damagedCardPanel";
            this.damagedCardPanel.Size = new System.Drawing.Size(780, 170);
            this.damagedCardPanel.Padding = new System.Windows.Forms.Padding(15);
            this.damagedCardPanel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.damagedCardPanel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.damagedCardPanel.TabIndex = 14;

            this.damagedLabel.AutoSize = false;
            this.damagedLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.damagedLabel.ForeColor = System.Drawing.Color.FromArgb(128, 0, 32);
            this.damagedLabel.Location = new System.Drawing.Point(20, 10);
            this.damagedLabel.Size = new System.Drawing.Size(740, 21);
            this.damagedLabel.Text = "ציוד פגום/אבוד";
            this.damagedLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.damagedLabel.TabIndex = 14;

            this.damagedDataGridView.Location = new System.Drawing.Point(15, 35);
            this.damagedDataGridView.Name = "damagedDataGridView";
            this.damagedDataGridView.Size = new System.Drawing.Size(750, 120);
            this.damagedDataGridView.ReadOnly = true;
            this.damagedDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.damagedDataGridView.GridColor = System.Drawing.Color.FromArgb(229, 231, 235);
            this.damagedDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.damagedDataGridView.EnableHeadersVisualStyles = false;
            this.damagedDataGridView.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(128, 0, 32);
            this.damagedDataGridView.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.damagedDataGridView.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.damagedDataGridView.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.damagedDataGridView.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39);
            this.damagedDataGridView.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.damagedDataGridView.TabIndex = 15;

            this.damagedCardPanel.Controls.Add(this.damagedLabel);
            this.damagedCardPanel.Controls.Add(this.damagedDataGridView);

            // ========== TABLE 4: TOTALS SUMMARY (סיכום) ==========
            this.totalsCardPanel.BackColor = System.Drawing.Color.White;
            this.totalsCardPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.totalsCardPanel.Location = new System.Drawing.Point(20, 740);
            this.totalsCardPanel.Name = "totalsCardPanel";
            this.totalsCardPanel.Size = new System.Drawing.Size(780, 170);
            this.totalsCardPanel.Padding = new System.Windows.Forms.Padding(15);
            this.totalsCardPanel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.totalsCardPanel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.totalsCardPanel.TabIndex = 16;

            this.totalsLabel.AutoSize = false;
            this.totalsLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.totalsLabel.ForeColor = System.Drawing.Color.FromArgb(128, 0, 32);
            this.totalsLabel.Location = new System.Drawing.Point(20, 10);
            this.totalsLabel.Size = new System.Drawing.Size(740, 21);
            this.totalsLabel.Text = "סיכום";
            this.totalsLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.totalsLabel.TabIndex = 16;

            this.totalsDataGridView.Location = new System.Drawing.Point(15, 35);
            this.totalsDataGridView.Name = "totalsDataGridView";
            this.totalsDataGridView.Size = new System.Drawing.Size(750, 120);
            this.totalsDataGridView.ReadOnly = true;
            this.totalsDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.totalsDataGridView.GridColor = System.Drawing.Color.FromArgb(229, 231, 235);
            this.totalsDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.totalsDataGridView.EnableHeadersVisualStyles = false;
            this.totalsDataGridView.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(128, 0, 32);
            this.totalsDataGridView.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.totalsDataGridView.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.totalsDataGridView.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.totalsDataGridView.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39);
            this.totalsDataGridView.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.totalsDataGridView.TabIndex = 17;

            this.totalsCardPanel.Controls.Add(this.totalsLabel);
            this.totalsCardPanel.Controls.Add(this.totalsDataGridView);

            // ========== PANEL PROPERTIES ==========
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(250, 249, 246);
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;

            // Add all controls to main panel in order
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.filterPanel);
            this.Controls.Add(this.consumablesCardPanel);
            this.Controls.Add(this.unretrurnedCardPanel);
            this.Controls.Add(this.damagedCardPanel);
            this.Controls.Add(this.totalsCardPanel);

            this.Name = "AnnualInventoryForecastReportPanel";
            this.Size = new System.Drawing.Size(820, 950);

            ((System.ComponentModel.ISupportInitialize)(this.consumablesDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.unretrurnedDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.damagedDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.totalsDataGridView)).EndInit();
            this.filterPanel.ResumeLayout(false);
            this.consumablesCardPanel.ResumeLayout(false);
            this.unretrurnedCardPanel.ResumeLayout(false);
            this.damagedCardPanel.ResumeLayout(false);
            this.totalsCardPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

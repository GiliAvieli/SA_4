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
        private System.Windows.Forms.Label totalsLabel;
        private System.Windows.Forms.DataGridView totalsDataGridView;

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
            this.SuspendLayout();

            // Title - Modern Typography (Larger for Visual Hierarchy)
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.titleLabel.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39);  // #111827 (Dark Gray)
            this.titleLabel.Location = new System.Drawing.Point(680, 15);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(100, 25);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "דוח ניבוי מלאי";

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
            this.backButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);

            // Filter Panel - White Card Background (Maximum Width for DatePicker Visibility)
            this.filterPanel.BackColor = System.Drawing.Color.White;
            this.filterPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.filterPanel.Location = new System.Drawing.Point(20, 50);
            this.filterPanel.Name = "filterPanel";
            this.filterPanel.Size = new System.Drawing.Size(780, 180);  // Increased width from 770 to 780 for maximum DatePicker space
            this.filterPanel.TabIndex = 2;
            this.filterPanel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;  // Explicit RTL for proper inheritance
            this.filterPanel.Padding = new System.Windows.Forms.Padding(15);  // Add internal padding for breathing room

            // Filter controls positioned relative to filterPanel
            int panelY = 15;
            int panelLabelX = 680;      // Shifted left to prevent clipping in RTL
            int panelControlX = 360;    // Shifted left to give controls more breathing room
            int labelWidth = 130;       // Fixed width for labels in RTL layout

            // Start Date Label - RTL Aligned
            this.startDateLabel.AutoSize = false;  // Manual sizing for consistent RTL layout
            this.startDateLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.startDateLabel.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39);  // #111827
            this.startDateLabel.Location = new System.Drawing.Point(panelLabelX, panelY);
            this.startDateLabel.Name = "startDateLabel";
            this.startDateLabel.Size = new System.Drawing.Size(labelWidth, 23);  // Fixed width for RTL
            this.startDateLabel.TabIndex = 2;
            this.startDateLabel.Text = "תאריך התחלה";
            this.startDateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;  // Right-aligned for RTL

            // Start Date Picker - FORCE RIGHT WITH MAXIMUM WIDTH
            this.startDatePicker.BackColor = System.Drawing.Color.White;
            this.startDatePicker.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.startDatePicker.Location = new System.Drawing.Point(panelControlX - 50, panelY);  // Further left for maximum width
            this.startDatePicker.Name = "startDatePicker";
            this.startDatePicker.Size = new System.Drawing.Size(350, 25);  // Increased to 350px (eliminate clipping)
            this.startDatePicker.TabIndex = 3;
            this.startDatePicker.RightToLeft = System.Windows.Forms.RightToLeft.Yes;  // FORCE RTL
            this.startDatePicker.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;  // Anchor to right

            panelY += 35;  // Increased spacing for breathing room

            // End Date Label - RTL Aligned
            this.endDateLabel.AutoSize = false;  // Manual sizing for consistent RTL layout
            this.endDateLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.endDateLabel.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39);  // #111827
            this.endDateLabel.Location = new System.Drawing.Point(panelLabelX, panelY);
            this.endDateLabel.Name = "endDateLabel";
            this.endDateLabel.Size = new System.Drawing.Size(labelWidth, 23);  // Fixed width for RTL
            this.endDateLabel.TabIndex = 4;
            this.endDateLabel.Text = "תאריך סיום";
            this.endDateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;  // Right-aligned for RTL

            // End Date Picker - FORCE RIGHT WITH MAXIMUM WIDTH
            this.endDatePicker.BackColor = System.Drawing.Color.White;
            this.endDatePicker.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.endDatePicker.Location = new System.Drawing.Point(panelControlX - 50, panelY);  // Further left for maximum width
            this.endDatePicker.Name = "endDatePicker";
            this.endDatePicker.Size = new System.Drawing.Size(350, 25);  // Increased to 350px (eliminate clipping)
            this.endDatePicker.TabIndex = 5;
            this.endDatePicker.RightToLeft = System.Windows.Forms.RightToLeft.Yes;  // FORCE RTL
            this.endDatePicker.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;  // Anchor to right

            panelY += 35;  // Increased spacing for breathing room

            // Category Label - RTL Aligned
            this.categoryLabel.AutoSize = false;  // Manual sizing for consistent RTL layout
            this.categoryLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.categoryLabel.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39);  // #111827
            this.categoryLabel.Location = new System.Drawing.Point(panelLabelX, panelY);
            this.categoryLabel.Name = "categoryLabel";
            this.categoryLabel.Size = new System.Drawing.Size(labelWidth, 23);  // Fixed width for RTL
            this.categoryLabel.TabIndex = 6;
            this.categoryLabel.Text = "קטגוריה";
            this.categoryLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;  // Right-aligned for RTL

            // Category ComboBox - Increased Width to Match DatePickers
            this.categoryComboBox.BackColor = System.Drawing.Color.White;
            this.categoryComboBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.categoryComboBox.Location = new System.Drawing.Point(panelControlX, panelY);
            this.categoryComboBox.Name = "categoryComboBox";
            this.categoryComboBox.Size = new System.Drawing.Size(240, 23);  // Increased from 200 to match DatePickers
            this.categoryComboBox.TabIndex = 7;

            panelY += 40;  // Larger spacing for buttons below

            // Generate Report Button - PRIMARY ACTION (Burgundy CTA)
            this.generateReportButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.generateReportButton.Location = new System.Drawing.Point(panelControlX + 20, panelY);  // Adjusted for new panelControlX
            this.generateReportButton.Name = "generateReportButton";
            this.generateReportButton.Size = new System.Drawing.Size(120, 40);
            this.generateReportButton.TabIndex = 8;
            this.generateReportButton.Text = "צור דוח";
            this.generateReportButton.BackColor = System.Drawing.Color.FromArgb(128, 0, 32);  // #800020 (Rich Burgundy)
            this.generateReportButton.ForeColor = System.Drawing.Color.White;  // #FFFFFF
            this.generateReportButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.generateReportButton.FlatAppearance.BorderSize = 0;
            this.generateReportButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.generateReportButton.Click += new System.EventHandler(this.generateReportButton_Click);

            // Export Button - SECONDARY ACTION (White with Burgundy Border)
            this.exportButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.exportButton.Location = new System.Drawing.Point(panelControlX + 160, panelY);  // Adjusted spacing for new coordinates
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(120, 40);
            this.exportButton.TabIndex = 9;
            this.exportButton.Text = "ייצוא";
            this.exportButton.BackColor = System.Drawing.Color.White;
            this.exportButton.ForeColor = System.Drawing.Color.FromArgb(128, 0, 32);  // #800020
            this.exportButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exportButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(128, 0, 32);
            this.exportButton.FlatAppearance.BorderSize = 2;
            this.exportButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exportButton.Enabled = false;

            // Add filter controls to filterPanel
            this.filterPanel.Controls.Add(this.startDateLabel);
            this.filterPanel.Controls.Add(this.startDatePicker);
            this.filterPanel.Controls.Add(this.endDateLabel);
            this.filterPanel.Controls.Add(this.endDatePicker);
            this.filterPanel.Controls.Add(this.categoryLabel);
            this.filterPanel.Controls.Add(this.categoryComboBox);
            this.filterPanel.Controls.Add(this.generateReportButton);
            this.filterPanel.Controls.Add(this.exportButton);

            // Main panel data sections - adjusted for increased filterPanel height
            int y = 240;  // Increased from 210 (50 + 180 filterPanel + 10 spacing)

            // Consumables Card Panel
            this.consumablesCardPanel.BackColor = System.Drawing.Color.White;
            this.consumablesCardPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.consumablesCardPanel.Location = new System.Drawing.Point(20, y);
            this.consumablesCardPanel.Name = "consumablesCardPanel";
            this.consumablesCardPanel.Size = new System.Drawing.Size(780, 140);  // Increased from 770 to match expanded filterPanel width
            this.consumablesCardPanel.TabIndex = 10;
            this.consumablesCardPanel.Padding = new System.Windows.Forms.Padding(15);
            this.consumablesCardPanel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;  // FORCE RTL for proper header alignment

            // Consumables Label - RIGHT-ALIGNED (Container RTL Inherited)
            this.consumablesLabel.AutoSize = false;
            this.consumablesLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.consumablesLabel.ForeColor = System.Drawing.Color.FromArgb(128, 0, 32);  // #800020
            this.consumablesLabel.Location = new System.Drawing.Point(20, 10);  // Right-edge position (780 - 760 = 20)
            this.consumablesLabel.Name = "consumablesLabel";
            this.consumablesLabel.Size = new System.Drawing.Size(760, 21);  // Full width
            this.consumablesLabel.TabIndex = 10;
            this.consumablesLabel.Text = "ניתוח צריכת מלאי";
            this.consumablesLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;  // TOP RIGHT alignment
            this.consumablesLabel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;  // Anchor to right

            // Consumables DataGridView
            this.consumablesDataGridView.Location = new System.Drawing.Point(15, 35);
            this.consumablesDataGridView.Name = "consumablesDataGridView";
            this.consumablesDataGridView.Size = new System.Drawing.Size(730, 90);
            this.consumablesDataGridView.TabIndex = 11;
            this.consumablesDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.consumablesDataGridView.GridColor = System.Drawing.Color.FromArgb(229, 231, 235);  // #E5E7EB
            this.consumablesDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.consumablesDataGridView.EnableHeadersVisualStyles = false;
            this.consumablesDataGridView.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(128, 0, 32);  // #800020
            this.consumablesDataGridView.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.consumablesDataGridView.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.consumablesDataGridView.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.consumablesDataGridView.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39);  // #111827
            this.consumablesDataGridView.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.consumablesDataGridView.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(255, 243, 224);  // Light peach

            this.consumablesCardPanel.Controls.Add(this.consumablesLabel);
            this.consumablesCardPanel.Controls.Add(this.consumablesDataGridView);

            y += 150;

            // Unreturned Card Panel
            this.unretrurnedCardPanel.BackColor = System.Drawing.Color.White;
            this.unretrurnedCardPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.unretrurnedCardPanel.Location = new System.Drawing.Point(20, y);
            this.unretrurnedCardPanel.Name = "unretrurnedCardPanel";
            this.unretrurnedCardPanel.Size = new System.Drawing.Size(780, 140);  // Increased from 770 to match expanded filterPanel width
            this.unretrurnedCardPanel.TabIndex = 12;
            this.unretrurnedCardPanel.Padding = new System.Windows.Forms.Padding(15);
            this.unretrurnedCardPanel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;  // FORCE RTL for proper header alignment

            // Unreturned Label - RIGHT-ALIGNED (Container RTL Inherited)
            this.unretrurnedLabel.AutoSize = false;
            this.unretrurnedLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.unretrurnedLabel.ForeColor = System.Drawing.Color.FromArgb(128, 0, 32);  // #800020
            this.unretrurnedLabel.Location = new System.Drawing.Point(20, 10);  // SAME X as consumablesLabel (right-edge position)
            this.unretrurnedLabel.Name = "unretrurnedLabel";
            this.unretrurnedLabel.Size = new System.Drawing.Size(760, 21);  // Full width
            this.unretrurnedLabel.TabIndex = 12;
            this.unretrurnedLabel.Text = "ציוד שלא הוחזר";
            this.unretrurnedLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;  // TOP RIGHT alignment
            this.unretrurnedLabel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;  // Anchor to right

            // Unreturned DataGridView
            this.unretrurnedDataGridView.Location = new System.Drawing.Point(15, 35);
            this.unretrurnedDataGridView.Name = "unretrurnedDataGridView";
            this.unretrurnedDataGridView.Size = new System.Drawing.Size(730, 90);
            this.unretrurnedDataGridView.TabIndex = 13;
            this.unretrurnedDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.unretrurnedDataGridView.GridColor = System.Drawing.Color.FromArgb(229, 231, 235);  // #E5E7EB
            this.unretrurnedDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.unretrurnedDataGridView.EnableHeadersVisualStyles = false;
            this.unretrurnedDataGridView.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(128, 0, 32);  // #800020
            this.unretrurnedDataGridView.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.unretrurnedDataGridView.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.unretrurnedDataGridView.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.unretrurnedDataGridView.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39);  // #111827
            this.unretrurnedDataGridView.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.unretrurnedDataGridView.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(255, 243, 224);  // Light peach

            this.unretrurnedCardPanel.Controls.Add(this.unretrurnedLabel);
            this.unretrurnedCardPanel.Controls.Add(this.unretrurnedDataGridView);

            y += 150;

            // Damaged/Missing Card Panel
            this.damagedCardPanel.BackColor = System.Drawing.Color.White;
            this.damagedCardPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.damagedCardPanel.Location = new System.Drawing.Point(20, y);
            this.damagedCardPanel.Name = "damagedCardPanel";
            this.damagedCardPanel.Size = new System.Drawing.Size(780, 140);  // Increased from 770 to match expanded filterPanel width
            this.damagedCardPanel.TabIndex = 14;
            this.damagedCardPanel.Padding = new System.Windows.Forms.Padding(15);
            this.damagedCardPanel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;  // FORCE RTL for proper header alignment

            // Damaged Label - RIGHT-ALIGNED (Container RTL Inherited)
            this.damagedLabel.AutoSize = false;
            this.damagedLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.damagedLabel.ForeColor = System.Drawing.Color.FromArgb(128, 0, 32);  // #800020
            this.damagedLabel.Location = new System.Drawing.Point(20, 10);  // SAME X as both other labels (right-edge position)
            this.damagedLabel.Name = "damagedLabel";
            this.damagedLabel.Size = new System.Drawing.Size(760, 21);  // Full width
            this.damagedLabel.TabIndex = 14;
            this.damagedLabel.Text = "ציוד פגום/אבוד";
            this.damagedLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;  // TOP RIGHT alignment
            this.damagedLabel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;  // Anchor to right

            // Damaged DataGridView
            this.damagedDataGridView.Location = new System.Drawing.Point(15, 35);
            this.damagedDataGridView.Name = "damagedDataGridView";
            this.damagedDataGridView.Size = new System.Drawing.Size(730, 90);
            this.damagedDataGridView.TabIndex = 15;
            this.damagedDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.damagedDataGridView.GridColor = System.Drawing.Color.FromArgb(229, 231, 235);  // #E5E7EB
            this.damagedDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.damagedDataGridView.EnableHeadersVisualStyles = false;
            this.damagedDataGridView.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(128, 0, 32);  // #800020
            this.damagedDataGridView.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.damagedDataGridView.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.damagedDataGridView.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.damagedDataGridView.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39);  // #111827
            this.damagedDataGridView.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.damagedDataGridView.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(255, 243, 224);  // Light peach

            this.damagedCardPanel.Controls.Add(this.damagedLabel);
            this.damagedCardPanel.Controls.Add(this.damagedDataGridView);

            y += 150;

            // Totals Label - Standalone (Not in a card panel)
            this.totalsLabel.AutoSize = true;
            this.totalsLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.totalsLabel.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39);  // #111827
            this.totalsLabel.Location = new System.Drawing.Point(700, y);
            this.totalsLabel.Name = "totalsLabel";
            this.totalsLabel.Size = new System.Drawing.Size(100, 21);
            this.totalsLabel.TabIndex = 16;
            this.totalsLabel.Text = "סה\"כ תקציב";

            y += 30;

            // Totals DataGridView - Standalone
            this.totalsDataGridView.Location = new System.Drawing.Point(20, y);
            this.totalsDataGridView.Name = "totalsDataGridView";
            this.totalsDataGridView.Size = new System.Drawing.Size(760, 80);
            this.totalsDataGridView.TabIndex = 17;
            this.totalsDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.totalsDataGridView.GridColor = System.Drawing.Color.FromArgb(229, 231, 235);  // #E5E7EB
            this.totalsDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.totalsDataGridView.EnableHeadersVisualStyles = false;
            this.totalsDataGridView.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(128, 0, 32);  // #800020
            this.totalsDataGridView.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.totalsDataGridView.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.totalsDataGridView.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.totalsDataGridView.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39);  // #111827
            this.totalsDataGridView.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.totalsDataGridView.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(255, 243, 224);  // Light peach

            // Panel Properties - Off-White Background & FORCE RTL
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(250, 249, 246);  // #FAF9F6 (Off-white)
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;  // FORCE RTL for entire panel
            this.Controls.Add(this.filterPanel);
            this.Controls.Add(this.consumablesCardPanel);
            this.Controls.Add(this.unretrurnedCardPanel);
            this.Controls.Add(this.damagedCardPanel);
            this.Controls.Add(this.totalsLabel);
            this.Controls.Add(this.totalsDataGridView);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.backButton);
            this.Name = "AnnualInventoryForecastReportPanel";
            this.Size = new System.Drawing.Size(800, 1000);
            ((System.ComponentModel.ISupportInitialize)(this.consumablesDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.unretrurnedDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.damagedDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.totalsDataGridView)).EndInit();
            this.filterPanel.ResumeLayout(false);
            this.filterPanel.PerformLayout();
            this.consumablesCardPanel.ResumeLayout(false);
            this.consumablesCardPanel.PerformLayout();
            this.unretrurnedCardPanel.ResumeLayout(false);
            this.unretrurnedCardPanel.PerformLayout();
            this.damagedCardPanel.ResumeLayout(false);
            this.damagedCardPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

namespace SmartShevet
{
    partial class IssueAndReturnEquipmentPanel
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Label masterLabel;
        private System.Windows.Forms.DataGridView masterOrdersGridView;
        private System.Windows.Forms.Label detailLabel;
        private System.Windows.Forms.DataGridView detailItemsGridView;
        private System.Windows.Forms.Button saveChangesButton;

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
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.masterLabel = new System.Windows.Forms.Label();
            this.masterOrdersGridView = new System.Windows.Forms.DataGridView();
            this.detailLabel = new System.Windows.Forms.Label();
            this.detailItemsGridView = new System.Windows.Forms.DataGridView();
            this.saveChangesButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.masterOrdersGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.detailItemsGridView)).BeginInit();
            this.SuspendLayout();

            // Title - Modern Typography (Larger for Visual Hierarchy)
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.titleLabel.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39);  // #111827 (Dark Gray)
            this.titleLabel.Location = new System.Drawing.Point(680, 18);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(100, 25);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "הוצאה והחזרה";

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

            // Split Container
            this.splitContainer.Location = new System.Drawing.Point(0, 60);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Size = new System.Drawing.Size(800, 540);
            this.splitContainer.SplitterDistance = 220;  // Give Panel1 220px for Orders grid
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.splitContainer.RightToLeft = System.Windows.Forms.RightToLeft.Yes;

            // PANEL 1 (Master Orders)
            this.splitContainer.Panel1.Controls.Add(this.masterLabel);
            this.splitContainer.Panel1.Controls.Add(this.masterOrdersGridView);

            this.masterLabel.AutoSize = false;
            this.masterLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.masterLabel.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39);  // #111827
            this.masterLabel.Location = new System.Drawing.Point(10, 10);
            this.masterLabel.Name = "masterLabel";
            this.masterLabel.Size = new System.Drawing.Size(780, 20);
            this.masterLabel.TabIndex = 2;
            this.masterLabel.Text = "הזמנות:";
            this.masterLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;

            this.masterOrdersGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.masterOrdersGridView.ColumnHeadersHeight = 35;
            this.masterOrdersGridView.RowTemplate.Height = 30;
            this.masterOrdersGridView.Location = new System.Drawing.Point(10, 35);
            this.masterOrdersGridView.Name = "masterOrdersGridView";
            this.masterOrdersGridView.Size = new System.Drawing.Size(780, 150);
            this.masterOrdersGridView.TabIndex = 3;
            this.masterOrdersGridView.BackgroundColor = System.Drawing.Color.White;  // #FFFFFF
            this.masterOrdersGridView.GridColor = System.Drawing.Color.FromArgb(229, 231, 235);  // #E5E7EB (row dividers)
            this.masterOrdersGridView.EnableHeadersVisualStyles = false;  // CRITICAL for custom header colors
            this.masterOrdersGridView.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(114, 47, 55);  // #722F37 (Rich Burgundy)
            this.masterOrdersGridView.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.masterOrdersGridView.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.masterOrdersGridView.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.masterOrdersGridView.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39);  // #111827
            this.masterOrdersGridView.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.masterOrdersGridView.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(255, 243, 224);  // Light peach
            this.masterOrdersGridView.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(17, 24, 39);
            this.masterOrdersGridView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.masterOrdersGridView.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.masterOrdersGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.masterOrdersGridView.MultiSelect = false;
            this.masterOrdersGridView.SelectionChanged += new System.EventHandler(this.masterOrdersGridView_SelectionChanged);

            // PANEL 2 (Detail Items)
            this.splitContainer.Panel2.Controls.Add(this.detailLabel);
            this.splitContainer.Panel2.Controls.Add(this.detailItemsGridView);
            this.splitContainer.Panel2.Controls.Add(this.saveChangesButton);

            this.detailLabel.AutoSize = false;
            this.detailLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.detailLabel.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39);  // #111827
            this.detailLabel.Location = new System.Drawing.Point(10, 10);
            this.detailLabel.Name = "detailLabel";
            this.detailLabel.Size = new System.Drawing.Size(780, 20);
            this.detailLabel.TabIndex = 4;
            this.detailLabel.Text = "פריטים:";
            this.detailLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;

            this.detailItemsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.detailItemsGridView.ColumnHeadersHeight = 35;
            this.detailItemsGridView.RowTemplate.Height = 30;
            this.detailItemsGridView.Location = new System.Drawing.Point(10, 35);
            this.detailItemsGridView.Name = "detailItemsGridView";
            this.detailItemsGridView.Size = new System.Drawing.Size(780, 200);
            this.detailItemsGridView.TabIndex = 5;
            this.detailItemsGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.detailItemsGridView.BackgroundColor = System.Drawing.Color.White;  // #FFFFFF
            this.detailItemsGridView.GridColor = System.Drawing.Color.FromArgb(229, 231, 235);  // #E5E7EB (row dividers)
            this.detailItemsGridView.EnableHeadersVisualStyles = false;  // CRITICAL for custom header colors
            this.detailItemsGridView.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(114, 47, 55);  // #722F37 (Rich Burgundy)
            this.detailItemsGridView.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.detailItemsGridView.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.detailItemsGridView.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.detailItemsGridView.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39);  // #111827
            this.detailItemsGridView.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.detailItemsGridView.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(255, 243, 224);  // Light peach
            this.detailItemsGridView.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(17, 24, 39);
            this.detailItemsGridView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.detailItemsGridView.RightToLeft = System.Windows.Forms.RightToLeft.Yes;

            this.saveChangesButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.saveChangesButton.Location = new System.Drawing.Point(300, 245);
            this.saveChangesButton.Name = "saveChangesButton";
            this.saveChangesButton.Size = new System.Drawing.Size(200, 40);
            this.saveChangesButton.TabIndex = 6;
            this.saveChangesButton.Text = "שמור שינויים";
            this.saveChangesButton.BackColor = System.Drawing.Color.FromArgb(114, 47, 55);  // #722F37 (Rich Burgundy)
            this.saveChangesButton.ForeColor = System.Drawing.Color.White;  // #FFFFFF
            this.saveChangesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveChangesButton.FlatAppearance.BorderSize = 0;
            this.saveChangesButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.saveChangesButton.Click += new System.EventHandler(this.saveChangesButton_Click);

            // Panel Properties - Lighter, Airier Off-White Background
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(250, 249, 246);  // #FAF9F6 (Off-white)
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.backButton);
            this.backButton.BringToFront();
            this.titleLabel.BringToFront();
            this.Name = "IssueAndReturnEquipmentPanel";
            this.Size = new System.Drawing.Size(800, 600);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel1.PerformLayout();
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.masterOrdersGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.detailItemsGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

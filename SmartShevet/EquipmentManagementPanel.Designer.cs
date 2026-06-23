namespace SmartShevet
{
    partial class EquipmentManagementPanel
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button addEquipmentButton;
        private System.Windows.Forms.Button editEquipmentButton;
        private System.Windows.Forms.DataGridView masterGrid;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.DataGridView detailGrid;
        private System.Windows.Forms.Panel detailPanel;
        private System.Windows.Forms.Button addInstanceButton;
        private System.Windows.Forms.Button editInstanceStatusButton;
        private System.Windows.Forms.Button deleteInstanceButton;
        private System.Windows.Forms.Label detailLabel;

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
            this.addEquipmentButton = new System.Windows.Forms.Button();
            this.editEquipmentButton = new System.Windows.Forms.Button();
            this.masterGrid = new System.Windows.Forms.DataGridView();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.detailPanel = new System.Windows.Forms.Panel();
            this.detailLabel = new System.Windows.Forms.Label();
            this.detailGrid = new System.Windows.Forms.DataGridView();
            this.addInstanceButton = new System.Windows.Forms.Button();
            this.editInstanceStatusButton = new System.Windows.Forms.Button();
            this.deleteInstanceButton = new System.Windows.Forms.Button();
            this.SuspendLayout();

            ((System.ComponentModel.ISupportInitialize)(this.masterGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.detailGrid)).BeginInit();
            this.detailPanel.SuspendLayout();

            // titleLabel - Modern Typography
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.titleLabel.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39);  // #111827
            this.titleLabel.Location = new System.Drawing.Point(680, 15);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(100, 25);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "ניהול ציוד";

            // backButton - Modern Flat Style
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

            // addEquipmentButton - PRIMARY ACTION
            this.addEquipmentButton.Location = new System.Drawing.Point(650, 60);
            this.addEquipmentButton.Name = "addEquipmentButton";
            this.addEquipmentButton.Size = new System.Drawing.Size(110, 35);
            this.addEquipmentButton.TabIndex = 2;
            this.addEquipmentButton.Text = "הוסף ציוד";
            this.addEquipmentButton.BackColor = System.Drawing.Color.FromArgb(128, 0, 32);  // #800020
            this.addEquipmentButton.ForeColor = System.Drawing.Color.White;
            this.addEquipmentButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addEquipmentButton.FlatAppearance.BorderSize = 0;
            this.addEquipmentButton.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.addEquipmentButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addEquipmentButton.Click += new System.EventHandler(this.addEquipmentButton_Click);

            // editEquipmentButton - PRIMARY ACTION
            this.editEquipmentButton.Location = new System.Drawing.Point(530, 60);
            this.editEquipmentButton.Name = "editEquipmentButton";
            this.editEquipmentButton.Size = new System.Drawing.Size(110, 35);
            this.editEquipmentButton.TabIndex = 3;
            this.editEquipmentButton.Text = "עריכה";
            this.editEquipmentButton.BackColor = System.Drawing.Color.FromArgb(128, 0, 32);  // #800020
            this.editEquipmentButton.ForeColor = System.Drawing.Color.White;
            this.editEquipmentButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editEquipmentButton.FlatAppearance.BorderSize = 0;
            this.editEquipmentButton.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.editEquipmentButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.editEquipmentButton.Click += new System.EventHandler(this.editEquipmentButton_Click);

            // masterGrid - MODERN STYLING
            this.masterGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.masterGrid.ColumnHeadersHeight = 35;
            this.masterGrid.RowTemplate.Height = 30;
            this.masterGrid.Location = new System.Drawing.Point(20, 105);
            this.masterGrid.Name = "masterGrid";
            this.masterGrid.ReadOnly = true;
            this.masterGrid.Size = new System.Drawing.Size(760, 180);
            this.masterGrid.TabIndex = 4;
            this.masterGrid.BackgroundColor = System.Drawing.Color.White;  // #FFFFFF
            this.masterGrid.GridColor = System.Drawing.Color.FromArgb(229, 231, 235);  // #E5E7EB (row dividers)
            this.masterGrid.EnableHeadersVisualStyles = false;  // CRITICAL for custom header colors
            this.masterGrid.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(128, 0, 32);  // #800020 (Burgundy)
            this.masterGrid.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.masterGrid.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.masterGrid.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.masterGrid.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39);  // #111827
            this.masterGrid.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.masterGrid.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(255, 243, 224);  // Light peach
            this.masterGrid.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(17, 24, 39);
            this.masterGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.masterGrid.RightToLeft = System.Windows.Forms.RightToLeft.Yes;

            // splitContainer
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.splitContainer.Panel1.Controls.Add(this.titleLabel);
            this.splitContainer.Panel1.Controls.Add(this.backButton);
            this.splitContainer.Panel1.Controls.Add(this.addEquipmentButton);
            this.splitContainer.Panel1.Controls.Add(this.editEquipmentButton);
            this.splitContainer.Panel1.Controls.Add(this.masterGrid);
            this.splitContainer.Panel2.Controls.Add(this.detailPanel);
            this.splitContainer.SplitterDistance = 320;
            this.splitContainer.TabIndex = 5;

            // detailPanel
            this.detailPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.detailPanel.Controls.Add(this.detailLabel);
            this.detailPanel.Controls.Add(this.addInstanceButton);
            this.detailPanel.Controls.Add(this.editInstanceStatusButton);
            this.detailPanel.Controls.Add(this.deleteInstanceButton);
            this.detailPanel.Controls.Add(this.detailGrid);
            this.detailPanel.Name = "detailPanel";
            this.detailPanel.Visible = false;

            // detailLabel - Modern Typography
            this.detailLabel.AutoSize = true;
            this.detailLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.detailLabel.ForeColor = System.Drawing.Color.FromArgb(128, 0, 32);  // #800020 (Burgundy)
            this.detailLabel.Location = new System.Drawing.Point(20, 20);
            this.detailLabel.Name = "detailLabel";
            this.detailLabel.Size = new System.Drawing.Size(150, 17);
            this.detailLabel.TabIndex = 0;
            this.detailLabel.Text = "יחידות";

            // detailGrid - MODERN STYLING
            this.detailGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.detailGrid.ColumnHeadersHeight = 35;
            this.detailGrid.RowTemplate.Height = 30;
            this.detailGrid.Location = new System.Drawing.Point(20, 50);
            this.detailGrid.Name = "detailGrid";
            this.detailGrid.ReadOnly = true;
            this.detailGrid.Size = new System.Drawing.Size(760, 120);
            this.detailGrid.TabIndex = 1;
            this.detailGrid.BackgroundColor = System.Drawing.Color.White;  // #FFFFFF
            this.detailGrid.GridColor = System.Drawing.Color.FromArgb(229, 231, 235);  // #E5E7EB (row dividers)
            this.detailGrid.EnableHeadersVisualStyles = false;  // CRITICAL for custom header colors
            this.detailGrid.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(128, 0, 32);  // #800020 (Burgundy)
            this.detailGrid.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.detailGrid.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.detailGrid.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.detailGrid.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39);  // #111827
            this.detailGrid.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.detailGrid.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(255, 243, 224);  // Light peach
            this.detailGrid.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(17, 24, 39);
            this.detailGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.detailGrid.RightToLeft = System.Windows.Forms.RightToLeft.Yes;

            // addInstanceButton - PRIMARY ACTION
            this.addInstanceButton.Location = new System.Drawing.Point(640, 200);
            this.addInstanceButton.Name = "addInstanceButton";
            this.addInstanceButton.Size = new System.Drawing.Size(110, 35);
            this.addInstanceButton.TabIndex = 2;
            this.addInstanceButton.Text = "הוסף יחידה";
            this.addInstanceButton.BackColor = System.Drawing.Color.FromArgb(128, 0, 32);  // #800020
            this.addInstanceButton.ForeColor = System.Drawing.Color.White;
            this.addInstanceButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addInstanceButton.FlatAppearance.BorderSize = 0;
            this.addInstanceButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.addInstanceButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addInstanceButton.Click += new System.EventHandler(this.addInstanceButton_Click);

            // editInstanceStatusButton - PRIMARY ACTION
            this.editInstanceStatusButton.Location = new System.Drawing.Point(520, 200);
            this.editInstanceStatusButton.Name = "editInstanceStatusButton";
            this.editInstanceStatusButton.Size = new System.Drawing.Size(110, 35);
            this.editInstanceStatusButton.TabIndex = 3;
            this.editInstanceStatusButton.Text = "ערוך סטטוס";
            this.editInstanceStatusButton.BackColor = System.Drawing.Color.FromArgb(128, 0, 32);  // #800020
            this.editInstanceStatusButton.ForeColor = System.Drawing.Color.White;
            this.editInstanceStatusButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editInstanceStatusButton.FlatAppearance.BorderSize = 0;
            this.editInstanceStatusButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.editInstanceStatusButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.editInstanceStatusButton.Click += new System.EventHandler(this.editInstanceStatusButton_Click);

            // deleteInstanceButton - PRIMARY ACTION
            this.deleteInstanceButton.Location = new System.Drawing.Point(400, 200);
            this.deleteInstanceButton.Name = "deleteInstanceButton";
            this.deleteInstanceButton.Size = new System.Drawing.Size(110, 35);
            this.deleteInstanceButton.TabIndex = 4;
            this.deleteInstanceButton.Text = "מחק יחידה";
            this.deleteInstanceButton.BackColor = System.Drawing.Color.FromArgb(128, 0, 32);  // #800020
            this.deleteInstanceButton.ForeColor = System.Drawing.Color.White;
            this.deleteInstanceButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteInstanceButton.FlatAppearance.BorderSize = 0;
            this.deleteInstanceButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.deleteInstanceButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.deleteInstanceButton.Click += new System.EventHandler(this.deleteInstanceButton_Click);

            // EquipmentManagementPanel - Modern Design
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(250, 249, 246);  // #FAF9F6 (Off-white)
            this.Controls.Add(this.splitContainer);
            this.Name = "EquipmentManagementPanel";
            this.Size = new System.Drawing.Size(800, 600);
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;

            ((System.ComponentModel.ISupportInitialize)(this.masterGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.detailGrid)).EndInit();
            this.detailPanel.ResumeLayout(false);
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

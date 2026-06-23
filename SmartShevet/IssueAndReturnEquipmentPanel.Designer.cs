namespace SmartShevet
{
    partial class IssueAndReturnEquipmentPanel
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label titleLabel;
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

            // Title
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.titleLabel.Location = new System.Drawing.Point(680, 15);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(100, 25);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "הוצאה והחזרה";

            // Split Container
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 50);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.splitContainer.RightToLeft = System.Windows.Forms.RightToLeft.Yes;

            // PANEL 1 (Master Orders)
            this.splitContainer.Panel1.Controls.Add(this.masterLabel);
            this.splitContainer.Panel1.Controls.Add(this.masterOrdersGridView);

            this.masterLabel.AutoSize = true;
            this.masterLabel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.masterLabel.Location = new System.Drawing.Point(700, 10);
            this.masterLabel.Name = "masterLabel";
            this.masterLabel.Size = new System.Drawing.Size(80, 17);
            this.masterLabel.TabIndex = 2;
            this.masterLabel.Text = "הזמנות:";

            this.masterOrdersGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.masterOrdersGridView.Location = new System.Drawing.Point(10, 35);
            this.masterOrdersGridView.Name = "masterOrdersGridView";
            this.masterOrdersGridView.Size = new System.Drawing.Size(770, 200);
            this.masterOrdersGridView.TabIndex = 3;
            this.masterOrdersGridView.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.masterOrdersGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.masterOrdersGridView.MultiSelect = false;
            this.masterOrdersGridView.SelectionChanged += new System.EventHandler(this.masterOrdersGridView_SelectionChanged);

            // PANEL 2 (Detail Items)
            this.splitContainer.Panel2.Controls.Add(this.detailLabel);
            this.splitContainer.Panel2.Controls.Add(this.detailItemsGridView);
            this.splitContainer.Panel2.Controls.Add(this.saveChangesButton);

            this.detailLabel.AutoSize = true;
            this.detailLabel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.detailLabel.Location = new System.Drawing.Point(700, 10);
            this.detailLabel.Name = "detailLabel";
            this.detailLabel.Size = new System.Drawing.Size(60, 17);
            this.detailLabel.TabIndex = 4;
            this.detailLabel.Text = "פריטים:";

            this.detailItemsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.detailItemsGridView.Location = new System.Drawing.Point(10, 35);
            this.detailItemsGridView.Name = "detailItemsGridView";
            this.detailItemsGridView.Size = new System.Drawing.Size(770, 150);
            this.detailItemsGridView.TabIndex = 5;
            this.detailItemsGridView.RightToLeft = System.Windows.Forms.RightToLeft.Yes;

            this.saveChangesButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.saveChangesButton.Location = new System.Drawing.Point(300, 195);
            this.saveChangesButton.Name = "saveChangesButton";
            this.saveChangesButton.Size = new System.Drawing.Size(200, 40);
            this.saveChangesButton.TabIndex = 6;
            this.saveChangesButton.Text = "שמור שינויים";
            this.saveChangesButton.Click += new System.EventHandler(this.saveChangesButton_Click);

            // Panel Properties
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.titleLabel);
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

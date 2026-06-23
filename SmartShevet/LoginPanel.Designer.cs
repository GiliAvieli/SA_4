namespace SmartShevet
{
    partial class LoginPanel
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel loginCardPanel;
        private System.Windows.Forms.PictureBox logoImage;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Button loginButton;

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
            this.loginCardPanel = new System.Windows.Forms.Panel();
            this.logoImage = new System.Windows.Forms.PictureBox();
            this.titleLabel = new System.Windows.Forms.Label();
            this.emailLabel = new System.Windows.Forms.Label();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.loginButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.logoImage)).BeginInit();
            this.loginCardPanel.SuspendLayout();
            this.SuspendLayout();

            // loginCardPanel - Modern Card Design
            this.loginCardPanel.BackColor = System.Drawing.Color.White;  // #FFFFFF
            this.loginCardPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.loginCardPanel.Location = new System.Drawing.Point(200, 75);
            this.loginCardPanel.Name = "loginCardPanel";
            this.loginCardPanel.Size = new System.Drawing.Size(400, 450);
            this.loginCardPanel.TabIndex = 0;

            // logoImage - Lion Logo
            this.logoImage.Location = new System.Drawing.Point(150, 15);
            this.logoImage.Name = "logoImage";
            this.logoImage.Size = new System.Drawing.Size(100, 100);
            this.logoImage.TabIndex = 0;
            this.logoImage.TabStop = false;
            this.logoImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logoImage.BackColor = System.Drawing.Color.White;  // #FFFFFF - blends with card
            // Note: Set Image property in designer or code to Resources.lion_logo

            // titleLabel - SmartShevet Title
            this.titleLabel.AutoSize = false;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.titleLabel.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39);  // #111827
            this.titleLabel.Location = new System.Drawing.Point(30, 125);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(340, 40);
            this.titleLabel.TabIndex = 1;
            this.titleLabel.Text = "SmartShevet";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // emailLabel - Modern Styling
            this.emailLabel.AutoSize = false;
            this.emailLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular);
            this.emailLabel.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39);  // #111827
            this.emailLabel.Location = new System.Drawing.Point(320, 170);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(60, 18);
            this.emailLabel.TabIndex = 2;
            this.emailLabel.Text = "דוא\"ל";
            this.emailLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // emailTextBox - Modern Styling
            this.emailTextBox.Location = new System.Drawing.Point(50, 170);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(250, 28);
            this.emailTextBox.TabIndex = 3;
            this.emailTextBox.BackColor = System.Drawing.Color.White;  // #FFFFFF
            this.emailTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.emailTextBox.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);

            // passwordLabel - Modern Styling
            this.passwordLabel.AutoSize = false;
            this.passwordLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular);
            this.passwordLabel.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39);  // #111827
            this.passwordLabel.Location = new System.Drawing.Point(330, 220);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(50, 18);
            this.passwordLabel.TabIndex = 4;
            this.passwordLabel.Text = "סיסמה";
            this.passwordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // passwordTextBox - Modern Styling
            this.passwordTextBox.Location = new System.Drawing.Point(50, 220);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '*';
            this.passwordTextBox.Size = new System.Drawing.Size(250, 28);
            this.passwordTextBox.TabIndex = 5;
            this.passwordTextBox.BackColor = System.Drawing.Color.White;  // #FFFFFF
            this.passwordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.passwordTextBox.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);

            // loginButton - PRIMARY ACTION (Burgundy)
            this.loginButton.Location = new System.Drawing.Point(150, 280);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(100, 40);
            this.loginButton.TabIndex = 6;
            this.loginButton.Text = "כניסה";
            this.loginButton.BackColor = System.Drawing.Color.FromArgb(128, 0, 32);  // #800020
            this.loginButton.ForeColor = System.Drawing.Color.White;  // #FFFFFF
            this.loginButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loginButton.FlatAppearance.BorderSize = 0;
            this.loginButton.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.loginButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);

            // Add controls to card panel
            this.loginCardPanel.Controls.Add(this.logoImage);
            this.loginCardPanel.Controls.Add(this.titleLabel);
            this.loginCardPanel.Controls.Add(this.emailLabel);
            this.loginCardPanel.Controls.Add(this.emailTextBox);
            this.loginCardPanel.Controls.Add(this.passwordLabel);
            this.loginCardPanel.Controls.Add(this.passwordTextBox);
            this.loginCardPanel.Controls.Add(this.loginButton);

            // LoginPanel - Modern Design
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(250, 249, 246);  // #FAF9F6 (Off-white)
            this.Controls.Add(this.loginCardPanel);
            this.Name = "LoginPanel";
            this.Size = new System.Drawing.Size(800, 600);
            ((System.ComponentModel.ISupportInitialize)(this.logoImage)).EndInit();
            this.loginCardPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

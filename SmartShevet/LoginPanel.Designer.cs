namespace SmartShevet
{
    partial class LoginPanel
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.Button devShortcutButton;

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
            this.emailLabel = new System.Windows.Forms.Label();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.loginButton = new System.Windows.Forms.Button();
            this.devShortcutButton = new System.Windows.Forms.Button();
            this.SuspendLayout();

            this.emailLabel.AutoSize = true;
            this.emailLabel.Location = new System.Drawing.Point(400, 100);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(50, 13);
            this.emailLabel.TabIndex = 0;
            this.emailLabel.Text = "דוא\"ל";

            this.emailTextBox.Location = new System.Drawing.Point(200, 100);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(150, 20);
            this.emailTextBox.TabIndex = 1;

            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(400, 150);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(50, 13);
            this.passwordLabel.TabIndex = 2;
            this.passwordLabel.Text = "סיסמה";

            this.passwordTextBox.Location = new System.Drawing.Point(200, 150);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '*';
            this.passwordTextBox.Size = new System.Drawing.Size(150, 20);
            this.passwordTextBox.TabIndex = 3;

            this.loginButton.Location = new System.Drawing.Point(200, 200);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(100, 30);
            this.loginButton.TabIndex = 4;
            this.loginButton.Text = "כניסה";
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);

            this.devShortcutButton.Location = new System.Drawing.Point(200, 250);
            this.devShortcutButton.Name = "devShortcutButton";
            this.devShortcutButton.Size = new System.Drawing.Size(100, 30);
            this.devShortcutButton.TabIndex = 5;
            this.devShortcutButton.Text = "כניסת מפתח";
            this.devShortcutButton.Click += new System.EventHandler(this.devShortcutButton_Click);

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.emailLabel);
            this.Controls.Add(this.emailTextBox);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.devShortcutButton);
            this.Name = "LoginPanel";
            this.Size = new System.Drawing.Size(800, 600);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

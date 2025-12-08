using System.Drawing;
using System.Windows.Forms;

namespace TaskManagementApp
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;
        private Panel mainPanel;
        private Label lblTitle;
        private Label lblUsername;
        private TextBox txtUsername;
        private Label lblPassword;
        private TextBox txtPassword;
        private CheckBox chkShowPassword;
        private Button btnLogin;
        private Button btnSignUp;
        private Button btnExit;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.mainPanel = new Panel();
            this.lblTitle = new Label();
            this.lblUsername = new Label();
            this.txtUsername = new TextBox();
            this.lblPassword = new Label();
            this.txtPassword = new TextBox();
            this.chkShowPassword = new CheckBox();
            this.btnLogin = new Button();
            this.btnSignUp = new Button();
            this.btnExit = new Button();

            this.mainPanel.SuspendLayout();
            this.SuspendLayout();

            // FORM
            this.ClientSize = new Size(500, 500);
            this.Text = "Login - Task Management System";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(60, 130, 200);

            // MAIN PANEL
            this.mainPanel.BackColor = Color.White;
            this.mainPanel.Location = new Point(50, 50);
            this.mainPanel.Size = new Size(400, 400);

            // TITLE
            this.lblTitle.Text = "🔐 Sign In";
            this.lblTitle.Font = new Font("Segoe UI", 20, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.FromArgb(60, 130, 200);
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new Point(135, 30);

            // USERNAME LABEL
            this.lblUsername.Text = "Username:";
            this.lblUsername.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            this.lblUsername.Location = new Point(40, 100);
            this.lblUsername.Size = new Size(100, 25);

            // USERNAME TEXTBOX
            this.txtUsername.Font = new Font("Segoe UI", 11);
            this.txtUsername.Location = new Point(40, 130);
            this.txtUsername.Size = new Size(320, 30);

            // PASSWORD LABEL
            this.lblPassword.Text = "Password:";
            this.lblPassword.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            this.lblPassword.Location = new Point(40, 180);
            this.lblPassword.Size = new Size(100, 25);

            // PASSWORD TEXTBOX
            this.txtPassword.Font = new Font("Segoe UI", 11);
            this.txtPassword.Location = new Point(40, 210);
            this.txtPassword.Size = new Size(320, 30);
            this.txtPassword.UseSystemPasswordChar = true;

            // SHOW PASSWORD CHECKBOX
            this.chkShowPassword.Text = "Show Password";
            this.chkShowPassword.Font = new Font("Segoe UI", 9);
            this.chkShowPassword.Location = new Point(40, 245);
            this.chkShowPassword.Size = new Size(150, 25);
            this.chkShowPassword.CheckedChanged += new System.EventHandler(this.chkShowPassword_CheckedChanged);

            // LOGIN BUTTON
            this.btnLogin.Text = "Login";
            this.btnLogin.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            this.btnLogin.ForeColor = Color.White;
            this.btnLogin.BackColor = Color.FromArgb(60, 130, 200);
            this.btnLogin.FlatStyle = FlatStyle.Flat;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.Location = new Point(40, 285);
            this.btnLogin.Size = new Size(150, 45);
            this.btnLogin.Cursor = Cursors.Hand;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);

            // SIGNUP BUTTON
            this.btnSignUp.Text = "Sign Up";
            this.btnSignUp.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            this.btnSignUp.ForeColor = Color.White;
            this.btnSignUp.BackColor = Color.FromArgb(40, 160, 80);
            this.btnSignUp.FlatStyle = FlatStyle.Flat;
            this.btnSignUp.FlatAppearance.BorderSize = 0;
            this.btnSignUp.Location = new Point(210, 285);
            this.btnSignUp.Size = new Size(150, 45);
            this.btnSignUp.Cursor = Cursors.Hand;
            this.btnSignUp.Click += new System.EventHandler(this.btnSignUp_Click);

            // EXIT BUTTON
            this.btnExit.Text = "Exit";
            this.btnExit.Font = new Font("Segoe UI", 10);
            this.btnExit.ForeColor = Color.White;
            this.btnExit.BackColor = Color.FromArgb(100, 100, 100);
            this.btnExit.FlatStyle = FlatStyle.Flat;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.Location = new Point(125, 345);
            this.btnExit.Size = new Size(150, 35);
            this.btnExit.Cursor = Cursors.Hand;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);

            // ADD CONTROLS TO PANEL
            this.mainPanel.Controls.Add(this.lblTitle);
            this.mainPanel.Controls.Add(this.lblUsername);
            this.mainPanel.Controls.Add(this.txtUsername);
            this.mainPanel.Controls.Add(this.lblPassword);
            this.mainPanel.Controls.Add(this.txtPassword);
            this.mainPanel.Controls.Add(this.chkShowPassword);
            this.mainPanel.Controls.Add(this.btnLogin);
            this.mainPanel.Controls.Add(this.btnSignUp);
            this.mainPanel.Controls.Add(this.btnExit);

            // ADD TO FORM
            this.Controls.Add(this.mainPanel);

            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}
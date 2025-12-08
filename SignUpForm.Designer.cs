using System.Drawing;
using System.Windows.Forms;

namespace TaskManagementApp
{
    partial class SignUpForm
    {
        private System.ComponentModel.IContainer components = null;
        private Panel mainPanel;
        private Label lblTitle;
        private Label lblUsername;
        private TextBox txtUsername;
        private Label lblPassword;
        private TextBox txtPassword;
        private Label lblRole;
        private ComboBox cmbRole;
        private Button btnSignUp;
        private Button btnGoToLogin;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.mainPanel = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblRole = new System.Windows.Forms.Label();
            this.cmbRole = new System.Windows.Forms.ComboBox();
            this.btnSignUp = new System.Windows.Forms.Button();
            this.btnGoToLogin = new System.Windows.Forms.Button();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.White;
            this.mainPanel.Controls.Add(this.lblTitle);
            this.mainPanel.Controls.Add(this.lblUsername);
            this.mainPanel.Controls.Add(this.txtUsername);
            this.mainPanel.Controls.Add(this.lblPassword);
            this.mainPanel.Controls.Add(this.txtPassword);
            this.mainPanel.Controls.Add(this.lblRole);
            this.mainPanel.Controls.Add(this.cmbRole);
            this.mainPanel.Controls.Add(this.btnSignUp);
            this.mainPanel.Controls.Add(this.btnGoToLogin);
            this.mainPanel.Location = new System.Drawing.Point(50, 50);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(453, 450);
            this.mainPanel.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(130)))), ((int)(((byte)(200)))));
            this.lblTitle.Location = new System.Drawing.Point(90, 30);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(320, 46);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "📝 Create Account";
            // 
            // lblUsername
            // 
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblUsername.Location = new System.Drawing.Point(40, 100);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(100, 25);
            this.lblUsername.TabIndex = 1;
            this.lblUsername.Text = "Username:";
            // 
            // txtUsername
            // 
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtUsername.Location = new System.Drawing.Point(40, 130);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(320, 32);
            this.txtUsername.TabIndex = 2;
            // 
            // lblPassword
            // 
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblPassword.Location = new System.Drawing.Point(40, 180);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(100, 25);
            this.lblPassword.TabIndex = 3;
            this.lblPassword.Text = "Password:";
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtPassword.Location = new System.Drawing.Point(40, 210);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(320, 32);
            this.txtPassword.TabIndex = 4;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // lblRole
            // 
            this.lblRole.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblRole.Location = new System.Drawing.Point(40, 260);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(100, 25);
            this.lblRole.TabIndex = 5;
            this.lblRole.Text = "Role:";
            // 
            // cmbRole
            // 
            this.cmbRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRole.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cmbRole.Items.AddRange(new object[] {
            "Admin",
            "User"});
            this.cmbRole.Location = new System.Drawing.Point(40, 290);
            this.cmbRole.Name = "cmbRole";
            this.cmbRole.Size = new System.Drawing.Size(320, 33);
            this.cmbRole.TabIndex = 6;
            // 
            // btnSignUp
            // 
            this.btnSignUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(130)))), ((int)(((byte)(200)))));
            this.btnSignUp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSignUp.FlatAppearance.BorderSize = 0;
            this.btnSignUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSignUp.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnSignUp.ForeColor = System.Drawing.Color.White;
            this.btnSignUp.Location = new System.Drawing.Point(40, 350);
            this.btnSignUp.Name = "btnSignUp";
            this.btnSignUp.Size = new System.Drawing.Size(320, 45);
            this.btnSignUp.TabIndex = 7;
            this.btnSignUp.Text = "Sign Up";
            this.btnSignUp.UseVisualStyleBackColor = false;
            this.btnSignUp.Click += new System.EventHandler(this.btnSignUp_Click);
            // 
            // btnGoToLogin
            // 
            this.btnGoToLogin.BackColor = System.Drawing.Color.White;
            this.btnGoToLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGoToLogin.FlatAppearance.BorderSize = 0;
            this.btnGoToLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGoToLogin.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Underline);
            this.btnGoToLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(130)))), ((int)(((byte)(200)))));
            this.btnGoToLogin.Location = new System.Drawing.Point(90, 405);
            this.btnGoToLogin.Name = "btnGoToLogin";
            this.btnGoToLogin.Size = new System.Drawing.Size(220, 30);
            this.btnGoToLogin.TabIndex = 8;
            this.btnGoToLogin.Text = "Already have an account? Login";
            this.btnGoToLogin.UseVisualStyleBackColor = false;
            this.btnGoToLogin.Click += new System.EventHandler(this.btnGoToLogin_Click);
            // 
            // SignUpForm
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(130)))), ((int)(((byte)(200)))));
            this.ClientSize = new System.Drawing.Size(708, 550);
            this.Controls.Add(this.mainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "SignUpForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sign Up - Task Management";
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
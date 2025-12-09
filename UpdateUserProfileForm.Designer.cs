using System.Drawing;
using System.Windows.Forms;

namespace TaskManagementApp
{
    partial class UpdateUserProfileForm
    {
        private System.ComponentModel.IContainer components = null;
        private Panel mainPanel;
        private Label lblTitle;
        private Label lblCurrentRole;
        private Label lblUsername;
        private TextBox txtUsername;
        private Label lblPassword;
        private TextBox txtPassword;
        private Button btnUpdate;
        private Button btnCancel;

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
            this.lblCurrentRole = new Label();
            this.lblUsername = new Label();
            this.txtUsername = new TextBox();
            this.lblPassword = new Label();
            this.txtPassword = new TextBox();
            this.btnUpdate = new Button();
            this.btnCancel = new Button();

            this.mainPanel.SuspendLayout();
            this.SuspendLayout();

            // FORM
            this.ClientSize = new Size(500, 400);
            this.Text = "Update My Profile";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(60, 130, 200);

            // MAIN PANEL
            this.mainPanel.BackColor = Color.White;
            this.mainPanel.Location = new Point(50, 50);
            this.mainPanel.Size = new Size(400, 300);

            // TITLE
            this.lblTitle.Text = "👤 Update My Profile";
            this.lblTitle.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.FromArgb(60, 130, 200);
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new Point(80, 20);

            // CURRENT ROLE
            this.lblCurrentRole.Text = "Role: User";
            this.lblCurrentRole.Font = new Font("Segoe UI", 10, FontStyle.Italic);
            this.lblCurrentRole.ForeColor = Color.Gray;
            this.lblCurrentRole.AutoSize = true;
            this.lblCurrentRole.Location = new Point(150, 60);

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
            this.lblPassword.Location = new Point(40, 170);
            this.lblPassword.Size = new Size(100, 25);

            // PASSWORD TEXTBOX
            this.txtPassword.Font = new Font("Segoe UI", 11);
            this.txtPassword.Location = new Point(40, 200);
            this.txtPassword.Size = new Size(320, 30);

            // UPDATE BUTTON
            this.btnUpdate.Text = "Update Profile";
            this.btnUpdate.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            this.btnUpdate.ForeColor = Color.White;
            this.btnUpdate.BackColor = Color.FromArgb(60, 130, 200);
            this.btnUpdate.FlatStyle = FlatStyle.Flat;
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.Location = new Point(40, 245);
            this.btnUpdate.Size = new Size(150, 40);
            this.btnUpdate.Cursor = Cursors.Hand;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);

            // CANCEL BUTTON
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            this.btnCancel.ForeColor = Color.White;
            this.btnCancel.BackColor = Color.FromArgb(100, 100, 100);
            this.btnCancel.FlatStyle = FlatStyle.Flat;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.Location = new Point(210, 245);
            this.btnCancel.Size = new Size(150, 40);
            this.btnCancel.Cursor = Cursors.Hand;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            this.mainPanel.Controls.Add(this.lblTitle);
            this.mainPanel.Controls.Add(this.lblCurrentRole);
            this.mainPanel.Controls.Add(this.lblUsername);
            this.mainPanel.Controls.Add(this.txtUsername);
            this.mainPanel.Controls.Add(this.lblPassword);
            this.mainPanel.Controls.Add(this.txtPassword);
            this.mainPanel.Controls.Add(this.btnUpdate);
            this.mainPanel.Controls.Add(this.btnCancel);

            this.Controls.Add(this.mainPanel);

            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}
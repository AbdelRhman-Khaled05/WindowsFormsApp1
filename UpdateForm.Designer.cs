using System.Drawing;
using System.Windows.Forms;

namespace TaskManagementApp
{
    partial class UpdateForm
    {
        private System.ComponentModel.IContainer components = null;
        private Panel header;
        private Label lblTitle;
        private TabControl tabControl;
        private TabPage tabUser;
        private TabPage tabTask;

        // User tab
        private Label lblSelectUser;
        private ComboBox cmbUsers;
        private Label lblUsername;
        private TextBox txtUsername;
        private Label lblPassword;
        private TextBox txtPassword;
        private Label lblRole;
        private TextBox txtRole;
        private Button btnUpdateUser;

        // Task tab
        private Label lblSelectTask;
        private ComboBox cmbTasks;
        private Label lblTaskUserID;
        private TextBox txtTaskUserID;
        private Label lblTaskTitle;
        private TextBox txtTaskTitle;
        private Label lblTaskDescription;
        private TextBox txtTaskDescription;
        private Label lblTaskStatus;
        private TextBox txtTaskStatus;
        private Button btnUpdateTask;

        private Button btnRefresh;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.header = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabUser = new System.Windows.Forms.TabPage();
            this.tabTask = new System.Windows.Forms.TabPage();
            this.lblSelectUser = new System.Windows.Forms.Label();
            this.cmbUsers = new System.Windows.Forms.ComboBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblRole = new System.Windows.Forms.Label();
            this.txtRole = new System.Windows.Forms.TextBox();
            this.btnUpdateUser = new System.Windows.Forms.Button();
            this.lblSelectTask = new System.Windows.Forms.Label();
            this.cmbTasks = new System.Windows.Forms.ComboBox();
            this.lblTaskUserID = new System.Windows.Forms.Label();
            this.txtTaskUserID = new System.Windows.Forms.TextBox();
            this.lblTaskTitle = new System.Windows.Forms.Label();
            this.txtTaskTitle = new System.Windows.Forms.TextBox();
            this.lblTaskDescription = new System.Windows.Forms.Label();
            this.txtTaskDescription = new System.Windows.Forms.TextBox();
            this.lblTaskStatus = new System.Windows.Forms.Label();
            this.txtTaskStatus = new System.Windows.Forms.TextBox();
            this.btnUpdateTask = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();

            this.header.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabUser.SuspendLayout();
            this.tabTask.SuspendLayout();
            this.SuspendLayout();

            // FORM
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Text = "Update Data";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;

            // HEADER
            this.header.BackColor = Color.FromArgb(60, 130, 200);
            this.header.Dock = DockStyle.Top;
            this.header.Height = 70;
            this.lblTitle.Text = "✏️ Update Data";
            this.lblTitle.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.White;
            this.lblTitle.Location = new Point(20, 20);
            this.lblTitle.AutoSize = true;
            this.header.Controls.Add(this.lblTitle);

            // REFRESH BUTTON
            this.btnRefresh.Text = "↻ Refresh";
            this.btnRefresh.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            this.btnRefresh.ForeColor = Color.White;
            this.btnRefresh.BackColor = Color.FromArgb(40, 160, 80);
            this.btnRefresh.FlatStyle = FlatStyle.Flat;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.Location = new Point(650, 20);
            this.btnRefresh.Size = new Size(120, 35);
            this.btnRefresh.Cursor = Cursors.Hand;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            this.header.Controls.Add(this.btnRefresh);

            // TAB CONTROL
            this.tabControl.Location = new Point(20, 90);
            this.tabControl.Size = new Size(760, 490);
            this.tabControl.Font = new Font("Segoe UI", 10);

            // USER TAB
            this.tabUser.Text = "Update User";
            this.tabUser.BackColor = Color.White;

            this.lblSelectUser.Text = "Select User:";
            this.lblSelectUser.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            this.lblSelectUser.Location = new Point(30, 30);
            this.lblSelectUser.Size = new Size(150, 25);

            this.cmbUsers.Location = new Point(200, 30);
            this.cmbUsers.Size = new Size(500, 30);
            this.cmbUsers.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbUsers.SelectedIndexChanged += new System.EventHandler(this.cmbUsers_SelectedIndexChanged);

            this.lblUsername.Text = "Username:";
            this.lblUsername.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            this.lblUsername.Location = new Point(30, 80);
            this.lblUsername.Size = new Size(150, 25);

            this.txtUsername.Location = new Point(200, 80);
            this.txtUsername.Size = new Size(500, 30);

            this.lblPassword.Text = "Password:";
            this.lblPassword.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            this.lblPassword.Location = new Point(30, 130);
            this.lblPassword.Size = new Size(150, 25);

            this.txtPassword.Location = new Point(200, 130);
            this.txtPassword.Size = new Size(500, 30);

            this.lblRole.Text = "Role:";
            this.lblRole.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            this.lblRole.Location = new Point(30, 180);
            this.lblRole.Size = new Size(150, 25);

            this.txtRole.Location = new Point(200, 180);
            this.txtRole.Size = new Size(500, 30);

            this.btnUpdateUser.Text = "Update User";
            this.btnUpdateUser.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            this.btnUpdateUser.ForeColor = Color.White;
            this.btnUpdateUser.BackColor = Color.FromArgb(60, 130, 200);
            this.btnUpdateUser.FlatStyle = FlatStyle.Flat;
            this.btnUpdateUser.FlatAppearance.BorderSize = 0;
            this.btnUpdateUser.Location = new Point(200, 240);
            this.btnUpdateUser.Size = new Size(200, 45);
            this.btnUpdateUser.Cursor = Cursors.Hand;
            this.btnUpdateUser.Click += new System.EventHandler(this.btnUpdateUser_Click);

            this.tabUser.Controls.Add(this.lblSelectUser);
            this.tabUser.Controls.Add(this.cmbUsers);
            this.tabUser.Controls.Add(this.lblUsername);
            this.tabUser.Controls.Add(this.txtUsername);
            this.tabUser.Controls.Add(this.lblPassword);
            this.tabUser.Controls.Add(this.txtPassword);
            this.tabUser.Controls.Add(this.lblRole);
            this.tabUser.Controls.Add(this.txtRole);
            this.tabUser.Controls.Add(this.btnUpdateUser);

            // TASK TAB
            this.tabTask.Text = "Update Task";
            this.tabTask.BackColor = Color.White;

            this.lblSelectTask.Text = "Select Task:";
            this.lblSelectTask.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            this.lblSelectTask.Location = new Point(30, 30);
            this.lblSelectTask.Size = new Size(150, 25);

            this.cmbTasks.Location = new Point(200, 30);
            this.cmbTasks.Size = new Size(500, 30);
            this.cmbTasks.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbTasks.SelectedIndexChanged += new System.EventHandler(this.cmbTasks_SelectedIndexChanged);

            this.lblTaskUserID.Text = "User ID:";
            this.lblTaskUserID.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            this.lblTaskUserID.Location = new Point(30, 80);
            this.lblTaskUserID.Size = new Size(150, 25);

            this.txtTaskUserID.Location = new Point(200, 80);
            this.txtTaskUserID.Size = new Size(500, 30);

            this.lblTaskTitle.Text = "Title:";
            this.lblTaskTitle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            this.lblTaskTitle.Location = new Point(30, 130);
            this.lblTaskTitle.Size = new Size(150, 25);

            this.txtTaskTitle.Location = new Point(200, 130);
            this.txtTaskTitle.Size = new Size(500, 30);

            this.lblTaskDescription.Text = "Description:";
            this.lblTaskDescription.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            this.lblTaskDescription.Location = new Point(30, 180);
            this.lblTaskDescription.Size = new Size(150, 25);

            this.txtTaskDescription.Location = new Point(200, 180);
            this.txtTaskDescription.Size = new Size(500, 80);
            this.txtTaskDescription.Multiline = true;

            this.lblTaskStatus.Text = "Status:";
            this.lblTaskStatus.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            this.lblTaskStatus.Location = new Point(30, 280);
            this.lblTaskStatus.Size = new Size(150, 25);

            this.txtTaskStatus.Location = new Point(200, 280);
            this.txtTaskStatus.Size = new Size(300, 30);

            this.btnUpdateTask.Text = "Update Task";
            this.btnUpdateTask.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            this.btnUpdateTask.ForeColor = Color.White;
            this.btnUpdateTask.BackColor = Color.FromArgb(60, 130, 200);
            this.btnUpdateTask.FlatStyle = FlatStyle.Flat;
            this.btnUpdateTask.FlatAppearance.BorderSize = 0;
            this.btnUpdateTask.Location = new Point(200, 340);
            this.btnUpdateTask.Size = new Size(200, 45);
            this.btnUpdateTask.Cursor = Cursors.Hand;
            this.btnUpdateTask.Click += new System.EventHandler(this.btnUpdateTask_Click);

            this.tabTask.Controls.Add(this.lblSelectTask);
            this.tabTask.Controls.Add(this.cmbTasks);
            this.tabTask.Controls.Add(this.lblTaskUserID);
            this.tabTask.Controls.Add(this.txtTaskUserID);
            this.tabTask.Controls.Add(this.lblTaskTitle);
            this.tabTask.Controls.Add(this.txtTaskTitle);
            this.tabTask.Controls.Add(this.lblTaskDescription);
            this.tabTask.Controls.Add(this.txtTaskDescription);
            this.tabTask.Controls.Add(this.lblTaskStatus);
            this.tabTask.Controls.Add(this.txtTaskStatus);
            this.tabTask.Controls.Add(this.btnUpdateTask);

            // ADD TABS
            this.tabControl.Controls.Add(this.tabUser);
            this.tabControl.Controls.Add(this.tabTask);

            // ADD TO FORM
            this.Controls.Add(this.header);
            this.Controls.Add(this.tabControl);

            this.header.ResumeLayout(false);
            this.header.PerformLayout();
            this.tabUser.ResumeLayout(false);
            this.tabUser.PerformLayout();
            this.tabTask.ResumeLayout(false);
            this.tabTask.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.ResumeLayout(false);
        }
        #endregion
    }
}
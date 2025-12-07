using System.Drawing;
using System.Windows.Forms;

namespace TaskManagementApp
{
    partial class DeleteForm
    {
        private System.ComponentModel.IContainer components = null;
        private Panel header;
        private Label lblTitle;
        private TabControl tabControl;
        private TabPage tabUser;
        private TabPage tabTask;

        private Label lblSelectUser;
        private ComboBox cmbUsers;
        private TextBox txtUserDetails;
        private Button btnDeleteUser;

        private Label lblSelectTask;
        private ComboBox cmbTasks;
        private TextBox txtTaskDetails;
        private Button btnDeleteTask;

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
            this.txtUserDetails = new System.Windows.Forms.TextBox();
            this.btnDeleteUser = new System.Windows.Forms.Button();
            this.lblSelectTask = new System.Windows.Forms.Label();
            this.cmbTasks = new System.Windows.Forms.ComboBox();
            this.txtTaskDetails = new System.Windows.Forms.TextBox();
            this.btnDeleteTask = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();

            this.header.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabUser.SuspendLayout();
            this.tabTask.SuspendLayout();
            this.SuspendLayout();

            // FORM
            this.ClientSize = new System.Drawing.Size(800, 550);
            this.Text = "Delete Data";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;

            // HEADER
            this.header.BackColor = Color.FromArgb(200, 60, 60);
            this.header.Dock = DockStyle.Top;
            this.header.Height = 70;
            this.lblTitle.Text = "🗑️ Delete Data";
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
            this.tabControl.Size = new Size(760, 440);
            this.tabControl.Font = new Font("Segoe UI", 10);

            // USER TAB
            this.tabUser.Text = "Delete User";
            this.tabUser.BackColor = Color.White;

            this.lblSelectUser.Text = "Select User to Delete:";
            this.lblSelectUser.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            this.lblSelectUser.Location = new Point(30, 30);
            this.lblSelectUser.Size = new Size(200, 25);

            this.cmbUsers.Location = new Point(240, 30);
            this.cmbUsers.Size = new Size(460, 30);
            this.cmbUsers.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbUsers.SelectedIndexChanged += new System.EventHandler(this.cmbUsers_SelectedIndexChanged);

            this.txtUserDetails.Location = new Point(30, 80);
            this.txtUserDetails.Size = new Size(670, 240);
            this.txtUserDetails.Multiline = true;
            this.txtUserDetails.ReadOnly = true;
            this.txtUserDetails.BackColor = Color.FromArgb(240, 240, 240);
            this.txtUserDetails.Font = new Font("Segoe UI", 10);

            this.btnDeleteUser.Text = "Delete User";
            this.btnDeleteUser.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            this.btnDeleteUser.ForeColor = Color.White;
            this.btnDeleteUser.BackColor = Color.FromArgb(200, 60, 60);
            this.btnDeleteUser.FlatStyle = FlatStyle.Flat;
            this.btnDeleteUser.FlatAppearance.BorderSize = 0;
            this.btnDeleteUser.Location = new Point(30, 340);
            this.btnDeleteUser.Size = new Size(200, 45);
            this.btnDeleteUser.Cursor = Cursors.Hand;
            this.btnDeleteUser.Click += new System.EventHandler(this.btnDeleteUser_Click);

            this.tabUser.Controls.Add(this.lblSelectUser);
            this.tabUser.Controls.Add(this.cmbUsers);
            this.tabUser.Controls.Add(this.txtUserDetails);
            this.tabUser.Controls.Add(this.btnDeleteUser);

            // TASK TAB
            this.tabTask.Text = "Delete Task";
            this.tabTask.BackColor = Color.White;

            this.lblSelectTask.Text = "Select Task to Delete:";
            this.lblSelectTask.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            this.lblSelectTask.Location = new Point(30, 30);
            this.lblSelectTask.Size = new Size(200, 25);

            this.cmbTasks.Location = new Point(240, 30);
            this.cmbTasks.Size = new Size(460, 30);
            this.cmbTasks.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbTasks.SelectedIndexChanged += new System.EventHandler(this.cmbTasks_SelectedIndexChanged);

            this.txtTaskDetails.Location = new Point(30, 80);
            this.txtTaskDetails.Size = new Size(670, 240);
            this.txtTaskDetails.Multiline = true;
            this.txtTaskDetails.ReadOnly = true;
            this.txtTaskDetails.BackColor = Color.FromArgb(240, 240, 240);
            this.txtTaskDetails.Font = new Font("Segoe UI", 10);

            this.btnDeleteTask.Text = "Delete Task";
            this.btnDeleteTask.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            this.btnDeleteTask.ForeColor = Color.White;
            this.btnDeleteTask.BackColor = Color.FromArgb(200, 60, 60);
            this.btnDeleteTask.FlatStyle = FlatStyle.Flat;
            this.btnDeleteTask.FlatAppearance.BorderSize = 0;
            this.btnDeleteTask.Location = new Point(30, 340);
            this.btnDeleteTask.Size = new Size(200, 45);
            this.btnDeleteTask.Cursor = Cursors.Hand;
            this.btnDeleteTask.Click += new System.EventHandler(this.btnDeleteTask_Click);

            this.tabTask.Controls.Add(this.lblSelectTask);
            this.tabTask.Controls.Add(this.cmbTasks);
            this.tabTask.Controls.Add(this.txtTaskDetails);
            this.tabTask.Controls.Add(this.btnDeleteTask);

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
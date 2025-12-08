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
            this.btnRefresh = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabUser = new System.Windows.Forms.TabPage();
            this.lblSelectUser = new System.Windows.Forms.Label();
            this.cmbUsers = new System.Windows.Forms.ComboBox();
            this.txtUserDetails = new System.Windows.Forms.TextBox();
            this.btnDeleteUser = new System.Windows.Forms.Button();
            this.tabTask = new System.Windows.Forms.TabPage();
            this.lblSelectTask = new System.Windows.Forms.Label();
            this.cmbTasks = new System.Windows.Forms.ComboBox();
            this.txtTaskDetails = new System.Windows.Forms.TextBox();
            this.btnDeleteTask = new System.Windows.Forms.Button();
            this.header.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabUser.SuspendLayout();
            this.tabTask.SuspendLayout();
            this.SuspendLayout();
            // 
            // header
            // 
            this.header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.header.Controls.Add(this.lblTitle);
            this.header.Controls.Add(this.btnRefresh);
            this.header.Dock = System.Windows.Forms.DockStyle.Top;
            this.header.Location = new System.Drawing.Point(0, 0);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(800, 70);
            this.header.TabIndex = 0;            
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(233, 41);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "🗑️ Delete Data";
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(160)))), ((int)(((byte)(80)))));
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(650, 20);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(120, 35);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "↻ Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabUser);
            this.tabControl.Controls.Add(this.tabTask);
            this.tabControl.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tabControl.Location = new System.Drawing.Point(20, 90);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(760, 440);
            this.tabControl.TabIndex = 1;
            // 
            // tabUser
            // 
            this.tabUser.BackColor = System.Drawing.Color.White;
            this.tabUser.Controls.Add(this.lblSelectUser);
            this.tabUser.Controls.Add(this.cmbUsers);
            this.tabUser.Controls.Add(this.txtUserDetails);
            this.tabUser.Controls.Add(this.btnDeleteUser);
            this.tabUser.Location = new System.Drawing.Point(4, 32);
            this.tabUser.Name = "tabUser";
            this.tabUser.Size = new System.Drawing.Size(752, 404);
            this.tabUser.TabIndex = 0;
            this.tabUser.Text = "Delete User";
            // 
            // lblSelectUser
            // 
            this.lblSelectUser.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblSelectUser.Location = new System.Drawing.Point(30, 30);
            this.lblSelectUser.Name = "lblSelectUser";
            this.lblSelectUser.Size = new System.Drawing.Size(200, 25);
            this.lblSelectUser.TabIndex = 0;
            this.lblSelectUser.Text = "Select User to Delete:";
            // 
            // cmbUsers
            // 
            this.cmbUsers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUsers.Location = new System.Drawing.Point(240, 30);
            this.cmbUsers.Name = "cmbUsers";
            this.cmbUsers.Size = new System.Drawing.Size(460, 31);
            this.cmbUsers.TabIndex = 1;
            this.cmbUsers.SelectedIndexChanged += new System.EventHandler(this.cmbUsers_SelectedIndexChanged);
            // 
            // txtUserDetails
            // 
            this.txtUserDetails.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.txtUserDetails.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtUserDetails.Location = new System.Drawing.Point(30, 80);
            this.txtUserDetails.Multiline = true;
            this.txtUserDetails.Name = "txtUserDetails";
            this.txtUserDetails.ReadOnly = true;
            this.txtUserDetails.Size = new System.Drawing.Size(670, 240);
            this.txtUserDetails.TabIndex = 2;
            // 
            // btnDeleteUser
            // 
            this.btnDeleteUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnDeleteUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteUser.FlatAppearance.BorderSize = 0;
            this.btnDeleteUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteUser.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnDeleteUser.ForeColor = System.Drawing.Color.White;
            this.btnDeleteUser.Location = new System.Drawing.Point(30, 340);
            this.btnDeleteUser.Name = "btnDeleteUser";
            this.btnDeleteUser.Size = new System.Drawing.Size(200, 45);
            this.btnDeleteUser.TabIndex = 3;
            this.btnDeleteUser.Text = "Delete User";
            this.btnDeleteUser.UseVisualStyleBackColor = false;
            this.btnDeleteUser.Click += new System.EventHandler(this.btnDeleteUser_Click);
            // 
            // tabTask
            // 
            this.tabTask.BackColor = System.Drawing.Color.White;
            this.tabTask.Controls.Add(this.lblSelectTask);
            this.tabTask.Controls.Add(this.cmbTasks);
            this.tabTask.Controls.Add(this.txtTaskDetails);
            this.tabTask.Controls.Add(this.btnDeleteTask);
            this.tabTask.Location = new System.Drawing.Point(4, 32);
            this.tabTask.Name = "tabTask";
            this.tabTask.Size = new System.Drawing.Size(752, 404);
            this.tabTask.TabIndex = 1;
            this.tabTask.Text = "Delete Task";
            // 
            // lblSelectTask
            // 
            this.lblSelectTask.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblSelectTask.Location = new System.Drawing.Point(30, 30);
            this.lblSelectTask.Name = "lblSelectTask";
            this.lblSelectTask.Size = new System.Drawing.Size(200, 25);
            this.lblSelectTask.TabIndex = 0;
            this.lblSelectTask.Text = "Select Task to Delete:";
            // 
            // cmbTasks
            // 
            this.cmbTasks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTasks.Location = new System.Drawing.Point(240, 30);
            this.cmbTasks.Name = "cmbTasks";
            this.cmbTasks.Size = new System.Drawing.Size(460, 31);
            this.cmbTasks.TabIndex = 1;
            this.cmbTasks.SelectedIndexChanged += new System.EventHandler(this.cmbTasks_SelectedIndexChanged);
            // 
            // txtTaskDetails
            // 
            this.txtTaskDetails.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.txtTaskDetails.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTaskDetails.Location = new System.Drawing.Point(30, 80);
            this.txtTaskDetails.Multiline = true;
            this.txtTaskDetails.Name = "txtTaskDetails";
            this.txtTaskDetails.ReadOnly = true;
            this.txtTaskDetails.Size = new System.Drawing.Size(670, 240);
            this.txtTaskDetails.TabIndex = 2;
            // 
            // btnDeleteTask
            // 
            this.btnDeleteTask.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnDeleteTask.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteTask.FlatAppearance.BorderSize = 0;
            this.btnDeleteTask.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteTask.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnDeleteTask.ForeColor = System.Drawing.Color.White;
            this.btnDeleteTask.Location = new System.Drawing.Point(30, 340);
            this.btnDeleteTask.Name = "btnDeleteTask";
            this.btnDeleteTask.Size = new System.Drawing.Size(200, 45);
            this.btnDeleteTask.TabIndex = 3;
            this.btnDeleteTask.Text = "Delete Task";
            this.btnDeleteTask.UseVisualStyleBackColor = false;
            this.btnDeleteTask.Click += new System.EventHandler(this.btnDeleteTask_Click);
            // 
            // DeleteForm
            // 
            this.ClientSize = new System.Drawing.Size(800, 550);
            this.Controls.Add(this.header);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "DeleteForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Delete Data";
            this.header.ResumeLayout(false);
            this.header.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabUser.ResumeLayout(false);
            this.tabUser.PerformLayout();
            this.tabTask.ResumeLayout(false);
            this.tabTask.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion
    }
}
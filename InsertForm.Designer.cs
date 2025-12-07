using System.Drawing;
using System.Windows.Forms;

namespace TaskManagementApp
{
    partial class InsertForm
    {
        private System.ComponentModel.IContainer components = null;
        private Panel header;
        private Label lblTitle;
        private TabControl tabControl;
        private TabPage tabUser;
        private TabPage tabTask;

        // User tab controls
        private Label lblUserID;
        private TextBox txtUserID;
        private Label lblUsername;
        private TextBox txtUsername;
        private Label lblPassword;
        private TextBox txtPassword;
        private Label lblRole;
        private TextBox txtRole;
        private Button btnInsertUser;

        // Task tab controls
        private Label lblTaskID;
        private TextBox txtTaskID;
        private Label lblTaskUserID;
        private TextBox txtTaskUserID;
        private Label lblTaskTitle;
        private TextBox txtTaskTitle;
        private Label lblTaskDescription;
        private TextBox txtTaskDescription;
        private Label lblTaskStatus;
        private TextBox txtTaskStatus;

        private GroupBox grpSteps;
        private Label lblStep1ID;
        private TextBox txtStep1ID;
        private Label lblStep1Desc;
        private TextBox txtStep1Desc;
        private Label lblStep1Status;
        private TextBox txtStep1Status;
        private Label lblStep2ID;
        private TextBox txtStep2ID;
        private Label lblStep2Desc;
        private TextBox txtStep2Desc;
        private Label lblStep2Status;
        private TextBox txtStep2Status;
        private Button btnInsertTask;

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
            this.lblUserID = new System.Windows.Forms.Label();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblRole = new System.Windows.Forms.Label();
            this.txtRole = new System.Windows.Forms.TextBox();
            this.btnInsertUser = new System.Windows.Forms.Button();
            this.tabTask = new System.Windows.Forms.TabPage();
            this.lblTaskID = new System.Windows.Forms.Label();
            this.txtTaskID = new System.Windows.Forms.TextBox();
            this.lblTaskUserID = new System.Windows.Forms.Label();
            this.txtTaskUserID = new System.Windows.Forms.TextBox();
            this.lblTaskTitle = new System.Windows.Forms.Label();
            this.txtTaskTitle = new System.Windows.Forms.TextBox();
            this.lblTaskDescription = new System.Windows.Forms.Label();
            this.txtTaskDescription = new System.Windows.Forms.TextBox();
            this.lblTaskStatus = new System.Windows.Forms.Label();
            this.txtTaskStatus = new System.Windows.Forms.TextBox();
            this.grpSteps = new System.Windows.Forms.GroupBox();
            this.lblStep1ID = new System.Windows.Forms.Label();
            this.txtStep1ID = new System.Windows.Forms.TextBox();
            this.lblStep1Desc = new System.Windows.Forms.Label();
            this.txtStep1Desc = new System.Windows.Forms.TextBox();
            this.lblStep1Status = new System.Windows.Forms.Label();
            this.txtStep1Status = new System.Windows.Forms.TextBox();
            this.lblStep2ID = new System.Windows.Forms.Label();
            this.txtStep2ID = new System.Windows.Forms.TextBox();
            this.lblStep2Desc = new System.Windows.Forms.Label();
            this.txtStep2Desc = new System.Windows.Forms.TextBox();
            this.lblStep2Status = new System.Windows.Forms.Label();
            this.txtStep2Status = new System.Windows.Forms.TextBox();
            this.btnInsertTask = new System.Windows.Forms.Button();
            this.header.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabUser.SuspendLayout();
            this.tabTask.SuspendLayout();
            this.grpSteps.SuspendLayout();
            this.SuspendLayout();
            // 
            // header
            // 
            this.header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(130)))), ((int)(((byte)(200)))));
            this.header.Controls.Add(this.lblTitle);
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
            this.lblTitle.Size = new System.Drawing.Size(296, 41);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "📥 Insert New Data";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabUser);
            this.tabControl.Controls.Add(this.tabTask);
            this.tabControl.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tabControl.Location = new System.Drawing.Point(20, 90);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(760, 590);
            this.tabControl.TabIndex = 1;
            // 
            // tabUser
            // 
            this.tabUser.BackColor = System.Drawing.Color.White;
            this.tabUser.Controls.Add(this.lblUserID);
            this.tabUser.Controls.Add(this.txtUserID);
            this.tabUser.Controls.Add(this.lblUsername);
            this.tabUser.Controls.Add(this.txtUsername);
            this.tabUser.Controls.Add(this.lblPassword);
            this.tabUser.Controls.Add(this.txtPassword);
            this.tabUser.Controls.Add(this.lblRole);
            this.tabUser.Controls.Add(this.txtRole);
            this.tabUser.Controls.Add(this.btnInsertUser);
            this.tabUser.Location = new System.Drawing.Point(4, 32);
            this.tabUser.Name = "tabUser";
            this.tabUser.Size = new System.Drawing.Size(752, 554);
            this.tabUser.TabIndex = 0;
            this.tabUser.Text = "Insert User";
            // 
            // lblUserID
            // 
            this.lblUserID.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblUserID.Location = new System.Drawing.Point(30, 30);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(150, 25);
            this.lblUserID.TabIndex = 0;
            this.lblUserID.Text = "User ID:";
            // 
            // txtUserID
            // 
            this.txtUserID.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtUserID.Location = new System.Drawing.Point(200, 30);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(500, 30);
            this.txtUserID.TabIndex = 1;
            this.txtUserID.TextChanged += new System.EventHandler(this.txtUserID_TextChanged);
            // 
            // lblUsername
            // 
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblUsername.Location = new System.Drawing.Point(30, 80);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(150, 25);
            this.lblUsername.TabIndex = 2;
            this.lblUsername.Text = "Username:";
            // 
            // txtUsername
            // 
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtUsername.Location = new System.Drawing.Point(200, 80);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(500, 30);
            this.txtUsername.TabIndex = 3;
            // 
            // lblPassword
            // 
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblPassword.Location = new System.Drawing.Point(30, 130);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(150, 25);
            this.lblPassword.TabIndex = 4;
            this.lblPassword.Text = "Password:";
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPassword.Location = new System.Drawing.Point(200, 130);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(500, 30);
            this.txtPassword.TabIndex = 5;
            // 
            // lblRole
            // 
            this.lblRole.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblRole.Location = new System.Drawing.Point(30, 180);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(150, 25);
            this.lblRole.TabIndex = 6;
            this.lblRole.Text = "Role:";
            // 
            // txtRole
            // 
            this.txtRole.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtRole.Location = new System.Drawing.Point(200, 180);
            this.txtRole.Name = "txtRole";
            this.txtRole.Size = new System.Drawing.Size(500, 30);
            this.txtRole.TabIndex = 7;
            // 
            // btnInsertUser
            // 
            this.btnInsertUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(130)))), ((int)(((byte)(200)))));
            this.btnInsertUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInsertUser.FlatAppearance.BorderSize = 0;
            this.btnInsertUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInsertUser.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnInsertUser.ForeColor = System.Drawing.Color.White;
            this.btnInsertUser.Location = new System.Drawing.Point(200, 240);
            this.btnInsertUser.Name = "btnInsertUser";
            this.btnInsertUser.Size = new System.Drawing.Size(200, 45);
            this.btnInsertUser.TabIndex = 8;
            this.btnInsertUser.Text = "Insert User";
            this.btnInsertUser.UseVisualStyleBackColor = false;
            this.btnInsertUser.Click += new System.EventHandler(this.btnInsertUser_Click);
            // 
            // tabTask
            // 
            this.tabTask.BackColor = System.Drawing.Color.White;
            this.tabTask.Controls.Add(this.lblTaskID);
            this.tabTask.Controls.Add(this.txtTaskID);
            this.tabTask.Controls.Add(this.lblTaskUserID);
            this.tabTask.Controls.Add(this.txtTaskUserID);
            this.tabTask.Controls.Add(this.lblTaskTitle);
            this.tabTask.Controls.Add(this.txtTaskTitle);
            this.tabTask.Controls.Add(this.lblTaskDescription);
            this.tabTask.Controls.Add(this.txtTaskDescription);
            this.tabTask.Controls.Add(this.lblTaskStatus);
            this.tabTask.Controls.Add(this.txtTaskStatus);
            this.tabTask.Controls.Add(this.grpSteps);
            this.tabTask.Controls.Add(this.btnInsertTask);
            this.tabTask.Location = new System.Drawing.Point(4, 32);
            this.tabTask.Name = "tabTask";
            this.tabTask.Size = new System.Drawing.Size(752, 554);
            this.tabTask.TabIndex = 1;
            this.tabTask.Text = "Insert Task";
            // 
            // lblTaskID
            // 
            this.lblTaskID.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTaskID.Location = new System.Drawing.Point(30, 20);
            this.lblTaskID.Name = "lblTaskID";
            this.lblTaskID.Size = new System.Drawing.Size(150, 25);
            this.lblTaskID.TabIndex = 0;
            this.lblTaskID.Text = "Task ID:";
            // 
            // txtTaskID
            // 
            this.txtTaskID.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTaskID.Location = new System.Drawing.Point(200, 20);
            this.txtTaskID.Name = "txtTaskID";
            this.txtTaskID.Size = new System.Drawing.Size(500, 30);
            this.txtTaskID.TabIndex = 1;
            this.txtTaskID.TextChanged += new System.EventHandler(this.txtTaskID_TextChanged);
            // 
            // lblTaskUserID
            // 
            this.lblTaskUserID.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTaskUserID.Location = new System.Drawing.Point(30, 60);
            this.lblTaskUserID.Name = "lblTaskUserID";
            this.lblTaskUserID.Size = new System.Drawing.Size(150, 25);
            this.lblTaskUserID.TabIndex = 2;
            this.lblTaskUserID.Text = "User ID:";
            // 
            // txtTaskUserID
            // 
            this.txtTaskUserID.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTaskUserID.Location = new System.Drawing.Point(200, 60);
            this.txtTaskUserID.Name = "txtTaskUserID";
            this.txtTaskUserID.Size = new System.Drawing.Size(500, 30);
            this.txtTaskUserID.TabIndex = 3;
            // 
            // lblTaskTitle
            // 
            this.lblTaskTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTaskTitle.Location = new System.Drawing.Point(30, 100);
            this.lblTaskTitle.Name = "lblTaskTitle";
            this.lblTaskTitle.Size = new System.Drawing.Size(150, 25);
            this.lblTaskTitle.TabIndex = 4;
            this.lblTaskTitle.Text = "Title:";
            // 
            // txtTaskTitle
            // 
            this.txtTaskTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTaskTitle.Location = new System.Drawing.Point(200, 100);
            this.txtTaskTitle.Name = "txtTaskTitle";
            this.txtTaskTitle.Size = new System.Drawing.Size(500, 30);
            this.txtTaskTitle.TabIndex = 5;
            // 
            // lblTaskDescription
            // 
            this.lblTaskDescription.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTaskDescription.Location = new System.Drawing.Point(30, 140);
            this.lblTaskDescription.Name = "lblTaskDescription";
            this.lblTaskDescription.Size = new System.Drawing.Size(150, 25);
            this.lblTaskDescription.TabIndex = 6;
            this.lblTaskDescription.Text = "Description:";
            // 
            // txtTaskDescription
            // 
            this.txtTaskDescription.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTaskDescription.Location = new System.Drawing.Point(200, 140);
            this.txtTaskDescription.Multiline = true;
            this.txtTaskDescription.Name = "txtTaskDescription";
            this.txtTaskDescription.Size = new System.Drawing.Size(500, 60);
            this.txtTaskDescription.TabIndex = 7;
            // 
            // lblTaskStatus
            // 
            this.lblTaskStatus.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTaskStatus.Location = new System.Drawing.Point(30, 210);
            this.lblTaskStatus.Name = "lblTaskStatus";
            this.lblTaskStatus.Size = new System.Drawing.Size(150, 25);
            this.lblTaskStatus.TabIndex = 8;
            this.lblTaskStatus.Text = "Task Status:";
            // 
            // txtTaskStatus
            // 
            this.txtTaskStatus.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTaskStatus.Location = new System.Drawing.Point(200, 210);
            this.txtTaskStatus.Name = "txtTaskStatus";
            this.txtTaskStatus.Size = new System.Drawing.Size(300, 30);
            this.txtTaskStatus.TabIndex = 9;
            // 
            // grpSteps
            // 
            this.grpSteps.Controls.Add(this.lblStep1ID);
            this.grpSteps.Controls.Add(this.txtStep1ID);
            this.grpSteps.Controls.Add(this.lblStep1Desc);
            this.grpSteps.Controls.Add(this.txtStep1Desc);
            this.grpSteps.Controls.Add(this.lblStep1Status);
            this.grpSteps.Controls.Add(this.txtStep1Status);
            this.grpSteps.Controls.Add(this.lblStep2ID);
            this.grpSteps.Controls.Add(this.txtStep2ID);
            this.grpSteps.Controls.Add(this.lblStep2Desc);
            this.grpSteps.Controls.Add(this.txtStep2Desc);
            this.grpSteps.Controls.Add(this.lblStep2Status);
            this.grpSteps.Controls.Add(this.txtStep2Status);
            this.grpSteps.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpSteps.Location = new System.Drawing.Point(30, 260);
            this.grpSteps.Name = "grpSteps";
            this.grpSteps.Size = new System.Drawing.Size(690, 220);
            this.grpSteps.TabIndex = 10;
            this.grpSteps.TabStop = false;
            this.grpSteps.Text = "Task Steps";
            // 
            // lblStep1ID
            // 
            this.lblStep1ID.Location = new System.Drawing.Point(20, 30);
            this.lblStep1ID.Name = "lblStep1ID";
            this.lblStep1ID.Size = new System.Drawing.Size(100, 25);
            this.lblStep1ID.TabIndex = 0;
            this.lblStep1ID.Text = "Step 1 ID:";
            // 
            // txtStep1ID
            // 
            this.txtStep1ID.Location = new System.Drawing.Point(130, 30);
            this.txtStep1ID.Name = "txtStep1ID";
            this.txtStep1ID.Size = new System.Drawing.Size(120, 30);
            this.txtStep1ID.TabIndex = 1;
            // 
            // lblStep1Desc
            // 
            this.lblStep1Desc.Location = new System.Drawing.Point(260, 30);
            this.lblStep1Desc.Name = "lblStep1Desc";
            this.lblStep1Desc.Size = new System.Drawing.Size(100, 25);
            this.lblStep1Desc.TabIndex = 2;
            this.lblStep1Desc.Text = "Description:";
            // 
            // txtStep1Desc
            // 
            this.txtStep1Desc.Location = new System.Drawing.Point(370, 30);
            this.txtStep1Desc.Name = "txtStep1Desc";
            this.txtStep1Desc.Size = new System.Drawing.Size(200, 30);
            this.txtStep1Desc.TabIndex = 3;
            // 
            // lblStep1Status
            // 
            this.lblStep1Status.Location = new System.Drawing.Point(580, 30);
            this.lblStep1Status.Name = "lblStep1Status";
            this.lblStep1Status.Size = new System.Drawing.Size(50, 25);
            this.lblStep1Status.TabIndex = 4;
            this.lblStep1Status.Text = "Status:";
            // 
            // txtStep1Status
            // 
            this.txtStep1Status.Location = new System.Drawing.Point(20, 60);
            this.txtStep1Status.Name = "txtStep1Status";
            this.txtStep1Status.Size = new System.Drawing.Size(650, 30);
            this.txtStep1Status.TabIndex = 5;
            // 
            // lblStep2ID
            // 
            this.lblStep2ID.Location = new System.Drawing.Point(20, 110);
            this.lblStep2ID.Name = "lblStep2ID";
            this.lblStep2ID.Size = new System.Drawing.Size(100, 25);
            this.lblStep2ID.TabIndex = 6;
            this.lblStep2ID.Text = "Step 2 ID:";
            // 
            // txtStep2ID
            // 
            this.txtStep2ID.Location = new System.Drawing.Point(130, 110);
            this.txtStep2ID.Name = "txtStep2ID";
            this.txtStep2ID.Size = new System.Drawing.Size(120, 30);
            this.txtStep2ID.TabIndex = 7;
            // 
            // lblStep2Desc
            // 
            this.lblStep2Desc.Location = new System.Drawing.Point(260, 110);
            this.lblStep2Desc.Name = "lblStep2Desc";
            this.lblStep2Desc.Size = new System.Drawing.Size(100, 25);
            this.lblStep2Desc.TabIndex = 8;
            this.lblStep2Desc.Text = "Description:";
            // 
            // txtStep2Desc
            // 
            this.txtStep2Desc.Location = new System.Drawing.Point(370, 110);
            this.txtStep2Desc.Name = "txtStep2Desc";
            this.txtStep2Desc.Size = new System.Drawing.Size(200, 30);
            this.txtStep2Desc.TabIndex = 9;
            // 
            // lblStep2Status
            // 
            this.lblStep2Status.Location = new System.Drawing.Point(580, 110);
            this.lblStep2Status.Name = "lblStep2Status";
            this.lblStep2Status.Size = new System.Drawing.Size(50, 25);
            this.lblStep2Status.TabIndex = 10;
            this.lblStep2Status.Text = "Status:";
            // 
            // txtStep2Status
            // 
            this.txtStep2Status.Location = new System.Drawing.Point(20, 140);
            this.txtStep2Status.Name = "txtStep2Status";
            this.txtStep2Status.Size = new System.Drawing.Size(650, 30);
            this.txtStep2Status.TabIndex = 11;
            // 
            // btnInsertTask
            // 
            this.btnInsertTask.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(130)))), ((int)(((byte)(200)))));
            this.btnInsertTask.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInsertTask.FlatAppearance.BorderSize = 0;
            this.btnInsertTask.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInsertTask.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnInsertTask.ForeColor = System.Drawing.Color.White;
            this.btnInsertTask.Location = new System.Drawing.Point(200, 495);
            this.btnInsertTask.Name = "btnInsertTask";
            this.btnInsertTask.Size = new System.Drawing.Size(200, 45);
            this.btnInsertTask.TabIndex = 11;
            this.btnInsertTask.Text = "Insert Task";
            this.btnInsertTask.UseVisualStyleBackColor = false;
            this.btnInsertTask.Click += new System.EventHandler(this.btnInsertTask_Click);
            // 
            // InsertForm
            // 
            this.ClientSize = new System.Drawing.Size(800, 700);
            this.Controls.Add(this.header);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "InsertForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Insert Data";
            this.Load += new System.EventHandler(this.InsertForm_Load);
            this.header.ResumeLayout(false);
            this.header.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabUser.ResumeLayout(false);
            this.tabUser.PerformLayout();
            this.tabTask.ResumeLayout(false);
            this.tabTask.PerformLayout();
            this.grpSteps.ResumeLayout(false);
            this.grpSteps.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion
    }
}
using System.Drawing;
using System.Windows.Forms;

namespace TaskManagementApp
{
    partial class UpdateForm
    {
        private System.ComponentModel.IContainer components = null;
        private Panel header;
        private Label lblTitle;
        private Button btnRefresh;
        private TabControl tabControl;
        private TabPage tabUser;
        private TabPage tabTask;

        // User Tab
        private Label lblSelectUser;
        private ComboBox cmbUsers;
        private Label lblUsername;
        private TextBox txtUsername;
        private Label lblPassword;
        private TextBox txtPassword;
        private Label lblRole;
        private TextBox txtRole;
        private Button btnUpdateUser;

        // Task Tab
        private Label lblSelectTask;
        private ComboBox cmbTasks;
        private Label lblTaskUserID;
        private TextBox txtTaskUserID;
        private Label lblTaskTitle;
        private TextBox txtTaskTitle;
        private Label lblTaskDescription;
        private TextBox txtTaskDescription;
        private Label lblTaskDueDate;
        private DateTimePicker dtpDueDate;
        private Button btnUpdateTask;

        // Steps Grid
        private DataGridView dgvSteps;
        private DataGridViewTextBoxColumn colStepID;
        private DataGridViewTextBoxColumn colDescription;
        private DataGridViewTextBoxColumn colStatus;

        // Step Editor
        private Label lblStepEditorTitle;
        private Label lblStepID;
        private TextBox txtStepID;
        private Label lblStepDesc;
        private TextBox txtStepDescription;
        private Label lblStepStatus;
        private ComboBox cmbStepStatus;
        private Button btnUpdateStep;

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
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblRole = new System.Windows.Forms.Label();
            this.txtRole = new System.Windows.Forms.TextBox();
            this.btnUpdateUser = new System.Windows.Forms.Button();
            this.tabTask = new System.Windows.Forms.TabPage();
            this.lblSelectTask = new System.Windows.Forms.Label();
            this.cmbTasks = new System.Windows.Forms.ComboBox();
            this.lblTaskUserID = new System.Windows.Forms.Label();
            this.txtTaskUserID = new System.Windows.Forms.TextBox();
            this.lblTaskTitle = new System.Windows.Forms.Label();
            this.txtTaskTitle = new System.Windows.Forms.TextBox();
            this.lblTaskDescription = new System.Windows.Forms.Label();
            this.txtTaskDescription = new System.Windows.Forms.TextBox();
            this.lblTaskDueDate = new System.Windows.Forms.Label();
            this.dtpDueDate = new System.Windows.Forms.DateTimePicker();
            this.btnUpdateTask = new System.Windows.Forms.Button();
            this.dgvSteps = new System.Windows.Forms.DataGridView();
            this.StepID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblStepEditorTitle = new System.Windows.Forms.Label();
            this.lblStepID = new System.Windows.Forms.Label();
            this.txtStepID = new System.Windows.Forms.TextBox();
            this.lblStepDesc = new System.Windows.Forms.Label();
            this.txtStepDescription = new System.Windows.Forms.TextBox();
            this.lblStepStatus = new System.Windows.Forms.Label();
            this.cmbStepStatus = new System.Windows.Forms.ComboBox();
            this.btnUpdateStep = new System.Windows.Forms.Button();
            this.header.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabUser.SuspendLayout();
            this.tabTask.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSteps)).BeginInit();
            this.SuspendLayout();
            // 
            // header
            // 
            this.header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(130)))), ((int)(((byte)(200)))));
            this.header.Controls.Add(this.lblTitle);
            this.header.Controls.Add(this.btnRefresh);
            this.header.Dock = System.Windows.Forms.DockStyle.Top;
            this.header.Location = new System.Drawing.Point(0, 0);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(1000, 70);
            this.header.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(246, 41);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "✏️ Update Data";
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(160)))), ((int)(((byte)(80)))));
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(860, 20);
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
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tabControl.Location = new System.Drawing.Point(0, 70);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1000, 680);
            this.tabControl.TabIndex = 0;
            // 
            // tabUser
            // 
            this.tabUser.BackColor = System.Drawing.Color.White;
            this.tabUser.Controls.Add(this.lblSelectUser);
            this.tabUser.Controls.Add(this.cmbUsers);
            this.tabUser.Controls.Add(this.lblUsername);
            this.tabUser.Controls.Add(this.txtUsername);
            this.tabUser.Controls.Add(this.lblPassword);
            this.tabUser.Controls.Add(this.txtPassword);
            this.tabUser.Controls.Add(this.lblRole);
            this.tabUser.Controls.Add(this.txtRole);
            this.tabUser.Controls.Add(this.btnUpdateUser);
            this.tabUser.Location = new System.Drawing.Point(4, 32);
            this.tabUser.Name = "tabUser";
            this.tabUser.Size = new System.Drawing.Size(992, 644);
            this.tabUser.TabIndex = 0;
            this.tabUser.Text = "👤 Update User";
            // 
            // lblSelectUser
            // 
            this.lblSelectUser.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblSelectUser.Location = new System.Drawing.Point(30, 30);
            this.lblSelectUser.Name = "lblSelectUser";
            this.lblSelectUser.Size = new System.Drawing.Size(150, 25);
            this.lblSelectUser.TabIndex = 0;
            this.lblSelectUser.Text = "Select User:";
            // 
            // cmbUsers
            // 
            this.cmbUsers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUsers.Location = new System.Drawing.Point(200, 30);
            this.cmbUsers.Name = "cmbUsers";
            this.cmbUsers.Size = new System.Drawing.Size(700, 31);
            this.cmbUsers.TabIndex = 1;
            this.cmbUsers.SelectedIndexChanged += new System.EventHandler(this.cmbUsers_SelectedIndexChanged);
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
            this.txtUsername.Location = new System.Drawing.Point(200, 80);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(700, 30);
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
            this.txtPassword.Location = new System.Drawing.Point(200, 130);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(700, 30);
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
            this.txtRole.Location = new System.Drawing.Point(200, 180);
            this.txtRole.Name = "txtRole";
            this.txtRole.Size = new System.Drawing.Size(700, 30);
            this.txtRole.TabIndex = 7;
            // 
            // btnUpdateUser
            // 
            this.btnUpdateUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(130)))), ((int)(((byte)(200)))));
            this.btnUpdateUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdateUser.FlatAppearance.BorderSize = 0;
            this.btnUpdateUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateUser.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnUpdateUser.ForeColor = System.Drawing.Color.White;
            this.btnUpdateUser.Location = new System.Drawing.Point(200, 240);
            this.btnUpdateUser.Name = "btnUpdateUser";
            this.btnUpdateUser.Size = new System.Drawing.Size(200, 45);
            this.btnUpdateUser.TabIndex = 8;
            this.btnUpdateUser.Text = "✓ Update User";
            this.btnUpdateUser.UseVisualStyleBackColor = false;
            this.btnUpdateUser.Click += new System.EventHandler(this.btnUpdateUser_Click);
            // 
            // tabTask
            // 
            this.tabTask.AutoScroll = true;
            this.tabTask.BackColor = System.Drawing.Color.White;
            this.tabTask.Controls.Add(this.lblSelectTask);
            this.tabTask.Controls.Add(this.cmbTasks);
            this.tabTask.Controls.Add(this.lblTaskUserID);
            this.tabTask.Controls.Add(this.txtTaskUserID);
            this.tabTask.Controls.Add(this.lblTaskTitle);
            this.tabTask.Controls.Add(this.txtTaskTitle);
            this.tabTask.Controls.Add(this.lblTaskDescription);
            this.tabTask.Controls.Add(this.txtTaskDescription);
            this.tabTask.Controls.Add(this.lblTaskDueDate);
            this.tabTask.Controls.Add(this.dtpDueDate);
            this.tabTask.Controls.Add(this.btnUpdateTask);
            this.tabTask.Controls.Add(this.dgvSteps);
            this.tabTask.Controls.Add(this.lblStepEditorTitle);
            this.tabTask.Controls.Add(this.lblStepID);
            this.tabTask.Controls.Add(this.txtStepID);
            this.tabTask.Controls.Add(this.lblStepDesc);
            this.tabTask.Controls.Add(this.txtStepDescription);
            this.tabTask.Controls.Add(this.lblStepStatus);
            this.tabTask.Controls.Add(this.cmbStepStatus);
            this.tabTask.Controls.Add(this.btnUpdateStep);
            this.tabTask.Location = new System.Drawing.Point(4, 32);
            this.tabTask.Name = "tabTask";
            this.tabTask.Size = new System.Drawing.Size(992, 644);
            this.tabTask.TabIndex = 1;
            this.tabTask.Text = "📋 Update Task";
            // 
            // lblSelectTask
            // 
            this.lblSelectTask.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblSelectTask.Location = new System.Drawing.Point(30, 30);
            this.lblSelectTask.Name = "lblSelectTask";
            this.lblSelectTask.Size = new System.Drawing.Size(150, 25);
            this.lblSelectTask.TabIndex = 0;
            this.lblSelectTask.Text = "Select Task:";
            // 
            // cmbTasks
            // 
            this.cmbTasks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTasks.Location = new System.Drawing.Point(200, 30);
            this.cmbTasks.Name = "cmbTasks";
            this.cmbTasks.Size = new System.Drawing.Size(700, 31);
            this.cmbTasks.TabIndex = 1;
            this.cmbTasks.SelectedIndexChanged += new System.EventHandler(this.cmbTasks_SelectedIndexChanged);
            // 
            // lblTaskUserID
            // 
            this.lblTaskUserID.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTaskUserID.Location = new System.Drawing.Point(30, 80);
            this.lblTaskUserID.Name = "lblTaskUserID";
            this.lblTaskUserID.Size = new System.Drawing.Size(150, 25);
            this.lblTaskUserID.TabIndex = 2;
            this.lblTaskUserID.Text = "User ID:";
            // 
            // txtTaskUserID
            // 
            this.txtTaskUserID.Location = new System.Drawing.Point(200, 80);
            this.txtTaskUserID.Name = "txtTaskUserID";
            this.txtTaskUserID.Size = new System.Drawing.Size(700, 30);
            this.txtTaskUserID.TabIndex = 3;
            // 
            // lblTaskTitle
            // 
            this.lblTaskTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTaskTitle.Location = new System.Drawing.Point(30, 130);
            this.lblTaskTitle.Name = "lblTaskTitle";
            this.lblTaskTitle.Size = new System.Drawing.Size(150, 25);
            this.lblTaskTitle.TabIndex = 4;
            this.lblTaskTitle.Text = "Title:";
            // 
            // txtTaskTitle
            // 
            this.txtTaskTitle.Location = new System.Drawing.Point(200, 130);
            this.txtTaskTitle.Name = "txtTaskTitle";
            this.txtTaskTitle.Size = new System.Drawing.Size(700, 30);
            this.txtTaskTitle.TabIndex = 5;
            // 
            // lblTaskDescription
            // 
            this.lblTaskDescription.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTaskDescription.Location = new System.Drawing.Point(30, 180);
            this.lblTaskDescription.Name = "lblTaskDescription";
            this.lblTaskDescription.Size = new System.Drawing.Size(150, 25);
            this.lblTaskDescription.TabIndex = 6;
            this.lblTaskDescription.Text = "Description:";
            // 
            // txtTaskDescription
            // 
            this.txtTaskDescription.Location = new System.Drawing.Point(200, 180);
            this.txtTaskDescription.Multiline = true;
            this.txtTaskDescription.Name = "txtTaskDescription";
            this.txtTaskDescription.Size = new System.Drawing.Size(700, 60);
            this.txtTaskDescription.TabIndex = 7;
            // 
            // lblTaskDueDate
            // 
            this.lblTaskDueDate.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTaskDueDate.Location = new System.Drawing.Point(30, 260);
            this.lblTaskDueDate.Name = "lblTaskDueDate";
            this.lblTaskDueDate.Size = new System.Drawing.Size(150, 25);
            this.lblTaskDueDate.TabIndex = 8;
            this.lblTaskDueDate.Text = "Due Date:";
            // 
            // dtpDueDate
            // 
            this.dtpDueDate.Location = new System.Drawing.Point(200, 260);
            this.dtpDueDate.Name = "dtpDueDate";
            this.dtpDueDate.Size = new System.Drawing.Size(300, 30);
            this.dtpDueDate.TabIndex = 9;
            // 
            // btnUpdateTask
            // 
            this.btnUpdateTask.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(130)))), ((int)(((byte)(200)))));
            this.btnUpdateTask.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdateTask.FlatAppearance.BorderSize = 0;
            this.btnUpdateTask.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateTask.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnUpdateTask.ForeColor = System.Drawing.Color.White;
            this.btnUpdateTask.Location = new System.Drawing.Point(200, 310);
            this.btnUpdateTask.Name = "btnUpdateTask";
            this.btnUpdateTask.Size = new System.Drawing.Size(200, 45);
            this.btnUpdateTask.TabIndex = 10;
            this.btnUpdateTask.Text = "✓ Update Task";
            this.btnUpdateTask.UseVisualStyleBackColor = false;
            this.btnUpdateTask.Click += new System.EventHandler(this.btnUpdateTask_Click);
            // 
            // dgvSteps
            // 
            this.dgvSteps.AllowUserToAddRows = false;
            this.dgvSteps.AllowUserToDeleteRows = false;
            this.dgvSteps.ColumnHeadersHeight = 29;
            this.dgvSteps.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StepID,
            this.Description,
            this.Status});
            this.dgvSteps.Location = new System.Drawing.Point(30, 380);
            this.dgvSteps.MultiSelect = false;
            this.dgvSteps.Name = "dgvSteps";
            this.dgvSteps.RowHeadersWidth = 51;
            this.dgvSteps.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSteps.Size = new System.Drawing.Size(900, 220);
            this.dgvSteps.TabIndex = 11;
            this.dgvSteps.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSteps_CellClick);
            this.dgvSteps.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvSteps_CellBeginEdit);
            // 
            // StepID
            // 
            this.StepID.HeaderText = "Step ID";
            this.StepID.MinimumWidth = 6;
            this.StepID.Name = "StepID";
            this.StepID.ReadOnly = true;
            this.StepID.Width = 125;
            // 
            // Description
            // 
            this.Description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Description.HeaderText = "Description";
            this.Description.MinimumWidth = 6;
            this.Description.Name = "Description";
            // 
            // Status
            // 
            this.Status.HeaderText = "Status";
            this.Status.MinimumWidth = 6;
            this.Status.Name = "Status";
            this.Status.Width = 120;
            // 
            // lblStepEditorTitle
            // 
            this.lblStepEditorTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblStepEditorTitle.Location = new System.Drawing.Point(30, 620);
            this.lblStepEditorTitle.Name = "lblStepEditorTitle";
            this.lblStepEditorTitle.Size = new System.Drawing.Size(300, 25);
            this.lblStepEditorTitle.TabIndex = 12;
            this.lblStepEditorTitle.Text = "🔧 Step Editor (Admin Only)";
            // 
            // lblStepID
            // 
            this.lblStepID.Location = new System.Drawing.Point(30, 660);
            this.lblStepID.Name = "lblStepID";
            this.lblStepID.Size = new System.Drawing.Size(100, 25);
            this.lblStepID.TabIndex = 13;
            this.lblStepID.Text = "Step ID:";
            // 
            // txtStepID
            // 
            this.txtStepID.Location = new System.Drawing.Point(140, 660);
            this.txtStepID.Name = "txtStepID";
            this.txtStepID.ReadOnly = true;
            this.txtStepID.Size = new System.Drawing.Size(120, 30);
            this.txtStepID.TabIndex = 14;
            // 
            // lblStepDesc
            // 
            this.lblStepDesc.Location = new System.Drawing.Point(30, 710);
            this.lblStepDesc.Name = "lblStepDesc";
            this.lblStepDesc.Size = new System.Drawing.Size(100, 25);
            this.lblStepDesc.TabIndex = 15;
            this.lblStepDesc.Text = "Description:";
            // 
            // txtStepDescription
            // 
            this.txtStepDescription.Location = new System.Drawing.Point(140, 710);
            this.txtStepDescription.Multiline = true;
            this.txtStepDescription.Name = "txtStepDescription";
            this.txtStepDescription.Size = new System.Drawing.Size(790, 60);
            this.txtStepDescription.TabIndex = 16;
            // 
            // lblStepStatus
            // 
            this.lblStepStatus.Location = new System.Drawing.Point(30, 790);
            this.lblStepStatus.Name = "lblStepStatus";
            this.lblStepStatus.Size = new System.Drawing.Size(100, 25);
            this.lblStepStatus.TabIndex = 17;
            this.lblStepStatus.Text = "Status:";
            // 
            // cmbStepStatus
            // 
            this.cmbStepStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStepStatus.Items.AddRange(new object[] {
            "Pending",
            "Completed"});
            this.cmbStepStatus.Location = new System.Drawing.Point(140, 790);
            this.cmbStepStatus.Name = "cmbStepStatus";
            this.cmbStepStatus.Size = new System.Drawing.Size(200, 31);
            this.cmbStepStatus.TabIndex = 18;
            // 
            // btnUpdateStep
            // 
            this.btnUpdateStep.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(140)))), ((int)(((byte)(0)))));
            this.btnUpdateStep.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdateStep.FlatAppearance.BorderSize = 0;
            this.btnUpdateStep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateStep.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnUpdateStep.ForeColor = System.Drawing.Color.White;
            this.btnUpdateStep.Location = new System.Drawing.Point(140, 840);
            this.btnUpdateStep.Name = "btnUpdateStep";
            this.btnUpdateStep.Size = new System.Drawing.Size(200, 45);
            this.btnUpdateStep.TabIndex = 19;
            this.btnUpdateStep.Text = "✓ Update Step";
            this.btnUpdateStep.UseVisualStyleBackColor = false;
            this.btnUpdateStep.Click += new System.EventHandler(this.btnUpdateStep_Click);
            // 
            // UpdateForm
            // 
            this.ClientSize = new System.Drawing.Size(1000, 750);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.header);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "UpdateForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Update Data - Admin";
            this.Load += new System.EventHandler(this.UpdateForm_Load);
            this.header.ResumeLayout(false);
            this.header.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabUser.ResumeLayout(false);
            this.tabUser.PerformLayout();
            this.tabTask.ResumeLayout(false);
            this.tabTask.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSteps)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private DataGridViewTextBoxColumn StepID;
        private DataGridViewTextBoxColumn Description;
        private DataGridViewTextBoxColumn Status;
    }
}
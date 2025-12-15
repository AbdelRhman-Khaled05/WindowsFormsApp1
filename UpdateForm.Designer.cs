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
            this.components = new System.ComponentModel.Container();

            // Header
            this.header = new Panel();
            this.header.BackColor = Color.FromArgb(60, 130, 200);
            this.header.Dock = DockStyle.Top;
            this.header.Height = 70;

            this.lblTitle = new Label();
            this.lblTitle.Text = "✏️ Update Data";
            this.lblTitle.ForeColor = Color.White;
            this.lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            this.lblTitle.Location = new Point(20, 18);
            this.lblTitle.AutoSize = true;

            this.btnRefresh = new Button();
            this.btnRefresh.Text = "↻ Refresh";
            this.btnRefresh.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnRefresh.BackColor = Color.FromArgb(40, 160, 80);
            this.btnRefresh.ForeColor = Color.White;
            this.btnRefresh.FlatStyle = FlatStyle.Flat;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.Size = new Size(120, 35);
            this.btnRefresh.Location = new Point(860, 20);
            this.btnRefresh.Cursor = Cursors.Hand;
            this.btnRefresh.Click += btnRefresh_Click;

            this.header.Controls.Add(lblTitle);
            this.header.Controls.Add(btnRefresh);

            // Tab Control
            this.tabControl = new TabControl();
            this.tabControl.Font = new Font("Segoe UI", 10F);
            this.tabControl.Dock = DockStyle.Fill;

            // ==================== USER TAB ====================
            this.tabUser = new TabPage("👤 Update User");
            this.tabUser.BackColor = Color.White;

            lblSelectUser = new Label();
            lblSelectUser.Text = "Select User:";
            lblSelectUser.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblSelectUser.Location = new Point(30, 30);
            lblSelectUser.Size = new Size(150, 25);

            cmbUsers = new ComboBox();
            cmbUsers.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbUsers.Location = new Point(200, 30);
            cmbUsers.Size = new Size(700, 31);
            cmbUsers.SelectedIndexChanged += cmbUsers_SelectedIndexChanged;

            lblUsername = new Label();
            lblUsername.Text = "Username:";
            lblUsername.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblUsername.Location = new Point(30, 80);
            lblUsername.Size = new Size(150, 25);

            txtUsername = new TextBox();
            txtUsername.Location = new Point(200, 80);
            txtUsername.Size = new Size(700, 30);

            lblPassword = new Label();
            lblPassword.Text = "Password:";
            lblPassword.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblPassword.Location = new Point(30, 130);
            lblPassword.Size = new Size(150, 25);

            txtPassword = new TextBox();
            txtPassword.Location = new Point(200, 130);
            txtPassword.Size = new Size(700, 30);

            lblRole = new Label();
            lblRole.Text = "Role:";
            lblRole.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblRole.Location = new Point(30, 180);
            lblRole.Size = new Size(150, 25);

            txtRole = new TextBox();
            txtRole.Location = new Point(200, 180);
            txtRole.Size = new Size(700, 30);

            btnUpdateUser = new Button();
            btnUpdateUser.Text = "✓ Update User";
            btnUpdateUser.BackColor = Color.FromArgb(60, 130, 200);
            btnUpdateUser.ForeColor = Color.White;
            btnUpdateUser.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnUpdateUser.FlatStyle = FlatStyle.Flat;
            btnUpdateUser.FlatAppearance.BorderSize = 0;
            btnUpdateUser.Size = new Size(200, 45);
            btnUpdateUser.Location = new Point(200, 240);
            btnUpdateUser.Cursor = Cursors.Hand;
            btnUpdateUser.Click += btnUpdateUser_Click;

            tabUser.Controls.Add(lblSelectUser);
            tabUser.Controls.Add(cmbUsers);
            tabUser.Controls.Add(lblUsername);
            tabUser.Controls.Add(txtUsername);
            tabUser.Controls.Add(lblPassword);
            tabUser.Controls.Add(txtPassword);
            tabUser.Controls.Add(lblRole);
            tabUser.Controls.Add(txtRole);
            tabUser.Controls.Add(btnUpdateUser);

            // ==================== TASK TAB ====================
            this.tabTask = new TabPage("📋 Update Task");
            this.tabTask.BackColor = Color.White;
            this.tabTask.AutoScroll = true;

            lblSelectTask = new Label();
            lblSelectTask.Text = "Select Task:";
            lblSelectTask.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblSelectTask.Location = new Point(30, 30);
            lblSelectTask.Size = new Size(150, 25);

            cmbTasks = new ComboBox();
            cmbTasks.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTasks.Location = new Point(200, 30);
            cmbTasks.Size = new Size(700, 31);
            cmbTasks.SelectedIndexChanged += cmbTasks_SelectedIndexChanged;

            lblTaskUserID = new Label();
            lblTaskUserID.Text = "User ID:";
            lblTaskUserID.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTaskUserID.Location = new Point(30, 80);
            lblTaskUserID.Size = new Size(150, 25);

            txtTaskUserID = new TextBox();
            txtTaskUserID.Location = new Point(200, 80);
            txtTaskUserID.Size = new Size(700, 30);

            lblTaskTitle = new Label();
            lblTaskTitle.Text = "Title:";
            lblTaskTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTaskTitle.Location = new Point(30, 130);
            lblTaskTitle.Size = new Size(150, 25);

            txtTaskTitle = new TextBox();
            txtTaskTitle.Location = new Point(200, 130);
            txtTaskTitle.Size = new Size(700, 30);

            lblTaskDescription = new Label();
            lblTaskDescription.Text = "Description:";
            lblTaskDescription.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTaskDescription.Location = new Point(30, 180);
            lblTaskDescription.Size = new Size(150, 25);

            txtTaskDescription = new TextBox();
            txtTaskDescription.Multiline = true;
            txtTaskDescription.Location = new Point(200, 180);
            txtTaskDescription.Size = new Size(700, 60);

            lblTaskDueDate = new Label();
            lblTaskDueDate.Text = "Due Date:";
            lblTaskDueDate.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTaskDueDate.Location = new Point(30, 260);
            lblTaskDueDate.Size = new Size(150, 25);

            dtpDueDate = new DateTimePicker();
            dtpDueDate.Location = new Point(200, 260);
            dtpDueDate.Size = new Size(300, 30);

            btnUpdateTask = new Button();
            btnUpdateTask.Text = "✓ Update Task";
            btnUpdateTask.BackColor = Color.FromArgb(60, 130, 200);
            btnUpdateTask.ForeColor = Color.White;
            btnUpdateTask.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnUpdateTask.FlatStyle = FlatStyle.Flat;
            btnUpdateTask.FlatAppearance.BorderSize = 0;
            btnUpdateTask.Size = new Size(200, 45);
            btnUpdateTask.Location = new Point(200, 310);
            btnUpdateTask.Cursor = Cursors.Hand;
            btnUpdateTask.Click += btnUpdateTask_Click;

            // Steps Grid
            dgvSteps = new DataGridView();
            dgvSteps.Location = new Point(30, 380);
            dgvSteps.Size = new Size(900, 220);
            dgvSteps.AllowUserToAddRows = false;
            dgvSteps.AllowUserToDeleteRows = false;
            dgvSteps.MultiSelect = false;
            dgvSteps.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSteps.ReadOnly = false;
            dgvSteps.CellClick += dgvSteps_CellClick;
            dgvSteps.CellBeginEdit += dgvSteps_CellBeginEdit;

            colStepID = new DataGridViewTextBoxColumn();
            colStepID.Name = "StepID";
            colStepID.HeaderText = "Step ID";
            colStepID.Width = 100;
            colStepID.ReadOnly = true;

            colDescription = new DataGridViewTextBoxColumn();
            colDescription.Name = "Description";
            colDescription.HeaderText = "Description";
            colDescription.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            colStatus = new DataGridViewTextBoxColumn();
            colStatus.Name = "Status";
            colStatus.HeaderText = "Status";
            colStatus.Width = 120;

            dgvSteps.Columns.AddRange(colStepID, colDescription, colStatus);

            // Step Editor
            lblStepEditorTitle = new Label();
            lblStepEditorTitle.Text = "🔧 Step Editor (Admin Only)";
            lblStepEditorTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblStepEditorTitle.Location = new Point(30, 620);
            lblStepEditorTitle.Size = new Size(300, 25);

            lblStepID = new Label();
            lblStepID.Text = "Step ID:";
            lblStepID.Location = new Point(30, 660);
            lblStepID.Size = new Size(100, 25);

            txtStepID = new TextBox();
            txtStepID.Location = new Point(140, 660);
            txtStepID.Size = new Size(120, 30);
            txtStepID.ReadOnly = true;

            lblStepDesc = new Label();
            lblStepDesc.Text = "Description:";
            lblStepDesc.Location = new Point(30, 710);
            lblStepDesc.Size = new Size(100, 25);

            txtStepDescription = new TextBox();
            txtStepDescription.Multiline = true;
            txtStepDescription.Location = new Point(140, 710);
            txtStepDescription.Size = new Size(790, 60);

            lblStepStatus = new Label();
            lblStepStatus.Text = "Status:";
            lblStepStatus.Location = new Point(30, 790);
            lblStepStatus.Size = new Size(100, 25);

            cmbStepStatus = new ComboBox();
            cmbStepStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStepStatus.Items.AddRange(new string[] { "Pending", "Completed" });
            cmbStepStatus.Location = new Point(140, 790);
            cmbStepStatus.Size = new Size(200, 31);

            btnUpdateStep = new Button();
            btnUpdateStep.Text = "✓ Update Step";
            btnUpdateStep.BackColor = Color.FromArgb(255, 140, 0);
            btnUpdateStep.ForeColor = Color.White;
            btnUpdateStep.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnUpdateStep.FlatStyle = FlatStyle.Flat;
            btnUpdateStep.FlatAppearance.BorderSize = 0;
            btnUpdateStep.Size = new Size(200, 45);
            btnUpdateStep.Location = new Point(140, 840);
            btnUpdateStep.Cursor = Cursors.Hand;
            btnUpdateStep.Click += btnUpdateStep_Click;

            tabTask.Controls.Add(lblSelectTask);
            tabTask.Controls.Add(cmbTasks);
            tabTask.Controls.Add(lblTaskUserID);
            tabTask.Controls.Add(txtTaskUserID);
            tabTask.Controls.Add(lblTaskTitle);
            tabTask.Controls.Add(txtTaskTitle);
            tabTask.Controls.Add(lblTaskDescription);
            tabTask.Controls.Add(txtTaskDescription);
            tabTask.Controls.Add(lblTaskDueDate);
            tabTask.Controls.Add(dtpDueDate);
            tabTask.Controls.Add(btnUpdateTask);
            tabTask.Controls.Add(dgvSteps);
            tabTask.Controls.Add(lblStepEditorTitle);
            tabTask.Controls.Add(lblStepID);
            tabTask.Controls.Add(txtStepID);
            tabTask.Controls.Add(lblStepDesc);
            tabTask.Controls.Add(txtStepDescription);
            tabTask.Controls.Add(lblStepStatus);
            tabTask.Controls.Add(cmbStepStatus);
            tabTask.Controls.Add(btnUpdateStep);

            // Add tabs
            tabControl.Controls.Add(tabUser);
            tabControl.Controls.Add(tabTask);

            // Form settings
            this.ClientSize = new Size(1000, 750);
            this.Controls.Add(tabControl);
            this.Controls.Add(header);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
            this.Text = "Update Data - Admin";
            this.Load += UpdateForm_Load;
        }
        #endregion
    }
}
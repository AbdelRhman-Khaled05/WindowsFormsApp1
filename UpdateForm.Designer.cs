using System.Drawing;
using System.Windows.Forms;

namespace TaskManagementApp
{
    partial class UpdateForm
    {
        private System.ComponentModel.IContainer components = null;

        // Header
        private Panel header;
        private Label lblTitle;
        private Button btnRefresh;

        // Tabs
        private TabControl tabControl;
        private TabPage tabUser;
        private TabPage tabTask;

        // User Tab Controls
        private Label lblSelectUser;
        private ComboBox cmbUsers;
        private Label lblUsername;
        private TextBox txtUsername;
        private Label lblPassword;
        private TextBox txtPassword;
        private Label lblRole;
        private TextBox txtRole;
        private Button btnUpdateUser;

        // Task Tab Controls
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

        // Step Editor Controls
        private Label lblStepEditorTitle;
        private Label lblStepID;
        private TextBox txtStepID;
        private Label lblStepDesc;
        private TextBox txtStepDescription;
        private Label lblStepStatus;
        private ComboBox cmbStepStatus;
        private Label lblSignedOff;
        private ComboBox cmbSignedOff;

        // Update Step Button
        private Button btnUpdateStep;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Designer
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            // =====================================================================
            // HEADER
            // =====================================================================
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
            this.btnRefresh.Location = new Point(780, 20);
            this.btnRefresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.btnRefresh.Click += btnRefresh_Click;

            this.header.Controls.Add(lblTitle);
            this.header.Controls.Add(btnRefresh);

            // =====================================================================
            // TAB CONTROL
            // =====================================================================
            this.tabControl = new TabControl();
            this.tabControl.Font = new Font("Segoe UI", 10F);
            // Make the tabs fill the remaining form area (below header)
            this.tabControl.Dock = DockStyle.Fill;
            this.tabControl.Padding = new Point(10, 6);

            // =====================================================================
            // USER TAB
            // =====================================================================
            this.tabUser = new TabPage("Update User");
            this.tabUser.BackColor = Color.White;
            this.tabUser.AutoScroll = true;

            lblSelectUser = new Label();
            lblSelectUser.Text = "Select User:";
            lblSelectUser.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblSelectUser.Location = new Point(30, 30);
            lblSelectUser.AutoSize = true;

            cmbUsers = new ComboBox();
            cmbUsers.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbUsers.Location = new Point(200, 30);
            cmbUsers.Size = new Size(620, 31);
            cmbUsers.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cmbUsers.SelectedIndexChanged += cmbUsers_SelectedIndexChanged;

            lblUsername = new Label();
            lblUsername.Text = "Username:";
            lblUsername.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblUsername.Location = new Point(30, 80);
            lblUsername.AutoSize = true;

            txtUsername = new TextBox();
            txtUsername.Location = new Point(200, 80);
            txtUsername.Size = new Size(620, 30);
            txtUsername.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            lblPassword = new Label();
            lblPassword.Text = "Password:";
            lblPassword.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblPassword.Location = new Point(30, 130);
            lblPassword.AutoSize = true;

            txtPassword = new TextBox();
            txtPassword.Location = new Point(200, 130);
            txtPassword.Size = new Size(620, 30);
            txtPassword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            lblRole = new Label();
            lblRole.Text = "Role:";
            lblRole.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblRole.Location = new Point(30, 180);
            lblRole.AutoSize = true;

            txtRole = new TextBox();
            txtRole.Location = new Point(200, 180);
            txtRole.Size = new Size(620, 30);
            txtRole.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            btnUpdateUser = new Button();
            btnUpdateUser.Text = "Update User";
            btnUpdateUser.BackColor = Color.FromArgb(60, 130, 200);
            btnUpdateUser.ForeColor = Color.White;
            btnUpdateUser.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnUpdateUser.FlatStyle = FlatStyle.Flat;
            btnUpdateUser.FlatAppearance.BorderSize = 0;
            btnUpdateUser.Size = new Size(200, 45);
            btnUpdateUser.Location = new Point(200, 240);
            btnUpdateUser.Anchor = AnchorStyles.Top | AnchorStyles.Left;
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

            // =====================================================================
            // TASK TAB
            // =====================================================================
            this.tabTask = new TabPage("Update Task");
            this.tabTask.BackColor = Color.White;
            // enable scrolling on task tab so step editor is reachable
            this.tabTask.AutoScroll = true;
            this.tabTask.AutoScrollMinSize = new Size(0, 1100);

            lblSelectTask = new Label();
            lblSelectTask.Text = "Select Task:";
            lblSelectTask.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblSelectTask.Location = new Point(30, 30);
            lblSelectTask.AutoSize = true;

            cmbTasks = new ComboBox();
            cmbTasks.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTasks.Location = new Point(200, 30);
            cmbTasks.Size = new Size(620, 31);
            cmbTasks.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cmbTasks.SelectedIndexChanged += cmbTasks_SelectedIndexChanged;

            lblTaskUserID = new Label();
            lblTaskUserID.Text = "User ID:";
            lblTaskUserID.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTaskUserID.Location = new Point(30, 80);
            lblTaskUserID.AutoSize = true;

            txtTaskUserID = new TextBox();
            txtTaskUserID.Location = new Point(200, 80);
            txtTaskUserID.Size = new Size(620, 30);
            txtTaskUserID.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            lblTaskTitle = new Label();
            lblTaskTitle.Text = "Title:";
            lblTaskTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTaskTitle.Location = new Point(30, 130);
            lblTaskTitle.AutoSize = true;

            txtTaskTitle = new TextBox();
            txtTaskTitle.Location = new Point(200, 130);
            txtTaskTitle.Size = new Size(620, 30);
            txtTaskTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            lblTaskDescription = new Label();
            lblTaskDescription.Text = "Description:";
            lblTaskDescription.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTaskDescription.Location = new Point(30, 180);
            lblTaskDescription.AutoSize = true;

            txtTaskDescription = new TextBox();
            txtTaskDescription.Multiline = true;
            txtTaskDescription.Location = new Point(200, 180);
            txtTaskDescription.Size = new Size(620, 60);
            txtTaskDescription.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            lblTaskDueDate = new Label();
            lblTaskDueDate.Text = "Due Date:";
            lblTaskDueDate.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTaskDueDate.Location = new Point(30, 260);
            lblTaskDueDate.AutoSize = true;

            dtpDueDate = new DateTimePicker();
            dtpDueDate.Location = new Point(200, 260);
            dtpDueDate.Size = new Size(300, 30);
            dtpDueDate.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            btnUpdateTask = new Button();
            btnUpdateTask.Text = "Update Task";
            btnUpdateTask.BackColor = Color.FromArgb(60, 130, 200);
            btnUpdateTask.ForeColor = Color.White;
            btnUpdateTask.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnUpdateTask.FlatStyle = FlatStyle.Flat;
            btnUpdateTask.FlatAppearance.BorderSize = 0;
            btnUpdateTask.Size = new Size(200, 45);
            btnUpdateTask.Location = new Point(200, 310);
            btnUpdateTask.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            btnUpdateTask.Click += btnUpdateTask_Click;

            // =====================================================================
            // STEPS GRID
            // =====================================================================
            dgvSteps = new DataGridView();
            dgvSteps.Location = new Point(30, 360);
            // give grid a fairly large height; tabTask has scrolling
            dgvSteps.Size = new Size(820, 220);
            dgvSteps.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvSteps.AllowUserToAddRows = false;
            dgvSteps.AllowUserToDeleteRows = false;
            dgvSteps.MultiSelect = false;
            dgvSteps.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSteps.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dgvSteps.CellClick += dgvSteps_CellClick;
            dgvSteps.CellBeginEdit += dgvSteps_CellBeginEdit;
            dgvSteps.ReadOnly = false;

            var colID = new DataGridViewTextBoxColumn();
            colID.Name = "StepID";
            colID.HeaderText = "Step ID";
            colID.Width = 90;
            colID.ReadOnly = true;

            var colDesc = new DataGridViewTextBoxColumn();
            colDesc.Name = "Description";
            colDesc.HeaderText = "Description";
            colDesc.Width = 480;
            colDesc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            var colStatus = new DataGridViewTextBoxColumn();
            colStatus.Name = "Status";
            colStatus.HeaderText = "Status";
            colStatus.Width = 120;

            var colSigned = new DataGridViewTextBoxColumn();
            colSigned.Name = "SignedOffStatus";
            colSigned.HeaderText = "SignedOff";
            colSigned.Visible = false;

            dgvSteps.Columns.AddRange(colID, colDesc, colStatus, colSigned);

            // =====================================================================
            // STEP EDITOR
            // =====================================================================
            lblStepEditorTitle = new Label();
            lblStepEditorTitle.Text = "Step Editor (Admin)";
            lblStepEditorTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblStepEditorTitle.Location = new Point(30, 600);
            lblStepEditorTitle.AutoSize = true;

            lblStepID = new Label();
            lblStepID.Text = "Step ID:";
            lblStepID.Location = new Point(30, 635);
            lblStepID.AutoSize = true;

            txtStepID = new TextBox();
            txtStepID.Location = new Point(100, 630);
            txtStepID.Size = new Size(120, 26);
            txtStepID.ReadOnly = true;

            lblStepDesc = new Label();
            lblStepDesc.Text = "Description:";
            lblStepDesc.Location = new Point(240, 635);
            lblStepDesc.AutoSize = true;

            txtStepDescription = new TextBox();
            txtStepDescription.Multiline = true;
            txtStepDescription.Location = new Point(330, 630);
            txtStepDescription.Size = new Size(520, 70);

            lblStepStatus = new Label();
            lblStepStatus.Text = "Status:";
            lblStepStatus.Location = new Point(30, 715);
            lblStepStatus.AutoSize = true;

            cmbStepStatus = new ComboBox();
            cmbStepStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStepStatus.Items.AddRange(new string[] { "Pending", "Completed" });
            cmbStepStatus.Location = new Point(100, 710);
            cmbStepStatus.Size = new Size(120, 26);

            lblSignedOff = new Label();
            lblSignedOff.Text = "SignedOff:";
            lblSignedOff.Location = new Point(240, 715);
            lblSignedOff.AutoSize = true;

            cmbSignedOff = new ComboBox();
            cmbSignedOff.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSignedOff.Items.AddRange(new string[] { "Signed", "Not-Signed" });
            cmbSignedOff.Location = new Point(330, 710);
            cmbSignedOff.Size = new Size(140, 26);

            // FIXED UPDATE BUTTON — MOVED DOWN (VISIBLE!)
            btnUpdateStep = new Button();
            btnUpdateStep.Text = "Update Step";
            btnUpdateStep.BackColor = Color.FromArgb(255, 160, 0);
            btnUpdateStep.ForeColor = Color.White;
            btnUpdateStep.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnUpdateStep.FlatStyle = FlatStyle.Flat;
            btnUpdateStep.FlatAppearance.BorderSize = 0;
            btnUpdateStep.Size = new Size(200, 45);

            // NEW POSITION (MUCH LOWER = ALWAYS VISIBLE)
            btnUpdateStep.Location = new Point(30, 760);

            btnUpdateStep.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            btnUpdateStep.Click += btnUpdateStep_Click;

            // Add controls
            tabTask.Controls.Add(lblStepEditorTitle);
            tabTask.Controls.Add(lblStepID);
            tabTask.Controls.Add(txtStepID);
            tabTask.Controls.Add(lblStepDesc);
            tabTask.Controls.Add(txtStepDescription);
            tabTask.Controls.Add(lblStepStatus);
            tabTask.Controls.Add(cmbStepStatus);
            tabTask.Controls.Add(lblSignedOff);
            tabTask.Controls.Add(cmbSignedOff);
            tabTask.Controls.Add(btnUpdateStep);

            // Important: ensure scrolling reveals everything
            tabTask.AutoScrollMinSize = new Size(0, 900);


            // Add controls to Task tab
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

            // Editor controls (below grid)
            tabTask.Controls.Add(lblStepEditorTitle);
            tabTask.Controls.Add(lblStepID);
            tabTask.Controls.Add(txtStepID);
            tabTask.Controls.Add(lblStepDesc);
            tabTask.Controls.Add(txtStepDescription);
            tabTask.Controls.Add(lblStepStatus);
            tabTask.Controls.Add(cmbStepStatus);
            tabTask.Controls.Add(lblSignedOff);
            tabTask.Controls.Add(cmbSignedOff);
            tabTask.Controls.Add(btnUpdateStep);

            // Add tabs to tabControl
            tabControl.Controls.Add(tabUser);
            tabControl.Controls.Add(tabTask);

            // =====================================================================
            // FINAL FORM SETTINGS
            // =====================================================================
            this.ClientSize = new Size(980, 820);
            // Add header first so it docks to top, then tabControl (docked fill)
            this.Controls.Add(tabControl);
            this.Controls.Add(header);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
            this.Text = "Update Data";
            this.Load += UpdateForm_Load;

            // Enable form scrolling if window is smaller than content
            this.AutoScroll = true;
            this.AutoScrollMinSize = new Size(0, 1100);
        }
        #endregion
    }
}

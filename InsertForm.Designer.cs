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

        // User controls
        private Label lblUserID;
        private TextBox txtUserID;
        private Label lblUsername;
        private TextBox txtUsername;
        private Label lblPassword;
        private TextBox txtPassword;
        private Label lblRole;
        private TextBox txtRole;
        private Button btnInsertUser;

        // Task Controls
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

        private void InitializeComponent()
        {
            this.header = new Panel();
            this.lblTitle = new Label();
            this.tabControl = new TabControl();
            this.tabUser = new TabPage();
            this.tabTask = new TabPage();

            // USER TAB CONTROLS
            this.lblUserID = new Label();
            this.txtUserID = new TextBox();
            this.lblUsername = new Label();
            this.txtUsername = new TextBox();
            this.lblPassword = new Label();
            this.txtPassword = new TextBox();
            this.lblRole = new Label();
            this.txtRole = new TextBox();
            this.btnInsertUser = new Button();

            // TASK TAB CONTROLS
            this.lblTaskID = new Label();
            this.txtTaskID = new TextBox();
            this.lblTaskUserID = new Label();
            this.txtTaskUserID = new TextBox();
            this.lblTaskTitle = new Label();
            this.txtTaskTitle = new TextBox();
            this.lblTaskDescription = new Label();
            this.txtTaskDescription = new TextBox();
            this.lblTaskStatus = new Label();
            this.txtTaskStatus = new TextBox();

            this.grpSteps = new GroupBox();
            this.lblStep1ID = new Label();
            this.txtStep1ID = new TextBox();
            this.lblStep1Desc = new Label();
            this.txtStep1Desc = new TextBox();
            this.lblStep1Status = new Label();
            this.txtStep1Status = new TextBox();
            this.lblStep2ID = new Label();
            this.txtStep2ID = new TextBox();
            this.lblStep2Desc = new Label();
            this.txtStep2Desc = new TextBox();
            this.lblStep2Status = new Label();
            this.txtStep2Status = new TextBox();

            this.btnInsertTask = new Button();

            // HEADER
            this.header.BackColor = Color.FromArgb(60, 130, 200);
            this.header.Dock = DockStyle.Top;
            this.header.Size = new Size(800, 70);
            this.header.Controls.Add(this.lblTitle);

            this.lblTitle.Text = "📥 Insert New Data";
            this.lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.White;
            this.lblTitle.Location = new Point(20, 18);

            // TAB CONTROL
            this.tabControl.Location = new Point(20, 90);
            this.tabControl.Size = new Size(760, 590);
            this.tabControl.Controls.Add(this.tabUser);
            this.tabControl.Controls.Add(this.tabTask);

            // ===============================
            // USER TAB
            // ===============================

            this.tabUser.Text = "Insert User";
            this.tabUser.BackColor = Color.White;
            this.tabUser.Controls.Add(this.lblUserID);
            this.tabUser.Controls.Add(this.txtUserID);
            this.tabUser.Controls.Add(this.lblUsername);
            this.tabUser.Controls.Add(this.txtUsername);
            this.tabUser.Controls.Add(this.lblPassword);
            this.tabUser.Controls.Add(this.txtPassword);
            this.tabUser.Controls.Add(this.lblRole);
            this.tabUser.Controls.Add(this.txtRole);
            this.tabUser.Controls.Add(this.btnInsertUser);

            this.lblUserID.Text = "User ID:";
            this.lblUserID.Location = new Point(30, 30);

            this.txtUserID.Location = new Point(200, 30);
            this.txtUserID.Size = new Size(500, 30);

            this.lblUsername.Text = "Username:";
            this.lblUsername.Location = new Point(30, 80);

            this.txtUsername.Location = new Point(200, 80);
            this.txtUsername.Size = new Size(500, 30);

            this.lblPassword.Text = "Password:";
            this.lblPassword.Location = new Point(30, 130);

            this.txtPassword.Location = new Point(200, 130);
            this.txtPassword.Size = new Size(500, 30);

            this.lblRole.Text = "Role:";
            this.lblRole.Location = new Point(30, 180);

            this.txtRole.Location = new Point(200, 180);
            this.txtRole.Size = new Size(500, 30);

            this.btnInsertUser.Text = "Insert User";
            this.btnInsertUser.Location = new Point(200, 240);
            this.btnInsertUser.Size = new Size(200, 45);
            this.btnInsertUser.BackColor = Color.FromArgb(60, 130, 200);
            this.btnInsertUser.ForeColor = Color.White;
            this.btnInsertUser.FlatStyle = FlatStyle.Flat;
            this.btnInsertUser.Click += new System.EventHandler(this.btnInsertUser_Click);

            // ===============================
            // TASK TAB
            // ===============================

            this.tabTask.Text = "Insert Task";
            this.tabTask.BackColor = Color.White;

            // Add all task fields
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

            // ✔ TASK STEPS GROUPBOX IS ADDED HERE
            this.tabTask.Controls.Add(this.grpSteps);

            // ✔ Insert Task button
            this.tabTask.Controls.Add(this.btnInsertTask);

            // TASK BASIC FIELDS
            this.lblTaskID.Text = "Task ID:";
            this.lblTaskID.Location = new Point(30, 20);

            this.txtTaskID.Location = new Point(200, 20);
            this.txtTaskID.Size = new Size(500, 30);

            this.lblTaskUserID.Text = "User ID (ObjectId):";
            this.lblTaskUserID.Location = new Point(30, 60);

            this.txtTaskUserID.Location = new Point(200, 60);
            this.txtTaskUserID.Size = new Size(500, 30);

            this.lblTaskTitle.Text = "Title:";
            this.lblTaskTitle.Location = new Point(30, 100);

            this.txtTaskTitle.Location = new Point(200, 100);
            this.txtTaskTitle.Size = new Size(500, 30);

            this.lblTaskDescription.Text = "Description:";
            this.lblTaskDescription.Location = new Point(30, 140);

            this.txtTaskDescription.Location = new Point(200, 140);
            this.txtTaskDescription.Size = new Size(500, 60);
            this.txtTaskDescription.Multiline = true;

            this.lblTaskStatus.Text = "Task Status:";
            this.lblTaskStatus.Location = new Point(30, 210);

            this.txtTaskStatus.Location = new Point(200, 210);
            this.txtTaskStatus.Size = new Size(300, 30);

            // ===============================
            // TASK STEPS GROUP (VISIBLE AGAIN)
            // ===============================

            this.grpSteps.Text = "Task Steps";
            this.grpSteps.Location = new Point(30, 260);
            this.grpSteps.Size = new Size(690, 220);
            this.grpSteps.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

            // STEP 1
            this.lblStep1ID.Text = "Step 1 ID:";
            this.lblStep1ID.Location = new Point(20, 30);

            this.txtStep1ID.Location = new Point(130, 30);
            this.txtStep1ID.Size = new Size(120, 30);

            this.lblStep1Desc.Text = "Description:";
            this.lblStep1Desc.Location = new Point(260, 30);

            this.txtStep1Desc.Location = new Point(360, 30);
            this.txtStep1Desc.Size = new Size(250, 30);

            this.lblStep1Status.Text = "Status:";
            this.lblStep1Status.Location = new Point(20, 70);

            this.txtStep1Status.Location = new Point(130, 70);
            this.txtStep1Status.Size = new Size(480, 30);

            // STEP 2
            this.lblStep2ID.Text = "Step 2 ID:";
            this.lblStep2ID.Location = new Point(20, 120);

            this.txtStep2ID.Location = new Point(130, 120);
            this.txtStep2ID.Size = new Size(120, 30);

            this.lblStep2Desc.Text = "Description:";
            this.lblStep2Desc.Location = new Point(260, 120);

            this.txtStep2Desc.Location = new Point(360, 120);
            this.txtStep2Desc.Size = new Size(250, 30);

            this.lblStep2Status.Text = "Status:";
            this.lblStep2Status.Location = new Point(20, 160);

            this.txtStep2Status.Location = new Point(130, 160);
            this.txtStep2Status.Size = new Size(480, 30);

            // Add step controls to groupbox
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

            // INSERT TASK BUTTON
            this.btnInsertTask.Text = "Insert Task";
            this.btnInsertTask.Location = new Point(200, 495);
            this.btnInsertTask.Size = new Size(200, 45);
            this.btnInsertTask.BackColor = Color.FromArgb(60, 130, 200);
            this.btnInsertTask.ForeColor = Color.White;
            this.btnInsertTask.FlatStyle = FlatStyle.Flat;
            this.btnInsertTask.Click += new System.EventHandler(this.btnInsertTask_Click);

            // FINAL FORM SETTINGS
            this.ClientSize = new Size(800, 700);
            this.Controls.Add(this.header);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;
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
    }
}

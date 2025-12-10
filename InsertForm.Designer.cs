//using System.Drawing;
//using System.Windows.Forms;

//namespace TaskManagementApp
//{
//    partial class InsertForm
//    {
//        private System.ComponentModel.IContainer components = null;

//        private Panel header;
//        private Label lblTitle;

//        private Panel mainPanel;

//        // Task Fields
//        private Label lblTaskID;
//        private TextBox txtTaskID;

//        private Label lblTaskUserID;
//        private TextBox txtTaskUserID;

//        private Label lblTaskTitle;
//        private TextBox txtTaskTitle;

//        private Label lblTaskDescription;
//        private TextBox txtTaskDescription;

//        private Label lblDueDate;
//        private DateTimePicker dtpDueDate;

//        // Steps controls
//        private GroupBox grpSteps;

//        private Button btnAddStep;

//        private ListView lvSteps;

//        private Button btnInsertTask;

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing && (components != null))
//                components.Dispose();
//            base.Dispose(disposing);
//        }

//        private void InitializeComponent()
//        {
//            this.header = new System.Windows.Forms.Panel();
//            this.lblTitle = new System.Windows.Forms.Label();
//            this.mainPanel = new System.Windows.Forms.Panel();
//            this.lblTaskID = new System.Windows.Forms.Label();
//            this.txtTaskID = new System.Windows.Forms.TextBox();
//            this.lblTaskUserID = new System.Windows.Forms.Label();
//            this.txtTaskUserID = new System.Windows.Forms.TextBox();
//            this.lblTaskTitle = new System.Windows.Forms.Label();
//            this.txtTaskTitle = new System.Windows.Forms.TextBox();
//            this.lblTaskDescription = new System.Windows.Forms.Label();
//            this.txtTaskDescription = new System.Windows.Forms.TextBox();
//            this.lblDueDate = new System.Windows.Forms.Label();
//            this.dtpDueDate = new System.Windows.Forms.DateTimePicker();
//            this.grpSteps = new System.Windows.Forms.GroupBox();
//            this.btnAddStep = new System.Windows.Forms.Button();
//            this.lvSteps = new System.Windows.Forms.ListView();
//            this.btnInsertTask = new System.Windows.Forms.Button();
//            this.header.SuspendLayout();
//            this.mainPanel.SuspendLayout();
//            this.grpSteps.SuspendLayout();
//            this.SuspendLayout();
//            // 
//            // header
//            // 
//            this.header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(130)))), ((int)(((byte)(200)))));
//            this.header.Controls.Add(this.lblTitle);
//            this.header.Dock = System.Windows.Forms.DockStyle.Top;
//            this.header.Location = new System.Drawing.Point(0, 0);
//            this.header.Name = "header";
//            this.header.Size = new System.Drawing.Size(900, 70);
//            this.header.TabIndex = 0;
//            this.header.Paint += new System.Windows.Forms.PaintEventHandler(this.header_Paint);
//            // 
//            // lblTitle
//            // 
//            this.lblTitle.AutoSize = true;
//            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
//            this.lblTitle.ForeColor = System.Drawing.Color.White;
//            this.lblTitle.Location = new System.Drawing.Point(20, 18);
//            this.lblTitle.Name = "lblTitle";
//            this.lblTitle.Size = new System.Drawing.Size(291, 41);
//            this.lblTitle.TabIndex = 0;
//            this.lblTitle.Text = "📥 Insert New Task";
//            // 
//            // mainPanel
//            // 
//            this.mainPanel.BackColor = System.Drawing.Color.White;
//            this.mainPanel.Controls.Add(this.lblTaskID);
//            this.mainPanel.Controls.Add(this.txtTaskID);
//            this.mainPanel.Controls.Add(this.lblTaskUserID);
//            this.mainPanel.Controls.Add(this.txtTaskUserID);
//            this.mainPanel.Controls.Add(this.lblTaskTitle);
//            this.mainPanel.Controls.Add(this.txtTaskTitle);
//            this.mainPanel.Controls.Add(this.lblTaskDescription);
//            this.mainPanel.Controls.Add(this.txtTaskDescription);
//            this.mainPanel.Controls.Add(this.lblDueDate);
//            this.mainPanel.Controls.Add(this.dtpDueDate);
//            this.mainPanel.Controls.Add(this.grpSteps);
//            this.mainPanel.Controls.Add(this.btnInsertTask);
//            this.mainPanel.Location = new System.Drawing.Point(20, 90);
//            this.mainPanel.Name = "mainPanel";
//            this.mainPanel.Size = new System.Drawing.Size(860, 580);
//            this.mainPanel.TabIndex = 1;
//            // 
//            // lblTaskID
//            // 
//            this.lblTaskID.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
//            this.lblTaskID.Location = new System.Drawing.Point(30, 20);
//            this.lblTaskID.Name = "lblTaskID";
//            this.lblTaskID.Size = new System.Drawing.Size(100, 23);
//            this.lblTaskID.TabIndex = 0;
//            this.lblTaskID.Text = "Task ID:";
//            // 
//            // txtTaskID
//            // 
//            this.txtTaskID.Location = new System.Drawing.Point(200, 20);
//            this.txtTaskID.Name = "txtTaskID";
//            this.txtTaskID.Size = new System.Drawing.Size(600, 22);
//            this.txtTaskID.TabIndex = 1;
//            // 
//            // lblTaskUserID
//            // 
//            this.lblTaskUserID.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
//            this.lblTaskUserID.Location = new System.Drawing.Point(30, 60);
//            this.lblTaskUserID.Name = "lblTaskUserID";
//            this.lblTaskUserID.Size = new System.Drawing.Size(160, 23);
//            this.lblTaskUserID.TabIndex = 2;
//            this.lblTaskUserID.Text = "User ID (ObjectId):";
//            // 
//            // txtTaskUserID
//            // 
//            this.txtTaskUserID.Location = new System.Drawing.Point(200, 60);
//            this.txtTaskUserID.Name = "txtTaskUserID";
//            this.txtTaskUserID.Size = new System.Drawing.Size(600, 22);
//            this.txtTaskUserID.TabIndex = 3;
//            // 
//            // lblTaskTitle
//            // 
//            this.lblTaskTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
//            this.lblTaskTitle.Location = new System.Drawing.Point(30, 100);
//            this.lblTaskTitle.Name = "lblTaskTitle";
//            this.lblTaskTitle.Size = new System.Drawing.Size(100, 23);
//            this.lblTaskTitle.TabIndex = 4;
//            this.lblTaskTitle.Text = "Title:";
//            // 
//            // txtTaskTitle
//            // 
//            this.txtTaskTitle.Location = new System.Drawing.Point(200, 100);
//            this.txtTaskTitle.Name = "txtTaskTitle";
//            this.txtTaskTitle.Size = new System.Drawing.Size(600, 22);
//            this.txtTaskTitle.TabIndex = 5;
//            // 
//            // lblTaskDescription
//            // 
//            this.lblTaskDescription.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
//            this.lblTaskDescription.Location = new System.Drawing.Point(30, 140);
//            this.lblTaskDescription.Name = "lblTaskDescription";
//            this.lblTaskDescription.Size = new System.Drawing.Size(100, 23);
//            this.lblTaskDescription.TabIndex = 6;
//            this.lblTaskDescription.Text = "Description:";
//            // 
//            // txtTaskDescription
//            // 
//            this.txtTaskDescription.Location = new System.Drawing.Point(200, 140);
//            this.txtTaskDescription.Multiline = true;
//            this.txtTaskDescription.Name = "txtTaskDescription";
//            this.txtTaskDescription.Size = new System.Drawing.Size(600, 80);
//            this.txtTaskDescription.TabIndex = 7;
//            // 
//            // lblDueDate
//            // 
//            this.lblDueDate.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
//            this.lblDueDate.Location = new System.Drawing.Point(30, 230);
//            this.lblDueDate.Name = "lblDueDate";
//            this.lblDueDate.Size = new System.Drawing.Size(100, 23);
//            this.lblDueDate.TabIndex = 8;
//            this.lblDueDate.Text = "Due Date:";
//            // 
//            // dtpDueDate
//            // 
//            this.dtpDueDate.Location = new System.Drawing.Point(200, 230);
//            this.dtpDueDate.Name = "dtpDueDate";
//            this.dtpDueDate.Size = new System.Drawing.Size(300, 22);
//            this.dtpDueDate.TabIndex = 9;
//            // 
//            // grpSteps
//            // 
//            this.grpSteps.Controls.Add(this.btnAddStep);
//            this.grpSteps.Controls.Add(this.lvSteps);
//            this.grpSteps.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
//            this.grpSteps.Location = new System.Drawing.Point(30, 270);
//            this.grpSteps.Name = "grpSteps";
//            this.grpSteps.Size = new System.Drawing.Size(770, 220);
//            this.grpSteps.TabIndex = 10;
//            this.grpSteps.TabStop = false;
//            this.grpSteps.Text = "Task Steps";
//            // 
//            // btnAddStep
//            // 
//            this.btnAddStep.Location = new System.Drawing.Point(20, 28);
//            this.btnAddStep.Name = "btnAddStep";
//            this.btnAddStep.Size = new System.Drawing.Size(110, 30);
//            this.btnAddStep.TabIndex = 0;
//            this.btnAddStep.Text = "➕ Add Step";
//            this.btnAddStep.Click += new System.EventHandler(this.btnAddStep_Click);
//            // 
//            // lvSteps
//            // 
//            this.lvSteps.FullRowSelect = true;
//            this.lvSteps.GridLines = true;
//            this.lvSteps.HideSelection = false;
//            this.lvSteps.Location = new System.Drawing.Point(20, 70);
//            this.lvSteps.Name = "lvSteps";
//            this.lvSteps.Size = new System.Drawing.Size(730, 130);
//            this.lvSteps.TabIndex = 1;
//            this.lvSteps.UseCompatibleStateImageBehavior = false;
//            this.lvSteps.View = System.Windows.Forms.View.Details;
//            // 
//            // btnInsertTask
//            // 
//            this.btnInsertTask.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(130)))), ((int)(((byte)(200)))));
//            this.btnInsertTask.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
//            this.btnInsertTask.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
//            this.btnInsertTask.ForeColor = System.Drawing.Color.White;
//            this.btnInsertTask.Location = new System.Drawing.Point(300, 510);
//            this.btnInsertTask.Name = "btnInsertTask";
//            this.btnInsertTask.Size = new System.Drawing.Size(260, 45);
//            this.btnInsertTask.TabIndex = 11;
//            this.btnInsertTask.Text = "Insert Task";
//            this.btnInsertTask.UseVisualStyleBackColor = false;
//            this.btnInsertTask.Click += new System.EventHandler(this.btnInsertTask_Click);
//            // 
//            // InsertForm
//            // 
//            this.ClientSize = new System.Drawing.Size(900, 700);
//            this.Controls.Add(this.header);
//            this.Controls.Add(this.mainPanel);
//            this.Name = "InsertForm";
//            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
//            this.Text = "Insert Task";
//            this.header.ResumeLayout(false);
//            this.header.PerformLayout();
//            this.mainPanel.ResumeLayout(false);
//            this.mainPanel.PerformLayout();
//            this.grpSteps.ResumeLayout(false);
//            this.ResumeLayout(false);

//        }
//    }
//}

using System.Drawing;
using System.Windows.Forms;

namespace TaskManagementApp
{
    partial class InsertForm
    {
        private System.ComponentModel.IContainer components = null;

        private Panel header;
        private Label lblTitle;
        private Label lblTaskID;
        private TextBox txtTaskID;
        private Label lblAssignUser;
        private ComboBox cmbAssignUser; // NEW
        private Label lblTaskTitle;
        private TextBox txtTaskTitle;
        private Label lblTaskDescription;
        private TextBox txtTaskDescription;
        private Label lblDueDate;
        private DateTimePicker dtpDueDate;
        private Button btnAddStep;
        private ListView lvSteps;
        private Button btnInsertTask;

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

            // Header (optional small header)
            this.header = new Panel();
            this.header.BackColor = Color.FromArgb(60, 130, 200);
            this.header.Dock = DockStyle.Top;
            this.header.Height = 50;

            this.lblTitle = new Label();
            this.lblTitle.Text = "Insert Task";
            this.lblTitle.ForeColor = Color.White;
            this.lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblTitle.Location = new Point(12, 10);

            this.header.Controls.Add(lblTitle);

            // Task ID
            lblTaskID = new Label();
            lblTaskID.Text = "Task ID:";
            lblTaskID.Location = new Point(30, 70);
            lblTaskID.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

            txtTaskID = new TextBox();
            txtTaskID.Location = new Point(150, 68);
            txtTaskID.Size = new Size(320, 26);

            // Assign user label + dropdown (NEW)
            lblAssignUser = new Label();
            lblAssignUser.Text = "Assign To:";
            lblAssignUser.Location = new Point(30, 110);
            lblAssignUser.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

            cmbAssignUser = new ComboBox();
            cmbAssignUser.Location = new Point(150, 108);
            cmbAssignUser.Size = new Size(320, 26);
            cmbAssignUser.DropDownStyle = ComboBoxStyle.DropDownList;

            // Title
            lblTaskTitle = new Label();
            lblTaskTitle.Text = "Title:";
            lblTaskTitle.Location = new Point(30, 150);
            lblTaskTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

            txtTaskTitle = new TextBox();
            txtTaskTitle.Location = new Point(150, 148);
            txtTaskTitle.Size = new Size(320, 26);

            // Description
            lblTaskDescription = new Label();
            lblTaskDescription.Text = "Description:";
            lblTaskDescription.Location = new Point(30, 190);
            lblTaskDescription.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

            txtTaskDescription = new TextBox();
            txtTaskDescription.Location = new Point(150, 188);
            txtTaskDescription.Size = new Size(320, 70);
            txtTaskDescription.Multiline = true;

            // Due date
            lblDueDate = new Label();
            lblDueDate.Text = "Due Date:";
            lblDueDate.Location = new Point(30, 270);
            lblDueDate.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

            dtpDueDate = new DateTimePicker();
            dtpDueDate.Location = new Point(150, 268);
            dtpDueDate.Size = new Size(220, 26);

            // Add Step button
            btnAddStep = new Button();
            btnAddStep.Text = "Add Step";
            btnAddStep.Location = new Point(500, 268);
            btnAddStep.Size = new Size(110, 30);
            btnAddStep.Click += btnAddStep_Click;

            // Steps ListView
            lvSteps = new ListView();
            lvSteps.Location = new Point(30, 310);
            lvSteps.Size = new Size(760, 200);
            lvSteps.View = View.Details;
            lvSteps.Columns.Add("Step ID", 120);
            lvSteps.Columns.Add("Description", 600);

            // Insert Task button
            btnInsertTask = new Button();
            btnInsertTask.Text = "Insert Task";
            btnInsertTask.BackColor = Color.FromArgb(60, 130, 200);
            btnInsertTask.ForeColor = Color.White;
            btnInsertTask.FlatStyle = FlatStyle.Flat;
            btnInsertTask.Size = new Size(160, 40);
            btnInsertTask.Location = new Point(320, 530);
            btnInsertTask.Click += btnInsertTask_Click;

            // Add controls to form
            this.Controls.Add(header);
            this.Controls.Add(lblTaskID);
            this.Controls.Add(txtTaskID);
            this.Controls.Add(lblAssignUser);
            this.Controls.Add(cmbAssignUser);
            this.Controls.Add(lblTaskTitle);
            this.Controls.Add(txtTaskTitle);
            this.Controls.Add(lblTaskDescription);
            this.Controls.Add(txtTaskDescription);
            this.Controls.Add(lblDueDate);
            this.Controls.Add(dtpDueDate);
            this.Controls.Add(btnAddStep);
            this.Controls.Add(lvSteps);
            this.Controls.Add(btnInsertTask);

            // Form
            this.ClientSize = new Size(820, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Insert Task";
            this.Load += InsertForm_Load;
        }
        #endregion
    }
}

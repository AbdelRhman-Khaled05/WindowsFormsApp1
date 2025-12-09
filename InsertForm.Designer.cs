using System.Drawing;
using System.Windows.Forms;

namespace TaskManagementApp
{
    partial class InsertForm
    {
        private System.ComponentModel.IContainer components = null;

        private Panel header;
        private Label lblTitle;
        private Panel mainPanel;

        // Task Controls
        private Label lblTaskID;
        private TextBox txtTaskID;
        private Label lblTaskUserID;
        private TextBox txtTaskUserID;
        private Label lblTaskTitle;
        private TextBox txtTaskTitle;
        private Label lblTaskDescription;
        private TextBox txtTaskDescription;
        private Label lblDueDate;
        private DateTimePicker dtpDueDate;

        private GroupBox grpSteps;
        private Label lblStep1ID;
        private TextBox txtStep1ID;
        private Label lblStep1Desc;
        private TextBox txtStep1Desc;
        private Label lblStep2ID;
        private TextBox txtStep2ID;
        private Label lblStep2Desc;
        private TextBox txtStep2Desc;

        private Button btnInsertTask;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.header = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.lblTaskID = new System.Windows.Forms.Label();
            this.txtTaskID = new System.Windows.Forms.TextBox();
            this.lblTaskUserID = new System.Windows.Forms.Label();
            this.txtTaskUserID = new System.Windows.Forms.TextBox();
            this.lblTaskTitle = new System.Windows.Forms.Label();
            this.txtTaskTitle = new System.Windows.Forms.TextBox();
            this.lblTaskDescription = new System.Windows.Forms.Label();
            this.txtTaskDescription = new System.Windows.Forms.TextBox();
            this.lblDueDate = new System.Windows.Forms.Label();
            this.dtpDueDate = new System.Windows.Forms.DateTimePicker();
            this.grpSteps = new System.Windows.Forms.GroupBox();
            this.lblStep1ID = new System.Windows.Forms.Label();
            this.txtStep1ID = new System.Windows.Forms.TextBox();
            this.lblStep1Desc = new System.Windows.Forms.Label();
            this.txtStep1Desc = new System.Windows.Forms.TextBox();
            this.lblStep2ID = new System.Windows.Forms.Label();
            this.txtStep2ID = new System.Windows.Forms.TextBox();
            this.lblStep2Desc = new System.Windows.Forms.Label();
            this.txtStep2Desc = new System.Windows.Forms.TextBox();
            this.btnInsertTask = new System.Windows.Forms.Button();
            this.header.SuspendLayout();
            this.mainPanel.SuspendLayout();
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
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(100, 52);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "📥 Insert New Task";
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.White;
            this.mainPanel.Controls.Add(this.lblTaskID);
            this.mainPanel.Controls.Add(this.txtTaskID);
            this.mainPanel.Controls.Add(this.lblTaskUserID);
            this.mainPanel.Controls.Add(this.txtTaskUserID);
            this.mainPanel.Controls.Add(this.lblTaskTitle);
            this.mainPanel.Controls.Add(this.txtTaskTitle);
            this.mainPanel.Controls.Add(this.lblTaskDescription);
            this.mainPanel.Controls.Add(this.txtTaskDescription);
            this.mainPanel.Controls.Add(this.lblDueDate);
            this.mainPanel.Controls.Add(this.dtpDueDate);
            this.mainPanel.Controls.Add(this.grpSteps);
            this.mainPanel.Controls.Add(this.btnInsertTask);
            this.mainPanel.Location = new System.Drawing.Point(20, 90);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(760, 590);
            this.mainPanel.TabIndex = 1;
            // 
            // lblTaskID
            // 
            this.lblTaskID.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTaskID.Location = new System.Drawing.Point(30, 20);
            this.lblTaskID.Name = "lblTaskID";
            this.lblTaskID.Size = new System.Drawing.Size(100, 23);
            this.lblTaskID.TabIndex = 0;
            this.lblTaskID.Text = "Task ID:";
            // 
            // txtTaskID
            // 
            this.txtTaskID.Location = new System.Drawing.Point(200, 20);
            this.txtTaskID.Name = "txtTaskID";
            this.txtTaskID.Size = new System.Drawing.Size(500, 22);
            this.txtTaskID.TabIndex = 1;
            // 
            // lblTaskUserID
            // 
            this.lblTaskUserID.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTaskUserID.Location = new System.Drawing.Point(30, 60);
            this.lblTaskUserID.Name = "lblTaskUserID";
            this.lblTaskUserID.Size = new System.Drawing.Size(100, 23);
            this.lblTaskUserID.TabIndex = 2;
            this.lblTaskUserID.Text = "User ID (ObjectId):";
            // 
            // txtTaskUserID
            // 
            this.txtTaskUserID.Location = new System.Drawing.Point(200, 60);
            this.txtTaskUserID.Name = "txtTaskUserID";
            this.txtTaskUserID.Size = new System.Drawing.Size(500, 22);
            this.txtTaskUserID.TabIndex = 3;
            // 
            // lblTaskTitle
            // 
            this.lblTaskTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTaskTitle.Location = new System.Drawing.Point(30, 100);
            this.lblTaskTitle.Name = "lblTaskTitle";
            this.lblTaskTitle.Size = new System.Drawing.Size(100, 23);
            this.lblTaskTitle.TabIndex = 4;
            this.lblTaskTitle.Text = "Title:";
            // 
            // txtTaskTitle
            // 
            this.txtTaskTitle.Location = new System.Drawing.Point(200, 100);
            this.txtTaskTitle.Name = "txtTaskTitle";
            this.txtTaskTitle.Size = new System.Drawing.Size(500, 22);
            this.txtTaskTitle.TabIndex = 5;
            // 
            // lblTaskDescription
            // 
            this.lblTaskDescription.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTaskDescription.Location = new System.Drawing.Point(30, 140);
            this.lblTaskDescription.Name = "lblTaskDescription";
            this.lblTaskDescription.Size = new System.Drawing.Size(100, 23);
            this.lblTaskDescription.TabIndex = 6;
            this.lblTaskDescription.Text = "Description:";
            // 
            // txtTaskDescription
            // 
            this.txtTaskDescription.Location = new System.Drawing.Point(200, 140);
            this.txtTaskDescription.Multiline = true;
            this.txtTaskDescription.Name = "txtTaskDescription";
            this.txtTaskDescription.Size = new System.Drawing.Size(500, 60);
            this.txtTaskDescription.TabIndex = 7;
            // 
            // lblDueDate
            // 
            this.lblDueDate.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblDueDate.Location = new System.Drawing.Point(30, 210);
            this.lblDueDate.Name = "lblDueDate";
            this.lblDueDate.Size = new System.Drawing.Size(100, 23);
            this.lblDueDate.TabIndex = 8;
            this.lblDueDate.Text = "Due Date:";
            // 
            // dtpDueDate
            // 
            this.dtpDueDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDueDate.Location = new System.Drawing.Point(200, 210);
            this.dtpDueDate.Name = "dtpDueDate";
            this.dtpDueDate.Size = new System.Drawing.Size(300, 22);
            this.dtpDueDate.TabIndex = 9;
            // 
            // grpSteps
            // 
            this.grpSteps.Controls.Add(this.lblStep1ID);
            this.grpSteps.Controls.Add(this.txtStep1ID);
            this.grpSteps.Controls.Add(this.lblStep1Desc);
            this.grpSteps.Controls.Add(this.txtStep1Desc);
            this.grpSteps.Controls.Add(this.lblStep2ID);
            this.grpSteps.Controls.Add(this.txtStep2ID);
            this.grpSteps.Controls.Add(this.lblStep2Desc);
            this.grpSteps.Controls.Add(this.txtStep2Desc);
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
            this.lblStep1ID.Size = new System.Drawing.Size(100, 23);
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
            this.lblStep1Desc.Size = new System.Drawing.Size(100, 23);
            this.lblStep1Desc.TabIndex = 2;
            this.lblStep1Desc.Text = "Description:";
            // 
            // txtStep1Desc
            // 
            this.txtStep1Desc.Location = new System.Drawing.Point(360, 30);
            this.txtStep1Desc.Name = "txtStep1Desc";
            this.txtStep1Desc.Size = new System.Drawing.Size(300, 30);
            this.txtStep1Desc.TabIndex = 3;
            // 
            // lblStep2ID
            // 
            this.lblStep2ID.Location = new System.Drawing.Point(20, 80);
            this.lblStep2ID.Name = "lblStep2ID";
            this.lblStep2ID.Size = new System.Drawing.Size(100, 23);
            this.lblStep2ID.TabIndex = 4;
            this.lblStep2ID.Text = "Step 2 ID:";
            // 
            // txtStep2ID
            // 
            this.txtStep2ID.Location = new System.Drawing.Point(130, 80);
            this.txtStep2ID.Name = "txtStep2ID";
            this.txtStep2ID.Size = new System.Drawing.Size(120, 30);
            this.txtStep2ID.TabIndex = 5;
            // 
            // lblStep2Desc
            // 
            this.lblStep2Desc.Location = new System.Drawing.Point(260, 80);
            this.lblStep2Desc.Name = "lblStep2Desc";
            this.lblStep2Desc.Size = new System.Drawing.Size(100, 23);
            this.lblStep2Desc.TabIndex = 6;
            this.lblStep2Desc.Text = "Description:";
            // 
            // txtStep2Desc
            // 
            this.txtStep2Desc.Location = new System.Drawing.Point(360, 80);
            this.txtStep2Desc.Name = "txtStep2Desc";
            this.txtStep2Desc.Size = new System.Drawing.Size(300, 30);
            this.txtStep2Desc.TabIndex = 7;
            // 
            // btnInsertTask
            // 
            this.btnInsertTask.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(130)))), ((int)(((byte)(200)))));
            this.btnInsertTask.Cursor = System.Windows.Forms.Cursors.Hand;
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
            this.Controls.Add(this.mainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "InsertForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Insert Task";
            this.header.ResumeLayout(false);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.grpSteps.ResumeLayout(false);
            this.grpSteps.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
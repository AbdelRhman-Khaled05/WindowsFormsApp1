using System.Drawing;
using System.Windows.Forms;

namespace TaskManagementApp
{
    partial class ViewTasksForm
    {
        private System.ComponentModel.IContainer components = null;
        private Panel header;
        private Label lblTitle;
        private Panel leftPanel;
        private Label lblTasksTitle;
        private ListBox lstTasks;
        private Label lblTaskCount;
        private Button btnRefresh;
        private Panel rightPanel;
        private Label lblDetailsTitle;
        private Label lblTaskID;
        private TextBox txtTaskID;
        private Label lblTaskTitle;
        private TextBox txtTitle;
        private Label lblDescription;
        private TextBox txtDescription;
        private Label lblStatus;
        private TextBox txtStatus;
        private Label lblDueDate;
        private TextBox txtDueDate;
        private Label lblStepsTitle;
        private ListBox lstSteps;
        private Button btnCompleteStep;
        private Button btnSubmitTask;
        private Button btnClose;

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
            this.leftPanel = new System.Windows.Forms.Panel();
            this.lblTasksTitle = new System.Windows.Forms.Label();
            this.lstTasks = new System.Windows.Forms.ListBox();
            this.lblTaskCount = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.rightPanel = new System.Windows.Forms.Panel();
            this.lblDetailsTitle = new System.Windows.Forms.Label();
            this.lblTaskID = new System.Windows.Forms.Label();
            this.txtTaskID = new System.Windows.Forms.TextBox();
            this.lblTaskTitle = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.lblDueDate = new System.Windows.Forms.Label();
            this.txtDueDate = new System.Windows.Forms.TextBox();
            this.lblStepsTitle = new System.Windows.Forms.Label();
            this.lstSteps = new System.Windows.Forms.ListBox();
            this.btnCompleteStep = new System.Windows.Forms.Button();
            this.btnSubmitTask = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.header.SuspendLayout();
            this.leftPanel.SuspendLayout();
            this.rightPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // header
            // 
            this.header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(130)))), ((int)(((byte)(200)))));
            this.header.Controls.Add(this.lblTitle);
            this.header.Dock = System.Windows.Forms.DockStyle.Top;
            this.header.Location = new System.Drawing.Point(0, 0);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(1200, 70);
            this.header.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(365, 41);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "📋 View & Complete Tasks";
            // 
            // leftPanel
            // 
            this.leftPanel.BackColor = System.Drawing.Color.White;
            this.leftPanel.Controls.Add(this.lblTasksTitle);
            this.leftPanel.Controls.Add(this.lstTasks);
            this.leftPanel.Controls.Add(this.lblTaskCount);
            this.leftPanel.Controls.Add(this.btnRefresh);
            this.leftPanel.Location = new System.Drawing.Point(20, 90);
            this.leftPanel.Name = "leftPanel";
            this.leftPanel.Size = new System.Drawing.Size(400, 590);
            this.leftPanel.TabIndex = 1;
            // 
            // lblTasksTitle
            // 
            this.lblTasksTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTasksTitle.Location = new System.Drawing.Point(10, 10);
            this.lblTasksTitle.Name = "lblTasksTitle";
            this.lblTasksTitle.Size = new System.Drawing.Size(380, 25);
            this.lblTasksTitle.TabIndex = 0;
            this.lblTasksTitle.Text = "Your Assigned Tasks";
            // 
            // lstTasks
            // 
            this.lstTasks.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lstTasks.ItemHeight = 23;
            this.lstTasks.Location = new System.Drawing.Point(10, 45);
            this.lstTasks.Name = "lstTasks";
            this.lstTasks.Size = new System.Drawing.Size(380, 464);
            this.lstTasks.TabIndex = 1;
            this.lstTasks.SelectedIndexChanged += new System.EventHandler(this.lstTasks_SelectedIndexChanged);
            // 
            // lblTaskCount
            // 
            this.lblTaskCount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTaskCount.Location = new System.Drawing.Point(10, 525);
            this.lblTaskCount.Name = "lblTaskCount";
            this.lblTaskCount.Size = new System.Drawing.Size(200, 20);
            this.lblTaskCount.TabIndex = 2;
            this.lblTaskCount.Text = "Your Tasks: 0";
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(160)))), ((int)(((byte)(80)))));
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(10, 550);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(380, 35);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "↻ Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // rightPanel
            // 
            this.rightPanel.BackColor = System.Drawing.Color.White;
            this.rightPanel.Controls.Add(this.lblDetailsTitle);
            this.rightPanel.Controls.Add(this.lblTaskID);
            this.rightPanel.Controls.Add(this.txtTaskID);
            this.rightPanel.Controls.Add(this.lblTaskTitle);
            this.rightPanel.Controls.Add(this.txtTitle);
            this.rightPanel.Controls.Add(this.lblDescription);
            this.rightPanel.Controls.Add(this.txtDescription);
            this.rightPanel.Controls.Add(this.lblStatus);
            this.rightPanel.Controls.Add(this.txtStatus);
            this.rightPanel.Controls.Add(this.lblDueDate);
            this.rightPanel.Controls.Add(this.txtDueDate);
            this.rightPanel.Controls.Add(this.lblStepsTitle);
            this.rightPanel.Controls.Add(this.lstSteps);
            this.rightPanel.Controls.Add(this.btnCompleteStep);
            this.rightPanel.Controls.Add(this.btnSubmitTask);
            this.rightPanel.Controls.Add(this.btnClose);
            this.rightPanel.Location = new System.Drawing.Point(440, 90);
            this.rightPanel.Name = "rightPanel";
            this.rightPanel.Size = new System.Drawing.Size(740, 590);
            this.rightPanel.TabIndex = 2;
            // 
            // lblDetailsTitle
            // 
            this.lblDetailsTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblDetailsTitle.Location = new System.Drawing.Point(10, 10);
            this.lblDetailsTitle.Name = "lblDetailsTitle";
            this.lblDetailsTitle.Size = new System.Drawing.Size(720, 25);
            this.lblDetailsTitle.TabIndex = 0;
            this.lblDetailsTitle.Text = "Task Details";
            // 
            // lblTaskID
            // 
            this.lblTaskID.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTaskID.Location = new System.Drawing.Point(10, 45);
            this.lblTaskID.Name = "lblTaskID";
            this.lblTaskID.Size = new System.Drawing.Size(100, 25);
            this.lblTaskID.TabIndex = 1;
            this.lblTaskID.Text = "Task ID:";
            // 
            // txtTaskID
            // 
            this.txtTaskID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.txtTaskID.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTaskID.Location = new System.Drawing.Point(120, 45);
            this.txtTaskID.Name = "txtTaskID";
            this.txtTaskID.ReadOnly = true;
            this.txtTaskID.Size = new System.Drawing.Size(150, 30);
            this.txtTaskID.TabIndex = 2;
            // 
            // lblTaskTitle
            // 
            this.lblTaskTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTaskTitle.Location = new System.Drawing.Point(290, 45);
            this.lblTaskTitle.Name = "lblTaskTitle";
            this.lblTaskTitle.Size = new System.Drawing.Size(50, 25);
            this.lblTaskTitle.TabIndex = 3;
            this.lblTaskTitle.Text = "Title:";
            // 
            // txtTitle
            // 
            this.txtTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.txtTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTitle.Location = new System.Drawing.Point(350, 45);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.ReadOnly = true;
            this.txtTitle.Size = new System.Drawing.Size(370, 30);
            this.txtTitle.TabIndex = 4;
            // 
            // lblDescription
            // 
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDescription.Location = new System.Drawing.Point(10, 80);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(146, 25);
            this.lblDescription.TabIndex = 5;
            this.lblDescription.Text = "Description:";
            // 
            // txtDescription
            // 
            this.txtDescription.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.txtDescription.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDescription.Location = new System.Drawing.Point(10, 105);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.Size = new System.Drawing.Size(710, 60);
            this.txtDescription.TabIndex = 6;
            // 
            // lblStatus
            // 
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblStatus.Location = new System.Drawing.Point(10, 175);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(100, 25);
            this.lblStatus.TabIndex = 7;
            this.lblStatus.Text = "Status:";
            // 
            // txtStatus
            // 
            this.txtStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.txtStatus.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtStatus.Location = new System.Drawing.Point(120, 175);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(200, 30);
            this.txtStatus.TabIndex = 8;
            // 
            // lblDueDate
            // 
            this.lblDueDate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDueDate.Location = new System.Drawing.Point(340, 175);
            this.lblDueDate.Name = "lblDueDate";
            this.lblDueDate.Size = new System.Drawing.Size(100, 25);
            this.lblDueDate.TabIndex = 9;
            this.lblDueDate.Text = "Due Date:";
            // 
            // txtDueDate
            // 
            this.txtDueDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.txtDueDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDueDate.Location = new System.Drawing.Point(450, 175);
            this.txtDueDate.Name = "txtDueDate";
            this.txtDueDate.ReadOnly = true;
            this.txtDueDate.Size = new System.Drawing.Size(150, 30);
            this.txtDueDate.TabIndex = 10;
            // 
            // lblStepsTitle
            // 
            this.lblStepsTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblStepsTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(130)))), ((int)(((byte)(200)))));
            this.lblStepsTitle.Location = new System.Drawing.Point(10, 215);
            this.lblStepsTitle.Name = "lblStepsTitle";
            this.lblStepsTitle.Size = new System.Drawing.Size(200, 25);
            this.lblStepsTitle.TabIndex = 11;
            this.lblStepsTitle.Text = "Checklist Steps";
            // 
            // lstSteps
            // 
            this.lstSteps.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lstSteps.ItemHeight = 20;
            this.lstSteps.Location = new System.Drawing.Point(10, 245);
            this.lstSteps.Name = "lstSteps";
            this.lstSteps.Size = new System.Drawing.Size(710, 244);
            this.lstSteps.TabIndex = 12;
            // 
            // btnCompleteStep
            // 
            this.btnCompleteStep.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(160)))), ((int)(((byte)(80)))));
            this.btnCompleteStep.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCompleteStep.FlatAppearance.BorderSize = 0;
            this.btnCompleteStep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCompleteStep.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnCompleteStep.ForeColor = System.Drawing.Color.White;
            this.btnCompleteStep.Location = new System.Drawing.Point(10, 510);
            this.btnCompleteStep.Name = "btnCompleteStep";
            this.btnCompleteStep.Size = new System.Drawing.Size(230, 40);
            this.btnCompleteStep.TabIndex = 13;
            this.btnCompleteStep.Text = "✓ Complete Selected Step";
            this.btnCompleteStep.UseVisualStyleBackColor = false;
            this.btnCompleteStep.Click += new System.EventHandler(this.btnCompleteStep_Click);
            // 
            // btnSubmitTask
            // 
            this.btnSubmitTask.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(130)))), ((int)(((byte)(200)))));
            this.btnSubmitTask.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSubmitTask.FlatAppearance.BorderSize = 0;
            this.btnSubmitTask.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmitTask.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnSubmitTask.ForeColor = System.Drawing.Color.White;
            this.btnSubmitTask.Location = new System.Drawing.Point(250, 510);
            this.btnSubmitTask.Name = "btnSubmitTask";
            this.btnSubmitTask.Size = new System.Drawing.Size(230, 40);
            this.btnSubmitTask.TabIndex = 14;
            this.btnSubmitTask.Text = "📤 Submit Task";
            this.btnSubmitTask.UseVisualStyleBackColor = false;
            this.btnSubmitTask.Click += new System.EventHandler(this.btnSubmitTask_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(490, 510);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(230, 40);
            this.btnClose.TabIndex = 15;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ViewTasksForm
            // 
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.header);
            this.Controls.Add(this.leftPanel);
            this.Controls.Add(this.rightPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "ViewTasksForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "View & Complete Tasks";
            this.Load += new System.EventHandler(this.ViewTasksForm_Load);
            this.header.ResumeLayout(false);
            this.header.PerformLayout();
            this.leftPanel.ResumeLayout(false);
            this.rightPanel.ResumeLayout(false);
            this.rightPanel.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion
    }
}
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

        // Task Fields
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

        // Steps controls
        private GroupBox grpSteps;

        private Button btnAddStep;

        private ListView lvSteps;

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
            this.mainPanel = new Panel();

            this.lblTaskID = new Label();
            this.txtTaskID = new TextBox();
            this.lblTaskUserID = new Label();
            this.txtTaskUserID = new TextBox();
            this.lblTaskTitle = new Label();
            this.txtTaskTitle = new TextBox();
            this.lblTaskDescription = new Label();
            this.txtTaskDescription = new TextBox();
            this.lblDueDate = new Label();
            this.dtpDueDate = new DateTimePicker();

            this.grpSteps = new GroupBox();
            this.btnAddStep = new Button();
            this.lvSteps = new ListView();

            this.btnInsertTask = new Button();

            this.header.SuspendLayout();
            this.mainPanel.SuspendLayout();
            this.grpSteps.SuspendLayout();
            this.SuspendLayout();

            // header
            this.header.BackColor = Color.FromArgb(60, 130, 200);
            this.header.Controls.Add(this.lblTitle);
            this.header.Dock = DockStyle.Top;
            this.header.Location = new Point(0, 0);
            this.header.Name = "header";
            this.header.Size = new Size(900, 70);

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.White;
            this.lblTitle.Location = new Point(20, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(291, 41);
            this.lblTitle.Text = "📥 Insert New Task";

            // mainPanel
            this.mainPanel.BackColor = Color.White;
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
            this.mainPanel.Location = new Point(20, 90);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new Size(860, 580);

            // lblTaskID
            this.lblTaskID.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblTaskID.Location = new Point(30, 20);
            this.lblTaskID.Size = new Size(100, 23);
            this.lblTaskID.Text = "Task ID:";

            // txtTaskID
            this.txtTaskID.Location = new Point(200, 20);
            this.txtTaskID.Size = new Size(600, 22);

            // lblTaskUserID
            this.lblTaskUserID.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblTaskUserID.Location = new Point(30, 60);
            this.lblTaskUserID.Size = new Size(160, 23);
            this.lblTaskUserID.Text = "User ID (ObjectId):";

            // txtTaskUserID
            this.txtTaskUserID.Location = new Point(200, 60);
            this.txtTaskUserID.Size = new Size(600, 22);

            // lblTaskTitle
            this.lblTaskTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblTaskTitle.Location = new Point(30, 100);
            this.lblTaskTitle.Size = new Size(100, 23);
            this.lblTaskTitle.Text = "Title:";

            // txtTaskTitle
            this.txtTaskTitle.Location = new Point(200, 100);
            this.txtTaskTitle.Size = new Size(600, 22);

            // lblTaskDescription
            this.lblTaskDescription.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblTaskDescription.Location = new Point(30, 140);
            this.lblTaskDescription.Size = new Size(100, 23);
            this.lblTaskDescription.Text = "Description:";

            // txtTaskDescription
            this.txtTaskDescription.Location = new Point(200, 140);
            this.txtTaskDescription.Multiline = true;
            this.txtTaskDescription.Size = new Size(600, 80);

            // lblDueDate
            this.lblDueDate.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblDueDate.Location = new Point(30, 230);
            this.lblDueDate.Size = new Size(100, 23);
            this.lblDueDate.Text = "Due Date:";

            // dtpDueDate
            this.dtpDueDate.Location = new Point(200, 230);
            this.dtpDueDate.Size = new Size(300, 22);

            // grpSteps
            this.grpSteps.Controls.Add(this.btnAddStep);
            this.grpSteps.Controls.Add(this.lvSteps);
            this.grpSteps.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.grpSteps.Location = new Point(30, 270);
            this.grpSteps.Size = new Size(770, 220);
            this.grpSteps.Text = "Task Steps";

            // btnAddStep
            this.btnAddStep.Location = new Point(20, 28);
            this.btnAddStep.Size = new Size(110, 30);
            this.btnAddStep.Text = "➕ Add Step";
            this.btnAddStep.Click += new System.EventHandler(this.btnAddStep_Click);

            // lvSteps
            this.lvSteps.Location = new Point(20, 70);
            this.lvSteps.Size = new Size(730, 130);
            this.lvSteps.View = View.Details;
            this.lvSteps.FullRowSelect = true;
            this.lvSteps.GridLines = true;
            this.lvSteps.HideSelection = false;
            this.lvSteps.Columns.Add("Step ID", 150);
            this.lvSteps.Columns.Add("Description", 550);

            // btnInsertTask
            this.btnInsertTask.BackColor = Color.FromArgb(60, 130, 200);
            this.btnInsertTask.FlatStyle = FlatStyle.Flat;
            this.btnInsertTask.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.btnInsertTask.ForeColor = Color.White;
            this.btnInsertTask.Location = new Point(300, 510);
            this.btnInsertTask.Size = new Size(260, 45);
            this.btnInsertTask.Text = "Insert Task";
            this.btnInsertTask.Click += new System.EventHandler(this.btnInsertTask_Click);

            // InsertForm
            this.ClientSize = new Size(900, 700);
            this.Controls.Add(this.header);
            this.Controls.Add(this.mainPanel);
            this.Name = "InsertForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Insert Task";

            this.header.ResumeLayout(false);
            this.header.PerformLayout();
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.grpSteps.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}

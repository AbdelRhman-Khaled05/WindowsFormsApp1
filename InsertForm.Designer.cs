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
            this.lblStep1ID = new Label();
            this.txtStep1ID = new TextBox();
            this.lblStep1Desc = new Label();
            this.txtStep1Desc = new TextBox();
            this.lblStep2ID = new Label();
            this.txtStep2ID = new TextBox();
            this.lblStep2Desc = new Label();
            this.txtStep2Desc = new TextBox();

            this.btnInsertTask = new Button();

            // HEADER
            this.header.BackColor = Color.FromArgb(60, 130, 200);
            this.header.Dock = DockStyle.Top;
            this.header.Size = new Size(800, 70);
            this.header.Controls.Add(this.lblTitle);

            this.lblTitle.Text = "📥 Insert New Task";
            this.lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.White;
            this.lblTitle.Location = new Point(20, 18);

            // MAIN PANEL
            this.mainPanel.BackColor = Color.White;
            this.mainPanel.Location = new Point(20, 90);
            this.mainPanel.Size = new Size(760, 590);

            // TASK ID
            this.lblTaskID.Text = "Task ID:";
            this.lblTaskID.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblTaskID.Location = new Point(30, 20);
            this.txtTaskID.Location = new Point(200, 20);
            this.txtTaskID.Size = new Size(500, 30);

            // USER ID
            this.lblTaskUserID.Text = "User ID (ObjectId):";
            this.lblTaskUserID.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblTaskUserID.Location = new Point(30, 60);
            this.txtTaskUserID.Location = new Point(200, 60);
            this.txtTaskUserID.Size = new Size(500, 30);

            // TITLE
            this.lblTaskTitle.Text = "Title:";
            this.lblTaskTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblTaskTitle.Location = new Point(30, 100);
            this.txtTaskTitle.Location = new Point(200, 100);
            this.txtTaskTitle.Size = new Size(500, 30);

            // DESCRIPTION
            this.lblTaskDescription.Text = "Description:";
            this.lblTaskDescription.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblTaskDescription.Location = new Point(30, 140);
            this.txtTaskDescription.Location = new Point(200, 140);
            this.txtTaskDescription.Size = new Size(500, 60);
            this.txtTaskDescription.Multiline = true;

            // DUE DATE
            this.lblDueDate.Text = "Due Date:";
            this.lblDueDate.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblDueDate.Location = new Point(30, 210);
            this.dtpDueDate.Location = new Point(200, 210);
            this.dtpDueDate.Size = new Size(300, 30);
            this.dtpDueDate.Format = DateTimePickerFormat.Short;

            // STEPS GROUPBOX
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
            this.txtStep1Desc.Size = new Size(300, 30);

            // STEP 2
            this.lblStep2ID.Text = "Step 2 ID:";
            this.lblStep2ID.Location = new Point(20, 80);
            this.txtStep2ID.Location = new Point(130, 80);
            this.txtStep2ID.Size = new Size(120, 30);

            this.lblStep2Desc.Text = "Description:";
            this.lblStep2Desc.Location = new Point(260, 80);
            this.txtStep2Desc.Location = new Point(360, 80);
            this.txtStep2Desc.Size = new Size(300, 30);

            this.grpSteps.Controls.Add(this.lblStep1ID);
            this.grpSteps.Controls.Add(this.txtStep1ID);
            this.grpSteps.Controls.Add(this.lblStep1Desc);
            this.grpSteps.Controls.Add(this.txtStep1Desc);
            this.grpSteps.Controls.Add(this.lblStep2ID);
            this.grpSteps.Controls.Add(this.txtStep2ID);
            this.grpSteps.Controls.Add(this.lblStep2Desc);
            this.grpSteps.Controls.Add(this.txtStep2Desc);

            // INSERT TASK BUTTON
            this.btnInsertTask.Text = "Insert Task";
            this.btnInsertTask.Location = new Point(200, 495);
            this.btnInsertTask.Size = new Size(200, 45);
            this.btnInsertTask.BackColor = Color.FromArgb(60, 130, 200);
            this.btnInsertTask.ForeColor = Color.White;
            this.btnInsertTask.FlatStyle = FlatStyle.Flat;
            this.btnInsertTask.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.btnInsertTask.Cursor = Cursors.Hand;
            this.btnInsertTask.Click += new System.EventHandler(this.btnInsertTask_Click);

            // Add to main panel
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

            // FORM SETTINGS
            this.ClientSize = new Size(800, 700);
            this.Controls.Add(this.header);
            this.Controls.Add(this.mainPanel);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Insert Task";
            this.Load += new System.EventHandler(this.InsertForm_Load);

            this.header.ResumeLayout(false);
            this.header.PerformLayout();
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.grpSteps.ResumeLayout(false);
            this.grpSteps.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}
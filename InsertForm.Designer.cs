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
        private ComboBox cmbAssignUser;
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
            this.components = new System.ComponentModel.Container();
            this.header = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblTaskID = new System.Windows.Forms.Label();
            this.txtTaskID = new System.Windows.Forms.TextBox();
            this.lblAssignUser = new System.Windows.Forms.Label();
            this.cmbAssignUser = new System.Windows.Forms.ComboBox();
            this.lblTaskTitle = new System.Windows.Forms.Label();
            this.txtTaskTitle = new System.Windows.Forms.TextBox();
            this.lblTaskDescription = new System.Windows.Forms.Label();
            this.txtTaskDescription = new System.Windows.Forms.TextBox();
            this.lblDueDate = new System.Windows.Forms.Label();
            this.dtpDueDate = new System.Windows.Forms.DateTimePicker();
            this.btnAddStep = new System.Windows.Forms.Button();
            this.lvSteps = new System.Windows.Forms.ListView();
            this.btnInsertTask = new System.Windows.Forms.Button();

            this.header.SuspendLayout();
            this.SuspendLayout();

            // header
            this.header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(130)))), ((int)(((byte)(200)))));
            this.header.Controls.Add(this.lblTitle);
            this.header.Dock = System.Windows.Forms.DockStyle.Top;
            this.header.Location = new System.Drawing.Point(0, 0);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(820, 50);
            this.header.TabIndex = 0;

            // lblTitle
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(12, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(200, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "➕ Insert New Task";

            // lblTaskID
            this.lblTaskID.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTaskID.Location = new System.Drawing.Point(30, 70);
            this.lblTaskID.Name = "lblTaskID";
            this.lblTaskID.Size = new System.Drawing.Size(100, 25);
            this.lblTaskID.TabIndex = 1;
            this.lblTaskID.Text = "Task ID:";

            // txtTaskID
            this.txtTaskID.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTaskID.Location = new System.Drawing.Point(150, 68);
            this.txtTaskID.Name = "txtTaskID";
            this.txtTaskID.Size = new System.Drawing.Size(320, 25);
            this.txtTaskID.TabIndex = 2;

            // lblAssignUser
            this.lblAssignUser.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblAssignUser.Location = new System.Drawing.Point(30, 110);
            this.lblAssignUser.Name = "lblAssignUser";
            this.lblAssignUser.Size = new System.Drawing.Size(100, 25);
            this.lblAssignUser.TabIndex = 3;
            this.lblAssignUser.Text = "Assign To:";

            // cmbAssignUser
            this.cmbAssignUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAssignUser.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbAssignUser.Location = new System.Drawing.Point(150, 108);
            this.cmbAssignUser.Name = "cmbAssignUser";
            this.cmbAssignUser.Size = new System.Drawing.Size(320, 25);
            this.cmbAssignUser.TabIndex = 4;

            // lblTaskTitle
            this.lblTaskTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTaskTitle.Location = new System.Drawing.Point(30, 150);
            this.lblTaskTitle.Name = "lblTaskTitle";
            this.lblTaskTitle.Size = new System.Drawing.Size(100, 25);
            this.lblTaskTitle.TabIndex = 5;
            this.lblTaskTitle.Text = "Title:";

            // txtTaskTitle
            this.txtTaskTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTaskTitle.Location = new System.Drawing.Point(150, 148);
            this.txtTaskTitle.Name = "txtTaskTitle";
            this.txtTaskTitle.Size = new System.Drawing.Size(320, 25);
            this.txtTaskTitle.TabIndex = 6;

            // lblTaskDescription
            this.lblTaskDescription.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTaskDescription.Location = new System.Drawing.Point(30, 190);
            this.lblTaskDescription.Name = "lblTaskDescription";
            this.lblTaskDescription.Size = new System.Drawing.Size(100, 25);
            this.lblTaskDescription.TabIndex = 7;
            this.lblTaskDescription.Text = "Description:";

            // txtTaskDescription
            this.txtTaskDescription.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTaskDescription.Location = new System.Drawing.Point(150, 188);
            this.txtTaskDescription.Multiline = true;
            this.txtTaskDescription.Name = "txtTaskDescription";
            this.txtTaskDescription.Size = new System.Drawing.Size(320, 70);
            this.txtTaskDescription.TabIndex = 8;

            // lblDueDate
            this.lblDueDate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDueDate.Location = new System.Drawing.Point(30, 270);
            this.lblDueDate.Name = "lblDueDate";
            this.lblDueDate.Size = new System.Drawing.Size(100, 25);
            this.lblDueDate.TabIndex = 9;
            this.lblDueDate.Text = "Due Date:";

            // dtpDueDate
            this.dtpDueDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpDueDate.Location = new System.Drawing.Point(150, 268);
            this.dtpDueDate.Name = "dtpDueDate";
            this.dtpDueDate.Size = new System.Drawing.Size(200, 25);
            this.dtpDueDate.TabIndex = 10;

            // btnAddStep
            this.btnAddStep.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(100)))));
            this.btnAddStep.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddStep.FlatAppearance.BorderSize = 0;
            this.btnAddStep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddStep.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAddStep.ForeColor = System.Drawing.Color.White;
            this.btnAddStep.Location = new System.Drawing.Point(470, 265);
            this.btnAddStep.Name = "btnAddStep";
            this.btnAddStep.Size = new System.Drawing.Size(120, 35);
            this.btnAddStep.TabIndex = 11;
            this.btnAddStep.Text = "➕ Add Step";
            this.btnAddStep.UseVisualStyleBackColor = false;
            this.btnAddStep.Click += new System.EventHandler(this.btnAddStep_Click);

            // lvSteps
            this.lvSteps.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lvSteps.FullRowSelect = true;
            this.lvSteps.HideSelection = false;
            this.lvSteps.Location = new System.Drawing.Point(30, 310);
            this.lvSteps.Name = "lvSteps";
            this.lvSteps.Size = new System.Drawing.Size(760, 180);
            this.lvSteps.TabIndex = 12;
            this.lvSteps.UseCompatibleStateImageBehavior = false;
            this.lvSteps.View = System.Windows.Forms.View.Details;

            // Add columns to ListView
            this.lvSteps.Columns.Add("Step ID", 150);
            this.lvSteps.Columns.Add("Description", 600);

            // btnInsertTask
            this.btnInsertTask.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(130)))), ((int)(((byte)(200)))));
            this.btnInsertTask.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInsertTask.FlatAppearance.BorderSize = 0;
            this.btnInsertTask.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInsertTask.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnInsertTask.ForeColor = System.Drawing.Color.White;
            this.btnInsertTask.Location = new System.Drawing.Point(280, 510);
            this.btnInsertTask.Name = "btnInsertTask";
            this.btnInsertTask.Size = new System.Drawing.Size(260, 40);
            this.btnInsertTask.TabIndex = 13;
            this.btnInsertTask.Text = "✓ Insert Task";
            this.btnInsertTask.UseVisualStyleBackColor = false;
            this.btnInsertTask.Click += new System.EventHandler(this.btnInsertTask_Click);

            // InsertForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 580);
            this.Controls.Add(this.header);
            this.Controls.Add(this.lblTaskID);
            this.Controls.Add(this.txtTaskID);
            this.Controls.Add(this.lblAssignUser);
            this.Controls.Add(this.cmbAssignUser);
            this.Controls.Add(this.lblTaskTitle);
            this.Controls.Add(this.txtTaskTitle);
            this.Controls.Add(this.lblTaskDescription);
            this.Controls.Add(this.txtTaskDescription);
            this.Controls.Add(this.lblDueDate);
            this.Controls.Add(this.dtpDueDate);
            this.Controls.Add(this.btnAddStep);
            this.Controls.Add(this.lvSteps);
            this.Controls.Add(this.btnInsertTask);
            this.Name = "InsertForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Insert Task";
            this.Load += new System.EventHandler(this.InsertForm_Load);
            this.header.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion
    }
}
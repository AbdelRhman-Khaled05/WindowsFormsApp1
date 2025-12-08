using System;
using System.Drawing;
using System.Windows.Forms;

namespace TaskManagementApp
{
    partial class UserDashboard
    {
        private System.ComponentModel.IContainer components = null;
        private Panel mainPanel;
        private Label lblTitle;
        private Label lblWelcome;
        private Button btnViewTasks;
        private Button btnReports;
        private Button btnLogout;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.mainPanel = new Panel();
            this.lblTitle = new Label();
            this.lblWelcome = new Label();
            this.btnViewTasks = new Button();
            this.btnReports = new Button();
            this.btnLogout = new Button();

            this.mainPanel.SuspendLayout();
            this.SuspendLayout();

            // FORM
            this.ClientSize = new Size(700, 500);
            this.Text = "User Dashboard";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(60, 130, 200);

            // MAIN PANEL
            this.mainPanel.BackColor = Color.White;
            this.mainPanel.Location = new Point(50, 50);
            this.mainPanel.Size = new Size(600, 400);

            // TITLE
            this.lblTitle.Text = "User Dashboard";
            this.lblTitle.Font = new Font("Segoe UI", 24, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.FromArgb(60, 130, 200);
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new Point(170, 30);

            // WELCOME
            this.lblWelcome.Text = "Welcome, User";
            this.lblWelcome.Font = new Font("Segoe UI", 12);
            this.lblWelcome.ForeColor = Color.FromArgb(100, 100, 100);
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Location = new Point(220, 75);

            // VIEW TASKS BUTTON
            this.btnViewTasks.Text = "📋 View & Complete Tasks";
            this.btnViewTasks.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            this.btnViewTasks.ForeColor = Color.White;
            this.btnViewTasks.BackColor = Color.FromArgb(60, 130, 200);
            this.btnViewTasks.FlatStyle = FlatStyle.Flat;
            this.btnViewTasks.FlatAppearance.BorderSize = 0;
            this.btnViewTasks.Location = new Point(150, 140);
            this.btnViewTasks.Size = new Size(300, 60);
            this.btnViewTasks.Cursor = Cursors.Hand;
            this.btnViewTasks.Click += new EventHandler(this.btnViewTasks_Click);

            // REPORTS BUTTON
            this.btnReports.Text = "📊 My Reports";
            this.btnReports.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            this.btnReports.ForeColor = Color.White;
            this.btnReports.BackColor = Color.FromArgb(40, 160, 80);
            this.btnReports.FlatStyle = FlatStyle.Flat;
            this.btnReports.FlatAppearance.BorderSize = 0;
            this.btnReports.Location = new Point(150, 220);
            this.btnReports.Size = new Size(300, 60);
            this.btnReports.Cursor = Cursors.Hand;
            this.btnReports.Click += new EventHandler(this.btnReports_Click);

            // LOGOUT BUTTON
            this.btnLogout.Text = "🚪 Logout";
            this.btnLogout.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            this.btnLogout.ForeColor = Color.White;
            this.btnLogout.BackColor = Color.FromArgb(200, 60, 60);
            this.btnLogout.FlatStyle = FlatStyle.Flat;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.Location = new Point(200, 320);
            this.btnLogout.Size = new Size(200, 45);
            this.btnLogout.Cursor = Cursors.Hand;
            this.btnLogout.Click += new EventHandler(this.btnLogout_Click);

            this.mainPanel.Controls.Add(this.lblTitle);
            this.mainPanel.Controls.Add(this.lblWelcome);
            this.mainPanel.Controls.Add(this.btnViewTasks);
            this.mainPanel.Controls.Add(this.btnReports);
            this.mainPanel.Controls.Add(this.btnLogout);

            this.Controls.Add(this.mainPanel);

            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}
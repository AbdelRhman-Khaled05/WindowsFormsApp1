using System;
using System.Windows.Forms;

namespace TaskManagementApp
{
    public partial class AdminDashboard : Form
    {
        public AdminDashboard()
        {
            InitializeComponent();
            lblWelcome.Text = $"Welcome, {LoginForm.LoggedInUsername} (Admin)";
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            InsertForm f = new InsertForm();
            f.ShowDialog();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateForm f = new UpdateForm();
            f.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteForm f = new DeleteForm();
            f.ShowDialog();
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            DisplayForm f = new DisplayForm();
            f.ShowDialog();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            ReportForm f = new ReportForm();
            f.ShowDialog();
        }

        private void btnAuditLogs_Click(object sender, EventArgs e)
        {
            AuditLogsForm f = new AuditLogsForm();
            f.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to logout?",
                "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Hide();
                LoginForm loginForm = new LoginForm();

                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    // Check role and show appropriate dashboard
                    if (LoginForm.LoggedInRole == "Admin")
                    {
                        AdminDashboard newDashboard = new AdminDashboard();
                        this.Close();
                        newDashboard.Show();
                    }
                    else if (LoginForm.LoggedInRole == "User")
                    {
                        UserDashboard userDashboard = new UserDashboard();
                        this.Close();
                        userDashboard.Show();
                    }
                }
                else
                {
                    Application.Exit();
                }
            }
        }
    }
}
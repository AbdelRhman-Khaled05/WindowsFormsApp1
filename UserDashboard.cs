using System;
using System.Windows.Forms;

namespace TaskManagementApp
{
    public partial class UserDashboard : Form
    {
        public UserDashboard()
        {
            InitializeComponent();
            lblWelcome.Text = $"Welcome, {LoginForm.LoggedInUsername} (User)";
        }

        private void btnViewTasks_Click(object sender, EventArgs e)
        {
            ViewTasksForm f = new ViewTasksForm();
            f.ShowDialog();
        }

        private void btnUpdateProfile_Click(object sender, EventArgs e)
        {
            UpdateUserProfileForm f = new UpdateUserProfileForm();
            f.ShowDialog();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            ReportForm f = new ReportForm();
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
                        AdminDashboard adminDashboard = new AdminDashboard();
                        this.Close();
                        adminDashboard.Show();
                    }
                    else if (LoginForm.LoggedInRole == "User")
                    {
                        UserDashboard newDashboard = new UserDashboard();
                        this.Close();
                        newDashboard.Show();
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
using System;
using System.Windows.Forms;

namespace TaskManagementApp
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Show login form first
            LoginForm loginForm = new LoginForm();

            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                // Check user role and show appropriate dashboard
                if (LoginForm.LoggedInRole == "Admin")
                {
                    // Show Admin Dashboard
                    Application.Run(new AdminDashboard());
                }
                else if (LoginForm.LoggedInRole == "User")
                {
                    // Show User Dashboard
                    Application.Run(new UserDashboard());
                }
                else
                {
                    MessageBox.Show("Unknown role. Please contact administrator.");
                    Application.Exit();
                }
            }
            else
            {
                // If login cancelled or failed, exit application
                Application.Exit();
            }
        }
    }
}
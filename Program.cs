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

            // Show login form
            LoginForm loginForm = new LoginForm();
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                // After successful login, show appropriate dashboard
                if (LoginForm.LoggedInRole == "Admin")
                {
                    Application.Run(new AdminDashboard());
                }
                else if (LoginForm.LoggedInRole == "User")
                {
                    Application.Run(new UserDashboard());
                }
            }
            else
            {
                Application.Exit();
            }
        }
    }
}
using System;
using System.Windows.Forms;
using MongoDB.Driver;
using TaskManagementApp.Models;

namespace TaskManagementApp
{
    public partial class LoginForm : Form
    {
        private IMongoCollection<User> usersCollection;

        public static string LoggedInUserID { get; private set; }
        public static string LoggedInUsername { get; private set; }
        public static string LoggedInRole { get; private set; }

        public LoginForm()
        {
            InitializeComponent();
            var db = MongoConnection.GetDatabase();
            usersCollection = db.GetCollection<User>("Users");
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter both username and password.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var filter = Builders<User>.Filter.And(
                    Builders<User>.Filter.Eq(u => u.Username, username),
                    Builders<User>.Filter.Eq(u => u.Password, password)
                );

                var user = usersCollection.Find(filter).FirstOrDefault();

                if (user != null)
                {
                    LoggedInUserID = user.UserID;
                    LoggedInUsername = user.Username;
                    LoggedInRole = user.Role;

                    // Log audit
                    LogAudit(user.UserID, null, null, "User Login");

                    MessageBox.Show($"Welcome, {user.Username}!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid username or password.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during login: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LogAudit(string userID, string taskID, string stepID, string action)
        {
            try
            {
                var db = MongoConnection.GetDatabase();
                var auditCollection = db.GetCollection<AuditLog>("AuditLogs");

                var log = new AuditLog
                {
                    LogID = Guid.NewGuid().ToString(),
                    UserID = userID,
                    TaskID = taskID,
                    StepID = stepID,
                    Action = action,
                    Timestamp = DateTime.Now
                };

                auditCollection.InsertOne(log);
            }
            catch (Exception ex)
            {
                // Silent fail for audit logs
                Console.WriteLine("Audit log error: " + ex.Message);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }
    }
}
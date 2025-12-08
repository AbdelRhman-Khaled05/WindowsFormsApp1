using System;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Driver;

namespace TaskManagementApp
{
    public partial class LoginForm : Form
    {
        private IMongoDatabase _db;
        private IMongoCollection<BsonDocument> _users;
        private IMongoCollection<BsonDocument> _auditLogs;

        public static string LoggedInUserID { get; private set; }
        public static string LoggedInUsername { get; private set; }
        public static string LoggedInRole { get; private set; }
        public static BsonValue LoggedInObjectId { get; private set; }

        public LoginForm()
        {
            InitializeComponent();

            try
            {
                _db = MongoConnection.GetDatabase();
                _users = _db.GetCollection<BsonDocument>("Users");
                _auditLogs = _db.GetCollection<BsonDocument>("AuditLogs");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database connection error: " + ex.Message);
            }
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
                var filter = Builders<BsonDocument>.Filter.And(
                    Builders<BsonDocument>.Filter.Eq("Username", username),
                    Builders<BsonDocument>.Filter.Eq("Password", password)
                );

                var user = _users.Find(filter).FirstOrDefault();

                if (user != null)
                {
                    LoggedInUserID = user["UserID"].AsString;
                    LoggedInUsername = user["Username"].AsString;
                    LoggedInRole = user["Role"].AsString;
                    LoggedInObjectId = user["_id"];

                    // Log audit
                    LogAudit(LoggedInUserID, "User Login", $"{LoggedInUsername} logged in");

                    MessageBox.Show($"Welcome, {LoggedInUsername}!\nRole: {LoggedInRole}",
                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            SignUpForm signUpForm = new SignUpForm();
            signUpForm.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }

        private void LogAudit(string userID, string action, string details)
        {
            try
            {
                var log = new BsonDocument
                {
                    { "LogID", Guid.NewGuid().ToString() },
                    { "UserID", userID },
                    { "Action", action },
                    { "Details", details },
                    { "Timestamp", DateTime.Now }
                };

                _auditLogs.InsertOne(log);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Audit log error: " + ex.Message);
            }
        }
    }
}
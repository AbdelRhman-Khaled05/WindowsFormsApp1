using System;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Driver;

namespace TaskManagementApp
{
    public partial class UpdateUserProfileForm : Form
    {
        private IMongoDatabase _db;
        private IMongoCollection<BsonDocument> _users;
        private IMongoCollection<BsonDocument> _auditLogs;

        public UpdateUserProfileForm()
        {
            InitializeComponent();

            try
            {
                _db = MongoConnection.GetDatabase();
                _users = _db.GetCollection<BsonDocument>("Users");
                _auditLogs = _db.GetCollection<BsonDocument>("AuditLogs");
                LoadCurrentUserData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting to database: " + ex.Message);
            }
        }

        private void LoadCurrentUserData()
        {
            try
            {
                var filter = Builders<BsonDocument>.Filter.Eq("_id", LoginForm.LoggedInObjectId.AsObjectId);
                var user = _users.Find(filter).FirstOrDefault();

                if (user != null)
                {
                    txtUsername.Text = user.GetValue("Username", "").ToString();
                    txtPassword.Text = user.GetValue("Password", "").ToString();
                    lblCurrentRole.Text = $"Role: {user.GetValue("Role", "").ToString()}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading profile: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            try
            {
                var filter = Builders<BsonDocument>.Filter.Eq("_id", LoginForm.LoggedInObjectId.AsObjectId);
                var update = Builders<BsonDocument>.Update
                    .Set("Username", txtUsername.Text)
                    .Set("Password", txtPassword.Text);

                _users.UpdateOne(filter, update);

                LogAudit(LoginForm.LoggedInUserID, "Update Profile", "Updated own profile");

                MessageBox.Show("Profile updated successfully!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating profile: " + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void UpdateUserProfileForm_Load(object sender, EventArgs e)
        {

        }
    }
}
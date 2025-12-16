
using System;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Driver;

namespace TaskManagementApp
{
    public partial class SignUpForm : Form
    {
        private IMongoDatabase _db;
        private IMongoCollection<BsonDocument> _users;

        public SignUpForm()
        {
            InitializeComponent();

            try
            {
                _db = MongoConnection.GetDatabase();
                _users = _db.GetCollection<BsonDocument>("Users");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database connection error: " + ex.Message);
            }
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            // Validation
            if (string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Please fill in Username and Password.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Check if username already exists
                var filter = Builders<BsonDocument>.Filter.Eq("Username", txtUsername.Text);
                var existingUser = _users.Find(filter).FirstOrDefault();

                if (existingUser != null)
                {
                    MessageBox.Show("Username already exists. Please choose another.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Generate new UserID (optional) - we will NOT rely on this in code anymore
                string newUserID = "USR" + DateTime.Now.ToString("yyyyMMddHHmmss");

                // Create user document — ROLE is always "User" for signups from form
                var user = new BsonDocument
                {
                    { "UserID", newUserID }, // optional legacy field (you can remove later from DB)
                    { "Username", txtUsername.Text },
                    { "Password", txtPassword.Text }, // In production, hash this!
                    { "Role", "User" }
                };

                _users.InsertOne(user);

                MessageBox.Show($"Account created successfully!\nUser ID: {newUserID}\nRole: User",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear fields
                txtUsername.Clear();
                txtPassword.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creating account: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGoToLogin_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SignUpForm_Load(object sender, EventArgs e)
        {

        }
    }
}

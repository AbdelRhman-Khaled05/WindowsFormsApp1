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

        public static string LoggedInUserID { get; set; }
        public static string LoggedInUsername { get; set; }
        public static string LoggedInRole { get; set; }
        public static BsonValue LoggedInObjectId { get; set; }

        public LoginForm()
        {
            InitializeComponent();

            try
            {
                _db = MongoConnection.GetDatabase();
                _users = _db.GetCollection<BsonDocument>("Users");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting to MongoDB: " + ex.Message);
                Application.Exit();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter username and password.");
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
                    LoggedInObjectId = user["_id"];
                    LoggedInUserID = user["_id"].ToString();
                    LoggedInUsername = user.GetValue("Username", "").AsString;
                    LoggedInRole = user.GetValue("Role", "").AsString;

                    this.DialogResult = DialogResult.OK;
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid username or password.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Login error: " + ex.Message);
            }
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            SignUpForm signUpForm = new SignUpForm();
            signUpForm.ShowDialog();
        }

        private void lblSignUp_Click(object sender, EventArgs e)
        {
            SignUpForm signUpForm = new SignUpForm();
            signUpForm.ShowDialog();
        }
    }
}
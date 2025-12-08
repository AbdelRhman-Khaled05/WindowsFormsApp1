using System;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Data;

namespace TaskManagementApp
{
    public partial class DisplayForm : Form
    {
        private IMongoDatabase _db;
        private IMongoCollection<BsonDocument> _users;
        private IMongoCollection<BsonDocument> _tasks;
        private IMongoCollection<BsonDocument> _auditLogs;

        public DisplayForm()
        {
            InitializeComponent();

            try
            {
                _db = MongoConnection.GetDatabase();
                _users = _db.GetCollection<BsonDocument>("Users");  // Fixed: Capitalized
                _tasks = _db.GetCollection<BsonDocument>("Tasks");  // Fixed: Capitalized
                _auditLogs = _db.GetCollection<BsonDocument>("AuditLogs");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting to MongoDB: " + ex.Message);
            }
        }

        private void btnDisplayUsers_Click(object sender, EventArgs e)
        {
            try
            {
                var users = _users.Find(new BsonDocument()).ToList();

                DataTable dt = new DataTable();
                dt.Columns.Add("UserID");
                dt.Columns.Add("Username");
                dt.Columns.Add("Password");
                dt.Columns.Add("Role");

                foreach (var user in users)
                {
                    dt.Rows.Add(
                        user.GetValue("UserID", ""),
                        user.GetValue("Username", ""),
                        user.GetValue("Password", ""),
                        user.GetValue("Role", "")
                    );
                }

                dgvDisplay.DataSource = dt;
                lblCount.Text = $"Total Records: {users.Count}";

                // Log audit
                LogAudit(LoginForm.LoggedInUserID, "Display Users", "Displayed all users");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error displaying users: " + ex.Message);
            }
        }

        private void btnDisplayTasks_Click(object sender, EventArgs e)
        {
            try
            {
                var tasks = _tasks.Find(new BsonDocument()).ToList();

                DataTable dt = new DataTable();
                dt.Columns.Add("TaskID");
                dt.Columns.Add("UserID");
                dt.Columns.Add("Title");
                dt.Columns.Add("Description");
                dt.Columns.Add("Status");
                dt.Columns.Add("Steps Count");

                foreach (var task in tasks)
                {
                    int stepsCount = 0;
                    if (task.Contains("Steps") && task["Steps"].IsBsonArray)
                    {
                        stepsCount = task["Steps"].AsBsonArray.Count;
                    }

                    dt.Rows.Add(
                        task.GetValue("TaskID", ""),
                        task.GetValue("UserID", ""),
                        task.GetValue("Title", ""),
                        task.GetValue("Description", ""),
                        task.GetValue("TaskStatus", ""),
                        stepsCount
                    );
                }

                dgvDisplay.DataSource = dt;
                lblCount.Text = $"Total Records: {tasks.Count}";

                // Log audit
                LogAudit(LoginForm.LoggedInUserID, "Display Tasks", "Displayed all tasks");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error displaying tasks: " + ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim();
            if (string.IsNullOrWhiteSpace(searchText))
            {
                MessageBox.Show("Please enter a search term.");
                return;
            }

            try
            {
                var filter = Builders<BsonDocument>.Filter.Or(
                    Builders<BsonDocument>.Filter.Regex("Title", new BsonRegularExpression(searchText, "i")),
                    Builders<BsonDocument>.Filter.Regex("TaskID", new BsonRegularExpression(searchText, "i")),
                    Builders<BsonDocument>.Filter.Regex("UserID", new BsonRegularExpression(searchText, "i"))
                );

                var tasks = _tasks.Find(filter).ToList();

                DataTable dt = new DataTable();
                dt.Columns.Add("TaskID");
                dt.Columns.Add("UserID");
                dt.Columns.Add("Title");
                dt.Columns.Add("Description");
                dt.Columns.Add("Status");

                foreach (var task in tasks)
                {
                    dt.Rows.Add(
                        task.GetValue("TaskID", ""),
                        task.GetValue("UserID", ""),
                        task.GetValue("Title", ""),
                        task.GetValue("Description", ""),
                        task.GetValue("TaskStatus", "")
                    );
                }

                dgvDisplay.DataSource = dt;
                lblCount.Text = $"Search Results: {tasks.Count}";

                // Log audit
                LogAudit(LoginForm.LoggedInUserID, "Search Tasks", $"Searched for: {searchText}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching: " + ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            dgvDisplay.DataSource = null;
            lblCount.Text = "Total Records: 0";
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnSearch_Click(sender, e);
                e.Handled = true;
            }
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
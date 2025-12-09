using System;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Driver;

namespace TaskManagementApp
{
    public partial class InsertForm : Form
    {
        private IMongoDatabase _db;
        private IMongoCollection<BsonDocument> _tasks;
        private IMongoCollection<BsonDocument> _auditLogs;

        public InsertForm()
        {
            InitializeComponent();

            try
            {
                _db = MongoConnection.GetDatabase();
                _tasks = _db.GetCollection<BsonDocument>("Tasks");
                _auditLogs = _db.GetCollection<BsonDocument>("AuditLogs");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting to MongoDB: " + ex.Message);
            }
        }

        private void btnInsertTask_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTaskID.Text) ||
                string.IsNullOrWhiteSpace(txtTaskUserID.Text) ||
                string.IsNullOrWhiteSpace(txtTaskTitle.Text))
            {
                MessageBox.Show("Please fill in all required fields (TaskID, UserID, Title).");
                return;
            }

            try
            {
                ObjectId userIdObj;
                if (!ObjectId.TryParse(txtTaskUserID.Text, out userIdObj))
                {
                    MessageBox.Show("Invalid UserID! Enter a valid ObjectId.");
                    return;
                }

                // Create task document with NO Status field - defaults to "Not Started"
                var task = new BsonDocument
                {
                    { "TaskID", txtTaskID.Text },
                    { "UserID", userIdObj },
                    { "Title", txtTaskTitle.Text },
                    { "Description", txtTaskDescription.Text },
                    { "Status", "Not Started" },  // DEFAULT STATUS
                    { "DueDate", dtpDueDate.Value },
                    { "CreatedDate", DateTime.Now },
                    { "Steps", new BsonArray() }  // Empty steps array
                };

                _tasks.InsertOne(task);

                LogAudit(LoginForm.LoggedInUsername, "Insert Task", $"Created task: {txtTaskID.Text}");

                MessageBox.Show("Task inserted successfully!");
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inserting task: " + ex.Message);
            }
        }

        private void ClearFields()
        {
            txtTaskID.Clear();
            txtTaskUserID.Clear();
            txtTaskTitle.Clear();
            txtTaskDescription.Clear();
            dtpDueDate.Value = DateTime.Now;
        }

        private void LogAudit(string username, string action, string details)
        {
            try
            {
                var log = new BsonDocument
                {
                    { "LogID", Guid.NewGuid().ToString() },
                    { "Username", username },  // Changed from UserID to Username
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
using System;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Driver;

namespace TaskManagementApp
{
    public partial class InsertForm : Form
    {
        private IMongoDatabase _db;
        private IMongoCollection<BsonDocument> _users;
        private IMongoCollection<BsonDocument> _tasks;
        private IMongoCollection<BsonDocument> _auditLogs;

        public InsertForm()
        {
            InitializeComponent();

            try
            {
                _db = MongoConnection.GetDatabase();
                _users = _db.GetCollection<BsonDocument>("Users");
                _tasks = _db.GetCollection<BsonDocument>("Tasks");
                _auditLogs = _db.GetCollection<BsonDocument>("AuditLogs");
            }
            catch { }
        }

        private void InsertForm_Load(object sender, EventArgs e)
        {
            // Optional initialization
        }

        // ---------------------------- INSERT TASK ONLY (No User Insert) ----------------------------
        private void btnInsertTask_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTaskID.Text) ||
                string.IsNullOrWhiteSpace(txtTaskUserID.Text) ||
                string.IsNullOrWhiteSpace(txtTaskTitle.Text))
            {
                MessageBox.Show("Please fill Task ID, User ID, and Title.");
                return;
            }

            try
            {
                // Convert to ObjectId as required by your schema
                if (!ObjectId.TryParse(txtTaskUserID.Text, out ObjectId userObjectId))
                {
                    MessageBox.Show("UserID must be a valid MongoDB ObjectId.");
                    return;
                }

                // ----------------- BUILD STEPS ARRAY -----------------
                var steps = new BsonArray();

                // STEP 1
                if (!string.IsNullOrWhiteSpace(txtStep1ID.Text))
                {
                    steps.Add(new BsonDocument
                    {
                        { "StepID", txtStep1ID.Text },
                        { "StepDescription", txtStep1Desc.Text ?? "" },
                        { "StepStatus", "Not Started" }, // Default status
                        { "SignedOff", new BsonDocument {
                            { "UserID", "" },
                            { "Status", "Not-Signed" },
                            { "Date", BsonNull.Value }
                        }}
                    });
                }

                // STEP 2
                if (!string.IsNullOrWhiteSpace(txtStep2ID.Text))
                {
                    steps.Add(new BsonDocument
                    {
                        { "StepID", txtStep2ID.Text },
                        { "StepDescription", txtStep2Desc.Text ?? "" },
                        { "StepStatus", "Not Started" }, // Default status
                        { "SignedOff", new BsonDocument {
                            { "UserID", "" },
                            { "Status", "Not-Signed" },
                            { "Date", BsonNull.Value }
                        }}
                    });
                }

                // ----------------- BUILD TASK DOCUMENT -----------------
                var task = new BsonDocument
                {
                    { "TaskID", txtTaskID.Text },
                    { "UserID", userObjectId },
                    { "Title", txtTaskTitle.Text },
                    { "Description", txtTaskDescription.Text ?? "" },
                    { "TaskStatus", "Not Started" }, // Default: Not Started
                    { "DueDate", dtpDueDate.Value },
                    { "Steps", steps }
                };

                _tasks.InsertOne(task);

                // Log audit
                LogAudit(LoginForm.LoggedInUserID, "Insert Task", $"Created task: {txtTaskID.Text}");

                MessageBox.Show("Task inserted successfully!");

                // Clear fields
                ClearTaskFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inserting task: " + ex.Message);
            }
        }

        private void ClearTaskFields()
        {
            txtTaskID.Clear();
            txtTaskUserID.Clear();
            txtTaskTitle.Clear();
            txtTaskDescription.Clear();
            txtStep1ID.Clear();
            txtStep1Desc.Clear();
            txtStep2ID.Clear();
            txtStep2Desc.Clear();
            dtpDueDate.Value = DateTime.Now;
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
using System;
using System.Collections.Generic;
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

        private List<BsonDocument> stepList = new List<BsonDocument>();

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

        private void btnAddStep_Click(object sender, EventArgs e)
        {
            using (var form = new AddStepForm())
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    var stepDoc = new BsonDocument
                    {
                        { "StepID", form.StepID },
                        { "StepDescription", form.StepDescription },
                        { "StepStatus", "Pending" } // matches schema
                    };

                    stepList.Add(stepDoc);

                    // Add to ListView (two columns: StepID, Description)
                    var item = new ListViewItem(form.StepID);
                    item.SubItems.Add(form.StepDescription);
                    lvSteps.Items.Add(item);
                }
            }
        }

        private void btnInsertTask_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTaskID.Text) ||
                string.IsNullOrWhiteSpace(txtTaskUserID.Text) ||
                string.IsNullOrWhiteSpace(txtTaskTitle.Text))
            {
                MessageBox.Show("TaskID, UserID, and Title are required.");
                return;
            }

            if (!ObjectId.TryParse(txtTaskUserID.Text, out ObjectId userIdObj))
            {
                MessageBox.Show("Invalid UserID.");
                return;
            }

            try
            {
                var taskDoc = new BsonDocument
                {
                    { "TaskID", txtTaskID.Text.Trim() },
                    { "UserID", userIdObj },
                    { "Title", txtTaskTitle.Text.Trim() },
                    { "Description", txtTaskDescription.Text.Trim() },
                    { "TaskStatus", "Pending" }, // must match schema
                    { "Steps", new BsonArray(stepList) },
                    { "CreatedDate", DateTime.Now },
                    { "DueDate", dtpDueDate.Value }
                };

                _tasks.InsertOne(taskDoc);

                LogAudit(LoginForm.LoggedInUsername, "Insert Task", $"Created task {txtTaskID.Text}");

                MessageBox.Show("Task Inserted.");
                stepList.Clear();
                lvSteps.Items.Clear();
                ClearFields();
            }
            catch (MongoWriteException mwx)
            {
                MessageBox.Show("MongoDB write error: " + mwx.Message);
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
                    { "Username", username ?? "" },
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

        private void InsertForm_Load(object sender, EventArgs e)
        {
            // no-op
        }
    }
}

using System;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Driver;

namespace TaskManagementApp
{
    public partial class UpdateForm : Form
    {
        private IMongoDatabase _db;
        private IMongoCollection<BsonDocument> _tasks;
        private IMongoCollection<BsonDocument> _auditLogs;

        public UpdateForm()
        {
            InitializeComponent();

            try
            {
                _db = MongoConnection.GetDatabase();
                _tasks = _db.GetCollection<BsonDocument>("Tasks");
                _auditLogs = _db.GetCollection<BsonDocument>("AuditLogs");
                LoadTasks();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting to MongoDB: " + ex.Message);
            }
        }

        private void LoadTasks()
        {
            try
            {
                cmbTasks.Items.Clear();
                var allTasks = _tasks.Find(new BsonDocument()).ToList();

                foreach (var task in allTasks)
                {
                    cmbTasks.Items.Add(task.GetValue("TaskID", "").ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading tasks: " + ex.Message);
            }
        }

        private void cmbTasks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTasks.SelectedItem == null) return;

            try
            {
                string taskID = cmbTasks.SelectedItem.ToString();
                var filter = Builders<BsonDocument>.Filter.Eq("TaskID", taskID);
                var task = _tasks.Find(filter).FirstOrDefault();

                if (task != null)
                {
                    if (task.Contains("UserID") && task["UserID"].IsObjectId)
                        txtTaskUserID.Text = task["UserID"].AsObjectId.ToString();
                    else
                        txtTaskUserID.Text = task.GetValue("UserID", "").ToString();

                    txtTaskTitle.Text = task.GetValue("Title", "").AsString;
                    txtTaskDescription.Text = task.GetValue("Description", "").AsString;

                    if (task.Contains("DueDate") && task["DueDate"].IsValidDateTime)
                    {
                        dtpDueDate.Value = task["DueDate"].ToUniversalTime();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading task details: " + ex.Message);
            }
        }

        private void btnUpdateTask_Click(object sender, EventArgs e)
        {
            if (cmbTasks.SelectedItem == null)
            {
                MessageBox.Show("Select a task to update.");
                return;
            }

            try
            {
                string taskID = cmbTasks.SelectedItem.ToString();
                var filter = Builders<BsonDocument>.Filter.Eq("TaskID", taskID);

                ObjectId userIdObj;
                if (!ObjectId.TryParse(txtTaskUserID.Text, out userIdObj))
                {
                    MessageBox.Show("Invalid UserID! Enter a valid ObjectId.");
                    return;
                }

                var update = Builders<BsonDocument>.Update
                    .Set("UserID", userIdObj)
                    .Set("Title", txtTaskTitle.Text)
                    .Set("Description", txtTaskDescription.Text)
                    .Set("DueDate", dtpDueDate.Value);

                _tasks.UpdateOne(filter, update);

                LogAudit(LoginForm.LoggedInUserID, "Update Task", $"Updated task: {taskID}");

                MessageBox.Show("Task updated successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating task: " + ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadTasks();
            MessageBox.Show("Data refreshed.");
        }

        private void header_Paint(object sender, PaintEventArgs e)
        {
            // Empty event handler
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
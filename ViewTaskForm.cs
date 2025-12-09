using System;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Driver;

namespace TaskManagementApp
{
    public partial class ViewTasksForm : Form
    {
        private IMongoDatabase _db;
        private IMongoCollection<BsonDocument> _tasks;
        private IMongoCollection<BsonDocument> _auditLogs;
        private BsonDocument selectedTask;

        public ViewTasksForm()
        {
            InitializeComponent();

            try
            {
                _db = MongoConnection.GetDatabase();
                _tasks = _db.GetCollection<BsonDocument>("Tasks");
                _auditLogs = _db.GetCollection<BsonDocument>("AuditLogs");
                LoadUserTasks();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting to database: " + ex.Message);
            }
        }

        private void LoadUserTasks()
        {
            try
            {
                var userObjectId = LoginForm.LoggedInObjectId.AsObjectId;
                var filter = Builders<BsonDocument>.Filter.Eq("UserID", userObjectId);
                var tasks = _tasks.Find(filter).ToList();

                lstTasks.Items.Clear();
                foreach (var task in tasks)
                {
                    string taskID = task.GetValue("TaskID", "").ToString();
                    string title = task.GetValue("Title", "").ToString();
                    string status = task.GetValue("TaskStatus", "").ToString();
                    lstTasks.Items.Add($"{taskID} - {title} [{status}]");
                }

                lblTaskCount.Text = $"Your Tasks: {tasks.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading tasks: " + ex.Message);
            }
        }

        private void lstTasks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstTasks.SelectedItem != null)
            {
                string selectedItem = lstTasks.SelectedItem.ToString();
                string taskID = selectedItem.Split('-')[0].Trim();
                LoadTaskDetails(taskID);

                LogAudit(LoginForm.LoggedInUserID, "View Task", $"Viewed task: {taskID}");
            }
        }

        private void LoadTaskDetails(string taskID)
        {
            try
            {
                var filter = Builders<BsonDocument>.Filter.Eq("TaskID", taskID);
                selectedTask = _tasks.Find(filter).FirstOrDefault();

                if (selectedTask != null)
                {
                    txtTaskID.Text = selectedTask.GetValue("TaskID", "").ToString();
                    txtTitle.Text = selectedTask.GetValue("Title", "").ToString();
                    txtDescription.Text = selectedTask.GetValue("Description", "").ToString();
                    txtStatus.Text = selectedTask.GetValue("TaskStatus", "").ToString();

                    if (selectedTask.Contains("DueDate") && selectedTask["DueDate"].IsValidDateTime)
                    {
                        txtDueDate.Text = selectedTask["DueDate"].ToUniversalTime().ToString("yyyy-MM-dd");
                    }
                    else
                    {
                        txtDueDate.Text = "N/A";
                    }

                    LoadSteps(selectedTask);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading task details: " + ex.Message);
            }
        }

        private void LoadSteps(BsonDocument task)
        {
            lstSteps.Items.Clear();

            if (task.Contains("Steps") && task["Steps"].IsBsonArray)
            {
                var steps = task["Steps"].AsBsonArray;
                foreach (var step in steps)
                {
                    var stepDoc = step.AsBsonDocument;
                    string stepID = stepDoc.GetValue("StepID", "").ToString();
                    string desc = stepDoc.GetValue("StepDescription", "").ToString();
                    string status = stepDoc.GetValue("StepStatus", "").ToString();

                    string signOffStatus = "Not Signed";
                    if (stepDoc.Contains("SignedOff") && stepDoc["SignedOff"].IsBsonDocument)
                    {
                        var signOff = stepDoc["SignedOff"].AsBsonDocument;
                        signOffStatus = signOff.GetValue("Status", "Not Signed").ToString();
                    }

                    lstSteps.Items.Add($"{stepID} - {desc} [{status}] - {signOffStatus}");
                }
            }
            else
            {
                lstSteps.Items.Add("No steps available");
            }
        }

        private void btnCompleteStep_Click(object sender, EventArgs e)
        {
            if (selectedTask == null)
            {
                MessageBox.Show("Please select a task first.");
                return;
            }

            if (lstSteps.SelectedItem == null)
            {
                MessageBox.Show("Please select a step to complete.");
                return;
            }

            string selectedStepText = lstSteps.SelectedItem.ToString();
            if (selectedStepText.Contains("No steps available")) return;

            string stepID = selectedStepText.Split('-')[0].Trim();

            try
            {
                if (selectedTask.Contains("Steps") && selectedTask["Steps"].IsBsonArray)
                {
                    var steps = selectedTask["Steps"].AsBsonArray;
                    bool stepFound = false;

                    for (int i = 0; i < steps.Count; i++)
                    {
                        var step = steps[i].AsBsonDocument;
                        if (step.GetValue("StepID", "").ToString() == stepID)
                        {
                            if (step.GetValue("StepStatus", "").ToString() == "Completed")
                            {
                                MessageBox.Show("This step is already completed.");
                                return;
                            }

                            // Update step to Completed
                            step["StepStatus"] = "Completed";
                            step["SignedOff"] = new BsonDocument
                            {
                                { "UserID", LoginForm.LoggedInUserID },
                                { "Status", "Approved" },
                                { "Date", DateTime.Now }
                            };
                            stepFound = true;

                            // Change task status to "In Progress" when first step is completed
                            if (selectedTask.GetValue("TaskStatus", "").ToString() == "Not Started")
                            {
                                selectedTask["TaskStatus"] = "In Progress";
                            }
                        }
                    }

                    if (stepFound)
                    {
                        var filter = Builders<BsonDocument>.Filter.Eq("TaskID", selectedTask.GetValue("TaskID", "").ToString());
                        _tasks.ReplaceOne(filter, selectedTask);

                        LogAudit(LoginForm.LoggedInUserID, "Complete Step", $"Completed step {stepID} in task {txtTaskID.Text}");

                        MessageBox.Show("Step completed successfully!");
                        LoadTaskDetails(selectedTask.GetValue("TaskID", "").ToString());
                        LoadUserTasks();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error completing step: " + ex.Message);
            }
        }

        private void btnSubmitTask_Click(object sender, EventArgs e)
        {
            if (selectedTask == null)
            {
                MessageBox.Show("Please select a task first.");
                return;
            }

            try
            {
                bool allCompleted = true;
                if (selectedTask.Contains("Steps") && selectedTask["Steps"].IsBsonArray)
                {
                    var steps = selectedTask["Steps"].AsBsonArray;
                    foreach (var step in steps)
                    {
                        if (step.AsBsonDocument.GetValue("StepStatus", "").ToString() != "Completed")
                        {
                            allCompleted = false;
                            break;
                        }
                    }
                }

                if (!allCompleted)
                {
                    MessageBox.Show("All steps must be completed before submitting the task.");
                    return;
                }

                // Set task status to "Finished"
                selectedTask["TaskStatus"] = "Finished";
                var filter = Builders<BsonDocument>.Filter.Eq("TaskID", selectedTask.GetValue("TaskID", "").ToString());
                _tasks.ReplaceOne(filter, selectedTask);

                LogAudit(LoginForm.LoggedInUserID, "Submit Task", $"Submitted task: {txtTaskID.Text}");

                MessageBox.Show("Task submitted successfully!");
                LoadUserTasks();
                ClearDetails();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error submitting task: " + ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadUserTasks();
            MessageBox.Show("Tasks refreshed!");
        }

        private void ClearDetails()
        {
            txtTaskID.Clear();
            txtTitle.Clear();
            txtDescription.Clear();
            txtStatus.Clear();
            txtDueDate.Clear();
            lstSteps.Items.Clear();
            selectedTask = null;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ViewTasksForm_Load(object sender, EventArgs e)
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
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

                LogAudit(LoginForm.LoggedInUsername, "View Task", $"Viewed task: {taskID}");
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

                    string stepID = stepDoc.Contains("StepID") ? stepDoc.GetValue("StepID", "").ToString() : "";
                    string desc = stepDoc.GetValue("StepDescription", "").ToString();

                    // 🔥 FIX: Correct status handling (StepStatus → Status fallback)
                    string status = "";
                    if (stepDoc.Contains("StepStatus") && !string.IsNullOrWhiteSpace(stepDoc["StepStatus"].ToString()))
                        status = stepDoc["StepStatus"].ToString();
                    else if (stepDoc.Contains("Status"))
                        status = stepDoc["Status"].ToString();
                    else
                        status = "Pending";

                    // SignedOff status
                    string signOffStatus = "Not-Signed";
                    if (stepDoc.Contains("SignedOff") && stepDoc["SignedOff"].IsBsonDocument)
                    {
                        var signOff = stepDoc["SignedOff"].AsBsonDocument;
                        signOffStatus = signOff.GetValue("Status", "Not-Signed").ToString();
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
                var steps = selectedTask["Steps"].AsBsonArray;

                // ---------------------------
                // FIND CURRENT STEP INDEX
                // ---------------------------
                int currentIndex = -1;
                for (int i = 0; i < steps.Count; i++)
                {
                    var step = steps[i].AsBsonDocument;
                    if (step["StepID"].AsString == stepID)
                    {
                        currentIndex = i;
                        break;
                    }
                }

                if (currentIndex == -1)
                {
                    MessageBox.Show("Step not found.");
                    return;
                }

                // ---------------------------
                // 🔥 SEQUENTIAL LOCK RULE
                // DO NOT ALLOW COMPLETION OF STEP N IF N-1 IS NOT SIGNED
                // ---------------------------
                if (currentIndex > 0)
                {
                    var previousStep = steps[currentIndex - 1].AsBsonDocument;

                    string prevSigned = "Not-Signed";
                    if (previousStep.Contains("SignedOff"))
                    {
                        prevSigned = previousStep["SignedOff"]
                            .AsBsonDocument
                            .GetValue("Status", "Not-Signed")
                            .AsString;
                    }

                    if (prevSigned != "Signed")
                    {
                        MessageBox.Show(
                            $"You cannot complete step {currentIndex + 1} before signing step {currentIndex}.",
                            "Step Locked",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );
                        return;
                    }
                }

                // ---------------------------
                // UPDATE CURRENT STEP → COMPLETED + SIGNED
                // ---------------------------
                var currentStep = steps[currentIndex].AsBsonDocument;

                if (currentStep["StepStatus"] == "Completed")
                {
                    MessageBox.Show("This step is already completed.");
                    return;
                }

                currentStep["StepStatus"] = "Completed";
                currentStep["SignedOff"] = new BsonDocument
        {
            { "Status", "Signed" },
            { "Date", DateTime.Now }
        };

                // Replace in array
                steps[currentIndex] = currentStep;

                // ---------------------------
                // UPDATE TASK STATUS
                // ---------------------------
                if (selectedTask["TaskStatus"].AsString == "Pending")
                    selectedTask["TaskStatus"] = "In Progress";

                // ---------------------------
                // SAVE TO DATABASE
                // ---------------------------
                var filter = Builders<BsonDocument>.Filter
                    .Eq("TaskID", selectedTask["TaskID"].AsString);

                _tasks.ReplaceOne(filter, selectedTask);

                LogAudit(LoginForm.LoggedInUsername, "Complete Step",
                    $"Completed step {stepID} in task {txtTaskID.Text}");

                MessageBox.Show("Step completed successfully!");
                LoadTaskDetails(selectedTask["TaskID"].AsString);
                LoadUserTasks();
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

                // Set task status to "Completed"
                selectedTask["TaskStatus"] = "Completed";
                var filter = Builders<BsonDocument>.Filter.Eq("TaskID", selectedTask.GetValue("TaskID", "").ToString());
                _tasks.ReplaceOne(filter, selectedTask);

                LogAudit(LoginForm.LoggedInUsername, "Submit Task", $"Submitted task: {txtTaskID.Text}");

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

        // Designer had referenced txtDescription_TextChanged — provide an empty handler so Designer stops complaining
        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
            // no-op (designer reference)
        }

        private void ViewTasksForm_Load(object sender, EventArgs e)
        {
            // no-op
        }

        private void LogAudit(string userID, string action, string details)
        {
            try
            {
                var log = new BsonDocument
                {
                    { "LogID", Guid.NewGuid().ToString() },
                    { "Username", userID },
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

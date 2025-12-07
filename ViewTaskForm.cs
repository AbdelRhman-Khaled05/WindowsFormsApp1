using System;
using System.Windows.Forms;
using MongoDB.Driver;
using TaskManagementApp.Models;
using System.Linq;

namespace TaskManagementApp
{
    public partial class ViewTasksForm : Form
    {
        private IMongoCollection<TaskItem> tasksCollection;
        private IMongoCollection<AuditLog> auditCollection;
        private TaskItem selectedTask;

        public ViewTasksForm()
        {
            InitializeComponent();
            var db = MongoConnection.GetDatabase();
            tasksCollection = db.GetCollection<TaskItem>("Tasks");
            auditCollection = db.GetCollection<AuditLog>("AuditLogs");
            LoadUserTasks();
        }

        private void LoadUserTasks()
        {
            try
            {
                var filter = Builders<TaskItem>.Filter.Eq(t => t.UserID, LoginForm.LoggedInUserID);
                var tasks = tasksCollection.Find(filter).ToList();

                lstTasks.Items.Clear();
                foreach (var task in tasks)
                {
                    lstTasks.Items.Add($"{task.TaskID} - {task.Title} [{task.Task_Status}]");
                }

                lblTaskCount.Text = $"Your Tasks: {tasks.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading tasks: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lstTasks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstTasks.SelectedItem != null)
            {
                string selectedItem = lstTasks.SelectedItem.ToString();
                string taskID = selectedItem.Split('-')[0].Trim();
                LoadTaskDetails(taskID);

                // Log audit
                LogAudit(LoginForm.LoggedInUserID, taskID, null, "View Task");
            }
        }

        private void LoadTaskDetails(string taskID)
        {
            try
            {
                var filter = Builders<TaskItem>.Filter.Eq(t => t.TaskID, taskID);
                selectedTask = tasksCollection.Find(filter).FirstOrDefault();

                if (selectedTask != null)
                {
                    txtTaskID.Text = selectedTask.TaskID;
                    txtTitle.Text = selectedTask.Title;
                    txtDescription.Text = selectedTask.Description;
                    txtStatus.Text = selectedTask.Task_Status;
                    txtDueDate.Text = selectedTask.DueDate?.ToShortDateString() ?? "N/A";

                    LoadSteps(selectedTask);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading task details: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadSteps(TaskItem task)
        {
            lstSteps.Items.Clear();

            if (task.Steps != null && task.Steps.Count > 0)
            {
                foreach (var step in task.Steps)
                {
                    string signOffInfo = step.SignedOff?.Status ?? "Not Signed";
                    lstSteps.Items.Add($"{step.StepID} - {step.StepDescription} [{step.StepStatus}] - {signOffInfo}");
                }
            }
            else
            {
                lstSteps.Items.Add("No steps available for this task");
            }
        }

        private void btnCompleteStep_Click(object sender, EventArgs e)
        {
            if (selectedTask == null)
            {
                MessageBox.Show("Please select a task first.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (lstSteps.SelectedItem == null)
            {
                MessageBox.Show("Please select a step to complete.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selectedStepText = lstSteps.SelectedItem.ToString();
            if (selectedStepText.Contains("No steps available")) return;

            string stepID = selectedStepText.Split('-')[0].Trim();

            try
            {
                var step = selectedTask.Steps.FirstOrDefault(s => s.StepID == stepID);
                if (step != null)
                {
                    if (step.StepStatus == "Completed")
                    {
                        MessageBox.Show("This step is already completed.", "Info",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    // Update step status and sign off
                    step.StepStatus = "Completed";
                    step.SignedOff = new SignedOff
                    {
                        UserID = LoginForm.LoggedInUserID,
                        Status = "Approved",
                        Date = DateTime.Now
                    };

                    // Check if all steps are completed
                    bool allStepsCompleted = selectedTask.Steps.All(s => s.StepStatus == "Completed");
                    if (allStepsCompleted)
                    {
                        selectedTask.Task_Status = "Completed";
                    }
                    else if (selectedTask.Task_Status == "Pending")
                    {
                        selectedTask.Task_Status = "In Progress";
                    }

                    // Update in database
                    var filter = Builders<TaskItem>.Filter.Eq(t => t.TaskID, selectedTask.TaskID);
                    tasksCollection.ReplaceOne(filter, selectedTask);

                    // Log audit
                    LogAudit(LoginForm.LoggedInUserID, selectedTask.TaskID, stepID, "Complete Step");

                    MessageBox.Show("Step completed successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadTaskDetails(selectedTask.TaskID);
                    LoadUserTasks();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error completing step: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSubmitTask_Click(object sender, EventArgs e)
        {
            if (selectedTask == null)
            {
                MessageBox.Show("Please select a task first.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool allStepsCompleted = selectedTask.Steps.All(s => s.StepStatus == "Completed");
            if (!allStepsCompleted)
            {
                MessageBox.Show("All steps must be completed before submitting the task.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                selectedTask.Task_Status = "Completed";
                var filter = Builders<TaskItem>.Filter.Eq(t => t.TaskID, selectedTask.TaskID);
                tasksCollection.ReplaceOne(filter, selectedTask);

                // Log audit
                LogAudit(LoginForm.LoggedInUserID, selectedTask.TaskID, null, "Submit Task");

                MessageBox.Show("Task submitted successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadUserTasks();
                ClearDetails();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error submitting task: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadUserTasks();
            MessageBox.Show("Tasks refreshed!", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void LogAudit(string userID, string taskID, string stepID, string action)
        {
            try
            {
                var log = new AuditLog
                {
                    LogID = Guid.NewGuid().ToString(),
                    UserID = userID,
                    TaskID = taskID,
                    StepID = stepID,
                    Action = action,
                    Timestamp = DateTime.Now
                };

                auditCollection.InsertOne(log);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Audit log error: " + ex.Message);
            }
        }
    }
}
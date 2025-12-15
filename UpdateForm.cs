using System;
using System.Linq;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Driver;

namespace TaskManagementApp
{
    public partial class UpdateForm : Form
    {
        private IMongoDatabase _db;
        private IMongoCollection<BsonDocument> _users;
        private IMongoCollection<BsonDocument> _tasks;
        private IMongoCollection<BsonDocument> _auditLogs;

        public UpdateForm()
        {
            InitializeComponent();

            try
            {
                _db = MongoConnection.GetDatabase();
                _users = _db.GetCollection<BsonDocument>("Users");
                _tasks = _db.GetCollection<BsonDocument>("Tasks");
                _auditLogs = _db.GetCollection<BsonDocument>("AuditLogs");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mongo connection failed: " + ex.Message);
            }
        }

        private void UpdateForm_Load(object sender, EventArgs e)
        {
            LoadUsers();
            LoadTasks();

            // Initialize dropdowns
            if (cmbStepStatus.Items.Count > 0)
                cmbStepStatus.SelectedIndex = 0;
        }

        // ============================= USER MANAGEMENT =============================

        private void LoadUsers()
        {
            try
            {
                cmbUsers.Items.Clear();
                var allUsers = _users.Find(new BsonDocument()).ToList();

                foreach (var user in allUsers)
                    cmbUsers.Items.Add(user["_id"].ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("LoadUsers error: " + ex.Message);
            }
        }

        private void cmbUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbUsers.SelectedItem == null) return;

            try
            {
                var id = ObjectId.Parse(cmbUsers.SelectedItem.ToString());
                var user = _users.Find(Builders<BsonDocument>.Filter.Eq("_id", id)).FirstOrDefault();

                if (user != null)
                {
                    txtUsername.Text = user.GetValue("Username", "").ToString();
                    txtPassword.Text = user.GetValue("Password", "").ToString();
                    txtRole.Text = user.GetValue("Role", "").ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("User load error: " + ex.Message);
            }
        }

        private void btnUpdateUser_Click(object sender, EventArgs e)
        {
            if (cmbUsers.SelectedItem == null)
            {
                MessageBox.Show("Pick a user first.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text) ||
                string.IsNullOrWhiteSpace(txtRole.Text))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            try
            {
                var id = ObjectId.Parse(cmbUsers.SelectedItem.ToString());

                var update = Builders<BsonDocument>.Update
                    .Set("Username", txtUsername.Text)
                    .Set("Password", txtPassword.Text)
                    .Set("Role", txtRole.Text);

                _users.UpdateOne(Builders<BsonDocument>.Filter.Eq("_id", id), update);

                LogAudit(LoginForm.LoggedInUsername, "Update User", $"Updated user: {txtUsername.Text}");
                MessageBox.Show("User updated!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update user error: " + ex.Message);
            }
        }

        // ============================= TASK MANAGEMENT =============================

        private void LoadTasks()
        {
            try
            {
                cmbTasks.Items.Clear();
                var tasks = _tasks.Find(new BsonDocument()).ToList();

                foreach (var task in tasks)
                {
                    var tid = task.Contains("TaskID") ? task["TaskID"].ToString() : task["_id"].ToString();
                    cmbTasks.Items.Add(tid);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("LoadTasks error: " + ex.Message);
            }
        }

        private void cmbTasks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTasks.SelectedItem == null) return;

            try
            {
                string taskId = cmbTasks.SelectedItem.ToString();

                BsonDocument task =
                    _tasks.Find(Builders<BsonDocument>.Filter.Eq("TaskID", taskId)).FirstOrDefault()
                    ?? (ObjectId.TryParse(taskId, out ObjectId oid)
                        ? _tasks.Find(Builders<BsonDocument>.Filter.Eq("_id", oid)).FirstOrDefault()
                        : null);

                if (task == null)
                {
                    dgvSteps.Rows.Clear();
                    ClearStepEditor();
                    return;
                }

                txtTaskUserID.Text = task.GetValue("UserID", "").ToString();
                txtTaskTitle.Text = task.GetValue("Title", "").ToString();
                txtTaskDescription.Text = task.GetValue("Description", "").ToString();

                if (task.Contains("DueDate") && task["DueDate"].IsValidDateTime)
                    dtpDueDate.Value = task["DueDate"].ToUniversalTime();
                else
                    dtpDueDate.Value = DateTime.Now;

                LoadStepsForTask(task);
                ClearStepEditor();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Task load error: " + ex.Message);
            }
        }

        private void LoadStepsForTask(BsonDocument task)
        {
            dgvSteps.Rows.Clear();

            if (!task.Contains("Steps") || !task["Steps"].IsBsonArray)
                return;

            foreach (var s in task["Steps"].AsBsonArray)
            {
                var step = s.AsBsonDocument;

                // Handle both field name variations
                string id = step.GetValue("StepID", "").ToString();
                string desc = step.GetValue("StepDescription", "").ToString();
                string status = step.GetValue("StepStatus", "Pending").ToString();

                dgvSteps.Rows.Add(id, desc, status);
            }
        }

        private void btnUpdateTask_Click(object sender, EventArgs e)
        {
            if (cmbTasks.SelectedItem == null)
            {
                MessageBox.Show("Pick a task.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTaskUserID.Text) ||
                string.IsNullOrWhiteSpace(txtTaskTitle.Text))
            {
                MessageBox.Show("Please fill in required fields.");
                return;
            }

            try
            {
                string tid = cmbTasks.SelectedItem.ToString();

                if (!ObjectId.TryParse(txtTaskUserID.Text, out ObjectId userId))
                {
                    MessageBox.Show("Invalid UserID.");
                    return;
                }

                var update = Builders<BsonDocument>.Update
                    .Set("UserID", userId)
                    .Set("Title", txtTaskTitle.Text)
                    .Set("Description", txtTaskDescription.Text)
                    .Set("DueDate", dtpDueDate.Value);

                _tasks.UpdateOne(
                    Builders<BsonDocument>.Filter.Eq("TaskID", tid),
                    update
                );

                MessageBox.Show("Task updated!");
                LogAudit(LoginForm.LoggedInUsername, "Update Task", $"Updated task: {tid}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update task error: " + ex.Message);
            }
        }

        // ============================= STEP EDITOR =============================

        private void dgvSteps_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvSteps.Rows[e.RowIndex];

            txtStepID.Text = row.Cells["StepID"].Value?.ToString() ?? "";
            txtStepDescription.Text = row.Cells["Description"].Value?.ToString() ?? "";

            string status = row.Cells["Status"].Value?.ToString() ?? "Pending";
            if (cmbStepStatus.Items.Contains(status))
                cmbStepStatus.SelectedItem = status;
            else
                cmbStepStatus.SelectedIndex = 0;
        }

        private void dgvSteps_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            // Admin can freely edit
        }

        private void btnUpdateStep_Click(object sender, EventArgs e)
        {
            if (cmbTasks.SelectedItem == null)
            {
                MessageBox.Show("Select a task first.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtStepID.Text))
            {
                MessageBox.Show("StepID cannot be empty.");
                return;
            }

            try
            {
                string taskID = cmbTasks.SelectedItem.ToString();
                string stepID = txtStepID.Text.Trim();

                var task = _tasks.Find(Builders<BsonDocument>.Filter.Eq("TaskID", taskID)).FirstOrDefault();
                if (task == null)
                {
                    MessageBox.Show("Task not found.");
                    return;
                }

                var steps = task["Steps"].AsBsonArray;

                int index = steps
                    .Select((s, i) => new { s, i })
                    .FirstOrDefault(x => x.s.AsBsonDocument["StepID"].ToString() == stepID)?.i ?? -1;

                if (index < 0)
                {
                    MessageBox.Show("Step not found.");
                    return;
                }

                // Update step with correct schema
                var updatedStep = new BsonDocument
                {
                    { "StepID", stepID },
                    { "StepDescription", txtStepDescription.Text },
                    { "StepStatus", cmbStepStatus.SelectedItem?.ToString() ?? "Pending" },
                    { "SignedOff", new BsonDocument
                        {
                            { "Status", "Not-Signed" },
                            { "Date", DateTime.UtcNow }
                        }
                    }
                };

                steps[index] = updatedStep;

                // Update TaskStatus based on step completion
                bool allCompleted = true;
                bool anyCompleted = false;

                foreach (var s in steps)
                {
                    var sd = s.AsBsonDocument;
                    string st = sd.GetValue("StepStatus", "Pending").ToString();

                    if (st != "Completed")
                        allCompleted = false;

                    if (st == "Completed")
                        anyCompleted = true;
                }

                if (allCompleted)
                    task["TaskStatus"] = "Completed";
                else if (anyCompleted)
                    task["TaskStatus"] = "In-Progress";
                else
                    task["TaskStatus"] = "Pending";

                // Save the task
                _tasks.ReplaceOne(
                    Builders<BsonDocument>.Filter.Eq("TaskID", taskID),
                    task
                );

                MessageBox.Show("Step updated successfully!");

                LogAudit(LoginForm.LoggedInUsername, "Update Step",
                    $"Updated Step {stepID} in Task {taskID}");

                LoadStepsForTask(task);
                ClearStepEditor();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating step: " + ex.Message);
            }
        }

        private void ClearStepEditor()
        {
            txtStepID.Text = "";
            txtStepDescription.Text = "";
            if (cmbStepStatus.Items.Count > 0)
                cmbStepStatus.SelectedIndex = 0;
        }

        // ============================= LOGGING =============================

        private void LogAudit(string username, string action, string details)
        {
            try
            {
                _auditLogs.InsertOne(new BsonDocument
                {
                    { "LogID", Guid.NewGuid().ToString() },
                    { "Username", username },
                    { "Action", action },
                    { "Details", details },
                    { "Timestamp", DateTime.UtcNow }
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine("Audit log error: " + ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadUsers();
            LoadTasks();
            MessageBox.Show("Refreshed.");
        }
    }
}
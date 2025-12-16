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

        // Helper class for ComboBox binding
        private class ComboItem
        {
            public string Text { get; set; }
            public string Value { get; set; }
            public override string ToString() => Text;
        }

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
                MessageBox.Show($"Mongo connection failed:\n{ex.Message}",
                    "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateForm_Load(object sender, EventArgs e)
        {
            try
            {
                LoadUsers();
                LoadTasks();

                // Initialize dropdowns
                if (cmbStepStatus.Items.Count > 0)
                    cmbStepStatus.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Load error:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================= USER MANAGEMENT =============================

        private void LoadUsers()
        {
            try
            {
                cmbUsers.Items.Clear();

                var allUsers = _users.Find(new BsonDocument()).ToList();

                if (allUsers.Count == 0)
                {
                    MessageBox.Show("No users found in database.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                foreach (var user in allUsers)
                {
                    string username = user.GetValue("Username", "Unknown").ToString();
                    string userId = user["_id"].ToString();

                    cmbUsers.Items.Add(new ComboItem
                    {
                        Text = $"{username} ({userId.Substring(0, Math.Min(8, userId.Length))}...)",
                        Value = userId
                    });
                }

                if (cmbUsers.Items.Count > 0)
                    cmbUsers.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"LoadUsers error:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbUsers.SelectedItem == null) return;

            try
            {
                var selectedItem = cmbUsers.SelectedItem as ComboItem;
                if (selectedItem == null) return;

                string userId = selectedItem.Value;
                var id = ObjectId.Parse(userId);
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
                MessageBox.Show($"User load error:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            // Validate role is Admin or User only
            if (txtRole.Text != "Admin" && txtRole.Text != "User")
            {
                MessageBox.Show("Role must be 'Admin' or 'User'.");
                return;
            }

            try
            {
                var selectedItem = cmbUsers.SelectedItem as ComboItem;
                if (selectedItem == null) return;

                string userId = selectedItem.Value;
                var id = ObjectId.Parse(userId);

                var update = Builders<BsonDocument>.Update
                    .Set("Username", txtUsername.Text)
                    .Set("Password", txtPassword.Text)
                    .Set("Role", txtRole.Text);

                _users.UpdateOne(Builders<BsonDocument>.Filter.Eq("_id", id), update);

                LogAudit(LoginForm.LoggedInUsername, "Update User", $"Updated user: {txtUsername.Text}");
                MessageBox.Show("User updated successfully!");
                LoadUsers(); // Refresh list
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Update user error:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================= TASK MANAGEMENT =============================

        private void LoadTasks()
        {
            try
            {
                cmbTasks.Items.Clear();

                var tasks = _tasks.Find(new BsonDocument()).ToList();

                if (tasks.Count == 0)
                {
                    MessageBox.Show("No tasks found in database.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                foreach (var task in tasks)
                {
                    string tid = task.Contains("TaskID") ? task["TaskID"].ToString() : task["_id"].ToString();
                    string title = task.GetValue("Title", "Untitled").ToString();

                    cmbTasks.Items.Add(new ComboItem
                    {
                        Text = $"{tid} - {title}",
                        Value = tid
                    });
                }

                if (cmbTasks.Items.Count > 0)
                    cmbTasks.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"LoadTasks error:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbTasks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTasks.SelectedItem == null) return;

            try
            {
                var selectedItem = cmbTasks.SelectedItem as ComboItem;
                if (selectedItem == null) return;

                string taskId = selectedItem.Value;

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
                MessageBox.Show($"Task load error:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            // Validate title length
            if (txtTaskTitle.Text.Length < 5)
            {
                MessageBox.Show("Title must be at least 5 characters.");
                return;
            }

            try
            {
                var selectedItem = cmbTasks.SelectedItem as ComboItem;
                if (selectedItem == null) return;

                string tid = selectedItem.Value;

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

                MessageBox.Show("Task updated successfully!");
                LogAudit(LoginForm.LoggedInUsername, "Update Task", $"Updated task: {tid}");
                LoadTasks(); // Refresh list
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Update task error:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            else if (cmbStepStatus.Items.Count > 0)
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

            if (cmbStepStatus.SelectedItem == null)
            {
                MessageBox.Show("Please select a step status.");
                return;
            }

            try
            {
                var selectedItem = cmbTasks.SelectedItem as ComboItem;
                if (selectedItem == null) return;

                string taskID = selectedItem.Value;
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
                    { "StepStatus", cmbStepStatus.SelectedItem.ToString() },
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
                MessageBox.Show($"Error updating step:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    { "Username", username ?? "Unknown" },
                    { "Action", action },
                    { "Details", details },
                    { "Timestamp", DateTime.UtcNow }
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Audit log error: {ex.Message}");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadUsers();
            LoadTasks();
            MessageBox.Show("Data refreshed successfully!");
        }
    }
}
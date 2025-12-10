using System;
using System.Collections.Generic;
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

            try
            {
                var id = ObjectId.Parse(cmbUsers.SelectedItem.ToString());

                var update = Builders<BsonDocument>.Update
                    .Set("Username", txtUsername.Text)
                    .Set("Password", txtPassword.Text)
                    .Set("Role", txtRole.Text);

                _users.UpdateOne(Builders<BsonDocument>.Filter.Eq("_id", id), update);

                LogAudit(LoginForm.LoggedInUserID, "UpdateUser", $"Updated user {id}");
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

                string id = step.GetValue("StepID", step.GetValue("Id", "")).ToString();
                string desc = step.GetValue("StepDescription", step.GetValue("Description", "")).ToString();
                string status = step.GetValue("StepStatus", step.GetValue("Status", "")).ToString();

                string signed = "Not-Signed";
                if (step.Contains("SignedOff"))
                {
                    signed = step["SignedOff"]
                        .AsBsonDocument
                        .GetValue("Status", new BsonString("Not-Signed"))
                        .ToString();
                }

                dgvSteps.Rows.Add(id, desc, status, signed);
            }
        }

        private void btnUpdateTask_Click(object sender, EventArgs e)
        {
            if (cmbTasks.SelectedItem == null)
            {
                MessageBox.Show("Pick a task.");
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
                LogAudit(LoginForm.LoggedInUserID, "UpdateTask", $"Updated task {tid}");
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

            cmbStepStatus.SelectedItem = row.Cells["Status"].Value?.ToString();
            cmbSignedOff.SelectedItem = row.Cells["SignedOffStatus"].Value?.ToString();
        }

        private void dgvSteps_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            // Admin can freely edit (no sequential lock)
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

                // Load full task
                var task = _tasks.Find(Builders<BsonDocument>.Filter.Eq("TaskID", taskID)).FirstOrDefault();
                if (task == null)
                {
                    MessageBox.Show("Task not found.");
                    return;
                }

                var steps = task["Steps"].AsBsonArray;

                // Find step index
                int index = steps
                    .Select((s, i) => new { s, i })
                    .FirstOrDefault(x => x.s.AsBsonDocument["StepID"].ToString() == stepID)?.i ?? -1;

                if (index < 0)
                {
                    MessageBox.Show("Step not found.");
                    return;
                }

                // Build updated step
                var updatedStep = new BsonDocument
                {
                    { "StepID", stepID },
                    { "StepDescription", txtStepDescription.Text },
                    { "Description", txtStepDescription.Text },
                    { "StepStatus", cmbStepStatus.SelectedItem?.ToString() ?? "Pending" },
                    { "Status", cmbStepStatus.SelectedItem?.ToString() ?? "Pending" },
                    { "SignedOff", new BsonDocument
                        {
                            { "Status", cmbSignedOff.SelectedItem?.ToString() ?? "Not-Signed" },
                            { "Date", DateTime.UtcNow }
                        }
                    }
                };

                // Replace in array
                steps[index] = updatedStep;

                // Save full task back
                _tasks.ReplaceOne(
                    Builders<BsonDocument>.Filter.Eq("TaskID", taskID),
                    task
                );

                MessageBox.Show("Step updated successfully!");

                LogAudit(LoginForm.LoggedInUserID, "Admin Update Step",
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
            cmbStepStatus.SelectedIndex = -1;
            cmbSignedOff.SelectedIndex = -1;
        }

        // ============================= LOGGING =============================

        private void LogAudit(string uid, string action, string details)
        {
            try
            {
                _auditLogs.InsertOne(new BsonDocument
                {
                    { "LogID", Guid.NewGuid().ToString() },
                    { "UserID", uid },
                    { "Action", action },
                    { "Details", details },
                    { "Timestamp", DateTime.Now }
                });
            }
            catch { }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadUsers();
            LoadTasks();
            MessageBox.Show("Refreshed.");
        }
    }
}

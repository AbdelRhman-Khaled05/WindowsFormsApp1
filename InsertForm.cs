//using System;
//using System.Collections.Generic;
//using System.Windows.Forms;
//using MongoDB.Bson;
//using MongoDB.Driver;

//namespace TaskManagementApp
//{
//    public partial class InsertForm : Form
//    {
//        private IMongoDatabase _db;
//        private IMongoCollection<BsonDocument> _tasks;
//        private IMongoCollection<BsonDocument> _auditLogs;

//        private List<BsonDocument> stepList = new List<BsonDocument>();

//        public InsertForm()
//        {
//            InitializeComponent();

//            try
//            {
//                _db = MongoConnection.GetDatabase();
//                _tasks = _db.GetCollection<BsonDocument>("Tasks");
//                _auditLogs = _db.GetCollection<BsonDocument>("AuditLogs");
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show("Error connecting to MongoDB: " + ex.Message);
//            }
//        }

//        private void btnAddStep_Click(object sender, EventArgs e)
//        {
//            using (var form = new AddStepForm())
//            {
//                if (form.ShowDialog(this) == DialogResult.OK)
//                {
//                    var stepDoc = new BsonDocument
//                    {
//                        { "StepID", form.StepID },
//                        { "StepDescription", form.StepDescription },
//                        { "StepStatus", "Pending" } // matches schema
//                    };

//                    stepList.Add(stepDoc);

//                    // Add to ListView (two columns: StepID, Description)
//                    var item = new ListViewItem(form.StepID);
//                    item.SubItems.Add(form.StepDescription);
//                    lvSteps.Items.Add(item);
//                }
//            }
//        }

//        private void btnInsertTask_Click(object sender, EventArgs e)
//        {
//            if (string.IsNullOrWhiteSpace(txtTaskID.Text) ||
//                string.IsNullOrWhiteSpace(txtTaskUserID.Text) ||
//                string.IsNullOrWhiteSpace(txtTaskTitle.Text))
//            {
//                MessageBox.Show("TaskID, UserID, and Title are required.");
//                return;
//            }

//            if (!ObjectId.TryParse(txtTaskUserID.Text, out ObjectId userIdObj))
//            {
//                MessageBox.Show("Invalid UserID.");
//                return;
//            }

//            try
//            {
//                var taskDoc = new BsonDocument
//                {
//                    { "TaskID", txtTaskID.Text.Trim() },
//                    { "UserID", userIdObj },
//                    { "Title", txtTaskTitle.Text.Trim() },
//                    { "Description", txtTaskDescription.Text.Trim() },
//                    { "TaskStatus", "Pending" }, // must match schema
//                    { "Steps", new BsonArray(stepList) },
//                    { "CreatedDate", DateTime.Now },
//                    { "DueDate", dtpDueDate.Value }
//                };

//                _tasks.InsertOne(taskDoc);

//                LogAudit(LoginForm.LoggedInUsername, "Insert Task", $"Created task {txtTaskID.Text}");

//                MessageBox.Show("Task Inserted.");
//                stepList.Clear();
//                lvSteps.Items.Clear();
//                ClearFields();
//            }
//            catch (MongoWriteException mwx)
//            {
//                MessageBox.Show("MongoDB write error: " + mwx.Message);
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show("Error inserting task: " + ex.Message);
//            }
//        }

//        private void ClearFields()
//        {
//            txtTaskID.Clear();
//            txtTaskUserID.Clear();
//            txtTaskTitle.Clear();
//            txtTaskDescription.Clear();
//            dtpDueDate.Value = DateTime.Now;
//        }

//        private void LogAudit(string username, string action, string details)
//        {
//            try
//            {
//                var log = new BsonDocument
//                {
//                    { "LogID", Guid.NewGuid().ToString() },
//                    { "Username", username ?? "" },
//                    { "Action", action },
//                    { "Details", details },
//                    { "Timestamp", DateTime.Now }
//                };

//                _auditLogs.InsertOne(log);
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine("Audit log error: " + ex.Message);
//            }
//        }

//        private void InsertForm_Load(object sender, EventArgs e)
//        {
//            // no-op
//        }

//        private void header_Paint(object sender, PaintEventArgs e)
//        {

//        }
//    }
//}

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
        private IMongoCollection<BsonDocument> _users;

        private List<BsonDocument> stepList = new List<BsonDocument>();

        // helper class for ComboBox items
        private class ComboItem
        {
            public string Text { get; set; }
            public ObjectId Value { get; set; }
            public override string ToString() => Text;
        }

        public InsertForm()
        {
            InitializeComponent();

            try
            {
                _db = MongoConnection.GetDatabase();
                _tasks = _db.GetCollection<BsonDocument>("Tasks");
                _auditLogs = _db.GetCollection<BsonDocument>("AuditLogs");
                _users = _db.GetCollection<BsonDocument>("Users");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting to MongoDB: " + ex.Message);
            }
        }

        private void InsertForm_Load(object sender, EventArgs e)
        {
            // populate user dropdown
            LoadUsersIntoDropdown();
        }

        private void LoadUsersIntoDropdown()
        {
            try
            {
                cmbAssignUser.Items.Clear();
                var users = _users.Find(new BsonDocument()).ToList();

                foreach (var u in users)
                {
                    var id = u.GetValue("_id", BsonNull.Value);
                    var username = u.GetValue("Username", new BsonString("unknown")).ToString();
                    var role = u.GetValue("Role", new BsonString("User")).ToString();

                    // ensure ObjectId
                    ObjectId oid = ObjectId.Empty;
                    if (id != BsonNull.Value && id.IsObjectId)
                        oid = id.AsObjectId;

                    var display = $"{username} ({role})";
                    cmbAssignUser.Items.Add(new ComboItem { Text = display, Value = oid });
                }

                if (cmbAssignUser.Items.Count > 0)
                    cmbAssignUser.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading users: " + ex.Message);
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
                cmbAssignUser.SelectedItem == null ||
                string.IsNullOrWhiteSpace(txtTaskTitle.Text))
            {
                MessageBox.Show("TaskID, Assigned User and Title are required.");
                return;
            }

            try
            {
                // get selected user's ObjectId
                var selected = cmbAssignUser.SelectedItem as ComboItem;
                if (selected == null || selected.Value == ObjectId.Empty)
                {
                    MessageBox.Show("Please select a valid user to assign the task to.");
                    return;
                }

                var taskDoc = new BsonDocument
                {
                    { "TaskID", txtTaskID.Text.Trim() },
                    { "UserID", selected.Value },                     // store ObjectId
                    { "Title", txtTaskTitle.Text.Trim() },
                    { "Description", txtTaskDescription.Text.Trim() },
                    { "TaskStatus", "Pending" }, // must match schema
                    { "Steps", new BsonArray(stepList) },
                    { "CreatedDate", DateTime.UtcNow },
                    { "DueDate", dtpDueDate.Value }
                };

                _tasks.InsertOne(taskDoc);

                LogAudit(LoginForm.LoggedInUsername, "Insert Task", $"Created task {txtTaskID.Text}");

                MessageBox.Show("Task Inserted.");
                stepList.Clear();
                lvSteps.Items.Clear();
                ClearFields();

                // reload users (not strictly necessary) and optionally refresh UI
                LoadUsersIntoDropdown();
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
            // txtTaskUserID removed — use combo
            if (cmbAssignUser.Items.Count > 0) cmbAssignUser.SelectedIndex = 0;
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

        private void header_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

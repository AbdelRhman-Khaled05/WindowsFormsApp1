using System;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Driver;

namespace TaskManagementApp
{
    public partial class DeleteForm : Form
    {
        private IMongoDatabase _db;
        private IMongoCollection<BsonDocument> _users;
        private IMongoCollection<BsonDocument> _tasks;

        public DeleteForm()
        {
            InitializeComponent();

            try
            {
                _db = MongoConnection.GetDatabase();
                _users = _db.GetCollection<BsonDocument>("users");
                _tasks = _db.GetCollection<BsonDocument>("tasks");
                LoadUsers();
                LoadTasks();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting to MongoDB: " + ex.Message);
            }
        }

        private void LoadUsers()
        {
            try
            {
                cmbUsers.Items.Clear();
                var users = _users.Find(new BsonDocument()).ToList();
                foreach (var user in users)
                {
                    cmbUsers.Items.Add(user["UserID"].AsString);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading users: " + ex.Message);
            }
        }

        private void LoadTasks()
        {
            try
            {
                cmbTasks.Items.Clear();
                var tasks = _tasks.Find(new BsonDocument()).ToList();
                foreach (var task in tasks)
                {
                    cmbTasks.Items.Add(task["TaskID"].AsString);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading tasks: " + ex.Message);
            }
        }

        private void cmbUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbUsers.SelectedItem == null) return;

            try
            {
                string userID = cmbUsers.SelectedItem.ToString();
                var filter = Builders<BsonDocument>.Filter.Eq("UserID", userID);
                var user = _users.Find(filter).FirstOrDefault();

                if (user != null)
                {
                    txtUserDetails.Text = $"User ID: {user["UserID"]}\r\n";
                    txtUserDetails.Text += $"Username: {user.GetValue("Username", "")}\r\n";
                    txtUserDetails.Text += $"Role: {user.GetValue("Role", "")}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading user details: " + ex.Message);
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
                    txtTaskDetails.Text = $"Task ID: {task["TaskID"]}\r\n";
                    txtTaskDetails.Text += $"User ID: {task.GetValue("UserID", "")}\r\n";
                    txtTaskDetails.Text += $"Title: {task.GetValue("Title", "")}\r\n";
                    txtTaskDetails.Text += $"Description: {task.GetValue("Description", "")}\r\n";
                    txtTaskDetails.Text += $"Status: {task.GetValue("TaskStatus", "")}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading task details: " + ex.Message);
            }
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (cmbUsers.SelectedItem == null)
            {
                MessageBox.Show("Please select a user to delete.");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this user?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                try
                {
                    string userID = cmbUsers.SelectedItem.ToString();
                    var filter = Builders<BsonDocument>.Filter.Eq("UserID", userID);
                    _users.DeleteOne(filter);
                    MessageBox.Show("User deleted successfully!");
                    txtUserDetails.Clear();
                    LoadUsers();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting user: " + ex.Message);
                }
            }
        }

        private void btnDeleteTask_Click(object sender, EventArgs e)
        {
            if (cmbTasks.SelectedItem == null)
            {
                MessageBox.Show("Please select a task to delete.");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this task?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                try
                {
                    string taskID = cmbTasks.SelectedItem.ToString();
                    var filter = Builders<BsonDocument>.Filter.Eq("TaskID", taskID);
                    _tasks.DeleteOne(filter);
                    MessageBox.Show("Task deleted successfully!");
                    txtTaskDetails.Clear();
                    LoadTasks();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting task: " + ex.Message);
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadUsers();
            LoadTasks();
            MessageBox.Show("Data refreshed!");
        }
    }
}
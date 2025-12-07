using System;
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

        public UpdateForm()
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
                    txtUsername.Text = user.GetValue("Username", "").AsString;
                    txtPassword.Text = user.GetValue("Password", "").AsString;
                    txtRole.Text = user.GetValue("Role", "").AsString;
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
                    txtTaskUserID.Text = task.GetValue("UserID", "").AsString;
                    txtTaskTitle.Text = task.GetValue("Title", "").AsString;
                    txtTaskDescription.Text = task.GetValue("Description", "").AsString;
                    txtTaskStatus.Text = task.GetValue("TaskStatus", "").AsString;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading task details: " + ex.Message);
            }
        }

        private void btnUpdateUser_Click(object sender, EventArgs e)
        {
            if (cmbUsers.SelectedItem == null)
            {
                MessageBox.Show("Please select a user to update.");
                return;
            }

            try
            {
                string userID = cmbUsers.SelectedItem.ToString();
                var filter = Builders<BsonDocument>.Filter.Eq("UserID", userID);
                var update = Builders<BsonDocument>.Update
                    .Set("Username", txtUsername.Text)
                    .Set("Password", txtPassword.Text)
                    .Set("Role", txtRole.Text);

                _users.UpdateOne(filter, update);
                MessageBox.Show("User updated successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating user: " + ex.Message);
            }
        }

        private void btnUpdateTask_Click(object sender, EventArgs e)
        {
            if (cmbTasks.SelectedItem == null)
            {
                MessageBox.Show("Please select a task to update.");
                return;
            }

            try
            {
                string taskID = cmbTasks.SelectedItem.ToString();
                var filter = Builders<BsonDocument>.Filter.Eq("TaskID", taskID);
                var update = Builders<BsonDocument>.Update
                    .Set("UserID", txtTaskUserID.Text)
                    .Set("Title", txtTaskTitle.Text)
                    .Set("Description", txtTaskDescription.Text)
                    .Set("TaskStatus", txtTaskStatus.Text);

                _tasks.UpdateOne(filter, update);
                MessageBox.Show("Task updated successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating task: " + ex.Message);
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
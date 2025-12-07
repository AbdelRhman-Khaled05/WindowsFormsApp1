using System;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Driver;

namespace TaskManagementApp
{
    public partial class InsertForm : Form
    {
        // Mongo collections used by the logic (optional: remove if you are wiring differently)
        private IMongoDatabase _db;
        private IMongoCollection<BsonDocument> _users;
        private IMongoCollection<BsonDocument> _tasks;

        public InsertForm()
        {
            InitializeComponent();

            // Optional: initialize mongo collections if you want inserts to work from this form
            try
            {
                _db = MongoConnection.GetDatabase();
                _users = _db.GetCollection<BsonDocument>("users");
                _tasks = _db.GetCollection<BsonDocument>("tasks");
            }
            catch
            {
                // If Mongo isn't configured yet, ignore; you can wire later
            }
        }

        // Event handler called by the designer when Insert (user) button is clicked
        private void btnInsertUser_Click(object sender, EventArgs e)
        {
            // basic validation
            if (string.IsNullOrWhiteSpace(txtUserID.Text)
                || string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Please fill at least User ID and Username.");
                return;
            }

            try
            {
                if (_users != null)
                {
                    var user = new BsonDocument
                    {
                        { "UserID", txtUserID.Text },
                        { "Username", txtUsername.Text },
                        { "Password", txtPassword.Text ?? string.Empty },
                        { "Role", txtRole.Text ?? string.Empty }
                    };
                    _users.InsertOne(user);
                    MessageBox.Show("User inserted.");
                }
                else
                {
                    MessageBox.Show("MongoDB not configured. Skipping actual insert.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inserting user: " + ex.Message);
            }
        }

        // Event handler called by the designer when Insert Task button is clicked
        private void btnInsertTask_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTaskID.Text) ||
                string.IsNullOrWhiteSpace(txtTaskUserID.Text) ||
                string.IsNullOrWhiteSpace(txtTaskTitle.Text))
            {
                MessageBox.Show("Please fill Task ID, User ID and Title.");
                return;
            }

            try
            {
                if (_tasks != null)
                {
                    var steps = new BsonArray();
                    if (!string.IsNullOrWhiteSpace(txtStep1ID.Text))
                    {
                        steps.Add(new BsonDocument {
                            { "StepID", txtStep1ID.Text },
                            { "StepDescription", txtStep1Desc.Text ?? string.Empty },
                            { "StepStatus", txtStep1Status.Text ?? string.Empty }
                        });
                    }
                    if (!string.IsNullOrWhiteSpace(txtStep2ID.Text))
                    {
                        steps.Add(new BsonDocument {
                            { "StepID", txtStep2ID.Text },
                            { "StepDescription", txtStep2Desc.Text ?? string.Empty },
                            { "StepStatus", txtStep2Status.Text ?? string.Empty }
                        });
                    }

                    var task = new BsonDocument
                    {
                        { "TaskID", txtTaskID.Text },
                        { "UserID", txtTaskUserID.Text },
                        { "Title", txtTaskTitle.Text },
                        { "Description", txtTaskDescription.Text ?? string.Empty },
                        { "TaskStatus", txtTaskStatus.Text ?? string.Empty },
                        { "steps", steps }
                    };

                    _tasks.InsertOne(task);
                    MessageBox.Show("Task inserted.");
                }
                else
                {
                    MessageBox.Show("MongoDB not configured. Skipping actual insert.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inserting task: " + ex.Message);
            }
        }

        private void InsertForm_Load(object sender, EventArgs e)
        {

        }

        private void txtUserID_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTaskID_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

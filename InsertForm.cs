using System;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Driver;

namespace TaskManagementApp
{
    public partial class InsertForm : Form
    {
        private IMongoDatabase _db;
        private IMongoCollection<BsonDocument> _users;
        private IMongoCollection<BsonDocument> _tasks;

        public InsertForm()
        {
            InitializeComponent();

            try
            {
                _db = MongoConnection.GetDatabase();
                _users = _db.GetCollection<BsonDocument>("Users");
                _tasks = _db.GetCollection<BsonDocument>("Tasks");
            }
            catch { }
        }

        // ✔ REQUIRED BY DESIGNER
        private void InsertForm_Load(object sender, EventArgs e)
        {
            // Optional initialization
        }

        // ---------------------------- INSERT USER ----------------------------
        private void btnInsertUser_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUserID.Text) ||
                string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Please fill at least User ID and Username.");
                return;
            }

            try
            {
                var user = new BsonDocument
                {
                    { "UserID", txtUserID.Text },
                    { "Username", txtUsername.Text },
                    { "Password", txtPassword.Text ?? "" },
                    { "Role", txtRole.Text ?? "" }
                };

                _users.InsertOne(user);
                MessageBox.Show("User inserted successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inserting user: " + ex.Message);
            }
        }

        // ---------------------------- INSERT TASK ----------------------------
        private void btnInsertTask_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTaskID.Text) ||
                string.IsNullOrWhiteSpace(txtTaskUserID.Text) ||
                string.IsNullOrWhiteSpace(txtTaskTitle.Text))
            {
                MessageBox.Show("Please fill Task ID, User ID, and Title.");
                return;
            }

            try
            {
                // Convert to ObjectId as required by your schema
                if (!ObjectId.TryParse(txtTaskUserID.Text, out ObjectId userObjectId))
                {
                    MessageBox.Show("UserID must be a valid MongoDB ObjectId.");
                    return;
                }

                // ----------------- BUILD STEPS ARRAY -----------------
                var steps = new BsonArray();

                // STEP 1
                if (!string.IsNullOrWhiteSpace(txtStep1ID.Text))
                {
                    steps.Add(new BsonDocument
                    {
                        { "StepID", txtStep1ID.Text },
                        { "StepDescription", txtStep1Desc.Text ?? "" },
                        { "StepStatus", txtStep1Status.Text ?? "Pending" },
                        { "SignedOff", new BsonDocument {
                            { "UserID", "" },
                            { "Status", "Not-Signed" },
                            { "Date", BsonDateTime.Create(DateTime.MinValue) }
                        }}
                    });
                }

                // STEP 2
                if (!string.IsNullOrWhiteSpace(txtStep2ID.Text))
                {
                    steps.Add(new BsonDocument
                    {
                        { "StepID", txtStep2ID.Text },
                        { "StepDescription", txtStep2Desc.Text ?? "" },
                        { "StepStatus", txtStep2Status.Text ?? "Pending" },
                        { "SignedOff", new BsonDocument {
                            { "UserID", "" },
                            { "Status", "Not-Signed" },
                            { "Date", BsonDateTime.Create(DateTime.MinValue) }
                        }}
                    });
                }

                // ----------------- BUILD TASK DOCUMENT -----------------
                var task = new BsonDocument
                {
                    { "TaskID", txtTaskID.Text },
                    { "UserID", userObjectId },
                    { "Title", txtTaskTitle.Text },
                    { "Description", txtTaskDescription.Text ?? "" },
                    { "TaskStatus", txtTaskStatus.Text ?? "Pending" },
                    { "Steps", steps }
                };

                _tasks.InsertOne(task);
                MessageBox.Show("Task inserted successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inserting task: " + ex.Message);
            }
        }
    }
}

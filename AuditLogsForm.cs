using System;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Driver;

namespace TaskManagementApp
{
    public partial class AuditLogsForm : Form
    {
        private IMongoDatabase _db;
        private IMongoCollection<BsonDocument> _auditLogs;

        public AuditLogsForm()
        {
            InitializeComponent();

            try
            {
                _db = MongoConnection.GetDatabase();
                _auditLogs = _db.GetCollection<BsonDocument>("AuditLogs");
                LoadAuditLogs();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting to MongoDB: " + ex.Message);
            }
        }

        private void EnsureColumns()
        {
            if (dgvAuditLogs.Columns.Count == 0)
            {
                dgvAuditLogs.Columns.Add("LogID", "LogID");
                dgvAuditLogs.Columns.Add("Username", "Username");
                dgvAuditLogs.Columns.Add("Action", "Action");
                dgvAuditLogs.Columns.Add("Details", "Details");
                dgvAuditLogs.Columns.Add("Timestamp", "Timestamp");

                dgvAuditLogs.Columns["LogID"].Width = 220;
                dgvAuditLogs.Columns["Username"].Width = 150;
                dgvAuditLogs.Columns["Action"].Width = 140;
                dgvAuditLogs.Columns["Details"].Width = 350;
                dgvAuditLogs.Columns["Timestamp"].Width = 140;
            }
        }

        private void LoadAuditLogs()
        {
            try
            {
                dgvAuditLogs.Rows.Clear();

                var logs = _auditLogs.Find(new BsonDocument())
                    .Sort(Builders<BsonDocument>.Sort.Descending("Timestamp"))
                    .ToList();

                foreach (var log in logs)
                {
                    dgvAuditLogs.Rows.Add(
                        log.GetValue("LogID", "").ToString(),
                        log.GetValue("Username", log.GetValue("UserID", "")).ToString(), // FIXED
                        log.GetValue("Action", "").ToString(),
                        log.GetValue("Details", "").ToString(),
                        log.GetValue("Timestamp", DateTime.Now).ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss")
                    );
                }

                lblCount.Text = $"Total Logs: {logs.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading audit logs: " + ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadAuditLogs();
            MessageBox.Show("Audit logs refreshed.");
        }

        private void header_Paint(object sender, PaintEventArgs e)
        {
            // Empty event handler
        }

        private void header_Paint_1(object sender, PaintEventArgs e)
        {
            // Empty event handler
        }
    }
}

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
                        log.GetValue("Username", "").ToString(),  // Changed from UserID
                        log.GetValue("Action", "").ToString(),
                        log.GetValue("Details", "").ToString(),
                        log.GetValue("Timestamp", DateTime.Now).ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss")
                    );
                }
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
    }
}
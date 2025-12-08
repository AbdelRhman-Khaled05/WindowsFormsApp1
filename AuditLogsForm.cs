using System;
using System.Data;
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
                MessageBox.Show("Error connecting to database: " + ex.Message);
            }
        }

        private void LoadAuditLogs()
        {
            try
            {
                var logs = _auditLogs.Find(new BsonDocument())
                    .Sort(Builders<BsonDocument>.Sort.Descending("Timestamp"))
                    .ToList();

                DataTable dt = new DataTable();
                dt.Columns.Add("Timestamp");
                dt.Columns.Add("UserID");
                dt.Columns.Add("Action");
                dt.Columns.Add("Details");

                foreach (var log in logs)
                {
                    dt.Rows.Add(
                        log.GetValue("Timestamp", DateTime.MinValue).ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss"),
                        log.GetValue("UserID", ""),
                        log.GetValue("Action", ""),
                        log.GetValue("Details", "")
                    );
                }

                dgvAuditLogs.DataSource = dt;
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
            MessageBox.Show("Audit logs refreshed!");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
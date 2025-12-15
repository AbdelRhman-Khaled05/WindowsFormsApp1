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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting to MongoDB: " + ex.Message);
            }
        }

        private void AuditLogsForm_Load(object sender, EventArgs e)
        {
            SetupDataGridView();
            LoadAuditLogs();
        }

        private void SetupDataGridView()
        {
            dgvAuditLogs.Rows.Clear();
            dgvAuditLogs.Columns.Clear();

            // Add columns
            dgvAuditLogs.Columns.Add("LogID", "Log ID");
            dgvAuditLogs.Columns.Add("Username", "Username");
            dgvAuditLogs.Columns.Add("Action", "Action");
            dgvAuditLogs.Columns.Add("Details", "Details");
            dgvAuditLogs.Columns.Add("Timestamp", "Timestamp");

            // Set column widths
            dgvAuditLogs.Columns["LogID"].Width = 200;
            dgvAuditLogs.Columns["Username"].Width = 150;
            dgvAuditLogs.Columns["Action"].Width = 150;
            dgvAuditLogs.Columns["Details"].Width = 300;
            dgvAuditLogs.Columns["Timestamp"].Width = 160;

            // Styling
            dgvAuditLogs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvAuditLogs.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dgvAuditLogs.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            dgvAuditLogs.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
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
                    string logID = log.GetValue("LogID", "").ToString();

                    // Check both Username and UserID for backwards compatibility
                    string username = log.Contains("Username")
                        ? log.GetValue("Username", "Unknown").ToString()
                        : log.GetValue("UserID", "Unknown").ToString();

                    string action = log.GetValue("Action", "").ToString();
                    string details = log.GetValue("Details", "").ToString();

                    DateTime timestamp = DateTime.UtcNow;
                    if (log.Contains("Timestamp") && log["Timestamp"].IsValidDateTime)
                    {
                        timestamp = log["Timestamp"].ToUniversalTime();
                    }

                    string timestampStr = timestamp.ToString("yyyy-MM-dd HH:mm:ss");

                    dgvAuditLogs.Rows.Add(logID, username, action, details, timestampStr);
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
            MessageBox.Show("Audit logs refreshed successfully!", "Refresh", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
using System.Drawing;
using System.Windows.Forms;

namespace TaskManagementApp
{
    partial class AuditLogsForm
    {
        private System.ComponentModel.IContainer components = null;

        private Panel header;
        private Label lblTitle;
        private DataGridView dgvAuditLogs;
        private Label lblCount;
        private Button btnRefresh;
        private Button btnClose;

        private DataGridViewTextBoxColumn colLogID;
        private DataGridViewTextBoxColumn colUsername;
        private DataGridViewTextBoxColumn colAction;
        private DataGridViewTextBoxColumn colDetails;
        private DataGridViewTextBoxColumn colTimestamp;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            this.header = new Panel();
            this.lblTitle = new Label();
            this.dgvAuditLogs = new DataGridView();
            this.lblCount = new Label();
            this.btnRefresh = new Button();
            this.btnClose = new Button();

            this.colLogID = new DataGridViewTextBoxColumn();
            this.colUsername = new DataGridViewTextBoxColumn();
            this.colAction = new DataGridViewTextBoxColumn();
            this.colDetails = new DataGridViewTextBoxColumn();
            this.colTimestamp = new DataGridViewTextBoxColumn();

            // HEADER PANEL
            this.header.BackColor = Color.FromArgb(60, 130, 200);
            this.header.Dock = DockStyle.Top;
            this.header.Size = new Size(1000, 70);
            this.header.Controls.Add(this.lblTitle);

            // HEADER LABEL
            this.lblTitle.Text = "📋 Audit Logs";
            this.lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.White;
            this.lblTitle.Location = new Point(20, 20);

            // DATAGRIDVIEW
            this.dgvAuditLogs.Location = new Point(20, 90);
            this.dgvAuditLogs.Size = new Size(960, 440);
            this.dgvAuditLogs.ReadOnly = true;
            this.dgvAuditLogs.RowHeadersVisible = false;
            this.dgvAuditLogs.AllowUserToAddRows = false;
            this.dgvAuditLogs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // ADD COLUMNS
            this.colLogID.HeaderText = "LogID";
            this.colUsername.HeaderText = "Username";
            this.colAction.HeaderText = "Action";
            this.colDetails.HeaderText = "Details";
            this.colTimestamp.HeaderText = "Timestamp";

            this.dgvAuditLogs.Columns.AddRange(new DataGridViewColumn[]
            {
                colLogID, colUsername, colAction, colDetails, colTimestamp
            });

            // LOGS COUNT LABEL
            this.lblCount.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblCount.Location = new Point(20, 540);
            this.lblCount.Text = "Total Logs: 0";

            // REFRESH BUTTON
            this.btnRefresh.Text = "↻ Refresh";
            this.btnRefresh.BackColor = Color.FromArgb(40, 160, 80);
            this.btnRefresh.ForeColor = Color.White;
            this.btnRefresh.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.btnRefresh.Location = new Point(740, 540);
            this.btnRefresh.Size = new Size(120, 40);
            this.btnRefresh.Click += btnRefresh_Click;

            // CLOSE BUTTON
            this.btnClose.Text = "Close";
            this.btnClose.BackColor = Color.FromArgb(100, 100, 100);
            this.btnClose.ForeColor = Color.White;
            this.btnClose.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.btnClose.Location = new Point(870, 540);
            this.btnClose.Size = new Size(110, 40);
            this.btnClose.Click += (s, e) => this.Close();

            // FORM SETTINGS
            this.ClientSize = new Size(1000, 600);
            this.Controls.Add(this.header);
            this.Controls.Add(this.dgvAuditLogs);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnClose);
            this.Text = "Audit Logs";
            this.StartPosition = FormStartPosition.CenterScreen;
        }
    }
}

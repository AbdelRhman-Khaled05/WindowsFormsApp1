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

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.header = new Panel();
            this.lblTitle = new Label();
            this.dgvAuditLogs = new DataGridView();
            this.lblCount = new Label();
            this.btnRefresh = new Button();
            this.btnClose = new Button();

            this.header.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAuditLogs)).BeginInit();
            this.SuspendLayout();

            // FORM
            this.ClientSize = new Size(1000, 600);
            this.Text = "Audit Logs";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;

            // HEADER
            this.header.BackColor = Color.FromArgb(60, 130, 200);
            this.header.Dock = DockStyle.Top;
            this.header.Height = 70;

            this.lblTitle.Text = "📋 Audit Logs";
            this.lblTitle.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.White;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new Point(20, 20);

            this.header.Controls.Add(this.lblTitle);

            // DATAGRIDVIEW
            this.dgvAuditLogs.Location = new Point(20, 90);
            this.dgvAuditLogs.Size = new Size(960, 440);
            this.dgvAuditLogs.BackgroundColor = Color.White;
            this.dgvAuditLogs.BorderStyle = BorderStyle.None;
            this.dgvAuditLogs.AllowUserToAddRows = false;
            this.dgvAuditLogs.AllowUserToDeleteRows = false;
            this.dgvAuditLogs.ReadOnly = true;
            this.dgvAuditLogs.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvAuditLogs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAuditLogs.RowHeadersVisible = false;
            this.dgvAuditLogs.ColumnHeadersHeight = 40;
            this.dgvAuditLogs.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(60, 130, 200);
            this.dgvAuditLogs.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgvAuditLogs.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            this.dgvAuditLogs.DefaultCellStyle.Font = new Font("Segoe UI", 9);
            this.dgvAuditLogs.DefaultCellStyle.SelectionBackColor = Color.FromArgb(100, 170, 230);
            this.dgvAuditLogs.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
            this.dgvAuditLogs.EnableHeadersVisualStyles = false;

            // COUNT LABEL
            this.lblCount.Text = "Total Logs: 0";
            this.lblCount.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            this.lblCount.Location = new Point(20, 540);
            this.lblCount.Size = new Size(300, 25);

            // REFRESH BUTTON
            this.btnRefresh.Text = "↻ Refresh";
            this.btnRefresh.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            this.btnRefresh.ForeColor = Color.White;
            this.btnRefresh.BackColor = Color.FromArgb(40, 160, 80);
            this.btnRefresh.FlatStyle = FlatStyle.Flat;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.Location = new Point(740, 540);
            this.btnRefresh.Size = new Size(120, 40);
            this.btnRefresh.Cursor = Cursors.Hand;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // CLOSE BUTTON
            this.btnClose.Text = "Close";
            this.btnClose.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            this.btnClose.ForeColor = Color.White;
            this.btnClose.BackColor = Color.FromArgb(100, 100, 100);
            this.btnClose.FlatStyle = FlatStyle.Flat;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.Location = new Point(870, 540);
            this.btnClose.Size = new Size(110, 40);
            this.btnClose.Cursor = Cursors.Hand;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            // ADD TO FORM
            this.Controls.Add(this.header);
            this.Controls.Add(this.dgvAuditLogs);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnClose);

            this.header.ResumeLayout(false);
            this.header.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAuditLogs)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
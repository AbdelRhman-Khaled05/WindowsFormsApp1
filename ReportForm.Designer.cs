using System.Drawing;
using System.Windows.Forms;

namespace TaskManagementApp
{
    partial class ReportForm
    {
        private System.ComponentModel.IContainer components = null;
        private Panel header;
        private Label lblTitle;
        private Panel mainPanel;
        private Label lblUser;
        private ComboBox cmbUser;
        private Button btnGenerate;
        private Label lblReportTitle;
        private TextBox txtReport;
        private Button btnExport;
        private Button btnClose;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.header = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.lblUser = new System.Windows.Forms.Label();
            this.cmbUser = new System.Windows.Forms.ComboBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.lblReportTitle = new System.Windows.Forms.Label();
            this.txtReport = new System.Windows.Forms.TextBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();

            this.header.SuspendLayout();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();

            // MAIN FORM
            this.ClientSize = new System.Drawing.Size(900, 700);
            this.Name = "ReportForm";
            this.Text = "Generate Reports";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;

            // HEADER
            this.header.BackColor = Color.FromArgb(60, 130, 200);
            this.header.Dock = DockStyle.Top;
            this.header.Height = 70;

            this.lblTitle.Text = "📊 Task Progress Reports";
            this.lblTitle.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.White;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new Point(20, 20);

            this.header.Controls.Add(this.lblTitle);

            // MAIN PANEL
            this.mainPanel.BackColor = Color.White;
            this.mainPanel.Location = new Point(20, 90);
            this.mainPanel.Size = new Size(860, 590);

            // USER LABEL
            this.lblUser.Text = "Select User:";
            this.lblUser.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            this.lblUser.Location = new Point(20, 20);
            this.lblUser.Size = new Size(120, 25);

            // USER COMBOBOX
            this.cmbUser.Font = new Font("Segoe UI", 10);
            this.cmbUser.Location = new Point(140, 20);
            this.cmbUser.Size = new Size(450, 30);
            this.cmbUser.DropDownStyle = ComboBoxStyle.DropDownList;

            // GENERATE BUTTON
            this.btnGenerate.Text = "Generate Report";
            this.btnGenerate.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            this.btnGenerate.ForeColor = Color.White;
            this.btnGenerate.BackColor = Color.FromArgb(60, 130, 200);
            this.btnGenerate.FlatStyle = FlatStyle.Flat;
            this.btnGenerate.FlatAppearance.BorderSize = 0;
            this.btnGenerate.Location = new Point(610, 17);
            this.btnGenerate.Size = new Size(230, 38);
            this.btnGenerate.Cursor = Cursors.Hand;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);

            // REPORT TITLE LABEL
            this.lblReportTitle.Text = "Report Output:";
            this.lblReportTitle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            this.lblReportTitle.Location = new Point(20, 75);
            this.lblReportTitle.Size = new Size(200, 25);

            // REPORT TEXTBOX
            this.txtReport.Font = new Font("Consolas", 9);
            this.txtReport.Location = new Point(20, 105);
            this.txtReport.Size = new Size(820, 420);
            this.txtReport.Multiline = true;
            this.txtReport.ScrollBars = ScrollBars.Both;
            this.txtReport.ReadOnly = true;
            this.txtReport.BackColor = Color.FromArgb(250, 250, 250);
            this.txtReport.WordWrap = false;

            // EXPORT BUTTON
            this.btnExport.Text = "💾 Export to File";
            this.btnExport.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            this.btnExport.ForeColor = Color.White;
            this.btnExport.BackColor = Color.FromArgb(40, 160, 80);
            this.btnExport.FlatStyle = FlatStyle.Flat;
            this.btnExport.FlatAppearance.BorderSize = 0;
            this.btnExport.Location = new Point(20, 540);
            this.btnExport.Size = new Size(400, 40);
            this.btnExport.Cursor = Cursors.Hand;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);

            // CLOSE BUTTON
            this.btnClose.Text = "Close";
            this.btnClose.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            this.btnClose.ForeColor = Color.White;
            this.btnClose.BackColor = Color.FromArgb(100, 100, 100);
            this.btnClose.FlatStyle = FlatStyle.Flat;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.Location = new Point(440, 540);
            this.btnClose.Size = new Size(400, 40);
            this.btnClose.Cursor = Cursors.Hand;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            // ADD CONTROLS TO MAIN PANEL
            this.mainPanel.Controls.Add(this.lblUser);
            this.mainPanel.Controls.Add(this.cmbUser);
            this.mainPanel.Controls.Add(this.btnGenerate);
            this.mainPanel.Controls.Add(this.lblReportTitle);
            this.mainPanel.Controls.Add(this.txtReport);
            this.mainPanel.Controls.Add(this.btnExport);
            this.mainPanel.Controls.Add(this.btnClose);

            // ADD TO FORM
            this.Controls.Add(this.header);
            this.Controls.Add(this.mainPanel);

            this.header.ResumeLayout(false);
            this.header.PerformLayout();
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.ResumeLayout(false);
        }
        #endregion
    }
}
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
            // 
            // header
            // 
            this.header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(130)))), ((int)(((byte)(200)))));
            this.header.Controls.Add(this.lblTitle);
            this.header.Dock = System.Windows.Forms.DockStyle.Top;
            this.header.Location = new System.Drawing.Point(0, 0);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(900, 70);
            this.header.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(376, 41);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "📊 Task Progress Reports";
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.White;
            this.mainPanel.Controls.Add(this.lblUser);
            this.mainPanel.Controls.Add(this.cmbUser);
            this.mainPanel.Controls.Add(this.btnGenerate);
            this.mainPanel.Controls.Add(this.lblReportTitle);
            this.mainPanel.Controls.Add(this.txtReport);
            this.mainPanel.Controls.Add(this.btnExport);
            this.mainPanel.Controls.Add(this.btnClose);
            this.mainPanel.Location = new System.Drawing.Point(20, 90);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(860, 590);
            this.mainPanel.TabIndex = 1;
            // 
            // lblUser
            // 
            this.lblUser.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblUser.Location = new System.Drawing.Point(20, 20);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(120, 25);
            this.lblUser.TabIndex = 0;
            this.lblUser.Text = "Select User:";
            // 
            // cmbUser
            // 
            this.cmbUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUser.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbUser.Location = new System.Drawing.Point(140, 20);
            this.cmbUser.Name = "cmbUser";
            this.cmbUser.Size = new System.Drawing.Size(450, 31);
            this.cmbUser.TabIndex = 1;
            // 
            // btnGenerate
            // 
            this.btnGenerate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(130)))), ((int)(((byte)(200)))));
            this.btnGenerate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenerate.FlatAppearance.BorderSize = 0;
            this.btnGenerate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerate.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnGenerate.ForeColor = System.Drawing.Color.White;
            this.btnGenerate.Location = new System.Drawing.Point(610, 17);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(230, 38);
            this.btnGenerate.TabIndex = 2;
            this.btnGenerate.Text = "Generate Report";
            this.btnGenerate.UseVisualStyleBackColor = false;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // lblReportTitle
            // 
            this.lblReportTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblReportTitle.Location = new System.Drawing.Point(20, 75);
            this.lblReportTitle.Name = "lblReportTitle";
            this.lblReportTitle.Size = new System.Drawing.Size(200, 25);
            this.lblReportTitle.TabIndex = 3;
            this.lblReportTitle.Text = "Report Output:";
            // 
            // txtReport
            // 
            this.txtReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.txtReport.Font = new System.Drawing.Font("Consolas", 9F);
            this.txtReport.Location = new System.Drawing.Point(20, 105);
            this.txtReport.Multiline = true;
            this.txtReport.Name = "txtReport";
            this.txtReport.ReadOnly = true;
            this.txtReport.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtReport.Size = new System.Drawing.Size(820, 420);
            this.txtReport.TabIndex = 4;
            this.txtReport.WordWrap = false;
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(160)))), ((int)(((byte)(80)))));
            this.btnExport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExport.FlatAppearance.BorderSize = 0;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.Location = new System.Drawing.Point(20, 540);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(400, 40);
            this.btnExport.TabIndex = 5;
            this.btnExport.Text = "💾 Export to File";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(440, 540);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(400, 40);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ReportForm
            // 
            this.ClientSize = new System.Drawing.Size(900, 700);
            this.Controls.Add(this.header);
            this.Controls.Add(this.mainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "ReportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generate Reports";
            this.header.ResumeLayout(false);
            this.header.PerformLayout();
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion
    }
}
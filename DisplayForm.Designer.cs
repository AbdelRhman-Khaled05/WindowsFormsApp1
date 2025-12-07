using System.Drawing;
using System.Windows.Forms;

namespace TaskManagementApp
{
    partial class DisplayForm
    {
        private System.ComponentModel.IContainer components = null;
        private Panel header;
        private Label lblTitle;
        private Panel searchPanel;
        private Label lblSearch;
        private TextBox txtSearch;
        private Button btnSearch;
        private Button btnClear;
        private Button btnDisplayUsers;
        private Button btnDisplayTasks;
        private DataGridView dgvDisplay;
        private Label lblCount;

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
            this.searchPanel = new System.Windows.Forms.Panel();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnDisplayUsers = new System.Windows.Forms.Button();
            this.btnDisplayTasks = new System.Windows.Forms.Button();
            this.dgvDisplay = new System.Windows.Forms.DataGridView();
            this.lblCount = new System.Windows.Forms.Label();

            this.header.SuspendLayout();
            this.searchPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDisplay)).BeginInit();
            this.SuspendLayout();

            // FORM
            this.ClientSize = new System.Drawing.Size(1100, 700);
            this.Text = "Display/Search Data";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;

            // HEADER
            this.header.BackColor = Color.FromArgb(60, 130, 200);
            this.header.Dock = DockStyle.Top;
            this.header.Height = 70;
            this.lblTitle.Text = "🔍 Display & Search Data";
            this.lblTitle.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.White;
            this.lblTitle.Location = new Point(20, 20);
            this.lblTitle.AutoSize = true;
            this.header.Controls.Add(this.lblTitle);

            // SEARCH PANEL
            this.searchPanel.BackColor = Color.White;
            this.searchPanel.Location = new Point(20, 90);
            this.searchPanel.Size = new Size(1060, 100);

            this.lblSearch.Text = "Search:";
            this.lblSearch.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            this.lblSearch.Location = new Point(20, 20);
            this.lblSearch.Size = new Size(100, 25);

            this.txtSearch.Font = new Font("Segoe UI", 10);
            this.txtSearch.Location = new Point(120, 20);
            this.txtSearch.Size = new Size(400, 30);
            this.txtSearch.KeyPress += new KeyPressEventHandler(this.txtSearch_KeyPress);

            this.btnSearch.Text = "Search";
            this.btnSearch.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            this.btnSearch.ForeColor = Color.White;
            this.btnSearch.BackColor = Color.FromArgb(60, 130, 200);
            this.btnSearch.FlatStyle = FlatStyle.Flat;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.Location = new Point(540, 18);
            this.btnSearch.Size = new Size(100, 35);
            this.btnSearch.Cursor = Cursors.Hand;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);

            this.btnClear.Text = "Clear";
            this.btnClear.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            this.btnClear.ForeColor = Color.White;
            this.btnClear.BackColor = Color.FromArgb(100, 100, 100);
            this.btnClear.FlatStyle = FlatStyle.Flat;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.Location = new Point(650, 18);
            this.btnClear.Size = new Size(100, 35);
            this.btnClear.Cursor = Cursors.Hand;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);

            this.btnDisplayUsers.Text = "📋 Display All Users";
            this.btnDisplayUsers.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            this.btnDisplayUsers.ForeColor = Color.White;
            this.btnDisplayUsers.BackColor = Color.FromArgb(40, 160, 80);
            this.btnDisplayUsers.FlatStyle = FlatStyle.Flat;
            this.btnDisplayUsers.FlatAppearance.BorderSize = 0;
            this.btnDisplayUsers.Location = new Point(120, 60);
            this.btnDisplayUsers.Size = new Size(180, 35);
            this.btnDisplayUsers.Cursor = Cursors.Hand;
            this.btnDisplayUsers.Click += new System.EventHandler(this.btnDisplayUsers_Click);

            this.btnDisplayTasks.Text = "📋 Display All Tasks";
            this.btnDisplayTasks.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            this.btnDisplayTasks.ForeColor = Color.White;
            this.btnDisplayTasks.BackColor = Color.FromArgb(40, 160, 80);
            this.btnDisplayTasks.FlatStyle = FlatStyle.Flat;
            this.btnDisplayTasks.FlatAppearance.BorderSize = 0;
            this.btnDisplayTasks.Location = new Point(310, 60);
            this.btnDisplayTasks.Size = new Size(180, 35);
            this.btnDisplayTasks.Cursor = Cursors.Hand;
            this.btnDisplayTasks.Click += new System.EventHandler(this.btnDisplayTasks_Click);

            this.searchPanel.Controls.Add(this.lblSearch);
            this.searchPanel.Controls.Add(this.txtSearch);
            this.searchPanel.Controls.Add(this.btnSearch);
            this.searchPanel.Controls.Add(this.btnClear);
            this.searchPanel.Controls.Add(this.btnDisplayUsers);
            this.searchPanel.Controls.Add(this.btnDisplayTasks);

            // DATAGRIDVIEW
            this.dgvDisplay.Location = new Point(20, 210);
            this.dgvDisplay.Size = new Size(1060, 430);
            this.dgvDisplay.BackgroundColor = Color.White;
            this.dgvDisplay.BorderStyle = BorderStyle.None;
            this.dgvDisplay.AllowUserToAddRows = false;
            this.dgvDisplay.AllowUserToDeleteRows = false;
            this.dgvDisplay.ReadOnly = true;
            this.dgvDisplay.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvDisplay.MultiSelect = false;
            this.dgvDisplay.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDisplay.RowHeadersVisible = false;
            this.dgvDisplay.ColumnHeadersHeight = 40;
            this.dgvDisplay.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(60, 130, 200);
            this.dgvDisplay.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgvDisplay.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            this.dgvDisplay.DefaultCellStyle.Font = new Font("Segoe UI", 9);
            this.dgvDisplay.DefaultCellStyle.SelectionBackColor = Color.FromArgb(100, 170, 230);
            this.dgvDisplay.DefaultCellStyle.SelectionForeColor = Color.White;
            this.dgvDisplay.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
            this.dgvDisplay.EnableHeadersVisualStyles = false;

            // COUNT LABEL
            this.lblCount.Text = "Total Records: 0";
            this.lblCount.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            this.lblCount.Location = new Point(20, 650);
            this.lblCount.Size = new Size(300, 25);

            // ADD TO FORM
            this.Controls.Add(this.header);
            this.Controls.Add(this.searchPanel);
            this.Controls.Add(this.dgvDisplay);
            this.Controls.Add(this.lblCount);

            this.header.ResumeLayout(false);
            this.header.PerformLayout();
            this.searchPanel.ResumeLayout(false);
            this.searchPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDisplay)).EndInit();
            this.ResumeLayout(false);
        }
        #endregion
    }
}
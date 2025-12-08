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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
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
            // 
            // header
            // 
            this.header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(130)))), ((int)(((byte)(200)))));
            this.header.Controls.Add(this.lblTitle);
            this.header.Dock = System.Windows.Forms.DockStyle.Top;
            this.header.Location = new System.Drawing.Point(0, 0);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(1100, 70);
            this.header.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(355, 41);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "🔍 Display & Search Data";
            // 
            // searchPanel
            // 
            this.searchPanel.BackColor = System.Drawing.Color.White;
            this.searchPanel.Controls.Add(this.lblSearch);
            this.searchPanel.Controls.Add(this.txtSearch);
            this.searchPanel.Controls.Add(this.btnSearch);
            this.searchPanel.Controls.Add(this.btnClear);
            this.searchPanel.Controls.Add(this.btnDisplayUsers);
            this.searchPanel.Controls.Add(this.btnDisplayTasks);
            this.searchPanel.Location = new System.Drawing.Point(20, 90);
            this.searchPanel.Name = "searchPanel";
            this.searchPanel.Size = new System.Drawing.Size(1060, 100);
            this.searchPanel.TabIndex = 1;
            // 
            // lblSearch
            // 
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblSearch.Location = new System.Drawing.Point(20, 20);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(100, 25);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "Search:";
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSearch.Location = new System.Drawing.Point(120, 20);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(400, 30);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(130)))), ((int)(((byte)(200)))));
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(540, 18);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 35);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(650, 18);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 35);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnDisplayUsers
            // 
            this.btnDisplayUsers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(160)))), ((int)(((byte)(80)))));
            this.btnDisplayUsers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDisplayUsers.FlatAppearance.BorderSize = 0;
            this.btnDisplayUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDisplayUsers.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDisplayUsers.ForeColor = System.Drawing.Color.White;
            this.btnDisplayUsers.Location = new System.Drawing.Point(120, 60);
            this.btnDisplayUsers.Name = "btnDisplayUsers";
            this.btnDisplayUsers.Size = new System.Drawing.Size(180, 35);
            this.btnDisplayUsers.TabIndex = 4;
            this.btnDisplayUsers.Text = "📋 Display All Users";
            this.btnDisplayUsers.UseVisualStyleBackColor = false;
            this.btnDisplayUsers.Click += new System.EventHandler(this.btnDisplayUsers_Click);
            // 
            // btnDisplayTasks
            // 
            this.btnDisplayTasks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(160)))), ((int)(((byte)(80)))));
            this.btnDisplayTasks.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDisplayTasks.FlatAppearance.BorderSize = 0;
            this.btnDisplayTasks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDisplayTasks.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDisplayTasks.ForeColor = System.Drawing.Color.White;
            this.btnDisplayTasks.Location = new System.Drawing.Point(310, 60);
            this.btnDisplayTasks.Name = "btnDisplayTasks";
            this.btnDisplayTasks.Size = new System.Drawing.Size(180, 35);
            this.btnDisplayTasks.TabIndex = 5;
            this.btnDisplayTasks.Text = "📋 Display All Tasks";
            this.btnDisplayTasks.UseVisualStyleBackColor = false;
            this.btnDisplayTasks.Click += new System.EventHandler(this.btnDisplayTasks_Click);
            // 
            // dgvDisplay
            // 
            this.dgvDisplay.AllowUserToAddRows = false;
            this.dgvDisplay.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.dgvDisplay.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDisplay.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDisplay.BackgroundColor = System.Drawing.Color.White;
            this.dgvDisplay.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(130)))), ((int)(((byte)(200)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDisplay.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDisplay.ColumnHeadersHeight = 40;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(170)))), ((int)(((byte)(230)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDisplay.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDisplay.EnableHeadersVisualStyles = false;
            this.dgvDisplay.Location = new System.Drawing.Point(20, 210);
            this.dgvDisplay.MultiSelect = false;
            this.dgvDisplay.Name = "dgvDisplay";
            this.dgvDisplay.ReadOnly = true;
            this.dgvDisplay.RowHeadersVisible = false;
            this.dgvDisplay.RowHeadersWidth = 51;
            this.dgvDisplay.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDisplay.Size = new System.Drawing.Size(1060, 430);
            this.dgvDisplay.TabIndex = 2;
            // 
            // lblCount
            // 
            this.lblCount.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCount.Location = new System.Drawing.Point(20, 650);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(300, 25);
            this.lblCount.TabIndex = 3;
            this.lblCount.Text = "Total Records: 0";
            // 
            // DisplayForm
            // 
            this.ClientSize = new System.Drawing.Size(1100, 700);
            this.Controls.Add(this.header);
            this.Controls.Add(this.searchPanel);
            this.Controls.Add(this.dgvDisplay);
            this.Controls.Add(this.lblCount);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "DisplayForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Display/Search Data";
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
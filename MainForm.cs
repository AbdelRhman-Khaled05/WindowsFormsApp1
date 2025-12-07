using System;
using System.Windows.Forms;

namespace TaskManagementApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            lblWelcome.Text = $"Welcome, {LoginForm.LoggedInUsername} ({LoginForm.LoggedInRole})";
        }

        private void btnViewTasks_Click(object sender, EventArgs e)
        {
            ViewTasksForm f = new ViewTasksForm();
            f.ShowDialog();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            InsertForm f = new InsertForm();
            f.ShowDialog();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateForm f = new UpdateForm();
            f.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteForm f = new DeleteForm();
            f.ShowDialog();
        }

        // Phase 2: Display/Search Form (replaces SearchForm)
        private void btnDisplay_Click(object sender, EventArgs e)
        {
            DisplayForm f = new DisplayForm();
            f.ShowDialog();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            ReportForm f = new ReportForm();
            f.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to logout?",
                "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void lblWelcome_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
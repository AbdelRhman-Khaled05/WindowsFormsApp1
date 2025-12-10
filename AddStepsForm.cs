using System;
using System.Windows.Forms;

namespace TaskManagementApp
{
    public partial class AddStepForm : Form
    {
        public string StepID => txtStepID.Text.Trim();
        public string StepDescription => txtStepDescription.Text.Trim();

        public AddStepForm()
        {
            InitializeComponent();
        }

        private void AddStepForm_Load(object sender, EventArgs e)
        {
            // nothing needed, but Designer sometimes references this - keep it
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(StepID) || string.IsNullOrWhiteSpace(StepDescription))
            {
                MessageBox.Show("Please enter both Step ID and Description.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}

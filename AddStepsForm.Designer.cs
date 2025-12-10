using System.Drawing;
using System.Windows.Forms;

namespace TaskManagementApp
{
    partial class AddStepForm
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblStepID;
        private TextBox txtStepID;
        private Label lblStepDescription;
        private TextBox txtStepDescription;
        private Button btnAdd;
        private Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblStepID = new Label();
            this.txtStepID = new TextBox();
            this.lblStepDescription = new Label();
            this.txtStepDescription = new TextBox();
            this.btnAdd = new Button();
            this.btnCancel = new Button();

            this.SuspendLayout();

            // lblStepID
            this.lblStepID.AutoSize = true;
            this.lblStepID.Location = new Point(20, 18);
            this.lblStepID.Name = "lblStepID";
            this.lblStepID.Text = "Step ID:";

            // txtStepID
            this.txtStepID.Location = new Point(120, 15);
            this.txtStepID.Name = "txtStepID";
            this.txtStepID.Size = new Size(220, 25);

            // lblStepDescription
            this.lblStepDescription.AutoSize = true;
            this.lblStepDescription.Location = new Point(20, 58);
            this.lblStepDescription.Name = "lblStepDescription";
            this.lblStepDescription.Text = "Description:";

            // txtStepDescription
            this.txtStepDescription.Location = new Point(120, 55);
            this.txtStepDescription.Name = "txtStepDescription";
            this.txtStepDescription.Size = new Size(220, 25);

            // btnAdd
            this.btnAdd.Location = new Point(120, 100);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new Size(90, 30);
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            // btnCancel
            this.btnCancel.Location = new Point(250, 100);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(90, 30);
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // Form
            this.ClientSize = new Size(360, 150);
            this.Controls.Add(this.lblStepID);
            this.Controls.Add(this.txtStepID);
            this.Controls.Add(this.lblStepDescription);
            this.Controls.Add(this.txtStepDescription);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddStepForm";
            this.Text = "Add Step";
            this.Load += new System.EventHandler(this.AddStepForm_Load);

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

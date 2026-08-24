namespace ImageConverter
{
    partial class PreferencesForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblOutputDir = new Label();
            this.txtOutputDir = new TextBox();
            this.btnBrowseDir = new Button();
            this.btnOk = new Button();
            this.btnCancel = new Button();
            this.groupBox = new GroupBox();

            this.groupBox.SuspendLayout();
            this.SuspendLayout();

            // groupBox
            this.groupBox.Controls.Add(this.btnBrowseDir);
            this.groupBox.Controls.Add(this.txtOutputDir);
            this.groupBox.Controls.Add(this.lblOutputDir);
            this.groupBox.Location = new Point(12, 12);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new Size(440, 80);
            this.groupBox.Text = "Output Settings";

            // lblOutputDir
            this.lblOutputDir.AutoSize = true;
            this.lblOutputDir.Location = new Point(10, 30);
            this.lblOutputDir.Name = "lblOutputDir";
            this.lblOutputDir.Text = "Output Directory:";

            // txtOutputDir
            this.txtOutputDir.Location = new Point(120, 27);
            this.txtOutputDir.Name = "txtOutputDir";
            this.txtOutputDir.Size = new Size(230, 23);
            this.txtOutputDir.ReadOnly = true;

            // btnBrowseDir
            this.btnBrowseDir.Location = new Point(360, 26);
            this.btnBrowseDir.Name = "btnBrowseDir";
            this.btnBrowseDir.Size = new Size(70, 25);
            this.btnBrowseDir.Text = "Browse...";
            this.btnBrowseDir.Click += new EventHandler(this.BtnBrowseDir_Click);

            // btnOk
            this.btnOk.Location = new Point(296, 110);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new Size(75, 28);
            this.btnOk.Text = "OK";
            this.btnOk.Click += new EventHandler(this.BtnOk_Click);

            // btnCancel
            this.btnCancel.Location = new Point(377, 110);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(75, 28);
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new EventHandler(this.BtnCancel_Click);

            // PreferencesForm
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(464, 150);
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PreferencesForm";
            this.Text = "Preferences";
            this.StartPosition = FormStartPosition.CenterParent;

            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.ResumeLayout(false);
        }

        private Label lblOutputDir;
        private TextBox txtOutputDir;
        private Button btnBrowseDir;
        private Button btnOk;
        private Button btnCancel;
        private GroupBox groupBox;
    }
}

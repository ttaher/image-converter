namespace ImageConverter
{
    partial class Form1
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
            this.menuStrip = new MenuStrip();
            this.fileMenu = new ToolStripMenuItem();
            this.addFilesMenuItem = new ToolStripMenuItem();
            this.clearListMenuItem = new ToolStripMenuItem();
            this.separatorMenuItem = new ToolStripSeparator();
            this.exitMenuItem = new ToolStripMenuItem();
            this.settingsMenu = new ToolStripMenuItem();
            this.preferencesMenuItem = new ToolStripMenuItem();
            this.imageListView = new ListView();
            this.colFileName = new ColumnHeader();
            this.colExtension = new ColumnHeader();
            this.colSize = new ColumnHeader();
            this.colStatus = new ColumnHeader();
            this.panelDrop = new Panel();
            this.lblDropHint = new Label();
            this.panelBottom = new Panel();
            this.lblOutputFormat = new Label();
            this.cmbOutputFormat = new ComboBox();
            this.btnBrowse = new Button();
            this.btnConvert = new Button();
            this.btnClear = new Button();
            this.progressBar = new ProgressBar();
            this.lblStatus = new Label();

            this.txtOutputDir = new TextBox();
            this.btnOutputDir = new Button();
            this.lblOutputDir = new Label();
            this.lblInputFormat = new Label();
            this.cmbInputFormat = new ComboBox();

            this.menuStrip.SuspendLayout();
            this.panelDrop.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();

            // menuStrip
            this.menuStrip.Items.AddRange(new ToolStripItem[] { this.fileMenu, this.settingsMenu });
            this.menuStrip.Location = new Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new Size(800, 24);

            // fileMenu
            this.fileMenu.DropDownItems.AddRange(new ToolStripItem[] {
                this.addFilesMenuItem, this.clearListMenuItem, this.separatorMenuItem, this.exitMenuItem
            });
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Text = "&File";

            // addFilesMenuItem
            this.addFilesMenuItem.Name = "addFilesMenuItem";
            this.addFilesMenuItem.Text = "&Add Images...";
            this.addFilesMenuItem.ShortcutKeys = Keys.Control | Keys.O;
            this.addFilesMenuItem.Click += new EventHandler(this.AddFilesMenuItem_Click);

            // clearListMenuItem
            this.clearListMenuItem.Name = "clearListMenuItem";
            this.clearListMenuItem.Text = "&Clear List";
            this.clearListMenuItem.Click += new EventHandler(this.ClearListMenuItem_Click);

            // exitMenuItem
            this.exitMenuItem.Name = "exitMenuItem";
            this.exitMenuItem.Text = "E&xit";
            this.exitMenuItem.ShortcutKeys = Keys.Alt | Keys.F4;
            this.exitMenuItem.Click += new EventHandler(this.ExitMenuItem_Click);

            // settingsMenu
            this.settingsMenu.DropDownItems.AddRange(new ToolStripItem[] { this.preferencesMenuItem });
            this.settingsMenu.Name = "settingsMenu";
            this.settingsMenu.Text = "&Settings";

            // preferencesMenuItem
            this.preferencesMenuItem.Name = "preferencesMenuItem";
            this.preferencesMenuItem.Text = "&Preferences...";
            this.preferencesMenuItem.Click += new EventHandler(this.PreferencesMenuItem_Click);

            // imageListView
            this.imageListView.Columns.AddRange(new ColumnHeader[] {
                this.colFileName, this.colExtension, this.colSize, this.colStatus
            });
            this.imageListView.Dock = DockStyle.Fill;
            this.imageListView.FullRowSelect = true;
            this.imageListView.GridLines = true;
            this.imageListView.View = View.Details;
            this.imageListView.Name = "imageListView";
            this.imageListView.AllowDrop = true;
            this.imageListView.DragEnter += new DragEventHandler(this.ImageListView_DragEnter);
            this.imageListView.DragDrop += new DragEventHandler(this.ImageListView_DragDrop);

            // colFileName
            this.colFileName.Text = "File Name";
            this.colFileName.Width = 300;

            // colExtension
            this.colExtension.Text = "Extension";
            this.colExtension.Width = 80;

            // colSize
            this.colSize.Text = "Size";
            this.colSize.Width = 100;

            // colStatus
            this.colStatus.Text = "Status";
            this.colStatus.Width = 150;

            // panelDrop
            this.panelDrop.BorderStyle = BorderStyle.FixedSingle;
            this.panelDrop.Controls.Add(this.imageListView);
            this.panelDrop.Controls.Add(this.lblDropHint);
            this.panelDrop.Dock = DockStyle.Fill;
            this.panelDrop.Name = "panelDrop";
            this.panelDrop.Padding = new Padding(5);

            // lblDropHint
            this.lblDropHint.Dock = DockStyle.Fill;
            this.lblDropHint.Font = new Font("Segoe UI", 14F, FontStyle.Regular);
            this.lblDropHint.ForeColor = Color.Gray;
            this.lblDropHint.Name = "lblDropHint";
            this.lblDropHint.Text = "Drag && Drop Images Here\nor use File > Add Images";
            this.lblDropHint.TextAlign = ContentAlignment.MiddleCenter;
            this.lblDropHint.AllowDrop = true;
            this.lblDropHint.DragEnter += new DragEventHandler(this.ImageListView_DragEnter);
            this.lblDropHint.DragDrop += new DragEventHandler(this.ImageListView_DragDrop);

            // panelBottom
            this.panelBottom.Controls.Add(this.lblStatus);
            this.panelBottom.Controls.Add(this.progressBar);
            this.panelBottom.Controls.Add(this.btnConvert);
            this.panelBottom.Controls.Add(this.btnOutputDir);
            this.panelBottom.Controls.Add(this.txtOutputDir);
            this.panelBottom.Controls.Add(this.lblOutputDir);
            this.panelBottom.Controls.Add(this.btnClear);
            this.panelBottom.Controls.Add(this.cmbInputFormat);
            this.panelBottom.Controls.Add(this.lblInputFormat);
            this.panelBottom.Controls.Add(this.btnBrowse);
            this.panelBottom.Controls.Add(this.cmbOutputFormat);
            this.panelBottom.Controls.Add(this.lblOutputFormat);
            this.panelBottom.Dock = DockStyle.Bottom;
            this.panelBottom.Height = 130;
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Padding = new Padding(10);

            // lblOutputFormat
            this.lblOutputFormat.AutoSize = true;
            this.lblOutputFormat.Location = new Point(13, 15);
            this.lblOutputFormat.Name = "lblOutputFormat";
            this.lblOutputFormat.Text = "Output Format:";

            // cmbOutputFormat
            this.cmbOutputFormat.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbOutputFormat.Location = new Point(110, 12);
            this.cmbOutputFormat.Name = "cmbOutputFormat";
            this.cmbOutputFormat.Size = new Size(100, 23);

            // lblInputFormat
            this.lblInputFormat.AutoSize = true;
            this.lblInputFormat.Location = new Point(225, 15);
            this.lblInputFormat.Name = "lblInputFormat";
            this.lblInputFormat.Text = "Input Filter:";

            // cmbInputFormat
            this.cmbInputFormat.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbInputFormat.Location = new Point(300, 12);
            this.cmbInputFormat.Name = "cmbInputFormat";
            this.cmbInputFormat.Size = new Size(90, 23);

            // btnBrowse
            this.btnBrowse.Location = new Point(405, 10);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new Size(110, 28);
            this.btnBrowse.Text = "Browse Images...";
            this.btnBrowse.Click += new EventHandler(this.AddFilesMenuItem_Click);

            // btnClear
            this.btnClear.Location = new Point(525, 10);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new Size(75, 28);
            this.btnClear.Text = "Clear";
            this.btnClear.Click += new EventHandler(this.ClearListMenuItem_Click);

            // btnConvert
            this.btnConvert.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnConvert.Location = new Point(610, 10);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new Size(100, 28);
            this.btnConvert.Text = "Convert";
            this.btnConvert.Click += new EventHandler(this.BtnConvert_Click);

            // lblOutputDir
            this.lblOutputDir.AutoSize = true;
            this.lblOutputDir.Location = new Point(13, 47);
            this.lblOutputDir.Name = "lblOutputDir";
            this.lblOutputDir.Text = "Output Dir:";

            // txtOutputDir
            this.txtOutputDir.Location = new Point(85, 44);
            this.txtOutputDir.Name = "txtOutputDir";
            this.txtOutputDir.Size = new Size(540, 23);
            this.txtOutputDir.ReadOnly = true;

            // btnOutputDir
            this.btnOutputDir.Location = new Point(630, 43);
            this.btnOutputDir.Name = "btnOutputDir";
            this.btnOutputDir.Size = new Size(80, 25);
            this.btnOutputDir.Text = "Change...";
            this.btnOutputDir.Click += new EventHandler(this.BtnOutputDir_Click);

            // progressBar
            this.progressBar.Location = new Point(13, 78);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new Size(697, 20);

            // lblStatus
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new Point(13, 103);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Text = "Ready";

            // Form1
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(730, 500);
            this.MinimumSize = new Size(730, 400);
            this.Controls.Add(this.panelDrop);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "Form1";
            this.Text = "Image Converter";
            this.StartPosition = FormStartPosition.CenterScreen;

            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.panelDrop.ResumeLayout(false);
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private MenuStrip menuStrip;
        private ToolStripMenuItem fileMenu;
        private ToolStripMenuItem addFilesMenuItem;
        private ToolStripMenuItem clearListMenuItem;
        private ToolStripSeparator separatorMenuItem;
        private ToolStripMenuItem exitMenuItem;
        private ToolStripMenuItem settingsMenu;
        private ToolStripMenuItem preferencesMenuItem;
        private ListView imageListView;
        private ColumnHeader colFileName;
        private ColumnHeader colExtension;
        private ColumnHeader colSize;
        private ColumnHeader colStatus;
        private Panel panelDrop;
        private Label lblDropHint;
        private Panel panelBottom;
        private Label lblOutputFormat;
        private ComboBox cmbOutputFormat;
        private Button btnBrowse;
        private Button btnConvert;
        private Button btnClear;
        private ProgressBar progressBar;
        private Label lblStatus;
        private Label lblOutputDir;
        private TextBox txtOutputDir;
        private Button btnOutputDir;
        private Label lblInputFormat;
        private ComboBox cmbInputFormat;
    }
}

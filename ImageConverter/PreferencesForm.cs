namespace ImageConverter
{
    public partial class PreferencesForm : Form
    {
        public string SelectedDirectory { get; private set; }

        public PreferencesForm(string currentDirectory)
        {
            InitializeComponent();
            SelectedDirectory = currentDirectory;
            txtOutputDir.Text = currentDirectory;
        }

        private void BtnBrowseDir_Click(object? sender, EventArgs e)
        {
            using var fbd = new FolderBrowserDialog
            {
                Description = "Select Output Directory",
                SelectedPath = txtOutputDir.Text,
                ShowNewFolderButton = true
            };

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                txtOutputDir.Text = fbd.SelectedPath;
            }
        }

        private void BtnOk_Click(object? sender, EventArgs e)
        {
            if (!Directory.Exists(txtOutputDir.Text))
            {
                var result = MessageBox.Show(
                    "The selected directory does not exist. Create it?",
                    "Directory Not Found",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        Directory.CreateDirectory(txtOutputDir.Text);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Failed to create directory: {ex.Message}",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    return;
                }
            }

            SelectedDirectory = txtOutputDir.Text;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void BtnCancel_Click(object? sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}

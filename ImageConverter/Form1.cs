using ImageMagick;

namespace ImageConverter
{
    public partial class Form1 : Form
    {
        private readonly List<string> _imageFiles = new();
        private string _outputDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

        private static readonly string[] SupportedExtensions =
        {
            ".png", ".jpg", ".jpeg", ".bmp", ".gif", ".tiff", ".tif",
            ".ico", ".webp", ".heic", ".heif", ".avif"
        };

        private static readonly string[] OutputFormats =
            { "PNG", "JPEG", "BMP", "GIF", "TIFF", "ICO", "WEBP", "HEIC", "AVIF" };

        public Form1()
        {
            InitializeComponent();
            LoadSettings();
            cmbOutputFormat.Items.AddRange(OutputFormats);
            cmbOutputFormat.SelectedIndex = 0;
            UpdateDropHintVisibility();
        }

        private void LoadSettings()
        {
            var saved = Properties.Settings.Default.OutputDirectory;
            if (!string.IsNullOrEmpty(saved) && Directory.Exists(saved))
                _outputDirectory = saved;
        }

        private void SaveSettings()
        {
            Properties.Settings.Default.OutputDirectory = _outputDirectory;
            Properties.Settings.Default.Save();
        }

        private void AddFilesMenuItem_Click(object? sender, EventArgs e)
        {
            using var ofd = new OpenFileDialog
            {
                Title = "Select Images",
                Filter = "Image Files|*.png;*.jpg;*.jpeg;*.bmp;*.gif;*.tiff;*.tif;*.ico;*.webp;*.heic;*.heif;*.avif|All Files|*.*",
                Multiselect = true
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                AddFiles(ofd.FileNames);
            }
        }

        private void ClearListMenuItem_Click(object? sender, EventArgs e)
        {
            _imageFiles.Clear();
            imageListView.Items.Clear();
            UpdateDropHintVisibility();
            lblStatus.Text = "Ready";
            progressBar.Value = 0;
        }

        private void ExitMenuItem_Click(object? sender, EventArgs e)
        {
            Application.Exit();
        }

        private void PreferencesMenuItem_Click(object? sender, EventArgs e)
        {
            using var prefs = new PreferencesForm(_outputDirectory);
            if (prefs.ShowDialog() == DialogResult.OK)
            {
                _outputDirectory = prefs.SelectedDirectory;
                SaveSettings();
            }
        }

        private void ImageListView_DragEnter(object? sender, DragEventArgs e)
        {
            if (e.Data?.GetDataPresent(DataFormats.FileDrop) == true)
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void ImageListView_DragDrop(object? sender, DragEventArgs e)
        {
            if (e.Data?.GetData(DataFormats.FileDrop) is string[] files)
            {
                var imageFiles = files.Where(f =>
                    SupportedExtensions.Contains(Path.GetExtension(f).ToLowerInvariant())).ToArray();
                AddFiles(imageFiles);
            }
        }

        private void AddFiles(string[] files)
        {
            foreach (var file in files)
            {
                var ext = Path.GetExtension(file).ToLowerInvariant();
                if (!SupportedExtensions.Contains(ext))
                    continue;

                if (_imageFiles.Contains(file))
                    continue;

                _imageFiles.Add(file);
                var fi = new FileInfo(file);
                var item = new ListViewItem(new[]
                {
                    fi.Name,
                    ext,
                    FormatFileSize(fi.Length),
                    "Pending"
                });
                item.Tag = file;
                imageListView.Items.Add(item);
            }
            UpdateDropHintVisibility();
            lblStatus.Text = $"{_imageFiles.Count} image(s) loaded";
        }

        private void UpdateDropHintVisibility()
        {
            lblDropHint.Visible = _imageFiles.Count == 0;
            imageListView.Visible = _imageFiles.Count > 0;
        }

        private async void BtnConvert_Click(object? sender, EventArgs e)
        {
            if (_imageFiles.Count == 0)
            {
                MessageBox.Show("Please add images to convert.", "No Images",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Directory.Exists(_outputDirectory))
            {
                MessageBox.Show($"Output directory does not exist:\n{_outputDirectory}\n\nPlease set a valid output directory in Settings > Preferences.",
                    "Invalid Output Directory", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var outputFormat = cmbOutputFormat.SelectedItem?.ToString() ?? "PNG";
            var magickFormat = GetMagickFormat(outputFormat);
            var outputExt = GetExtensionForFormat(outputFormat);

            btnConvert.Enabled = false;
            btnBrowse.Enabled = false;
            progressBar.Maximum = _imageFiles.Count;
            progressBar.Value = 0;

            int success = 0, failed = 0;

            await Task.Run(() =>
            {
                for (int i = 0; i < _imageFiles.Count; i++)
                {
                    var inputFile = _imageFiles[i];
                    var outputName = Path.GetFileNameWithoutExtension(inputFile) + outputExt;
                    var outputPath = Path.Combine(_outputDirectory, outputName);

                    try
                    {
                        using var image = new MagickImage(inputFile);
                        image.Format = magickFormat;
                        image.Write(outputPath);
                        success++;
                        UpdateItemStatus(i, "Converted");
                    }
                    catch (Exception ex)
                    {
                        failed++;
                        UpdateItemStatus(i, $"Error: {ex.Message}");
                    }

                    UpdateProgress(i + 1);
                }
            });

            btnConvert.Enabled = true;
            btnBrowse.Enabled = true;
            lblStatus.Text = $"Done! {success} converted, {failed} failed. Output: {_outputDirectory}";
        }

        private void UpdateItemStatus(int index, string status)
        {
            if (InvokeRequired)
                Invoke(() => imageListView.Items[index].SubItems[3].Text = status);
            else
                imageListView.Items[index].SubItems[3].Text = status;
        }

        private void UpdateProgress(int value)
        {
            if (InvokeRequired)
                Invoke(() => progressBar.Value = value);
            else
                progressBar.Value = value;
        }

        private static MagickFormat GetMagickFormat(string format) => format.ToUpper() switch
        {
            "PNG" => MagickFormat.Png,
            "JPEG" => MagickFormat.Jpeg,
            "BMP" => MagickFormat.Bmp,
            "GIF" => MagickFormat.Gif,
            "TIFF" => MagickFormat.Tiff,
            "ICO" => MagickFormat.Ico,
            "WEBP" => MagickFormat.WebP,
            "HEIC" => MagickFormat.Heic,
            "AVIF" => MagickFormat.Avif,
            _ => MagickFormat.Png
        };

        private static string GetExtensionForFormat(string format) => format.ToUpper() switch
        {
            "PNG" => ".png",
            "JPEG" => ".jpg",
            "BMP" => ".bmp",
            "GIF" => ".gif",
            "TIFF" => ".tiff",
            "ICO" => ".ico",
            "WEBP" => ".webp",
            "HEIC" => ".heic",
            "AVIF" => ".avif",
            _ => ".png"
        };

        private static string FormatFileSize(long bytes)
        {
            if (bytes < 1024) return $"{bytes} B";
            if (bytes < 1024 * 1024) return $"{bytes / 1024.0:F1} KB";
            return $"{bytes / (1024.0 * 1024.0):F1} MB";
        }
    }
}

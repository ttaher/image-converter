namespace ImageConverter.Properties
{
    internal sealed class Settings
    {
        private static readonly Settings _default = new();
        public static Settings Default => _default;

        private readonly string _settingsFile;

        public string OutputDirectory { get; set; } = "";

        public Settings()
        {
            var appData = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "ImageConverter");
            Directory.CreateDirectory(appData);
            _settingsFile = Path.Combine(appData, "settings.txt");
            Load();
        }

        private void Load()
        {
            if (File.Exists(_settingsFile))
            {
                var lines = File.ReadAllLines(_settingsFile);
                foreach (var line in lines)
                {
                    var parts = line.Split('=', 2);
                    if (parts.Length == 2 && parts[0] == "OutputDirectory")
                        OutputDirectory = parts[1];
                }
            }
        }

        public void Save()
        {
            File.WriteAllText(_settingsFile, $"OutputDirectory={OutputDirectory}");
        }
    }
}

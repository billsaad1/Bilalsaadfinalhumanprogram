using HumanitarianProjectManagement.Models;
using Newtonsoft.Json;
using System;
using System.IO;

namespace HumanitarianProjectManagement.DataAccessLayer
{
    public class SettingsService
    {
        private readonly string _settingsFilePath;

        public SettingsService()
        {
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string appFolderPath = Path.Combine(appDataPath, "HumanitarianProjectManagement");
            Directory.CreateDirectory(appFolderPath); // Ensure the directory exists
            _settingsFilePath = Path.Combine(appFolderPath, "settings.json");
        }

        public Settings LoadSettings()
        {
            if (File.Exists(_settingsFilePath))
            {
                var json = File.ReadAllText(_settingsFilePath);
                return JsonConvert.DeserializeObject<Settings>(json);
            }
            return new Settings();
        }

        public void SaveSettings(Settings settings)
        {
            var json = JsonConvert.SerializeObject(settings, Formatting.Indented);
            File.WriteAllText(_settingsFilePath, json);
        }
    }
}

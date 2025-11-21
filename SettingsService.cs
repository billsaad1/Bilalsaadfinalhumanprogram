using HumanitarianProjectManagement.Models;
using Newtonsoft.Json;
using System.IO;

namespace HumanitarianProjectManagement.Services
{
    public class SettingsService
    {
        private readonly string _settingsFilePath = "settings.json";

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

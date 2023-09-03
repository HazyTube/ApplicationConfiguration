//#####################################################################################################################
//
//                  ApplicationConfiguration
//                  Library (.dll) used for managing application wide settings/configuration using XML
//
//                  Developed by Zafer Altan
//                  Copyright © 2023 ZA Ecom
//
//#####################################################################################################################

namespace ApplicationConfiguration
{
    public class ConfigurationHelper
    {

        private static readonly XmlSettingsManager settingsManager = new XmlSettingsManager();

        private static Dictionary<string, string> _loadedSettings;

        public static Dictionary<string, string> LoadedSettings
        {
            get
            {
                if (_loadedSettings == null)
                    _loadedSettings = settingsManager.LoadSettings();

                return _loadedSettings;
            }
        }

        // Default settings
        public static Dictionary<string, string> defaultSettings = new Dictionary<string, string>
            {
                { "setting1", "yes" },
                { "setting2", "no" }

            };

        public static void ResetSettingsToDefault()
        {
            _loadedSettings = defaultSettings;
            settingsManager.SaveSettings(defaultSettings);
        }

        // Update the value of a single setting key
        public static void ChangeSetting(string key, string value)
        {
            if (LoadedSettings.ContainsKey(key))
            {
                LoadedSettings[key] = value;
                settingsManager.SaveSettings(LoadedSettings);
            }
        }

        // Update the value of multiple setting keys, use a dictionary of strings
        public static void ChangeMultipleSettings(Dictionary<string, string> newSettings)
        {
            foreach (var newSetting in newSettings)
            {
                if (LoadedSettings.ContainsKey(newSetting.Key))
                {
                    LoadedSettings[newSetting.Key] = newSetting.Value;
                }
            }

            settingsManager.SaveSettings(LoadedSettings);
        }

    }
}

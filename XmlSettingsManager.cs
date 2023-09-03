//#####################################################################################################################
//
//                  ApplicationConfiguration
//                  Library (.dll) used for managing application wide settings/configuration using XML
//
//                  Developed by Zafer Altan
//                  Copyright © 2023 ZA Ecom
//
//#####################################################################################################################

using System.Reflection;
using System.Xml.Linq;

namespace ApplicationConfiguration
{
    public class XmlSettingsManager
    {

        private readonly string _filePath;

        public XmlSettingsManager()
        {
            string executablePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            _filePath = Path.Combine(executablePath, "App.config");
        }

        public Dictionary<string, string> LoadSettings()
        {
            Dictionary<string, string> settings = new Dictionary<string, string>();

            try
            {
                if (File.Exists(_filePath))
                {
                    XDocument xmlDoc = XDocument.Load(_filePath);
                    foreach (var element in xmlDoc.Root.Elements())
                    {
                        string key = element.Name.ToString();
                        string value = element.Value;
                        settings[key] = value;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error sloading settings: " + ex.Message);
            }

            return settings;
        }

        public void SaveSettings(Dictionary<string, string> settings)
        {
            try
            {
                XDocument xmlDoc = new XDocument(new XElement("Settings"));

                foreach (var setting in settings)
                {
                    xmlDoc.Root.Add(new XElement(setting.Key, setting.Value));
                }

                xmlDoc.Save(_filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving settings: " + ex.Message);
            }
        }

        public void InitializeDefaultSettings(Dictionary<string, string> defaultSettings)
        {
            try
            {
                if (!File.Exists(_filePath))
                {
                    XDocument xmlDoc = new XDocument(new XElement("Settings"));

                    foreach (var setting in defaultSettings)
                    {
                        xmlDoc.Root.Add(new XElement(setting.Key, setting.Value));
                    }

                    xmlDoc.Save(_filePath);
                    Console.WriteLine("Default settings file created.");
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions here
                Console.WriteLine("Error initializing default settings: " + ex.Message);
            }
        }

    }
}
# ApplicationConfiguration
Library (.dll) used for managing application wide settings/configuration using XML

Please read this file carefully before implementing the library.

Developed by Zafer Altan
Copyright © 2023 *ZA Ecom*

# 1. Functions
This library comes with a couple of functions to manage the settings/configuration file of the application.

#### ConfigurationHelper.cs:
- **ResetSettingsToDefault()** - Resets the settings to default values
- **ChangeSetting()** - Update the value of a single setting key
- **ChangeMultipleSettings()** - Update the value of multiple setting keys, use a dictionary of strings

#### XmlSettingsManager.cs:
- **LoadSettings()** - Fills a dictionary with the current settings
- **SaveSettings()** - Adds new setting key(s) to the file, uses a dictionary so you can add multiple new settings
- **InitializeDefaultSettings()** - Checks if the settings file exists, if not creates it with the default values

# 2. Examples
#### Start of application:

            var settingsManager = new XmlSettingsManager();

            // Initialize default settings
            settingsManager.InitializeDefaultSettings(ConfigurationHelper.defaultSettings);

            // Load and display existing settings
            Dictionary<string, string> loadedSettings = settingsManager.LoadSettings();
            
This will load the settings from the file and store them in a dictionary called **loadedSettings[]**
It will also check if the settings file exists, if not it will create a new settings file with the default values

#### Reading settings:
To read settings from the loadedSettings[] dictionary, you do it like this:
>ConfigurationHelper.LoadedSettings["setting_name"];

#### Updating single setting:
To update a single setting to the file, you do it like this:
>ChangeSetting(string setting_name, string value);

#### Updating multiple settings:
To update multiple settings, you first create a dictionary with all of the settings. Like this:

            Dictionary<string, string> newSettings = new Dictionary<string, string>
            {
                { "setting_name", new_value.Text },
                { "setting_name", new_value.Text }
            };
            
Then, you can write the new settings to the file like this:
>ChangeMultipleSettings(dictionary);

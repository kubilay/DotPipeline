using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotPipeline
{
    public class Settings
    {
        Dictionary<string, Setting> globalSettings;

        public Settings()
        {
            globalSettings = new Dictionary<string, Setting>();
        }

        public int? GetInteger(string setting)
        {
            if (globalSettings.ContainsKey(setting) && globalSettings[setting].settingType != SettingType.Integer)
                return null;
            return (int)globalSettings[setting].value;
        }

        public double? GetDouble(string setting)
        {
            if (globalSettings.ContainsKey(setting) && globalSettings[setting].settingType != SettingType.Double)
                return null;
            return (double)globalSettings[setting].value;
        }

        public bool? GetBoolean(string setting)
        {
            if (globalSettings.ContainsKey(setting) && globalSettings[setting].settingType != SettingType.Boolean)
                return null;
            return (bool)globalSettings[setting].value;
        }

        public string GetString(string setting)
        {
            if (globalSettings.ContainsKey(setting) && globalSettings[setting].settingType != SettingType.String)
                return null;
            return (string)globalSettings[setting].value;
        }

        public Settings GetSettings(string setting)
        {
            if (globalSettings.ContainsKey(setting) && globalSettings[setting].settingType != SettingType.Settings)
                return null;
            return (Settings)globalSettings[setting].value;
        }
    }
}

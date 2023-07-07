using Newtonsoft.Json;
using System.Collections.Generic;


public static class SettingsProvider
{
    private static readonly string m_gameNameKey = "game-name";
    private static readonly string m_musicNameKey = "music-name";
    private static readonly string m_settingsFileName = "settings.json";

    private static Dictionary<string, string> m_settings = new Dictionary<string, string>();

    static SettingsProvider()
    {
        var settingsStr = Utils.LoadResourceTextfile(m_settingsFileName);

        m_settings = JsonConvert.DeserializeObject<Dictionary<string, string>>(settingsStr);
        if (!ValidateSettings())
            throw new System.Exception($"file<{m_settingsFileName}> not correct");
    }

    public static string GetGameName() => m_settings[m_gameNameKey];

    private static bool ValidateSettings()
    {
        if (m_settings.ContainsKey(m_gameNameKey) && m_settings.ContainsKey(m_musicNameKey))
            return true;
        else
            return false;
    }
}

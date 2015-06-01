using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Windows.Forms;

namespace NppQuickSearchPanel
{
    public class Settings
    {
        public static string ConfigDir = "";
        public static string Version = Main.PluginVersion;
        public static string PluginName = Main.PluginName;
        public static Config Configs;

        public class Config
        {
            public string version = Settings.Version;
            public bool showOnStartup = false;
            public bool matchWord = false;
            public bool matchCase = false;
            public bool wrapSearch = true;
            public bool isRegExp = false;
        }

        public static void LoadConfigs()
        {
            string configFileName = Path.Combine(ConfigDir, PluginName + "Config.xml");
            try
            {
                FileStream fs = new FileStream(configFileName, FileMode.Open);
                XmlSerializer ser = new XmlSerializer(typeof(Config));
                Configs = (Config)ser.Deserialize(fs);
                fs.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Open config error: " + ex.Message);
                File.Delete(configFileName);
                Configs = new Settings.Config();
            }
        }

        public static void SaveConfigs()
        {
            string configFileName = Path.Combine(ConfigDir, PluginName + "Config.xml");
            try
            {
                TextWriter writer = new StreamWriter(configFileName);
                XmlSerializer ser = new XmlSerializer(typeof(Config));
                ser.Serialize(writer, Configs);
                writer.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Save config error: " + ex.Message);
                File.Delete(configFileName);
            }
        }
    }
}

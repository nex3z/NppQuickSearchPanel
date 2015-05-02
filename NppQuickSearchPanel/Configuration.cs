using System;
using System.Collections.Generic;
using System.Text;

namespace NppQuickSearchPanel
{
    class Configuration
    {
        private static Configuration instance;

        private Configuration() 
        {
            Version = Main.PluginVersion;
            matchWord = false;
            matchCase = false;
            wrapSearch = false;
            isRegExp = false;
            ConfigFilePath = ""; 
        }

        public static Configuration Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Configuration();
                }
                return instance;
            }
        }

        public string Version { get; set; }
        public bool matchWord { get; set; }
        public bool matchCase { get; set; }
        public bool wrapSearch { get; set; }
        public bool isRegExp { get; set; }
        public string ConfigFilePath { get; set; }
    }
}

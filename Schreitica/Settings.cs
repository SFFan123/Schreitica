using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Schreitica.Actions;

namespace Schreitica
{
    [Serializable]
    public class Settings
    {
        private static Settings instance;

        public static Settings Instance => instance ?? (instance = new Settings());

        private Settings()
        { }

        public double DbThreshold { get; set; }

        public bool AutoConnectRun { get; set; }
        
        public string OBSUrl { get; set; } = "";

        public string OBSPassword { get; set; } = "";

        public string HueURL { get; set; } = "";

        public string HueUser { get; set; } = "";

        [XmlArray]
        public string[] Actions = Array.Empty<string>();


        public void Load()
        {
            XmlSerializer serializer =
                new XmlSerializer(typeof(Settings));

            var stream = SettingHelper.LoadSettings();
            if (stream != null)
            {
                Settings loadSettings;
                using (stream)
                {
                    loadSettings = (Settings)serializer.Deserialize(stream);
                }

                this.Actions = loadSettings.Actions;
                this.AutoConnectRun = loadSettings.AutoConnectRun;
                this.OBSPassword = loadSettings.OBSPassword;
                this.DbThreshold = loadSettings.DbThreshold;
                this.OBSUrl = loadSettings.OBSUrl;
                this.HueURL = loadSettings.HueURL;
                this.HueUser = loadSettings.HueUser;
                this.Actions = loadSettings.Actions;
            }
        }

        public string ToXML()
        {
            var xmlserializer = new XmlSerializer(typeof(Settings));
            var stringWriter = new StringWriter();
            using (var writer = XmlWriter.Create(stringWriter, new XmlWriterSettings(){Encoding = Encoding.UTF8}))
            {
                xmlserializer.Serialize(writer, this);
                return stringWriter.ToString();
            }
        }
    }
}

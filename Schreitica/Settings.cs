using System;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Schreitica
{
    [Serializable]
    public class Settings
    {
        private static Settings instance;

        public static Settings Instance => instance ?? (instance = new Settings());

        private Settings()
        { }

        public double DbThreshold;

        public bool AutoConnectRun;
        
        public string OBSUrl = "";

        public string OBSPassword = "";


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

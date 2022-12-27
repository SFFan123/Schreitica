using System;
using System.IO;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Schreitica
{
    [Serializable]
    public class Settings
    {
        private static Settings instance;

        [XmlArray] public string[] Actions = Array.Empty<string>();

        private Settings()
        {
        }

        public static Settings Instance => instance ?? (instance = new Settings());

        public double DbThreshold { get; set; }

        public bool AutoConnectRun { get; set; }

        public string OBSUrl { get; set; } = "";

        public string OBSPassword { get; set; } = "";

        public string HueURL { get; set; } = "";

        public string HueUser { get; set; } = "";

        public int USBPollingDelay { get; set; }

        public bool ContinueOnActionError { get; set; }


        public void Load()
        {
            string path = SettingHelper.SettingsPath();

            if (!File.Exists(path))
            {
                return;
            }

            var doc = XDocument.Load(new StreamReader(path, Encoding.Default));

            XmlSerializer serializer =
                new XmlSerializer(typeof(Settings));

            Settings loadSettings;
            loadSettings = (Settings)serializer.Deserialize(doc.CreateReader());

            Actions = loadSettings.Actions;
            AutoConnectRun = loadSettings.AutoConnectRun;
            OBSPassword = loadSettings.OBSPassword;
            DbThreshold = loadSettings.DbThreshold;
            USBPollingDelay = loadSettings.USBPollingDelay;
            OBSUrl = loadSettings.OBSUrl;
            HueURL = loadSettings.HueURL;
            HueUser = loadSettings.HueUser;
            Actions = loadSettings.Actions;
            ContinueOnActionError = loadSettings.ContinueOnActionError;
        }

        public string ToXML()
        {
            using (var stringwriter = new StringWriter())
            {
                var serializer = new XmlSerializer(this.GetType());
                serializer.Serialize(stringwriter, this);
                return stringwriter.ToString();
            }
        }
    }
}
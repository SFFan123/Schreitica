using System.Security;

namespace Schreitica
{
    public class Settings
    {
        private static Settings instance;

        public static Settings Instance => instance ?? (instance = new Settings());

        public double DbThreshold;

        public string OBSUrl;

        public string OBSPassword;

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schreitica
{
    internal class HueHandler
    {
        private string userName { get; set; }
        public string HueURL { get; private set; }

        public HueHandler(string HueURL, string userName)
        {
            this.userName = userName;
            this.HueURL = HueURL;
        }

        public bool CanUseHue => !string.IsNullOrEmpty(HueURL) && !string.IsNullOrEmpty(userName);



    }
}

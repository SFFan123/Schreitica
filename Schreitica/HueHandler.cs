using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schreitica
{
    internal class HueHandler
    {
        public string userName { get; private set; }

        public HueHandler(string userName)
        {
            this.userName = userName;
        }

        public bool CanUseHue => !string.IsNullOrEmpty(userName);



    }
}

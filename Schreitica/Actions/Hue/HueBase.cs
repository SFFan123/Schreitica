using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schreitica.Actions.Hue
{
    public abstract class HueBase : IActionBase
    {
        public abstract Task<object> ExecuteAsync();
        public abstract string ToXMLAction();
    }
}

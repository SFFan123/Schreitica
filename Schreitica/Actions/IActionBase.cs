using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schreitica.Actions
{
    public interface IActionBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="resetDelay">-1 to disable</param>
        void Execute(double value, int resetDelay = -1);
    }
}

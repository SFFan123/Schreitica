using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schreitica.Actions
{
    public interface IActionBase
    {
        Task<object> ExecuteAsync();

        string ToXMLAction();

        string LogName { get; }
    }
}

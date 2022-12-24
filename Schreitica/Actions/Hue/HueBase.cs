using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schreitica.Actions.Hue
{
    public abstract class HueBase : IActionBase
    {
        public virtual Task<object> ExecuteAsync()
        {
            #region Check Hue Settings

            if (string.IsNullOrEmpty(Settings.Instance.HueURL))
                throw new ArgumentNullException(nameof(Settings.Instance.HueURL));

            if (string.IsNullOrEmpty(Settings.Instance.HueUser))
                throw new ArgumentNullException(nameof(Settings.Instance.HueURL));

            #endregion
            return Task.FromResult((object)true);
        }
        public abstract string ToXMLAction();
        public abstract string LogName { get; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schreitica.Actions
{
    internal class WaitForEventAction:IActionBase
    {
        public async Task ExecuteAsync()
        {
            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();

            AppEvents.BelowThresholdAgain += (sender, args) =>
            {
                tcs.TrySetResult(true);
            };
            await tcs.Task;
        }
    }
}

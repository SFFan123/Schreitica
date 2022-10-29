using System;
using System.Threading.Tasks;

namespace Schreitica.Actions
{
    internal class WaitForEventAction:IActionBase, IDisposable
    {
        public WaitForEventAction(EventHandler handel)
        {
            this.eventToListen = handel;
        }

        private EventHandler eventToListen;
        private TaskCompletionSource<bool> tcs;

        public async Task<object> ExecuteAsync()
        {
            tcs = new TaskCompletionSource<bool>();

            eventToListen += fire;

            await tcs.Task;

            return Task.CompletedTask;
        }

        private void fire(object sender, EventArgs args)
        {
            tcs.TrySetResult(true);
        }

        public void Dispose()
        {
            eventToListen -= fire;
            tcs.TrySetCanceled();
            tcs = null;
        }
    }

    internal class WaitAction : IActionBase
    {
        public WaitAction(int timeout)
        {
            timeout_s = timeout;
        }
        public int timeout_s { get; }
        public async Task<object> ExecuteAsync()
        {
            await Task.Delay(timeout_s * 100);
            return Task.CompletedTask;
        }
    }
}

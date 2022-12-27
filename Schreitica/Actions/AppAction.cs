using System;
using System.Threading.Tasks;

namespace Schreitica.Actions
{
    internal abstract class AppAction : IActionBase 
    { 
        public abstract Task<object> ExecuteAsync();
        public abstract string ToXMLAction();
        public abstract string LogName { get; }
    }


    internal class WaitForEventAction:AppAction, IActionBase, IDisposable
    {
        public WaitForEventAction(string handel)
        {
            eventToListen = handel;
        }

        private string eventToListen;
        private TaskCompletionSource<bool> tcs;

        public override async Task<object> ExecuteAsync()
        {
            tcs = new TaskCompletionSource<bool>();

            switch (eventToListen)
            {
                case "BelowThresholdAgain":
                    AppEvents.BelowThresholdAgain += fire;
                    break;
            }

            await tcs.Task;

            return Task.CompletedTask;
        }

        public override string ToXMLAction()
        {
            return $"App.WaitFor({eventToListen})";
        }

        public override string LogName => "App.WaitFor";

        private void fire(object sender, EventArgs args)
        {
            tcs.TrySetResult(true);
        }

        public void Dispose()
        {
            switch (eventToListen)
            {
                case "BelowThresholdAgain":
                    AppEvents.BelowThresholdAgain -= fire;
                    break;
            }

            tcs.TrySetCanceled();
            tcs = null;
        }
    }

    internal class WaitAction : AppAction
    {
        public WaitAction(int timeout)
        {
            timeout_s = timeout;
        }
        public override string LogName => "App.Wait";
        public int timeout_s { get; }
        public override async Task<object> ExecuteAsync()
        {
            await Task.Delay(timeout_s * 1000);
            return Task.CompletedTask;
        }

        public override string ToXMLAction()
        {
            return $"App.Wait({timeout_s})";
        }
    }
}

using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using OBSWebsocketDotNet;

namespace Schreitica.Actions
{
    public class DynamicOBSAction : IActionBase
    {
        public DynamicOBSAction(OBSWebsocket obs, string command)
        {
            this.obs = obs;
            this.command = command;
        }

        private OBSWebsocket obs;
        private string command;

        
        public async Task ExecuteAsync()
        {
            await CSharpScript.EvaluateAsync(command, globals:obs);
        }
    }
}

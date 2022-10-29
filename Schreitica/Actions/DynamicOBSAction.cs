using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
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

        public OBSWebsocket obs { get; }
        private string command { get; }

        
        public async Task<object> ExecuteAsync()
        {
            return await CSharpScript.EvaluateAsync(command,
                ScriptOptions.Default
                    .AddReferences(typeof(Enumerable).GetTypeInfo().Assembly)
                    .AddImports("System", "System.Linq"),
                globals: this);
        }
    }
}

using System;
using System.Threading.Tasks;

namespace Schreitica.Actions.OBS
{
    public class SwitchScene : OBSBase, IActionBase
    {
        public SwitchScene(string SceneName)
        {
            this.SceneName = SceneName;
        }

        public string SceneName { get; private set; }
        
        public async Task<object> ExecuteAsync()
        {
            GetObsConnection().SetCurrentProgramScene(SceneName);
            return Task.CompletedTask;;
        }

        public string ToXMLAction()
        {
            return $"OBS.{nameof(SwitchScene)}({SceneName}";
        }

        public string LogName => "OBS." + nameof(SwitchScene);
    }
}
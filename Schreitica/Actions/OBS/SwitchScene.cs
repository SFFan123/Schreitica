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
        
        public Task<object> ExecuteAsync()
        {
            GetOBSConnection().SetCurrentProgramScene(SceneName);
            return null;
        }

        public string ToXMLAction()
        {
            return $"OBS.{nameof(SwitchScene)}({SceneName}";
        }
    }
}
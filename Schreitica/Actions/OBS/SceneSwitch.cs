using System;
using System.Threading.Tasks;

namespace Schreitica.Actions.OBS
{
    public class SceneSwitch : OBSBase, IActionBase
    {
        public SceneSwitch(string SceneName)
        {
            this.SceneName = SceneName;
        }

        public string SceneName { get; private set; }
        
        public Task<object> ExecuteAsync()
        {
            GetOBSConnection().SetCurrentProgramScene(SceneName);
            return null;
        }
    }
}
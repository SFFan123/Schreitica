using System;
using System.Linq;
using System.Threading.Tasks;

namespace Schreitica.Actions.OBS
{
    public class HideSource: OBSBase, IActionBase 
    {
        public HideSource(string SourceName, string SceneName = null)
        {
            this.SceneName = SceneName;
            this.SourceName = SourceName;
        }

        public string SceneName { get; private set; }
        public string SourceName { get; private set; }

        public Task<object> ExecuteAsync()
        {
            var obs = GetOBSConnection();

            if (string.IsNullOrEmpty(SceneName))
            {
                SceneName = CurrentSceneName;
            }

            int id = obs.GetSceneItemList(SceneName).FirstOrDefault(x => x.SourceName.Equals(SourceName))?.ItemId ?? -1;
            if (id == -1)
            {
                throw new ApplicationException("Source not found in scene");
            }
            obs.SetSceneItemEnabled(SceneName, id , false );

            return null;
        }

        public string ToXMLAction()
        {
            if (string.IsNullOrEmpty(SceneName))
            {
                return $"OBS.{nameof(HideSource)}({SourceName})";
            }
            else
            {
                return $"OBS.{nameof(HideSource)}({SourceName}, {SceneName})";
            }
        }
    }
}
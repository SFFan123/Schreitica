using System;
using System.Linq;
using System.Threading.Tasks;

namespace Schreitica.Actions.OBS
{
    public class ShowSource: OBSBase, IActionBase 
    {
        public ShowSource(string SourceName, string SceneName = null)
        {
            this.SceneName = SceneName;
            this.SourceName = SourceName;
        }

        public string SceneName { get; private set; }
        public string SourceName { get; private set; }

        public Task<object> ExecuteAsync()
        {
            var obs = GetObsConnection();

            if (string.IsNullOrEmpty(SceneName))
            {
                SceneName = CurrentSceneName;
            }

            int id = obs.GetSceneItemList(SceneName).FirstOrDefault(x => x.SourceName.Equals(SourceName))?.ItemId ?? -1;
            if (id == -1)
            {
                throw new ApplicationException("Source not found in scene");
            }
            obs.SetSceneItemEnabled(SceneName, id , true );

            return null;
        }

        public string ToXMLAction()
        {
            if (string.IsNullOrEmpty(SceneName))
            {
                return $"OBS.{nameof(ShowSource)}({SourceName})";
            }
            else
            {
                return $"OBS.{nameof(ShowSource)}({SourceName}, {SceneName})";
            }
        }

        public string LogName => "OBS." + nameof(ShowSource);
    }
}
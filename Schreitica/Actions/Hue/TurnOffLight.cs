using System.Threading.Tasks;

namespace Schreitica.Actions.Hue
{
    public class TurnOffLight:SetLightBase
    {
        public string LightName { get; set; }
        
        public TurnOffLight(string LightName)
        {
            this.LightName = LightName;
        }

        public override async Task<object> ExecuteAsync()
        {
            await base.ExecuteAsync();
            
            await SetLight(LightName, "{\"on\":false}");
            return Task.CompletedTask;
        }

        public override string ToXMLAction()
        {
            return $"Hue.{nameof(TurnOffLight)}({LightName})";
        }
    }
}

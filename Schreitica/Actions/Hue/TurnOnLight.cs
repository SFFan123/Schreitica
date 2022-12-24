using System.Threading.Tasks;

namespace Schreitica.Actions.Hue
{
    public class TurnOnLight:SetLightBase
    {
        public string LightName { get; set; }

        public TurnOnLight(string LightName)
        {
            this.LightName = LightName;
        }

        public override async Task<object> ExecuteAsync()
        {
            await base.ExecuteAsync();
            await SetLight(LightName, "{\"on\":true}");
            return Task.CompletedTask;
        }

        public override string ToXMLAction()
        {
            return $"Hue.{nameof(TurnOnLight)}({LightName})";
        }

        public override string LogName => "Hue." + nameof(TurnOnLight);
    }
}

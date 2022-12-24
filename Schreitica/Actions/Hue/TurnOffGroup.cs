using System.Threading.Tasks;

namespace Schreitica.Actions.Hue
{
    public class TurnOffGroup:SetLightBase
    {
        public string GroupName { get; set; }

        public TurnOffGroup(string GroupName)
        {
            this.GroupName = GroupName;
        }

        public override async Task<object> ExecuteAsync()
        {
            await base.ExecuteAsync();
            await SetGroup(GroupName, "{\"on\":true}");
            return Task.CompletedTask;
        }

        public override string ToXMLAction()
        {
            return $"Hue.{nameof(Hue.TurnOffGroup)}({GroupName})";
        }

        public override string LogName => "Hue." + nameof(TurnOffGroup);
    }
    
}
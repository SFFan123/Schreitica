using System;
using System.Text.RegularExpressions;
using Schreitica.Actions;
using Schreitica.Actions.Hue;
using Schreitica.Actions.OBS;

namespace Schreitica
{
    internal static class CommandParser
    {
        private static Regex MethodRegex = new Regex(@"^(?<method>\w+)\(((?<parameter>\w+)(?:, )?)+\)");
        
        public static IActionBase ParseOBSCommand(string command)
        {
            if (string.IsNullOrEmpty(command))
                return null;
            command = command.Trim();
            if (command == string.Empty)
                return null;

            IActionBase resultCommand = null;
            Match methodMatch;
            
            methodMatch = MethodRegex.Match(command);
            if (methodMatch.Success)
            {
                switch (methodMatch.Groups["method"].Value)
                {
                    case nameof(HideSource):
                    {
                        resultCommand = new HideSource(methodMatch.Groups["parameter"].Value, null);
                        break;
                    }
                    case nameof(ShowSource):
                    {
                        resultCommand = new ShowSource(methodMatch.Groups["parameter"].Value, null);
                        break;
                    }
                    case nameof(SwitchScene):
                    {
                        resultCommand = new SwitchScene(methodMatch.Groups["parameter"].Value);
                        break;
                    }
                    default:
                    {
                        throw new NotSupportedException();
                    }
                }
            }
            return resultCommand;
        }

        public static AppAction ParseAppCommand(string command)
        {
            if (string.IsNullOrEmpty(command))
                return null;
            command = command.Trim();
            if (command == string.Empty)
                return null;


            Match methodMatch;
            
            methodMatch = MethodRegex.Match(command);
            if (methodMatch.Success)
            {
                string method = methodMatch.Groups["method"].Value;

                switch (method)
                {
                    case "WaitFor":
                    {
                        string name = methodMatch.Groups["parameter"].Value;
                        return new WaitForEventAction(name);
                    }
                    
                    case "Wait":
                        return new WaitAction(int.Parse(methodMatch.Groups["parameter"].Value));
                }
            }

            return null;
        }

        public static HueBase ParseHueCommand(string command)
        {
            if (string.IsNullOrEmpty(command))
                return null;
            command = command.Trim();
            if (command == string.Empty)
                return null;


            Match methodMatch;
            
            methodMatch = MethodRegex.Match(command);
            if (methodMatch.Success)
            {
                string method = methodMatch.Groups["method"].Value;

                switch (method)
                {
                    case nameof(TurnOffLight):
                    {
                        string name = methodMatch.Groups["parameter"].Value;
                        return new TurnOffLight(name);
                    }
                    case nameof(TurnOnLight):
                    {
                        string name = methodMatch.Groups["parameter"].Value;
                        return new TurnOnLight(name);
                    }
                }
            }
            return null;
        }
    }

    
}

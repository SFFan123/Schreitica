﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Schreitica.Actions;

namespace Schreitica
{
    internal static class Commands
    {
        #region OBS
        public static string CurrentScene { get; } = @"string sceneName = obs.GetCurrentProgramScene();";


        /// <summary>
        /// requires obs
        /// requires sceneName to be filled.
        /// input string sceneName
        /// </summary>
        public static string ShowSource(string sourceName)
        {
            return
                $"int id = obs.GetSceneItemList(sceneName).FirstOrDefault(x => x.SourceName.Equals(\"{sourceName}\"))?.ItemId ?? -1; " +
                "if(id == -1) return; " + "obs.SetSceneItemEnabled(sceneName, id , true );";
        }


        public static string HideSource(string sourceName)
        {
            return
                $"int id = obs.GetSceneItemList(sceneName).FirstOrDefault(x => x.SourceName.Equals(\"{sourceName}\"))?.ItemId ?? -1; " +
                "if(id == -1) return; " + "obs.SetSceneItemEnabled(sceneName, id , false );";
        }


        public static async void Wait(TimeSpan timeSpan)
        {
            await Task.Delay(timeSpan);
        }
        #endregion


    }

    internal static class CommandParser
    {
        private static Regex MethodRegex = new Regex(@"^(?<method>\w+)\((?<parameter>\w+)\)");
        private static Regex PropertyRegex = new Regex(@"^\w+(?=\.)");

        public static string ParseOBSCommand(string command)
        {
            if (string.IsNullOrEmpty(command))
                return string.Empty;
            command = command.Trim();
            if (command == string.Empty)
                return string.Empty;

            string resultCommand = string.Empty;
            string cache;
            PropertyInfo prop;
            MethodInfo method;
            Match methodMatch;
            Match propertyMatch;
            do
            {
                propertyMatch = PropertyRegex.Match(command);
                if (propertyMatch.Success)
                {
                    prop = typeof(Commands).GetProperty(propertyMatch.Value);
                    if(prop == null)
                    {
                        // error
                        return string.Empty;
                    }

                    cache = (string)prop.GetValue(null);

                    
                    resultCommand = string.Join(" ", resultCommand, cache);


                    rmMatch(ref command, propertyMatch.Value);
                    prop = null;
                }

                if (command.Length == 0)
                    break;

                methodMatch = MethodRegex.Match(command);
                if (methodMatch.Success)
                {
                    method = typeof(Commands).GetMethod(methodMatch.Groups["method"].Value);

                    if (method == null)
                    {
                        // error
                        return string.Empty;
                    }

                    cache = (string)method.Invoke(obj: null,
                        parameters: new object[] { methodMatch.Groups["parameter"].Value });


                    resultCommand = string.Join(" ", resultCommand, cache);

                    rmMatch(ref command, methodMatch.Value);
                    method = null;
                }


            } while (command.Length > 0);

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


        private static void rmMatch(ref string str, string match)
        {
            str = str.Substring(match.Length);

            if (str.Length > 0 && str[0] == '.')
            {
                str = str.Substring(1);
            }
        }
    }

    
}

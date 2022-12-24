using System;
using System.Linq;
using OBSWebsocketDotNet;

namespace Schreitica.Actions.OBS
{
    public class OBSBase
    {
        protected OBSWebsocket GetObsConnection()
        {
            if (!(Program.OBSConnection?.IsConnected ?? false))
            {
                throw new ApplicationException("Obs not connected");
            }
            
            return Program.OBSConnection.obs;
        }

        protected string CurrentSceneName => GetObsConnection().GetCurrentProgramScene();

        public void T(string sceneName, string sourceName)
        {
            var obs = GetObsConnection();
            
        }



    }
}
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using OBSWebsocketDotNet;
using OBSWebsocketDotNet.Communication;
using OBSWebsocketDotNet.Types;
using OBSWebsocketDotNet.Types.Events;

namespace Schreitica
{
    internal class OBSConenction
    {
        private static OBSConenction instance;
        public static OBSConenction Instance => instance;
        protected OBSWebsocket obs;
        public OBSConenction(string url, SecureString password)
        {
            if (instance != null)
            {
                throw new Exception();
            }
            obs = new OBSWebsocket();

            obs.Connected += OnConnect;
            obs.Disconnected += OnDisconnect;

            //obs.CurrentProgramSceneChanged += onCurrentProgramSceneChanged;
            //obs.CurrentSceneCollectionChanged += onSceneCollectionChanged;
            //obs.CurrentProfileChanged += onCurrentProfileChanged;
            //obs.CurrentSceneTransitionChanged += onCurrentSceneTransitionChanged;
            //obs.CurrentSceneTransitionDurationChanged += onCurrentSceneTransitionDurationChanged;

            //obs.StreamStateChanged += onStreamStateChanged;
            //obs.RecordStateChanged += onRecordStateChanged;


            obs.ConnectAsync(url, new NetworkCredential(string.Empty, password).Password);
            instance = this;
        }

        public bool IsConnected => obs.IsConnected;

        private void OnConnect(object sender, EventArgs e)
        {
            AppEvents.RaiseOBSConnectionStateChanged(this, new ConnectionChangedEventArgs(true));
        }

        private void OnDisconnect(object sender, ObsDisconnectionInfo obsDisconnectionInfo)
        {
            AppEvents.RaiseOBSConnectionStateChanged(this, new ConnectionChangedEventArgs(false));
        }
    }
}

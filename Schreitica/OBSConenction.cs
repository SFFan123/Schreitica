using System;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using OBSWebsocketDotNet;
using OBSWebsocketDotNet.Communication;
using OBSWebsocketDotNet.Types;
using OBSWebsocketDotNet.Types.Events;

namespace Schreitica
{
    public class OBSConenction
    {
        private static OBSConenction instance;
        public static OBSConenction Instance => instance;
        public OBSWebsocket obs;

        private string url;
        private SecureString passwd;
        private bool shouldReconnect = false;
        public OBSConenction(string url, SecureString password, bool autoConnected)
        {
            if (instance != null)
            {
                throw new Exception();
            }
            obs = new OBSWebsocket();

            obs.Connected += OnConnect;
            obs.Disconnected += OnDisconnect;

            passwd = password;
            this.url = url;

            //obs.CurrentProgramSceneChanged += onCurrentProgramSceneChanged;
            //obs.CurrentSceneCollectionChanged += onSceneCollectionChanged;
            //obs.CurrentProfileChanged += onCurrentProfileChanged;
            //obs.CurrentSceneTransitionChanged += onCurrentSceneTransitionChanged;
            //obs.CurrentSceneTransitionDurationChanged += onCurrentSceneTransitionDurationChanged;

            //obs.StreamStateChanged += onStreamStateChanged;
            //obs.RecordStateChanged += onRecordStateChanged;
            if (autoConnected)
            {
                Connect();
            }
            
            
            instance = this;
        }

        public bool IsConnected => obs?.IsConnected ?? false;


        public void Connect()
        {
            Task.Run(async () =>
            {
                while (!IsConnected)
                {
                    obs.ConnectAsync(url, new NetworkCredential(string.Empty, passwd).Password);
                    await Task.Delay(1000);
                }
            });
        }

        private async void OnConnect(object sender, EventArgs e)
        {
            AppEvents.RaiseOBSConnectionStateChanged(this, new ConnectionChangedEventArgs(true));

            shouldReconnect = true;

            //string test = "CurrentScene.ShowSource(ALARM)";


            //string cssharpScript = CommandParser.ParseCommand(test);

            //await CSharpScript.EvaluateAsync(cssharpScript,
            //    ScriptOptions.Default
            //        .AddReferences(typeof(Enumerable).GetTypeInfo().Assembly)
            //        .AddImports("System", "System.Linq"),
            //    globals: this);

        }


        private void OnDisconnect(object sender, ObsDisconnectionInfo obsDisconnectionInfo)
        {
            AppEvents.RaiseOBSConnectionStateChanged(this, new ConnectionChangedEventArgs(false));
            if(shouldReconnect)
                Connect();
        }
    }
}

using System;
using System.Net;
using System.Security;
using System.Threading.Tasks;
using OBSWebsocketDotNet;
using OBSWebsocketDotNet.Communication;

namespace Schreitica
{
    public class OBSConenction : IDisposable
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

        private void OnConnect(object sender, EventArgs e)
        {
            AppEvents.RaiseOBSConnectionStateChanged(this, new ConnectionChangedEventArgs(true));

            shouldReconnect = true;
        }


        private void OnDisconnect(object sender, ObsDisconnectionInfo obsDisconnectionInfo)
        {
            AppEvents.RaiseOBSConnectionStateChanged(this, new ConnectionChangedEventArgs(false));
            if(shouldReconnect)
                Connect();
        }

        public void Dispose()
        {
            shouldReconnect = false;
            obs.Connected -= OnConnect;
            obs.Disconnected -= OnDisconnect;
            obs.Disconnect();
            obs = null;
            GC.Collect();
        }
    }
}

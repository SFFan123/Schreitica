using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schreitica
{
    public static class AppEvents
    {
        public static event EventHandler<ConnectionChangedEventArgs> USBConnectionStateChanged;
        public static event EventHandler<ConnectionChangedEventArgs> OBSConnectionStateChanged;

        public static event EventHandler ThresholdExceeded;
        public static event EventHandler BelowThresholdAgain;

        public static event EventHandler<ReadOutEventArgs> OnReadOut;


        public static bool CanRaiseBlowThreshold { get; private set; } = false;

        public static void RaiseUSBConnectionStateChanged(object sender, ConnectionChangedEventArgs e)
        {
            EventHandler<ConnectionChangedEventArgs> handler = USBConnectionStateChanged;
            handler?.Invoke(sender,e);
        }

        public static void RaiseOBSConnectionStateChanged(object sender, ConnectionChangedEventArgs e)
        {
            EventHandler<ConnectionChangedEventArgs> handler = OBSConnectionStateChanged;
            handler?.Invoke(sender,e);
        }


        public static void RaiseThresholdExceeded(object sender, EventArgs e)
        {
            CanRaiseBlowThreshold = true;
            EventHandler handler = ThresholdExceeded;
            handler?.Invoke(sender,e);
        }


        public static void RaiseBelowThresholdAgain(object sender, EventArgs e)
        {
            if (!CanRaiseBlowThreshold)
                return;

            EventHandler handler = BelowThresholdAgain;
            handler?.Invoke(sender,e);

            CanRaiseBlowThreshold = false;
        }

        public static void RaiseOnReadOut(object sender, ReadOutEventArgs e)
        {
            EventHandler<ReadOutEventArgs> handler = OnReadOut;
            handler?.Invoke(sender, e);
        }


    }

    public class ConnectionChangedEventArgs : EventArgs
    {
        public ConnectionChangedEventArgs(bool connected)
        {
            this.Connected = connected;
        }
        public bool Connected;
    }

    public class ReadOutEventArgs : EventArgs
    {
        public ReadOutEventArgs(double dba)
        {
            Dba = dba;
        }
        public double Dba;
    }
}

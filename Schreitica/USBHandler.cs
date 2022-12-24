using System;
using System.Linq;
using System.Threading.Tasks;
using HidLibrary;

namespace Schreitica
{
    public class USBHandler
    {
        private bool _isConnected;

        private HidDevice device;
        private readonly int PID = 0x5750;
        private readonly int VID = 0x0483;
        
        /// <summary>
        /// Delay in ms
        /// </summary>
        public int pollingDelay;
        private Task PollingTask;
        private Task ReadingTask;
        private bool running;

        public USBHandler()
        {
            pollingDelay = Settings.Instance.USBPollingDelay == default? 1000: Settings.Instance.USBPollingDelay;
            Task.Run(async () =>
            {
                while (true)
                {
                    device = HidDevices.Enumerate(VID, PID).FirstOrDefault();
                    if (device == null)
                        await Task.Delay(1000);
                    else
                        break;
                }

                device.MonitorDeviceEvents = true;

                device.Removed += delegate { IsConnected = false; };
                device.Inserted += delegate { IsConnected = true; };
            });
        }

        public bool IsConnected
        {
            get => _isConnected;
            private set
            {
                if (value != _isConnected)
                {
                    _isConnected = value;
                    AppEvents.RaiseUSBConnectionStateChanged(this, new ConnectionChangedEventArgs(value));
                }
            }
        }

        public void StartReading()
        {
            if (!IsConnected) throw new ApplicationException();
            running = false;
            PollingTask?.Dispose();

            running = true;
            PollingTask = QueryTask();
            ReadingTask = ReadTask();
        }

        public void StopReading()
        {
            running = false;
            PollingTask?.Dispose();
            ReadingTask?.Dispose();
        }


        private async Task ReadTask()
        {
            while (running)
            {
                while (!IsConnected)
                    await Task.Delay(1000);

                var report = await device.ReadReportAsync();

                var dat = report.Data;
                var rawVal = (dat[0] << 8) | dat[1];
                var db = rawVal / 10.0;

                db = Math.Round(db, 1);

                AppEvents.RaiseOnReadOut(this, new ReadOutEventArgs(db));

                if (db > Settings.Instance.DbThreshold)
                    AppEvents.RaiseThresholdExceeded(this, EventArgs.Empty);
                else if (AppEvents.CanRaiseBlowThreshold) AppEvents.RaiseBelowThresholdAgain(this, EventArgs.Empty);
            }
        }

        private async Task QueryTask()
        {
            while (running)
            {
                while (!IsConnected)
                    await Task.Delay(1000);

                var report = device.CreateReport();

                report.ReportId = 179;
                report.Data = new byte[] { 0xb3 };

                device.WriteReport(report);

                await Task.Delay(pollingDelay);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;
using HidLibrary;

namespace Schreitica
{
    public class USBHandler
    {
        private int VID = 0x0483;
        private int PID = 0x5750;
        private bool _isConnected = false;

        private HidDevice device;

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
        private bool running = false;
        public int pollingDelay = 1000;
        private Task PollingTask;
        private Task ReadingTask;


        public USBHandler()
        {
            Task.Run( async () =>
            {
                while (true)
                {
                    device = HidDevices.Enumerate(VID, PID).FirstOrDefault();
                    if (device == null)
                    {
                        await Task.Delay(1000);
                    }
                    else
                    {
                        break;
                    }
                }
                device.MonitorDeviceEvents = true;
               
                device.Removed += delegate
                {
                    IsConnected = false;
                };
                device.Inserted += delegate
                {
                    IsConnected = true;
                };
            });
        }

        public void StartReading()
        {
            if (!IsConnected)
            {
                throw new ApplicationException();
            }
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
                int rawVal = (dat[0] << 8 | dat[1]); 
                double db = rawVal / 10.0;

                db = Math.Round(db, 1);

                AppEvents.RaiseOnReadOut(this, new ReadOutEventArgs(db));

                if (db > Settings.Instance.DbThreshold)
                {
                    AppEvents.RaiseThresholdExceeded(this, EventArgs.Empty);
                }
                else if( AppEvents.CanRaiseBlowThreshold)
                {
                    AppEvents.RaiseBelowThresholdAgain(this, EventArgs.Empty);
                }


                // LOG
                //Console.WriteLine($"{db:F1} dBA");
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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32.SafeHandles;
using Schreitica.Properties;

namespace Schreitica
{
    public partial class Schreitica : Form
    {
        public Schreitica()
        {
            this.Icon = Resources.AppIcon;
            InitializeComponent();

            UsbConnectionStateChanged(null, new ConnectionChangedEventArgs( Program.USBHandler.IsConnected ));
            OBSConnectionStateChanged(null, new ConnectionChangedEventArgs( OBSConenction.Instance.IsConnected ));

            AppEvents.USBConnectionStateChanged += UsbConnectionStateChanged;
            AppEvents.OBSConnectionStateChanged += OBSConnectionStateChanged;

            init_GetValues();
        }

        private void init_ParsePollingDelay()
        {
            double delay = Program.USBHandler.pollingDelay;

            double hz = 1000 / delay;

            this.numUpDown_PollingRate.Value = (decimal)hz;
        }

        private void init_GetValues()
        {
            txt_OBS_Password.Text =
                new NetworkCredential(string.Empty, CryptHelper.Decrypt(Settings.Instance.OBSPassword)).Password;
            txt_OBS_URL.Text = Settings.Instance.OBSUrl;
            init_ParsePollingDelay();
        }

        private void UsbConnectionStateChanged(object sender, ConnectionChangedEventArgs e)
        {
            this.btn_Start.Enabled = e.Connected;
            this.toolstrip_lbl_Connection.Text = e.Connected ? "Connected" : "Disconnected";
        }
        private void OBSConnectionStateChanged(object sender, ConnectionChangedEventArgs e)
        {
            this.toolStripStatusLabel_OBS_Status.Text = e.Connected ? "Connected" : "Disconnected";
        }

        private void saveSettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SettingHelper.SaveSetting(Settings.Instance.ToXML());
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                MessageBox.Show(exception.Message, exception.GetType().Name, MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void checkBox_ShowOBSPassword_CheckedChanged(object sender, EventArgs e)
        {
            txt_OBS_Password.PasswordChar = checkBox_ShowOBSPassword.Checked ? '\0' : '*';
        }

        private void btn_Start_Click(object sender, EventArgs e)
        {
            Program.USBHandler.StartReading();
        }

        private void btn_Stop_Click(object sender, EventArgs e)
        {
            Program.USBHandler.StopReading();
        }
    }
}

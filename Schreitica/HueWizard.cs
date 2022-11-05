using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Schreitica
{
    public partial class HueWizard : Form
    {
        public HueWizard()
        {
            InitializeComponent();
        }



        private void SearchHue()
        {
            string defaultHueName = "Philips-Hue-Hub";

            var adresses = Dns.GetHostAddresses(defaultHueName);

            if (adresses.Length == 0)
            {
                MessageBox.Show("Hue Bridge nicht gefunden.");
                return;
            }

            mtxt_HueIp.Text = adresses[0].ToString();
        }

        private void PingHue()
        {
            Ping ping = null;
            IPAddress address = IPAddress.Parse(mtxt_HueIp.Text);
            
            try
            {
                ping = new Ping();
                if (ping.Send(address).Status != IPStatus.Success)
                {
                    MessageBox.Show("Hue Bridge nicht pingbar.");
                    checkBox1.Checked = false;
                }
                else
                {
                    checkBox1.Checked = true;
                }
            }
            catch (PingException pe)
            {
                MessageBox.Show("Fehler beim Hue Bridge pingen.");
                checkBox1.Checked = false;
            }
            finally
            {
                if (ping != null)
                {
                    ping.Dispose();
                }
            }
        }


        private void Search_Click(object sender, EventArgs e)
        {
            SearchHue();
            PingHue();
        }

        private void Ping_Click(object sender, EventArgs e)
        {
            PingHue();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Results;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace Schreitica
{
    public partial class HueWizard : Form
    {
        public HueWizard()
        {
            InitializeComponent();
            this.DialogResult = DialogResult.Cancel;
        }

        public string UserName => txtHueUser.Text;
        public string HueAdress => txt_HueIp.Text;
        public bool IgnoreSSLCertError => checkbox_ignoreSSLCertError.Checked;

        private void PingHue()
        {
            Ping ping = null;

            try
            {
                ping = new Ping();
                var stat = ping.Send(txt_HueIp.Text).Status;
                if (stat != IPStatus.Success)
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
                if (pe.InnerException is SocketException se)
                {
                    if (se.ErrorCode == 11001) // Host not found
                    {
                        MessageBox.Show("Hue Bridge pingen nicht unter diesen namen gefunden.");
                        return;
                    }
                }
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

        private void CreateUser()
        {
            HttpClient client = new HttpClient();
            HttpRequestMessage UserRequest = new HttpRequestMessage(method: HttpMethod.Post, requestUri: "/api");
            UserRequest.Content = new StringContent("{\"devicetype\":\"SchreiticaApp\"}");
            UserRequest.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
            
            client.BaseAddress = new Uri("https://" + txt_HueIp.Text);
            if (checkbox_ignoreSSLCertError.Checked)
            {
                ServicePointManager.ServerCertificateValidationCallback +=
                    (sender, cert, chain, sslPolicyErrors) => true;
            }

            HttpResponseMessage result;
            try
            {
                using (client)
                {
                    result = client.SendAsync(UserRequest).GetAwaiter().GetResult();
                }
            }
            catch (HttpRequestException e)
            {
                MessageBox.Show(e.InnerException?.Message?? e.Message);
                return;
            }
            

            if (result.StatusCode != HttpStatusCode.OK)
            {
                // error
            }

            var jarray = JArray.Parse(result.Content.ReadAsStringAsync().Result);
            


            if (jarray.First()["error"] != null)
            {
                MessageBox.Show(jarray.First()["error"]["description"].ToString());
                return;
            }
            else if (jarray.First()["success"] != null)
            {
                txtHueUser.Text = jarray.First()["success"]["username"].ToString();
            }
        }


        private void TestHue()
        {
            bool TestResult = false;

            HttpClient client = new HttpClient();
            HttpRequestMessage UserRequest = new HttpRequestMessage(method: HttpMethod.Get, requestUri: "/api/" + txtHueUser.Text);

            client.BaseAddress = new Uri("https://" + txt_HueIp.Text);
            if (checkbox_ignoreSSLCertError.Checked)
            {
                ServicePointManager.ServerCertificateValidationCallback +=
                    (sender, cert, chain, sslPolicyErrors) => true;
            }

            HttpResponseMessage result;
            try
            {
                using (client)
                {
                    result = client.SendAsync(UserRequest).GetAwaiter().GetResult();
                }
            }
            catch (HttpRequestException e)
            {
                MessageBox.Show(e.InnerException?.Message?? e.Message);
                check_HueTest.Checked = TestResult;
                return;
            }

            string resultContent = result.Content.ReadAsStringAsync().Result;

            try
            {
                var jarray = JArray.Parse(resultContent);
                
                if (jarray.First()["error"] != null)
                {
                    MessageBox.Show(jarray.First()["error"]["description"].ToString());
                    check_HueTest.Checked = TestResult;
                    return;
                }
            }
            catch (Exception) { }

            try
            {
                var jObject = JObject.Parse(resultContent);

                if (jObject.ContainsKey("lights"))
                {
                    TestResult = true;
                }
               
            }
            catch (Exception) { }

            check_HueTest.Checked = TestResult;
        }

        private void Ping_Click(object sender, EventArgs e)
        {
            PingHue();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CreateUser();
        }

        private void CheckChange(object sender, EventArgs e)
        {
            txtHueUser.UseSystemPasswordChar = !checkBoxShowPW.Checked;
        }

        private void button4_Click(object sender, EventArgs e)
        {

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TestHue();
        }
    }
}

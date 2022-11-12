using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Schreitica.Actions.Hue
{
    public abstract class SetLightBase : HueBase
    {
        protected const string GetLightsURLFormat = "/api/{0}/lights/";
        protected const string SetLightURLFormat = "/api/{0}/lights/{1}/state";

        protected async Task SetLight(string LightName, string body)
        {
            if (string.IsNullOrEmpty(LightName))
                throw new ArgumentNullException(nameof(LightName));

            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(Settings.Instance.HueURL);

                var result = await httpClient.GetAsync(string.Format(GetLightsURLFormat, Settings.Instance.HueUser));

                if (result.StatusCode != HttpStatusCode.OK)
                {
                    // error
                    throw new Exception();
                }

                JObject resultContent = JObject.Parse(await result.Content.ReadAsStringAsync());
                string id = string.Empty;
                foreach (JProperty property in resultContent.Properties())
                {
                    if (property.Value["name"].ToString() == LightName)
                    {
                        id = property.Name;
                        break;
                    }
                }

                if (string.IsNullOrEmpty(id))
                    throw new Exception();

                HttpContent request = new StringContent(body);
                request.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

                var setResult =
                    await httpClient.PutAsync(string.Format(SetLightURLFormat, Settings.Instance.HueUser, id), request);

                if (!setResult.IsSuccessStatusCode)
                {
                    throw new Exception();
                }
            }
        }
    }
}
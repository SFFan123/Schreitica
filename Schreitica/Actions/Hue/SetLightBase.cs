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
        
        protected const string GetGroupsURLFormat = "/api/{0}/groups/";
        protected const string SetGroupURLFormat = "/api/{0}/groups/{1}/action";

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
                    throw new Exception("Error Querying Lights");
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
                    throw new Exception("Error Finding Light");

                HttpContent request = new StringContent(body);
                request.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

                var setResult =
                    await httpClient.PutAsync(string.Format(SetLightURLFormat, Settings.Instance.HueUser, id), request);

                if (!setResult.IsSuccessStatusCode)
                {
                    throw new Exception("Error Setting Light state");
                }
            }
        }

        protected async Task SetGroup(string GroupName, string body)
        {
            if (string.IsNullOrEmpty(GroupName))
                throw new ArgumentNullException(nameof(GroupName));

            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(Settings.Instance.HueURL);

                var result = await httpClient.GetAsync(string.Format(GetGroupsURLFormat, Settings.Instance.HueUser));

                if (result.StatusCode != HttpStatusCode.OK)
                {
                    // error
                    throw new Exception("Error Querying Groups");
                }

                JObject resultContent = JObject.Parse(await result.Content.ReadAsStringAsync());
                string id = string.Empty;
                foreach (JProperty property in resultContent.Properties())
                {
                    if (property.Value["name"].ToString() == GroupName)
                    {
                        id = property.Name;
                        break;
                    }
                }

                if (string.IsNullOrEmpty(id))
                    throw new Exception("Error Finding Group");
                

                HttpContent request = new StringContent(body);
                request.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

                var setResult =
                    await httpClient.PutAsync(string.Format(SetGroupURLFormat, Settings.Instance.HueUser, id), request);

                if (!setResult.IsSuccessStatusCode)
                {
                    throw new Exception("Error Setting Group state");
                }
            }
        }
        
    }
}
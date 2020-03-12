using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Web.Script.Serialization;

namespace LiveSplit.CatchTheRun
{
    internal class ApiClient
    {
        private readonly HttpClient Client = new HttpClient();
        private readonly JavaScriptSerializer Serializer = new JavaScriptSerializer();
        private readonly Uri BasePath = new Uri("https://catch-the-run-website.cyghfer.now.sh");

        internal async Task<bool> VerifyClientCredentials(string twitchUsername, string clientKey)
        {
            var endpoint = new Uri(BasePath, "credentials/verify");
            var serialized = Serializer.Serialize(new ClientCredentials() { ClientID = twitchUsername, ClientKey = clientKey });
            var content = new StringContent(serialized);
            var response = await Client.PostAsync(endpoint, content);
            return response.StatusCode == HttpStatusCode.OK;
        }

        internal async Task<bool> SaveNewFeedCategory()
        {
            return true;
        }

        internal async Task<bool> DeleteFeedCategory()
        {
            return true;
        }

        internal async Task<bool> SendNotificationsRequest(EventRequestBody requestBody, ClientCredentials credentials)
        {
            var endpoint = new Uri(BasePath, "event");
            var serialized = Serializer.Serialize(requestBody);
            var content = new StringContent(serialized);
            content.Headers.Add("ClientID", credentials.ClientID);
            content.Headers.Add("ClientKey", credentials.ClientKey);
            var response = await Client.PostAsync(endpoint, content);
            return response.StatusCode == HttpStatusCode.OK;
        }
    }
}

using System;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Web.Script.Serialization;
using System.Text;

namespace LiveSplit.CatchTheRun
{
    internal class ApiClient
    {
        private readonly HttpClient Client = new HttpClient();
        private readonly JavaScriptSerializer Serializer = new JavaScriptSerializer();
        private readonly Uri BasePath = new Uri("https://catch-the-run-website.cyghfer.now.sh/");

        internal async Task<bool> RegisterProducerCategory(string accountGuid, string producer, string game, string category)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var endpoint = new Uri(BasePath, "api/feed/category/create");
            var serialized = Serializer.Serialize(new RegisterFeedCategoryRequest() { Producer =  producer, Game = game, Category = category});
            var content = new StringContent(serialized, Encoding.UTF8, "application/json");
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            content.Headers.Add("Account-Guid", accountGuid);
            var response = await Client.PostAsync(endpoint, content);
            return response.StatusCode == HttpStatusCode.OK;
        }

        internal async Task<bool> UnregisterProducerCategory(string accountGuid, string producer, string game, string category)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var endpoint = new Uri(BasePath, $"api/feed/category/delete?Producer={producer}&Game={game}&Category={category}");
            var response = await Client.DeleteAsync(endpoint);
            return response.StatusCode == HttpStatusCode.OK;
        }

        internal async Task<bool> SendNotificationsRequest(string accountGuid, EventRequestBody requestBody)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var endpoint = new Uri(BasePath, "event");
            var serialized = Serializer.Serialize(requestBody);
            var content = new StringContent(serialized, Encoding.UTF8, "application/json");
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            content.Headers.Add("Account-Guid", accountGuid);
            var response = await Client.PostAsync(endpoint, content);
            return response.StatusCode == HttpStatusCode.OK;
        }
    }
}

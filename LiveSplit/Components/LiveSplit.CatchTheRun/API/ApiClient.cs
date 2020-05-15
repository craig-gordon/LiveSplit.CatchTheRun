using System;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Web.Script.Serialization;
using System.Text;

namespace LiveSplit.CatchTheRun
{
    internal class ApiClient : IDisposable
    {
        private readonly HttpClient HttpClient = new HttpClient();
        private readonly JavaScriptSerializer Serializer = new JavaScriptSerializer();
        private readonly Uri BasePath = new Uri("https://catch-the-run-website-staging.now.sh");

        internal async Task<HttpResponseMessage> GetTwitchUsername(string twitchUserId)
        {
            return await SendRequest(null, HttpMethod.Get, "api/producer/twitch/username", null, $"?id={twitchUserId}");
        }

        internal async Task<HttpResponseMessage> RegisterProducerCategory(string producerKey, RegisterProducerCategoryCommand cmd)
        {
            var serialized = Serializer.Serialize(cmd);
            return await SendRequest(producerKey, HttpMethod.Post, "api/producer/category", serialized);
        }

        internal async Task<HttpResponseMessage> UnregisterProducerCategory(string producerKey, UnregisterProducerCategoryCommand cmd)
        {
            return await SendRequest(producerKey, HttpMethod.Delete, "api/producer/category", null, $"?TwitchId={cmd.TwitchId}&Game={cmd.Game}&Category={cmd.Category}");
        }

        internal async Task<HttpResponseMessage> PushEvent(string producerKey, EventCommand cmd)
        {
            var serialized = Serializer.Serialize(cmd);
            return await SendRequest(producerKey, HttpMethod.Post, "api/event", serialized, null);
        }

        protected async Task<HttpResponseMessage> SendRequest(string producerKey, HttpMethod httpMethod, string relativePath, string payload = null, string queryString = null)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            if (queryString != null)
                relativePath += queryString;

            var endpoint = new Uri(BasePath, relativePath);
            var request = new HttpRequestMessage(httpMethod, endpoint);

            if (payload != null)
                request.Content = new StringContent(payload, Encoding.UTF8, "application/json");

            if (producerKey != null)
                request.Headers.Add("x-producer-key", producerKey);

            return await HttpClient.SendAsync(request);
        }

        public void Dispose()
        {
            HttpClient.Dispose();
        }
    }
}

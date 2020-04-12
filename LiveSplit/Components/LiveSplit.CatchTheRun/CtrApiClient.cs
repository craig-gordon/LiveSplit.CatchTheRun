using System;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Web.Script.Serialization;
using System.Text;

namespace LiveSplit.CatchTheRun
{
    internal class CtrApiClient
    {
        private readonly HttpClient HttpClient = new HttpClient();
        private readonly JavaScriptSerializer Serializer = new JavaScriptSerializer();
        private readonly Uri BasePath = new Uri("https://catch-the-run-website.cyghfer.now.sh/");

        internal async Task<bool> RegisterProducerCategory(string producerKey, string producer, string game, string category)
        {
            var serialized = Serializer.Serialize(new RegisterFeedCategoryRequest() { Producer =  producer, Game = game, Category = category});
            var response = await SendRequest(producerKey, HttpMethod.Post, "api/feed/category", serialized);
            return response.StatusCode == HttpStatusCode.OK;
        }

        internal async Task<bool> UnregisterProducerCategory(string producerKey, string producer, string game, string category)
        {
            var response = await SendRequest(producerKey, HttpMethod.Delete, "api/feed/category", null, $"?Producer={producer}&Game={game}&Category={category}");
            return response.StatusCode == HttpStatusCode.OK;
        }

        internal async Task<bool> PushEvent(string producerKey, EventRequestBody requestBody)
        {
            var serialized = Serializer.Serialize(requestBody);
            var response = await SendRequest(producerKey, HttpMethod.Post, "event", serialized, serialized);
            return response.StatusCode == HttpStatusCode.OK;
        }

        protected async Task<HttpResponseMessage> SendRequest(string producerKey, HttpMethod httpVerb, string relativePath, string payload = null, string queryString = null)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            if (queryString != null)
                relativePath += queryString;

            var endpoint = new Uri(BasePath, relativePath);
            var request = new HttpRequestMessage(httpVerb, endpoint);

            if (payload != null)
                request.Content = new StringContent(payload, Encoding.UTF8, "application/json");

            request.Headers.Add("Producer-Key", producerKey);
            return await HttpClient.SendAsync(request);
        }
    }
}

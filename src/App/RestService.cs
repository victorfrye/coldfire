using System.Net.Http.Headers;
using System.Text.Json;

namespace VictorFrye.Coldfire.App
{
    public abstract class RestService<T> : IRestService<T>
    {
        protected readonly Uri _baseUri;
        protected readonly HttpClient _client;
        protected readonly JsonSerializerOptions _serializerOptions;

        public RestService(Uri baseUri)
        {
#if DEBUG
            var clientHandlerService = new HttpsClientHandlerService();
            var handler = clientHandlerService.GetPlatformMessageHandler();

            _client = handler == null
                ? new HttpClient() 
                : new HttpClient(handler);
#else

            _client = new HttpClient();
#endif
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            _baseUri = baseUri;

            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }

        public abstract Task<T> SendGet(int id);
    }
}

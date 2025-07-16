using SpaceStation.Enums;
using SpaceStation.Models;
using SpaceStation.Interfaces;
using System.Collections.Specialized;
using System.Text.Json;
using System.Text;

namespace SpaceStation.DataLayer
{
    public class RestWorker : IRestWorker
    {
        private static readonly HttpClient httpClient = new();
        public async Task<T> CallService<T>(Uri uri, HttpVerb httpVerb = HttpVerb.Get, object data = null, NameValueCollection headerData = null) where T : BaseResponse, new()
        {
            T result = default;
            StringContent _content = null;

            if (data is not null)
            {
                var mediaType = "application/json";
                var encoding = Encoding.UTF8;
                _content = new StringContent(JsonSerializer.Serialize(data), encoding, mediaType);
            }

            var _method = VerbMethod(httpVerb);
            var request = new HttpRequestMessage()
            {
                RequestUri = uri,
                Method = _method,
                Content = _content
            };

            if (headerData is not null)
            {
                foreach (string key in headerData)
                {
                    request.Headers.Add(key, headerData.Get(key));
                }
            }

            var response = await httpClient.SendAsync(request);

            if (response is not null)
            {
                var resultData = await response.Content.ReadAsStringAsync();

                if (string.IsNullOrEmpty(resultData))
                {
                    result = new T();
                }
                else
                {
                    result = JsonSerializer.Deserialize<T>(resultData);
                }

                result.StatusCode = response.StatusCode;
                result.IsErrorResponse = !response.IsSuccessStatusCode;
            }

            return result;

        }
        //RC need this because we cannot set a default HttpMethod at compile time unless it is a constant
        private static HttpMethod VerbMethod(HttpVerb httpVerb) => httpVerb switch
        {
            HttpVerb.Get => HttpMethod.Get,
            HttpVerb.Post => HttpMethod.Post,
            HttpVerb.Put => HttpMethod.Put,
            HttpVerb.Delete => HttpMethod.Delete,
            _ => HttpMethod.Get,
        };
    }
}
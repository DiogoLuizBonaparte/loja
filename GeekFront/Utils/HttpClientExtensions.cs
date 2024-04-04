using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text.Json;

namespace GeekFront.Utils
{
    public static class  HttpClientExtensions
    {
        private static MediaTypeHeaderValue contentType;

        public static async Task<T> ReadContexAs<T>(
            this HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode) throw new ApplicationException($"Algo de errado aconteceu: {response.ReasonPhrase}");
            var dataAsString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return JsonSerializer.Deserialize<T>(dataAsString,
                new JsonSerializerOptions{PropertyNameCaseInsensitive = true});
        }

        public static Task<HttpResponseMessage> PostAsJson<T>(
            this HttpClient httpclient,
            string url,
            T data)
        {
            var dataAsString = JsonSerializer.Serialize(data);
            var content = new StringContent(dataAsString);
            content.Headers.ContentType = contentType;
            return httpclient.PostAsync(url, content);
        }

        public static Task<HttpResponseMessage> PutAsJson<T>(
           this HttpClient httpclient,
           string url,
           T data)
        {
            var dataAsString = JsonSerializer.Serialize(data);
            var content = new StringContent(dataAsString);
            content.Headers.ContentType = contentType;
            return httpclient.PutAsync(url, content);
        }


    }
}

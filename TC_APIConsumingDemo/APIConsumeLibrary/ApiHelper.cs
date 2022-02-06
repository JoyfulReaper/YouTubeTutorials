using MonkeyCache.SQLite;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace APIConsumeLibrary
{
    public static class ApiHelper
    {
        private static HttpClient _httpClient;

        public static HttpClient ApiClient
        {
            get
            {
                if (_httpClient == null)
                {
                    Barrel.ApplicationId = "ApiConsumeDemo";
                    Barrel.Current.EmptyExpired();

                    _httpClient = new HttpClient();
                    _httpClient.DefaultRequestHeaders.Accept.Clear();
                    _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                }
                return _httpClient;
            }
        }

        public static async Task<T> GetAsync<T>(string url, TimeSpan expiration, bool forceRefresh = false)
        {
            var json = string.Empty;

            if (!forceRefresh && !Barrel.Current.IsExpired(url))
            {
                json = Barrel.Current.Get<string>(url);
            }

            try
            {
                if (string.IsNullOrWhiteSpace(json))
                {
                    json = await ApiClient.GetStringAsync(url);
                    Barrel.Current.Add(url, json, expiration);
                }
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
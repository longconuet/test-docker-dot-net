using System.Text.Json;
using TestHttpClient.Models;

namespace TestHttpClient.Services
{
    public class HttpClientCrudService : IHttpClientServiceImplementation
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        private readonly JsonSerializerOptions _options;

        public HttpClientCrudService()
        {
            _httpClient.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
            _httpClient.Timeout = new TimeSpan(0, 0, 30);

            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        //public async Task Execute()
        //{
        //    await GetUsers();
        //}

        public async Task<List<UserModel>> GetUsers()
        {
            var response = await _httpClient.GetAsync("users");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return !string.IsNullOrEmpty(content) ? JsonSerializer.Deserialize<List<UserModel>>(content, _options) : new List<UserModel>();
        }
    }
}

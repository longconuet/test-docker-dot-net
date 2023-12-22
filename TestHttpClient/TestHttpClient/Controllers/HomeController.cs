using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text.Json;
using TestHttpClient.Models;
using TestHttpClient.Services;

namespace TestHttpClient.Controllers
{
    [Route("api/home")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IHttpClientServiceImplementation _httpClient;

        public HomeController(IHttpClientServiceImplementation httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet]
        public async Task<List<UserModel>> GetUsers()
        {
            return await _httpClient.GetUsers();
        }
    }
}

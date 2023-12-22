using TestHttpClient.Models;

namespace TestHttpClient.Services
{
    public interface IHttpClientServiceImplementation
    {
        Task<List<UserModel>> GetUsers();
    }
}

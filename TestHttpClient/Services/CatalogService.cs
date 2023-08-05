using System.Text.Json;

namespace TestHttpClient.Services
{
    public interface ICatalogService
    {
        Task<List<Product>> GetAll();
    }

    public class CatalogService : ICatalogService
    {
        private readonly HttpClient _httpClient;

        public CatalogService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Product>> GetAll()
        {
            var responseString = await _httpClient.GetStringAsync("http://192.168.1.23:8001");
            return JsonSerializer.Deserialize<List<Product>>(responseString);
        }
    }

    public record Product(string Name, string Description);
}

using ProductMvc.Interfaces;
using ProductMvc.Models;
using System.Text.Json;
using System.Text;

namespace ProductMvc.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _client;
        public const string BasePath = "http://localhost:5173/api/product";

        public ProductService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<ProductModel> Find(int productId)
        {
            var response = await _client.GetAsync(BasePath + "/" + productId);

            return await response.ReadContentAsync<ProductModel>();
        }

        public async Task<List<ProductModel>> FindAll()
        {
            var response = await _client.GetAsync(BasePath);

            var content = await response.ReadContentAsync<List<ProductModel>>();

            return content;
        }

        public async Task Create(ProductModel productModel)
        {
            var jsonContent = JsonSerializer.Serialize(productModel);

            var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(BasePath, httpContent);

            response.EnsureSuccessStatusCode();
        }

        public async Task Update(ProductModel productModel)
        {
            var jsonContent = JsonSerializer.Serialize(productModel);

            var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await _client.PutAsync(BasePath, httpContent);

            response.EnsureSuccessStatusCode();
        }

        public async Task Delete(int productId)
        {
            var response = await _client.DeleteAsync(BasePath + "/" + productId);

            response.EnsureSuccessStatusCode();
        }
    }
}

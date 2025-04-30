using ECommerce.MVC.Models.ViewModels.Product;
using Newtonsoft.Json;

namespace ECommerce.MVC.Services
{
    public class ProductApiService
    {
        private readonly HttpClient _httpClient;

        public ProductApiService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7295/api/");
        }

        public async Task<List<ProductSummaryViewModel>> GetAllSummariesAsync()
        {
            var response = await _httpClient.GetAsync("Product/summary");
            if (!response.IsSuccessStatusCode)
                return new List<ProductSummaryViewModel>();

            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<ProductSummaryViewModel>>(content)!;
        }
    }
}

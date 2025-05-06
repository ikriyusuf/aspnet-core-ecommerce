using ECommerce.UI.Models.ViewModels.Product;
using Newtonsoft.Json;
using System.Net.Http;

namespace ECommerce.UI.Services
{
    public class ProductApiService
    {
        private readonly HttpClient _httpClient;

        public ProductApiService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7295/api/Product/");
        }

        public async Task<List<ProductSummaryViewModel>> GetAllSummariesAsync()
        {
            var response = await _httpClient.GetAsync($"summary");
            if (!response.IsSuccessStatusCode)
                return new List<ProductSummaryViewModel>();

            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<ProductSummaryViewModel>>(content)!;
        }
        //https://localhost:7295/api/Product/forPage?productId=32
        public async Task<ProductSummaryViewModel> GetSummaryByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"forPage?productId={id}");
            if (!response.IsSuccessStatusCode)
                return new ProductSummaryViewModel();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ProductSummaryViewModel>(content)!;
        }
    }
}

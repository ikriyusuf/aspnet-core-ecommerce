using ECommerce.UI.Models.ViewModels.Category;
using Newtonsoft.Json;

namespace ECommerce.UI.Services
{
    public class CategoryApiService
    {
        private readonly HttpClient _httpClient;

        public CategoryApiService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7295/api/");
        }

        public async Task<List<CategoryViewModel>> GetAllCategoriesAsync()
        {
            var response = await _httpClient.GetAsync("Category/categories");
            if (!response.IsSuccessStatusCode)
                return new List<CategoryViewModel>();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<CategoryViewModel>>(content)!;
        }
    }
}

using ECommerce.UI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.UI.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductApiService _productApiService;

        public ProductController(ProductApiService productApiService)
        {
            _productApiService = productApiService;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productApiService.GetAllSummariesAsync();
            return View(products);
        }
    }
}

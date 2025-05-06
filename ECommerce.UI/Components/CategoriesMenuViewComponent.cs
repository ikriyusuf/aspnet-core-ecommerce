using ECommerce.UI.Models.ViewModels.Product;
using ECommerce.UI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.UI.ViewComponents
{
    public class CategoriesMenuViewComponent : ViewComponent
    {
        private readonly CategoryApiService _categoryApiService;

        public CategoriesMenuViewComponent(CategoryApiService categoryApiService)
        {
            _categoryApiService = categoryApiService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await _categoryApiService.GetAllCategoriesAsync();
            return View(categories);
        }
    }
} 

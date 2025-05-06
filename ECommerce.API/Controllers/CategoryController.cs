using ECommerce.API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public CategoryController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet("categories")]
        public async Task<IActionResult> GetCategoriesAsync()
        {
            var categories = await _serviceManager.CategoryService.GetAllCategoriesAsync(false);
            return Ok(categories);
        }
    }
}

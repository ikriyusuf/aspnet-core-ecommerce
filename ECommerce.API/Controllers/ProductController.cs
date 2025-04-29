using ECommerce.API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("summaries")]
        public async Task<IActionResult> GetProductSummaries()
        {
            var summaries = await _productService.GetProductSummariesAsync(false);
            return Ok(summaries);
        }

        [HttpGet("{productId:int}", Name = "GetProductById")]
        public IActionResult GetProductById(int productId)
        {
            var product = _productService.GetProductById(productId, false);
            if (product == null)
                return NotFound();
            return Ok(product);
        }
    }
}

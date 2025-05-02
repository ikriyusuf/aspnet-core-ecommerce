using ECommerce.API.Entities.Dtos;
using ECommerce.API.Services.Implementations;
using ECommerce.API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ECommerce.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ILoggerService _logger;

        public ProductController(IProductService productService,ILoggerService logger)
        {
            _productService = productService;
            _logger = logger;
        }

        /// <summary>
        /// Tüm ürünlerin özet listesini getirir (vitrin görünümü için).
        /// </summary>
        [HttpGet("summary")]
        public async Task<IActionResult> GetProductSummariesAsync()
        {
            var summaries = await _productService.GetProductSummariesAsync(false);
            return Ok(summaries);
        }

        /// <summary>
        /// Belirli bir ürünün detayını getirir.
        /// </summary>
        /// <param name="productId">Ürün ID</param>
        [HttpGet("{productId:int}")]
        public async Task<IActionResult> GetProductByIdAsync(int productId)
        {
            var product = await _productService.GetProductByIdAsync(productId, false);
            if (product == null)
                return NotFound(new { Message = "Ürün bulunamadı." });
            return Ok(product);
        }

        /// <summary>
        /// Yeni ürün ekler.
        /// </summary>
        /// <param name="createProductDto">Ürün bilgileri</param>
        [HttpPost]
        public async Task<IActionResult> CreateProductAsync([FromBody] CreateProductDto createProductDto)
        {
            if (createProductDto == null)
                return BadRequest(new { Message = "Product data is null." });

            if(!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            var product = await _productService.CreateProductAsync(createProductDto);
            return StatusCode(201,product);
        }

        /// <summary>
        /// Belirtilen ürünü siler.
        /// </summary>
        /// <param name="productId">Ürün ID</param>
        [HttpDelete("{productId:int}")]
        public async Task<IActionResult> DeleteProductAsync(int productId)
        {
            await _productService.DeleteProductAsync(productId, false);
            _logger.LogInformation("Here is info message from the controller.");
            return NoContent();
        }

        /// <summary>
        /// Mevcut ürünü günceller.
        /// </summary>
        /// <param name="id">Ürün ID</param>
        /// <param name="updateProductDto">Güncellenmiş veriler</param>
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateProductAsync(int id, [FromBody] UpdateProductDto updateProductDto)
        {
            if (updateProductDto == null)
                return BadRequest(new { Message = "Güncelleme verisi boş olamaz." });

            if(!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            await _productService.UpdateProductAsync(id, updateProductDto, false);
            return NoContent();
        }

        /// <summary>
        /// Tüm ürünlerin toplam sayısını döner (admin).
        /// </summary>
        [HttpGet("count")]
        public async Task<IActionResult> ProductCount()
        {
            var count = await _productService.ProductCountAsync();
            return Ok(count);
        }

        /// <summary>
        /// Belirli bir satıcının ürünlerini ve aktif/pasif sayısını getirir.
        /// </summary>
        /// <param name="sellerId">Satıcı ID</param>
        [HttpGet("seller/{sellerId:int}")]
        public async Task<IActionResult> GetProductsBySellerId(int sellerId)
        {
            var products = await _productService.GetProductCountBySellerIdAsync(sellerId);
            return Ok(products);
        }

        /// <summary>
        /// Belirli bir alana göre sıralı ürün listesini getirir.
        /// </summary>
        /// <param name="sortBy">Sıralama alanı (örnek: price, createdAt)</param>
        [HttpGet("sorted")]
        public async Task<IActionResult> GetSortedProductsAsync([FromQuery] string sortBy)
        {
            var products = await _productService.GetSortedProductsAsync(sortBy, false);
            return Ok(products);
        }
    }
}

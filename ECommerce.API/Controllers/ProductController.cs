using ECommerce.API.Entities.Dtos;
using ECommerce.API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// Tüm ürünlerin özet listesini getirir (vitrin görünümü için).
        /// </summary>
        [HttpGet("summary")]
        public async Task<IActionResult> GetProductSummaries()
        {
            var summaries = await _productService.GetProductSummariesAsync(false);
            return Ok(summaries);
        }

        /// <summary>
        /// Belirli bir ürünün detayını getirir.
        /// </summary>
        /// <param name="productId">Ürün ID</param>
        [HttpGet("{productId:int}")]
        public IActionResult GetProductById(int productId)
        {
            var product = _productService.GetProductById(productId, false);
            if (product == null)
                return NotFound(new { Message = "Ürün bulunamadı." });
            return Ok(product);
        }

        /// <summary>
        /// Yeni ürün ekler.
        /// </summary>
        /// <param name="createProductDto">Ürün bilgileri</param>
        [HttpPost]
        public IActionResult CreateProduct([FromBody] CreateProductDto createProductDto)
        {
            if (createProductDto == null)
                return BadRequest(new { Message = "Product data is null." });

            _productService.CreateProduct(createProductDto);
            return Ok(new { Message = "Ürün başarıyla eklendi." });
        }

        /// <summary>
        /// Belirtilen ürünü siler.
        /// </summary>
        /// <param name="productId">Ürün ID</param>
        [HttpDelete("{productId:int}")]
        public IActionResult DeleteProduct(int productId)
        {
            try
            {
                _productService.DeleteProduct(productId);
                return Ok(new { Message = "Ürün silindi." });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Bir hata oluştu.", Details = ex.Message });
            }
        }

        /// <summary>
        /// Mevcut ürünü günceller.
        /// </summary>
        /// <param name="id">Ürün ID</param>
        /// <param name="updateProductDto">Güncellenmiş veriler</param>
        [HttpPut("{id:int}")]
        public IActionResult UpdateProduct(int id, [FromBody] UpdateProductDto updateProductDto)
        {
            if (updateProductDto == null)
                return BadRequest(new { Message = "Güncelleme verisi boş olamaz." });

            try
            {
                _productService.UpdateProduct(id, updateProductDto);
                return Ok(new { Message = $"Product with id {id} updated successfully." });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Bir hata oluştu.", Details = ex.Message });
            }
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

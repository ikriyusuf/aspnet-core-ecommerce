using ECommerce.UI.Models.CartModels;
using ECommerce.UI.Models.ViewModels.Product;
using ECommerce.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace ECommerce.UI.Pages
{
    public class CartModel : PageModel
    {
        private readonly ProductApiService _productApiService;
        public Cart Cart { get; set; }

        public CartModel( ProductApiService productApiService, Cart cart)
        {
            _productApiService = productApiService;
            Cart = cart;
        }

        public async Task<IActionResult> OnPost(int id)
        {
            var product = await _productApiService.GetSummaryByIdAsync(id);
            if (product is not null)
            {
                Cart.AddItem(product, 1);
            }

            return Page();
        }

        public IActionResult OnPostRemove(int productId)
        {
            var line = Cart.CartLines.FirstOrDefault(p => p.Product.Id == productId);
            if (line != null)
            {
                Cart.RemoveLine(line.Product);
            }

            return Page();
        }

        public IActionResult OnPostDecrease(int productId)
        {
            var line = Cart.CartLines.FirstOrDefault(p => p.Product.Id == productId);
            if (line != null)
            {
                if (line.Quantity > 1)
                    line.Quantity--;
                else
                    Cart.RemoveLine(line.Product);
            }

            return Page();
        }

        public IActionResult OnPostIncrease(int productId)
        {
            var line = Cart.CartLines.FirstOrDefault(p => p.Product.Id == productId);
            if (line != null)
            {
                line.Quantity++;
            }

            return Page();
        }
    }
}

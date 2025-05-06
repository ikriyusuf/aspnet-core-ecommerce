using ECommerce.UI.Models.ViewModels.Product;

namespace ECommerce.UI.Models.CartModels
{
    public class CartLine
    {
        public int CartLineId { get; set; }
        public ProductSummaryViewModel Product { get; set; } = new();
        public int Quantity { get; set; }
    }
}

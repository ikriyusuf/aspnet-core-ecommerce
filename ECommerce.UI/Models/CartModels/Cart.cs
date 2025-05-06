using ECommerce.UI.Models.ViewModels.Product;

namespace ECommerce.UI.Models.CartModels
{
    public class Cart
    {
        private readonly List<CartLine> _cartLines = new();

        public List<CartLine> CartLines => _cartLines;

        public void AddItem(ProductSummaryViewModel product, int quantity)
        {
            var line = _cartLines
                .FirstOrDefault(p => p.Product.Id == product.Id);
            if (line == null)
            {
                _cartLines.Add(new CartLine
                {
                    Product = product,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }
        public void RemoveLine(ProductSummaryViewModel product) =>
                    _cartLines.RemoveAll(l => l.Product.Id.Equals(product.Id));

        public decimal ComputeTotalValue() =>
            _cartLines.Sum(e =>
                (e.Product.DiscountedPrice < e.Product.Price
                    ? e.Product.DiscountedPrice
                    : e.Product.Price) * e.Quantity
            );


        public void Clear() => _cartLines.Clear();
    }
}

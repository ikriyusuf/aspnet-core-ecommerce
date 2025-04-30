namespace ECommerce.API.Entities.Dtos
{
    public class ProductCountBySellerDto
    {
        public int TotalProductCount { get; set; }
        public int ActiveProductCount { get; set; }
        public int PassiveProductCount { get; set; }
    }
}

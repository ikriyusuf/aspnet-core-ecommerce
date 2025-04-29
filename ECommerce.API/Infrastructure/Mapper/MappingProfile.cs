using AutoMapper;
using ECommerce.API.Entities.Dtos;
using ECommerce.API.Entities.Model;

namespace ECommerce.API.Infrastructure.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductSummaryDto>()
                .ForMember(dest => dest.SellerShopName, opt => opt.MapFrom(src => src.Seller.SellerProfile.ShopName));

            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.SellerShopName, opt => opt.MapFrom(src => src.Seller.SellerProfile.ShopName))
                .ReverseMap();

        }
    }
}
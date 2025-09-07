using AutoMapper;
using StockSphere.Domain.Entities;

namespace StockSphere.Application.Dtos.Profiles
{
    public class ProductProfile:Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductDto, Product>();
            CreateMap<Product, ProductDto>()
    .ForMember(dest => dest.Quantity,
               opt => opt.MapFrom(src => src.Stocks.Sum(s => s.Quantity)))
    .ForMember(dest => dest.WarehouseName,
               opt => opt.MapFrom(src => src.Stocks.Select(x => x.Warehouse.Name).FirstOrDefault()));
        }
    }
}

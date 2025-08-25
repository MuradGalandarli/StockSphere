using AutoMapper;
using StockSphere.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSphere.Application.Dtos.Profiles
{
    public class ProductProfile:Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductDto, Product>();
            CreateMap<Product, ProductDto>().ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Stocks.Sum(s => s.Quantity)));
        
        }
    }
}

using StockSphere.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSphere.Application.Abstractions.Services
{
    public interface IProductService
    {
        public Task<bool> AddProduct(ProductDto product);
        public List<ProductDto> GetAllProduct(int page,int size);
    }
}

using StockSphere.Application.Abstractions.Services;
using StockSphere.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSphere.Persistence.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> AddProduct(ProductDto product)
        {
          bool status = await _unitOfWork.ProductWriteRepository.AddAsync(new()
            {
                Barcode = product.Barcode,
                CategoryId = product.CategoryId,
                Description = product.Description,
                Name = product.Name,
                SKU = product.SKU,
                UnitOfMeasure = product.UnitOfMeasure,
            });
            await _unitOfWork.CommitAsync();
            return status;
        }
    }
}

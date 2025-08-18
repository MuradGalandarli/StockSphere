using StockSphere.Application.Abstractions.Services;
using StockSphere.Application.Dtos;
using StockSphere.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
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

        public async Task<bool> DeleteProduct(int Id)
        {
           Product product = await _unitOfWork.ProductReadRepository.GetByIdAsync(Id);
            if(product == null)
          return false;
            _unitOfWork.ProductWriteRepository.Delete(product);
            await _unitOfWork.CommitAsync();
            return true;
        }

        public List<ProductDto> GetAllProduct(int page, int size)
        {
           var product = _unitOfWork.ProductReadRepository.GetAll().Skip((page-1)*size).Take(size);
            return product.Select(p=> new ProductDto(){
                Barcode = p.Barcode,
                CategoryId = p.CategoryId,
                Description = p.Description,
                Name = p.Name,
                SKU = p.SKU,
                UnitOfMeasure = p.UnitOfMeasure,
                Id = p.Id
            }).ToList();
        }

        public async Task<ProductDto> GetProduct(int productId)
        {
           Product product = await _unitOfWork.ProductReadRepository.GetByIdAsync(productId);
           if(product == null)
            {
                return new();
            }
            return new()
            {
                Barcode = product.Barcode,
                CategoryId = product.CategoryId,
                Description = product.Description,
                Name = product.Name,
                SKU = product.SKU,
                UnitOfMeasure = product.UnitOfMeasure,
            };
        }

        public async Task<bool> UpdateProduct(ProductDto product)
        {
            Product data =  await _unitOfWork.ProductReadRepository.GetByIdAsync(product.Id);
           if(data == null)
                return false;
            data.UnitOfMeasure = product.UnitOfMeasure;
            data.CategoryId = product.CategoryId;
            data.Description = product.Description;
            data.Name = product.Name;
            data.SKU = product.SKU;
            data.Barcode = product.Barcode;
            await _unitOfWork.CommitAsync();
            return true;
        }
    }
}

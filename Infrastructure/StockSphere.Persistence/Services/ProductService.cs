using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StockSphere.Application.Abstractions.Services;
using StockSphere.Application.Dtos;
using StockSphere.Domain.Entities;

namespace StockSphere.Persistence.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> AddProduct(ProductDto product)
        {
            using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                Product newProduct = _mapper.Map<Product>(product);
                bool status = await _unitOfWork.ProductWriteRepository.AddAsync(newProduct);
                await _unitOfWork.CommitAsync();
                if (status)
                {
                    bool stockStatus = await _unitOfWork.StockWriteRepository.AddAsync(new()
                    {
                        ProductId = newProduct.Id,
                        Quantity = product.Quantity,
                        WarehouseId = product.WarehouseId,
                    });
                    await _unitOfWork.CommitAsync();
                    await transaction.CommitAsync();

                    return stockStatus;
                }
            }
            catch
            {
                await _unitOfWork.RollbackAsync(transaction);
            }
            return false;
        }

        public async Task<bool> DeleteProduct(int Id)
        {
            var product = await _unitOfWork.ProductReadRepository.GetWhere(x => x.Id == Id).Include(x => x.Stocks).FirstOrDefaultAsync();
            if (product == null)
                return false;

            using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                _unitOfWork.ProductWriteRepository.Delete(product);
                _unitOfWork.StockWriteRepository.Delete(product.Stocks.Where(x => x.ProductId == product.Id).FirstOrDefault());
                await _unitOfWork.CommitAsync();
                await transaction.CommitAsync();
                return true;
            }
            catch
            {
                await _unitOfWork.RollbackAsync(transaction);
            }
            return false;
        }

        public async Task<List<ProductDto>> GetAllProduct(int page, int size)
        {
            var product = await _unitOfWork.ProductReadRepository.GetAll().Include(x => x.Stocks).ThenInclude(w=>w.Warehouse).Skip((page - 1) * size).Take(size).ToListAsync();

            return _mapper.Map<List<ProductDto>>(product);
        }

        public async Task<ProductDto> GetProduct(int productId)
        {
            Product? product = await _unitOfWork.ProductReadRepository.GetWhere(x => x.Id == productId).Include(s => s.Stocks).FirstOrDefaultAsync();
            if (product == null)
            {
                return new();
            }

            return _mapper.Map<ProductDto>(product);
        }

        public async Task<List<ProductDto>> Search(SearchRequestDto searchRequestDto)
        {
            var query = _unitOfWork.ProductReadRepository.Table.Include(s => s.Stocks).AsQueryable();
            if (searchRequestDto.WarehouseId > 0)
            {
                var productId = _unitOfWork.WarehouseReadRepository.GetWhere(w => w.Id == searchRequestDto.WarehouseId).Include(s => s.Stocks).SelectMany(x => x.Stocks.Select(i => i.ProductId));
                if (productId.Any())
                {
                    query = query.Where(w => productId.Contains(w.Id));
                }
            }
                if (searchRequestDto.ProductId > 0)
                {
                    query = query.Where(p => p.Id == searchRequestDto.ProductId);
                }
                if (searchRequestDto.CategoryId > 0)
                {
                    query = query.Where(c => c.CategoryId == searchRequestDto.CategoryId);
                }
                if (!string.IsNullOrEmpty(searchRequestDto.Name))
                {
                    query = query.Where(n => n.Name == searchRequestDto.Name);
                }

            
            var datas = _mapper.Map<List<ProductDto>>(query);
            return datas;
        }

        public async Task<bool> UpdateProduct(ProductDto product)
        {
            Product? data = await _unitOfWork.ProductReadRepository.GetWhere(x => x.Id == product.Id).Include(x => x.Stocks).FirstOrDefaultAsync();

            if (data == null)
                return false;

            using var transaction = await _unitOfWork.BeginTransactionAsync();

            try
            {
                _mapper.Map(product, data);
                foreach (Stock stock in data.Stocks)
                {
                    stock.Quantity = product.Quantity;

                }
                await transaction.CommitAsync();
                await _unitOfWork.CommitAsync();

            }
            catch
            {
                await _unitOfWork.RollbackAsync(transaction);
                return false;
            }

            return true;
        }
    }
}

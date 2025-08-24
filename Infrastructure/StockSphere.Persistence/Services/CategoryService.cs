using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.Json;
using StockSphere.Application.Abstractions.Services;
using StockSphere.Application.Dtos;
using StockSphere.Application.Repositories;
using StockSphere.Domain.Entities;

namespace StockSphere.Persistence.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> AddCategory(CategoryDto category)
        {
            bool status = await _unitOfWork.CategoryWriteRepository.AddAsync(new() { Description = category.Description, Name = category.Name });
            await _unitOfWork.CommitAsync();
            return status;
        }

        public async Task<bool> CategoryDelete(int id)
        {
            Category? category = await _unitOfWork.CategoryReadRepository.GetWhere(c => c.Id == id).Include(p => p.Products).ThenInclude(s => s.Stocks).FirstOrDefaultAsync();
            if (category == null)
                return false;
            using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                bool statusProduct = false;
                bool statusCategory = _unitOfWork.CategoryWriteRepository.Delete(category);
                if (statusCategory && category.Products.Count > 0)
                    foreach (Product product in category.Products)
                    {
                        statusProduct = _unitOfWork.ProductWriteRepository.Delete(product);

                        if (statusProduct && product.Stocks.Count > 0)
                            foreach (Stock stock in product.Stocks) 
                            {
                                bool statusStock = _unitOfWork.StockWriteRepository.Delete(stock);
                            }
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

        public List<CategoryDto> GetAllCategory(int page, int size)
        {
            var categories = _unitOfWork.CategoryReadRepository.GetAll().Skip((page - 1) * size).Take(size);
            return categories.Select(c => new CategoryDto()
            {
                Name = c.Name,
                Description = c.Description,
                Id = c.Id
            }).ToList();

        }

        public async Task<CategoryDto> GetByIdCategory(int id)
        {
            Category category = await _unitOfWork.CategoryReadRepository.GetByIdAsync(id);
            if (category != null)
            {
                return new()
                {
                    Id = category.Id,
                    Name = category.Name,
                    Description = category.Description,
                };
            }
            return new();

        }

        public async Task<bool> UpdateCategory(CategoryDto category)
        {
            bool status = _unitOfWork.CategoryWriteRepository.Update(new() { Id = category.Id, Description = category.Description, Name = category.Name });
            await _unitOfWork.CategoryWriteRepository.SaveAsync();
            return status;
        }
    }
}

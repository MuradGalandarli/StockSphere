using StockSphere.Application.Abstractions.Services;
using StockSphere.Application.Dtos;
using StockSphere.Application.Repositories;

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
           bool status = await _unitOfWork.CategoryWriteRepository.AddAsync(new() { Description =category.Description, Name = category.Name});
           await _unitOfWork.CommitAsync();
            return status;
        }

        public async Task<bool> UpdateCategory(CategoryDto category)
        {
          bool status = _unitOfWork.CategoryWriteRepository.Update(new() { Id = category.Id, Description = category.Description, Name = category.Name });
            await _unitOfWork.CategoryWriteRepository.SaveAsync();
            return status;
        }
    }
}

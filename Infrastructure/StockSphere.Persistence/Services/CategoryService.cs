using StockSphere.Application.Abstractions.Services;
using StockSphere.Application.Dtos;
using StockSphere.Application.Repositories;

namespace StockSphere.Persistence.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryWriteRepository _categoryWriteRepository;

        public CategoryService(ICategoryWriteRepository categoryWriteRepository)
        {
            _categoryWriteRepository = categoryWriteRepository;
        }

        public async Task<bool> AddCategory(CategoryDto category)
        {
           bool status = await _categoryWriteRepository.AddAsync(new() { Description =category.Description, Name = category.Name});
           await _categoryWriteRepository.SaveAsync();
            return status;
        }

        public async Task<bool> UpdateCategory(CategoryDto category)
        {
          bool status = _categoryWriteRepository.Update(new() { Id = category.Id, Description = category.Description, Name = category.Name });
            await _categoryWriteRepository.SaveAsync();
            return status;
        }
    }
}

using StockSphere.Application.Abstractions.Services;
using StockSphere.Application.Dtos;
using StockSphere.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}

using StockSphere.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSphere.Application.Abstractions.Services
{
    public interface ICategoryService
    {
        public Task<bool> AddCategory(CategoryDto category);
        public Task<bool> UpdateCategory(CategoryDto category);
        public List<CategoryDto> GetAllCategory(int page,int size);
        public Task<CategoryDto> GetByIdCategory(int id);
        public Task<bool> CategoryDelete(int id);
    }
}

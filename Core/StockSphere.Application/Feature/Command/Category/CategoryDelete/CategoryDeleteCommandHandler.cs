using MediatR;
using StockSphere.Application.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSphere.Application.Feature.Command.Category.CategoryDelete
{
    public class CategoryDeleteCommandHandler : IRequestHandler<CategoryDeleteCommandRequest, CategoryDeleteCommandResponse>
    {
        private readonly ICategoryService _categoryService;

        public CategoryDeleteCommandHandler(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<CategoryDeleteCommandResponse> Handle(CategoryDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            bool status = await _categoryService.CategoryDelete(request.id);
            return new() { Status = status };
        }
    }
}

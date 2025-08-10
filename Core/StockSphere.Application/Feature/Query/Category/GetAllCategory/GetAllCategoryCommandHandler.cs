using MediatR;
using StockSphere.Application.Abstractions.Services;
using StockSphere.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSphere.Application.Feature.Query.Category.GetAllCategory
{
    public class GetAllCategoryCommandHandler : IRequestHandler<GetAllCategoryCommandRequest, List<GetAllCategoryCommandResponse>>
    {
        private readonly ICategoryService _categoryService;

        public GetAllCategoryCommandHandler(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<List<GetAllCategoryCommandResponse>> Handle(GetAllCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            List<CategoryDto> categoryDtos = _categoryService.GetAllCategory(request.Page, request.Size);

            return categoryDtos.Select(c => new GetAllCategoryCommandResponse()
            {
                Id = c.Id,
                Description = c.Description,
                Name = c.Name
            }).ToList();
        }
    }
}

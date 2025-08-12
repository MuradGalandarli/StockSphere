using MediatR;
using StockSphere.Application.Abstractions.Services;
using StockSphere.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSphere.Application.Feature.Query.GetByIdCategory
{
    public class GetByIdCategoryQueryHandler : IRequestHandler<GetByIdCategoryQueryRequest, GetByIdCategoryQueryResponse>
    {
        private readonly ICategoryService _categoryService;

        public GetByIdCategoryQueryHandler(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<GetByIdCategoryQueryResponse> Handle(GetByIdCategoryQueryRequest request, CancellationToken cancellationToken)
        {
           CategoryDto category = await _categoryService.GetByIdCategory(request.Id);
            return new()
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description
            };
        }
    }
}

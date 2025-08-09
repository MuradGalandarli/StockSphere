using MediatR;
using StockSphere.Application.Abstractions.Services;

namespace StockSphere.Application.Feature.Command.Category.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommandRequest, UpdateCategoryCommandResponse>
    {
        private readonly ICategoryService _categoryService;

        public UpdateCategoryCommandHandler(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<UpdateCategoryCommandResponse> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            bool status =await _categoryService.UpdateCategory(new()
            {
                Id = request.Id,
                Name = request.Name,
                Description = request.Description,
            });
            return new(){ Status = status};


        }
    }
}

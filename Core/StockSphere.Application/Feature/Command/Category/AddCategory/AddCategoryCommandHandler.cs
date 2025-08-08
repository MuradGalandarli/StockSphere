using MediatR;
using StockSphere.Application.Abstractions.Services;

namespace StockSphere.Application.Feature.Command.Category.AddCategory
{
    public class AddCategoryCommandHandler : IRequestHandler<AddCategoryCommandRequest, AddCategoryCommandResponse>
    {
        private readonly ICategoryService _categoryService;

        public AddCategoryCommandHandler(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<AddCategoryCommandResponse> Handle(AddCategoryCommandRequest request, CancellationToken cancellationToken)
        {
          bool status = await _categoryService.AddCategory(new()
            {
                Description = request.Description,
                Name = request.Name,
            });
            return new() { Status = status };
        }
    }
}

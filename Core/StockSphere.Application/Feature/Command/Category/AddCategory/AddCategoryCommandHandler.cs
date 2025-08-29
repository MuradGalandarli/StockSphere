using FluentValidation;
using MediatR;
using StockSphere.Application.Abstractions.Services;

namespace StockSphere.Application.Feature.Command.Category.AddCategory
{
    public class AddCategoryCommandHandler : IRequestHandler<AddCategoryCommandRequest, AddCategoryCommandResponse>
    {
        private readonly ICategoryService _categoryService;
        private readonly IEnumerable<IValidator<AddCategoryCommandRequest>> _validators;
        public AddCategoryCommandHandler(ICategoryService categoryService, IEnumerable<IValidator<AddCategoryCommandRequest>> validators)
        {
            _categoryService = categoryService;
            _validators = validators;
        }

        public async Task<AddCategoryCommandResponse> Handle(AddCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            bool status = false;

            if (_validators.Any())
            {
                status = await _categoryService.AddCategory(new()
                {
                    Description = request.Description,
                    Name = request.Name,
                });
            }
            return new() { Status = status };
        }
    }
}

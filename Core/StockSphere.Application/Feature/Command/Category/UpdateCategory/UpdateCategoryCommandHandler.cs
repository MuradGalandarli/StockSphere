using FluentValidation;
using MediatR;
using StockSphere.Application.Abstractions.Services;

namespace StockSphere.Application.Feature.Command.Category.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommandRequest, UpdateCategoryCommandResponse>
    {
        private readonly ICategoryService _categoryService;
        private readonly IEnumerable<IValidator<UpdateCategoryCommandRequest>> _validators;

        public UpdateCategoryCommandHandler(ICategoryService categoryService, IEnumerable<IValidator<UpdateCategoryCommandRequest>> validators)
        {
            _categoryService = categoryService;
            _validators = validators;
        }

        public async Task<UpdateCategoryCommandResponse> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            bool status = false;
            if (_validators.Any())
            {
                status = await _categoryService.UpdateCategory(new()
                {
                    Id = request.Id,
                    Name = request.Name,
                    Description = request.Description,
                });
            }
            return new(){ Status = status};


        }
    }
}

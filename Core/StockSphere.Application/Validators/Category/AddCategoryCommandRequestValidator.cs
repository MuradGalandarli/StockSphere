using FluentValidation;
using StockSphere.Application.Feature.Command.Category.AddCategory;

namespace StockSphere.Application.Validators.Category
{
    public class AddCategoryCommandRequestValidator:AbstractValidator<AddCategoryCommandRequest>
    {
        public AddCategoryCommandRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull();
        }
    }
}

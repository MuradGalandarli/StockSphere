using FluentValidation;
using StockSphere.Application.Feature.Command.Category.UpdateCategory;

namespace StockSphere.Application.Validators.Category
{
    public class UpdateCategoryCommandRequestValidator:AbstractValidator<UpdateCategoryCommandRequest>
    {
        public UpdateCategoryCommandRequestValidator() { 
        RuleFor(x => x.Name).NotEmpty().NotNull();
        RuleFor(x => x.Id).Must(i=>i>0);
        }
    }
}

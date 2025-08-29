using FluentValidation;
using StockSphere.Application.Feature.Command.Product.AddProduct;


namespace StockSphere.Application.Validators.Product
{
    public class AddProductCommandRequestValidator:AbstractValidator<AddProductCommandRequest>
    {
        public AddProductCommandRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotEmpty();
            RuleFor(x => x.CategoryId).Must(i => i > 0);
            RuleFor(x => x.WarehouseId).Must(i => i > 0);
            RuleFor(x => x.Quantity).Must(i => i > 0);
        }
    }
}

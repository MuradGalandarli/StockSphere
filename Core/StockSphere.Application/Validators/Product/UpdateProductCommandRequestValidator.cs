using FluentValidation;
using StockSphere.Application.Feature.Command.Product.UpdateProduct;

namespace StockSphere.Application.Validators.Product
{
    public class UpdateProductCommandRequestValidator:AbstractValidator<UpdateProductCommandRequest>
    {
        public UpdateProductCommandRequestValidator()
        {
            RuleFor(x => x.ProductDto.Name).NotEmpty().NotEmpty();
            RuleFor(x => x.ProductDto.CategoryId).Must(i => i > 0);
            RuleFor(x => x.ProductDto.WarehouseId).Must(i => i > 0);
            RuleFor(x => x.ProductDto.Quantity).Must(i => i > 0);
            RuleFor(x => x.ProductDto.Id).Must(i => i > 0);
        }
    }
}

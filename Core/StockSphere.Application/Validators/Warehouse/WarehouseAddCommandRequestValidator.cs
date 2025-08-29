using FluentValidation;
using StockSphere.Application.Feature.Command.Warehouse.AddWarehouse;

namespace StockSphere.Application.Validators.Warehouse
{
    public class WarehouseAddCommandRequestValidator : AbstractValidator<WarehouseAddCommandRequest>
    {
        public WarehouseAddCommandRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().MinimumLength(3);
            RuleFor(x => x.Location).NotEmpty().NotNull();
        }
    }
}

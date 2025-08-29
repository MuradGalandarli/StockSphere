using FluentValidation;
using StockSphere.Application.Feature.Command.Warehouse.WarehouseUpdate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSphere.Application.Validators.Warehouse
{
    public class WarehouseUpdateCommandRequestValidator:AbstractValidator<WarehouseUpdateCommandRequest>
    {
        public WarehouseUpdateCommandRequestValidator()
        {
            RuleFor(x => x.Id).Must(i => i > 0);
            RuleFor(x => x.Name).NotEmpty().NotNull().MinimumLength(3);
            RuleFor(x => x.Location).NotEmpty().NotNull();
        }
    }
}

using FluentValidation;
using MediatR;
using StockSphere.Application.Abstractions.Services;


namespace StockSphere.Application.Feature.Command.Warehouse.WarehouseUpdate
{
    public class WarehouseUpdateCommandHandler : IRequestHandler<WarehouseUpdateCommandRequest, WarehouseUpdateCommandResponse>
    {
        private readonly IWarehouseService _warehouseService;
        private readonly IEnumerable<IValidator<WarehouseUpdateCommandRequest>> _validators;

        public WarehouseUpdateCommandHandler(IWarehouseService warehouseService, IEnumerable<IValidator<WarehouseUpdateCommandRequest>> validators)
        {
            _warehouseService = warehouseService;
            _validators = validators;
        }

        public async Task<WarehouseUpdateCommandResponse> Handle(WarehouseUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            bool status = false;
            if (_validators.Any())
            {
                 status = await _warehouseService.WarehouseUpdate(new()
                {
                    Id = request.Id,
                    Name = request.Name,
                    Location = request.Location,
                });
            }
            return new()
            {
                Status = status,
            };

        }
    }
}

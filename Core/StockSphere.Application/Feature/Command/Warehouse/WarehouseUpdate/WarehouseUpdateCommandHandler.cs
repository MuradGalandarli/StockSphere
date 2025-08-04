using MediatR;
using StockSphere.Application.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSphere.Application.Feature.Command.Warehouse.WarehouseUpdate
{
    public class WarehouseUpdateCommandHandler : IRequestHandler<WarehouseUpdateCommandRequest, WarehouseUpdateCommandResponse>
    {
        private readonly IWarehouseService _warehouseService;

        public WarehouseUpdateCommandHandler(IWarehouseService warehouseService)
        {
            _warehouseService = warehouseService;
        }

        public async Task<WarehouseUpdateCommandResponse> Handle(WarehouseUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            bool status = await _warehouseService.WarehouseUpdate(new()
            {
                Id = request.Id,
                Name = request.Name,
                Location = request.Location,
            });

            return new()
            {
                Status = status,
            };

        }
    }
}

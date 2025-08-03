using MediatR;
using StockSphere.Application.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSphere.Application.Feature.Command.Warehouse.AddWarehouse
{
    public class WarehouseAddCommandHandler : IRequestHandler<WarehouseAddCommandRequest, WarehouseAddCommandResponse>
    {
        private readonly IWarehouseService _warehouseService;

        public WarehouseAddCommandHandler(IWarehouseService warehouseService)
        {
            _warehouseService = warehouseService;
        }

        public async Task<WarehouseAddCommandResponse> Handle(WarehouseAddCommandRequest request, CancellationToken cancellationToken)
        {
           bool status = await _warehouseService.AddWarehouse(request.Name, request.Location);
            return new()
            {
                Status = status,
            };
        }
    }
}

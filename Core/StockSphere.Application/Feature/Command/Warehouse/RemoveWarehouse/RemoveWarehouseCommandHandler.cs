using MediatR;
using StockSphere.Application.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSphere.Application.Feature.Command.Warehouse.RemoveWarehouse
{
    public class RemoveWarehouseCommandHandler : IRequestHandler<RemoveWarehouseCommandRequest, RemoveWarehouseCommandResponse>
    {
        private readonly IWarehouseService _warehouseService;

        public RemoveWarehouseCommandHandler(IWarehouseService warehouseService)
        {
            _warehouseService = warehouseService;
        }

        public async Task<RemoveWarehouseCommandResponse> Handle(RemoveWarehouseCommandRequest request, CancellationToken cancellationToken)
        {
            bool status = await _warehouseService.RemoveWarehouse(request.Id);
            return new()
            {
                Status = status
            };
        }
    }
}

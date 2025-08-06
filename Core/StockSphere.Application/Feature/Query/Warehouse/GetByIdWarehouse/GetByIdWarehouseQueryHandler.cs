using MediatR;
using StockSphere.Application.Abstractions.Services;
using StockSphere.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSphere.Application.Feature.Query.Warehouse.GetByIdWarehouse
{
    public class GetByIdWarehouseQueryHandler : IRequestHandler<GetByIdWarehouseQueryRequest, GetByIdWarehouseQueryResponse>
    {
        private readonly IWarehouseService _warehouseService;

        public GetByIdWarehouseQueryHandler(IWarehouseService warehouseService)
        {
            _warehouseService = warehouseService;
        }

        public async Task<GetByIdWarehouseQueryResponse> Handle(GetByIdWarehouseQueryRequest request, CancellationToken cancellationToken)
        {
           WarehouseDto warehouseDto = await _warehouseService.GetByIdWarehouse(request.Id);
            return new()
            {
                Id = warehouseDto.Id,
                Location = warehouseDto.Location,
                Name = warehouseDto.Name,
            };
        }
    }
}

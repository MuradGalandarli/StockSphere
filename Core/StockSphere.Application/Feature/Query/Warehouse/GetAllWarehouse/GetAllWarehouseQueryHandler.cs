using MediatR;
using StockSphere.Application.Abstractions.Services;
using StockSphere.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace StockSphere.Application.Feature.Query.Warehouse.GetAllWarehouse
{
    public class GetAllWarehouseQueryHandler : IRequestHandler<GetAllWarehouseQueryRequest, List<GetAllWarehouseQueryResponse>>
    {
        private readonly IWarehouseService _warehouseService;

        public GetAllWarehouseQueryHandler(IWarehouseService warehouseService)
        {
            _warehouseService = warehouseService;
        }

        public async Task<List<GetAllWarehouseQueryResponse>> Handle(GetAllWarehouseQueryRequest request, CancellationToken cancellationToken)
        {
            List<WarehouseDto> warehouseDto = _warehouseService.GetAllWarehouse(request.Page, request.Size);
            var getAllWarehouseQueryResponse = warehouseDto.Select(w => new GetAllWarehouseQueryResponse() { Location = w.Location, Name = w.Name,Id = w.Id}).ToList();
            return getAllWarehouseQueryResponse;
        }
    }
}

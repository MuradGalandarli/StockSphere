using FluentValidation;
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
        private readonly IEnumerable<IValidator<WarehouseAddCommandRequest>> _validator;

        public WarehouseAddCommandHandler(IWarehouseService warehouseService, IEnumerable<IValidator<WarehouseAddCommandRequest>> validator)
        {
            _warehouseService = warehouseService;
            _validator = validator;
        }

        public async Task<WarehouseAddCommandResponse> Handle(WarehouseAddCommandRequest request, CancellationToken cancellationToken)
        {
            bool status = false;

            if (_validator.Any())
            {
                status = await _warehouseService.AddWarehouse(request.Name, request.Location);
            }

            return new WarehouseAddCommandResponse
            {
                Status = status
            };
        }
    }
}

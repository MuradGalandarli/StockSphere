using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockSphere.Application.Feature.Command.Warehouse.AddWarehouse;

namespace StockSphere.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WarehouseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("add-warehouse")]
        public async Task<IActionResult> AddWarehouse(WarehouseAddCommandRequest warehouseAddCommandRequest)
        {
            WarehouseAddCommandResponse warehouseAddCommandResponse = await _mediator.Send(warehouseAddCommandRequest);
       return Ok(warehouseAddCommandResponse);
        }


    }
}   

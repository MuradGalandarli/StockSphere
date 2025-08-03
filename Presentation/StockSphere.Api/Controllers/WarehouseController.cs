using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockSphere.Application.Feature.Command.Warehouse.AddWarehouse;
using StockSphere.Application.Feature.Query.Warehouse.GetAllWarehouse;

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
        [HttpGet("get-all-warehouse")]
        public async Task<IActionResult>GetAllWarehouse([FromQuery]GetAllWarehouseQueryRequest getAllWarehouseQueryRequest)
        {
          List<GetAllWarehouseQueryResponse> getAllWarehouseQueryResponse = await _mediator.Send(getAllWarehouseQueryRequest);
          return Ok(getAllWarehouseQueryResponse);  
        }


    }
}   

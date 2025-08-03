using MediatR;

namespace StockSphere.Application.Feature.Command.Warehouse.AddWarehouse
{
    public class WarehouseAddCommandRequest:IRequest<WarehouseAddCommandResponse>
    {
        public string Name { get; set; }
        public string Location { get; set; }
    }
}
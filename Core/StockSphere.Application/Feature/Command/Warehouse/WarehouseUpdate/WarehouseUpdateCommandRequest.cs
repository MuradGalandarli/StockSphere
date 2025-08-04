using MediatR;

namespace StockSphere.Application.Feature.Command.Warehouse.WarehouseUpdate
{
    public class WarehouseUpdateCommandRequest:IRequest<WarehouseUpdateCommandResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
    }
}
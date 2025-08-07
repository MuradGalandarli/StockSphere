using MediatR;

namespace StockSphere.Application.Feature.Command.Warehouse.RemoveWarehouse
{
    public class RemoveWarehouseCommandRequest:IRequest<RemoveWarehouseCommandResponse>
    {
        public int Id { get; set; }
    }
}
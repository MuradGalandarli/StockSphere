using MediatR;

namespace StockSphere.Application.Feature.Query.Warehouse.GetByIdWarehouse
{
    public class GetByIdWarehouseQueryRequest:IRequest<GetByIdWarehouseQueryResponse>
    {
        public int Id { get; set; }
    }
}
using MediatR;

namespace StockSphere.Application.Feature.Query.Product.GetProduct
{
    public class GetProductQueryRequest:IRequest<GetProductQueryResponse>
    {
        public int Id { get; set; }
    }
}
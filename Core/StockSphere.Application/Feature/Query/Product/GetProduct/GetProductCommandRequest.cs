using MediatR;

namespace StockSphere.Application.Feature.Query.Product.GetProduct
{
    public class GetProductCommandRequest:IRequest<GetProductCommandResponse>
    {
        public int Id { get; set; }
    }
}
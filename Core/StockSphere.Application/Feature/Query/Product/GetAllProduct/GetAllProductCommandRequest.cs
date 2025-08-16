using MediatR;

namespace StockSphere.Application.Feature.Query.Product.GetAllProduct
{
    public class GetAllProductCommandRequest : IRequest<List<GetAllProductCommandResponse>>
    {
        public int Page { get; set; }
        public int Size { get; set; }
    }
}
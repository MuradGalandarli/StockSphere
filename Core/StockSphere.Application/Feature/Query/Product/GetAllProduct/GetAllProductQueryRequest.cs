using MediatR;

namespace StockSphere.Application.Feature.Query.Product.GetAllProduct
{
    public class GetAllProductQueryRequest : IRequest<List<GetAllProductQueryResponse>>
    {
        public int Page { get; set; }
        public int Size { get; set; }
    }
}
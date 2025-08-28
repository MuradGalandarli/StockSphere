using MediatR;
using StockSphere.Application.Dtos;

namespace StockSphere.Application.Feature.Query.Product.SearchProduct
{
    public class SearchQueryRequest:IRequest<SearchQueryResponse>
    {
        public SearchRequestDto SearchRequestDto { get; set; }
      
    }
}
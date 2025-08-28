using MediatR;
using StockSphere.Application.Abstractions.Services;
using StockSphere.Application.Dtos;


namespace StockSphere.Application.Feature.Query.Product.SearchProduct
{
    public class SearchQueryHandler : IRequestHandler<SearchQueryRequest,SearchQueryResponse>
    {
        private readonly IProductService _productService;

        public SearchQueryHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<SearchQueryResponse> Handle(SearchQueryRequest request, CancellationToken cancellationToken)
        {
           List<ProductDto> productDtos = await _productService.Search(request.SearchRequestDto);
            return new()
            {
                 productDto = productDtos
            };
        }
    }
}

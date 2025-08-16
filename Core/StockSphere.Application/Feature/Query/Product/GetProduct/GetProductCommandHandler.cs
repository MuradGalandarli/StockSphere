using MediatR;
using StockSphere.Application.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSphere.Application.Feature.Query.Product.GetProduct
{
    public class GetProductCommandHandler : IRequestHandler<GetProductCommandRequest, GetProductCommandResponse>
    {
        private readonly IProductService _productService;

        public GetProductCommandHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<GetProductCommandResponse> Handle(GetProductCommandRequest request, CancellationToken cancellationToken)
        {
            var productDto = await _productService.GetProduct(request.Id);
            return new()
            {
                Product = productDto,
            };
        }
    }
}

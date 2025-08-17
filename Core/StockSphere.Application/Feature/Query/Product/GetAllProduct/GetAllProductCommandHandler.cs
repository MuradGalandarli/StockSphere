using MediatR;
using StockSphere.Application.Abstractions.Services;
using StockSphere.Application.Dtos;
using StockSphere.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSphere.Application.Feature.Query.Product.GetAllProduct
{
    public class GetAllProductCommandHandler : IRequestHandler<GetAllProductCommandRequest, List<GetAllProductCommandResponse>>
    {
        private readonly IProductService _productService;

        public GetAllProductCommandHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<List<GetAllProductCommandResponse>> Handle(GetAllProductCommandRequest request, CancellationToken cancellationToken)
        {
            List<ProductDto> products = _productService.GetAllProduct(request.Page, request.Size);
            return products.Select(p => new GetAllProductCommandResponse()
            {
                Barcode = p.Barcode,
                CategoryId = p.CategoryId,
                Description = p.Description,
                Name = p.Name,
                SKU = p.SKU,
                UnitOfMeasure = p.UnitOfMeasure,
                Id = p.Id,
            }).ToList();
        }
    }
}

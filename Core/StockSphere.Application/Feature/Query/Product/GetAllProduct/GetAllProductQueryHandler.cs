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
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQueryRequest, List<GetAllProductQueryResponse>>
    {
        private readonly IProductService _productService;

        public GetAllProductQueryHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<List<GetAllProductQueryResponse>> Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
        {
            List<ProductDto> products = await _productService.GetAllProduct(request.Page, request.Size);
            return products.Select(p => new GetAllProductQueryResponse()
            {
                Barcode = p.Barcode,
                CategoryId = p.CategoryId,
                Description = p.Description,
                Name = p.Name,
                SKU = p.SKU,
                WarehouseName = p.WarehouseName,
                UnitOfMeasure = p.UnitOfMeasure,
                Id = p.Id,
                Quantity = p.Quantity,
            }).ToList();
        }
    }
}

using FluentValidation;
using MediatR;
using StockSphere.Application.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSphere.Application.Feature.Command.Product.AddProduct
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommandRequest, AddProductCommandResponce>
    {
        private readonly IProductService _productService;
        private readonly IEnumerable<IValidator<AddProductCommandRequest>> _validators;

        public AddProductCommandHandler(IProductService productService, IEnumerable<IValidator<AddProductCommandRequest>> validators)
        {
            _productService = productService;
            _validators = validators;
        }

        public async Task<AddProductCommandResponce> Handle(AddProductCommandRequest request, CancellationToken cancellationToken)
        {
            bool status = false;
            if (_validators.Any())
            {
                status = await _productService.AddProduct(new()
                {
                    Barcode = request.Barcode,
                    CategoryId = request.CategoryId,
                    Description = request.Description,
                    Name = request.Name,
                    SKU = request.SKU,
                    UnitOfMeasure = request.UnitOfMeasure,
                    WarehouseId = request.WarehouseId,
                    Quantity = request.Quantity
                });
            }
            return new() { Status = status };
        }
    }
}

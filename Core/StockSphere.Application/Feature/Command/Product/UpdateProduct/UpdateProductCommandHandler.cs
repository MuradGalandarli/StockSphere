using FluentValidation;
using MediatR;
using StockSphere.Application.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSphere.Application.Feature.Command.Product.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, UpdateProductCommandResponse>
    {
        private readonly IProductService _productService;
        private readonly IEnumerable<IValidator<UpdateProductCommandRequest>> _validators;

        public UpdateProductCommandHandler(IProductService productService, IEnumerable<IValidator<UpdateProductCommandRequest>> validators)
        {
            _productService = productService;
            _validators = validators;
        }

        public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            bool status = false;
            if (_validators.Any())
            {
                 status = await _productService.UpdateProduct(request.ProductDto);
            }
            return new()
            {
                Status = status,
            };
        }
    }
}

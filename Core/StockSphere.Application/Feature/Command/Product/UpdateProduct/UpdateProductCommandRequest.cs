using MediatR;
using StockSphere.Application.Dtos;

namespace StockSphere.Application.Feature.Command.Product.UpdateProduct
{
    public class UpdateProductCommandRequest:IRequest<UpdateProductCommandResponse> 
    {
        public ProductDto ProductDto { get; set; }
    }
}
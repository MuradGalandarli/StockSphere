using MediatR;

namespace StockSphere.Application.Feature.Command.Product.DeleteProduct
{
    public class DeleteProductCommandRequest:IRequest<DeleteProductCommandResponse>
    {
        public int Id { get; set; }
    }
}
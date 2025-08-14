using MediatR;

namespace StockSphere.Application.Feature.Command.Product.AddProduct
{
    public class AddProductCommandRequest:IRequest<AddProductCommandResponce>
    {
        public string Name { get; set; }
        public string? Barcode { get; set; }
        public string? SKU { get; set; }
        public int? CategoryId { get; set; }
        public string? UnitOfMeasure { get; set; }
        public string? Description { get; set; }
    }
}
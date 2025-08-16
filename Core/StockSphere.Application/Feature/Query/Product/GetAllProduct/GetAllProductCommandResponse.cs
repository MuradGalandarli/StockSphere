namespace StockSphere.Application.Feature.Query.Product.GetAllProduct
{
    public class GetAllProductCommandResponse
    {
        public string Name { get; set; }
        public string? Barcode { get; set; }
        public string? SKU { get; set; }
        public int? CategoryId { get; set; }
        public string? UnitOfMeasure { get; set; }
        public string? Description { get; set; }
    }
}
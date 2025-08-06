namespace StockSphere.Application.Feature.Query.Warehouse.GetAllWarehouse
{
    public class GetAllWarehouseQueryResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Location { get; set; }
    }
}
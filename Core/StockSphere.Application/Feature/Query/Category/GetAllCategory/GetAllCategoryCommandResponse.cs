namespace StockSphere.Application.Feature.Query.Category.GetAllCategory
{
    public class GetAllCategoryCommandResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
    }
}
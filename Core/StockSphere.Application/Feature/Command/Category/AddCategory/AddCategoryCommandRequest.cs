using MediatR;

namespace StockSphere.Application.Feature.Command.Category.AddCategory
{
    public class AddCategoryCommandRequest:IRequest<AddCategoryCommandResponse>
    {
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
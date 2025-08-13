using MediatR;

namespace StockSphere.Application.Feature.Command.Category.CategoryDelete
{
    public class CategoryDeleteCommandRequest:IRequest<CategoryDeleteCommandResponse>
    {
        public int id { get; set; }
    }
}
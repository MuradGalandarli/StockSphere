using MediatR;

namespace StockSphere.Application.Feature.Query.Category.GetAllCategory
{
    public class GetAllCategoryCommandRequest:IRequest<List<GetAllCategoryCommandResponse>>
    {
        public int Page { get; set; }
        public int Size { get; set; }
    }
}
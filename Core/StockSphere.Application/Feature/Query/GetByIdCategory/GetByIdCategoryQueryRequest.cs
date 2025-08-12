using MediatR;

namespace StockSphere.Application.Feature.Query.GetByIdCategory
{
    public class GetByIdCategoryQueryRequest:IRequest<GetByIdCategoryQueryResponse>
    {
        public int Id { get; set; }
    }
}
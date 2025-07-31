using MediatR;

namespace StockSphere.Application.Feature.Query.Login
{
    public class LoginQueryRequest:IRequest<LoginQueryResponse>
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}
using MediatR;

namespace StockSphere.Application.Feature.Command.Register
{
    public class RegisterCommandRequest:IRequest<RegisterCommandResponse>
    {
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
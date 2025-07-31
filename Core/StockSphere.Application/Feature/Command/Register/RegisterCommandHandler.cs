using MediatR;
using StockSphere.Application.Abstractions.Services;
using StockSphere.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSphere.Application.Feature.Command.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommandRequest, RegisterCommandResponse>
    {
        private readonly IAuthService _authService;

        public RegisterCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<RegisterCommandResponse> Handle(RegisterCommandRequest request, CancellationToken cancellationToken)
        {
            ResponseDto response = await _authService.Register(
                 new()
                 {
                     Password = request.Password,
                     Email = request.Email,
                     Username = request.Username,
                 });

            return new()
            { Message =response.Message,
            Status = response.Status,   
            };


        }
    }
}

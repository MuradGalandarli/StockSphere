using MediatR;
using StockSphere.Application.Abstractions.Services;
using StockSphere.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSphere.Application.Feature.Query.Login
{
    public class LoginQueryHandler : IRequestHandler<LoginQueryRequest, LoginQueryResponse>
    {
        private readonly IAuthService _authService;

        public LoginQueryHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<LoginQueryResponse> Handle(LoginQueryRequest request, CancellationToken cancellationToken)
        {
            TokenDto tokenDto = await _authService.Login(new() { Username = request.Username, Password = request.Password });
            return new()
            {
            Expiration = tokenDto.Expiration,
            Token = tokenDto.Token,
            };

        }
    }
}

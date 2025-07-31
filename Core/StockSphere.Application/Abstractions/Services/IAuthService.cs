using StockSphere.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSphere.Application.Abstractions.Services
{
    public interface IAuthService
    {
        public Task<ResponseDto> Register(RegisterModelDto register);
        public Task<TokenDto> Login(LoginModelDto login); 
    }
}

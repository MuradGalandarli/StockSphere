using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using StockSphere.Application.Abstractions.Services;
using StockSphere.Application.Dtos;
using StockSphere.Application.Excetions;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace StockSphere.Persistence.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        public AuthService(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        public async Task<TokenDto> Login(LoginModelDto login)
        {
            var user = await _userManager.FindByNameAsync(login.Username);
            if (user != null && await _userManager.CheckPasswordAsync(user, login.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };
                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }
                var token = GetToken(authClaims);
                
                return new()
                {
                    Token = token.token,
                    Expiration = token.expiration
                };
            }
            throw new LoginFailedException("İstifadəçi adı və ya şifrə yanlışdır.");
        }
        public async Task<ResponseDto> Register(RegisterModelDto register)
        {
          
            var userExists = await _userManager.FindByNameAsync(register.Username);
            if (userExists != null)
                return new ResponseDto { Status = "Error", Message = "User already exists!" };
            IdentityUser user = new()
            {
                Email = register.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = register.Username

            };
            var result = await _userManager.CreateAsync(user, register.Password);
            if (!result.Succeeded)
                return  new ResponseDto { Status = "Error", Message = "User creation failed! Please check user details and try again." };
            return new ResponseDto { Status = "Success", Message = "User created successfully!" };
        }
        private (string token,DateTime expiration) GetToken(List<Claim> authClaims)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );
           
            string jwt = tokenHandler.WriteToken(token);
            return (jwt,token.ValidTo);
        }
    }
}

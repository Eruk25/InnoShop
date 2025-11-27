using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using InnoShop.UsersService.Application.Abstractions.TokenGenerator;
using Microsoft.IdentityModel.Tokens;

namespace InnoShop.UsersService.Infrastructure.Implementations.TokenGenerator;

public class TokenService : ITokenService
{
    public Task<string> GenerateServiceTokenAsync(string secretKey, string issuer)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            issuer: issuer,
            audience: issuer,
            claims: new[]
            {
                new Claim("service", "UserService"),
            },
            expires: DateTime.UtcNow.AddMinutes(20),
            signingCredentials: credentials);
        return Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));
    }
}
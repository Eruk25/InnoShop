namespace InnoShop.UsersService.Application.Abstractions.TokenGenerator;

public interface ITokenService
{
    public Task<string> GenerateServiceTokenAsync(string secretKey, string issuer);
}
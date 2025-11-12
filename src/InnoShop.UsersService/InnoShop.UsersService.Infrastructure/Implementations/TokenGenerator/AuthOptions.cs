namespace InnoShop.UsersService.Infrastructure.Implementations.TokenGenerator;

public class AuthOptions
{
    public string Issuer { get; init; } = string.Empty;
    public string Audience { get; init; } = string.Empty;
    public string SecretKey { get; init; } = string.Empty;
    public string ExpirationTime { get; init; } = string.Empty;
}
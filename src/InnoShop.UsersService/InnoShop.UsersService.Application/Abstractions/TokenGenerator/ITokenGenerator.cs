using InnoShop.UsersService.Domain.Entities;

namespace InnoShop.UsersService.Application.Abstractions.TokenGenerator;

public interface ITokenGenerator
{
    public string GenerateToken(User user);
}
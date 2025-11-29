using InnoShop.UsersService.Domain.Entities;

namespace InnoShop.UsersService.Application.Abstractions.UrlGenerator;

public interface IPasswordResetLinkFactory
{
    public string GenerateLink(PasswordResetToken token);
}
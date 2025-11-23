using InnoShop.UsersService.Domain.Entities;

namespace InnoShop.UsersService.Application.Abstractions.UrlGenerator;

public interface IUrlGenerator
{
    public string GenerateLink(EmailVerificationToken emailVerificationToken);
}
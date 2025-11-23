using InnoShop.UsersService.Domain.Entities;

namespace InnoShop.UsersService.Application.Abstractions.UrlGenerator;

public interface IUrlGenerator
{
    public string GenerateLink(Domain.Entities.EmailVerificationToken emailVerificationToken);
}
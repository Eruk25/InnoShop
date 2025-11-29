using InnoShop.UsersService.Application.Abstractions.UrlGenerator;
using InnoShop.UsersService.Domain.Entities;

namespace InnoShop.UsersService.API.Implementations;

public class PasswordResetUrlGenerator : IPasswordResetLinkFactory
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly LinkGenerator _linkGenerator;
    
    public PasswordResetUrlGenerator()
    public string GenerateLink(Guid token)
    {
        
    }
}
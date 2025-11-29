using InnoShop.UsersService.Application.Abstractions.UrlGenerator;
using InnoShop.UsersService.Domain.Entities;

namespace InnoShop.UsersService.API.Implementations;

public class PasswordResetLinkFactory : IPasswordResetLinkFactory
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly LinkGenerator _linkGenerator;

    public PasswordResetLinkFactory(IHttpContextAccessor httpContextAccessor, LinkGenerator linkGenerator)
    {
        _httpContextAccessor = httpContextAccessor;
        _linkGenerator = linkGenerator;
    }
    
    public string GenerateLink(PasswordResetToken token)
    {
        string? verificationLink = _linkGenerator.GetUriByAction(
            action: "ResetPassword",
            controller: "Auth",
            values: new { token = token.Id},
            scheme: _httpContextAccessor.HttpContext!.Request.Scheme,
            host: _httpContextAccessor.HttpContext.Request.Host);
        return verificationLink ?? throw new Exception("Could not generate link");
    }
}
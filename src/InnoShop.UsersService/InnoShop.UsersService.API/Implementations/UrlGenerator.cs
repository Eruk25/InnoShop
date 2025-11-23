using InnoShop.UsersService.Application.Abstractions.UrlGenerator;
using InnoShop.UsersService.Domain.Entities;

namespace InnoShop.UsersService.API.Implementations;

public class UrlGenerator : IUrlGenerator
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly LinkGenerator _linkGenerator;

    public UrlGenerator(IHttpContextAccessor httpContextAccessor, LinkGenerator linkGenerator)
    {
        _httpContextAccessor = httpContextAccessor;
        _linkGenerator = linkGenerator;
    }
    
    public string GenerateLink(EmailVerificationToken emailVerificationToken)
    {
        string? verificationLink = _linkGenerator.GetUriByAction(
            action: "VerifyEmail",
            controller: "Auth",
            values: new { token = emailVerificationToken.Id},
            scheme: _httpContextAccessor.HttpContext!.Request.Scheme,
            host: _httpContextAccessor.HttpContext.Request.Host);
        
        return verificationLink ?? throw new Exception("Could not generate link");
    }
}
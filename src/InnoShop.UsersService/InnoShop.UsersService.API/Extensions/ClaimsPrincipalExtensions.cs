using System.Security.Claims;

namespace InnoShop.UsersService.API.Extensions;

public static class ClaimsPrincipalExtensions
{
    public static string GetUserId(this ClaimsPrincipal principal)
    {
        var userId = principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (userId is null)
            throw new KeyNotFoundException($"User with id {userId} not found");

        return userId;
    }

    public static string? GetEmail(this ClaimsPrincipal principal)
        => principal.FindFirst(ClaimTypes.Email)?.Value;

    public static string? GetName(this ClaimsPrincipal principal)
        => principal.FindFirst(ClaimTypes.Name)?.Value;

    public static string? GetRole(this ClaimsPrincipal principal)
        => principal.FindFirst(ClaimTypes.Role)?.Value;
}
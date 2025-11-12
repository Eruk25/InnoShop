using InnoShop.UsersService.Application.Users.Get;
using Microsoft.Extensions.DependencyInjection;

namespace InnoShop.UsersService.Application.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(typeof(GetAllUsersQuery).Assembly));
        
        return services;
    }
}
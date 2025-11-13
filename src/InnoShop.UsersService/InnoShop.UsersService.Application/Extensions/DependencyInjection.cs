using InnoShop.UsersService.Application.Mappings;
using InnoShop.UsersService.Application.Users.Get;
using Microsoft.Extensions.DependencyInjection;

namespace InnoShop.UsersService.Application.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssemblies(typeof(DependencyInjection).Assembly));
        services.AddAutoMapper(cfg =>
        {
            cfg.AddMaps(typeof(DependencyInjection).Assembly);
        });
        return services;
    }
}
using InnoShop.ProductsService.Application.Mappings;
using Microsoft.Extensions.DependencyInjection;

namespace InnoShop.ProductsService.Application.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssemblies(typeof(ProductProfile).Assembly));
        services.AddAutoMapper(cfg =>
            cfg.AddProfile<ProductProfile>());
        return services;
    }
}
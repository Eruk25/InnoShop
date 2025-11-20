namespace InnoShop.ProductsService.API.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddOpenApi();
        
        return services;
    }
}
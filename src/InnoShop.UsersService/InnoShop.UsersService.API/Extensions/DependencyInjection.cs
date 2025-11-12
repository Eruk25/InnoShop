namespace InnoShop.UsersService.API.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddInnoShopUsersServices(this IServiceCollection services)
    {
        services.AddOpenApi();
        services.AddControllers();
        services.AddSwaggerGen();

        return services;
    }
}
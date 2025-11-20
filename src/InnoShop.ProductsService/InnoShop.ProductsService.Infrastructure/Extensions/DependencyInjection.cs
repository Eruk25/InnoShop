using InnoShop.ProductsService.Application.Abstractions.Repositories;
using InnoShop.ProductsService.Infrastructure.Persistence.DB;
using InnoShop.ProductsService.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InnoShop.ProductsService.Infrastructure.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<ProductContext>(opt =>
            opt.UseSqlServer(configuration.GetConnectionString("SqlConnection")));

        services.AddScoped<IProductRepository, ProductRepository>();
        return services;
    }
}
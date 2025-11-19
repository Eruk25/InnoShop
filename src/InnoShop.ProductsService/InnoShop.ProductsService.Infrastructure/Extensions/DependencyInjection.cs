using InnoShop.ProductsService.Infrastructure.Persistence.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InnoShop.ProductsService.Infrastructure.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<ProductContext>(opt =>
            opt.UseSqlServer(configuration.GetConnectionString("SqlConnection")));
        
        return services;
    }
}
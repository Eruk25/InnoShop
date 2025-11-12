using Identity.PasswordHasher;
using InnoShop.UsersService.Application.Abstractions.Repositories;
using InnoShop.UsersService.Application.Abstractions.TokenGenerator;
using InnoShop.UsersService.Infrastructure.Implementations.TokenGenerator;
using InnoShop.UsersService.Infrastructure.Persistence.DB;
using InnoShop.UsersService.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InnoShop.UsersService.Infrastructure.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<UserContext>(opt =>
            opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IPasswordHasher, PasswordHasher>();
        return services;
    }
}
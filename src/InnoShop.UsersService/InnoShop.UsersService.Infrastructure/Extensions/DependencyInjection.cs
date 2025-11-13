using InnoShop.UsersService.Application.Abstractions.PasswordHasher;
using InnoShop.UsersService.Infrastructure.Implementations.PasswordHasher;
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
            opt.UseSqlServer(configuration.GetConnectionString("SqlConnection")));
        services.Configure<AuthOptions>(configuration.GetSection("AuthOptions"));
        
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<Identity.PasswordHasher.PasswordHasher>();
        services.AddScoped<IPasswordHasher, PasswordHasher>();
        services.AddScoped<ITokenGenerator, TokenGenerator>();
        return services;
    }
}
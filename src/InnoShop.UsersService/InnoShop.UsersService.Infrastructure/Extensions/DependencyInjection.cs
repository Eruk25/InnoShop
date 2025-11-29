using InnoShop.UsersService.Application.Abstractions.EmailSender;
using InnoShop.UsersService.Application.Abstractions.PasswordHasher;
using InnoShop.UsersService.Infrastructure.Implementations.PasswordHasher;
using InnoShop.UsersService.Application.Abstractions.Repositories;
using InnoShop.UsersService.Application.Abstractions.TokenGenerator;
using InnoShop.UsersService.Infrastructure.HostedServices;
using InnoShop.UsersService.Infrastructure.Implementations.EmailSender;
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
        var userSection = configuration.GetSection("UserService:ConnectionStrings");
        var connectionString = userSection["DefaultConnection"];
        services.AddDbContext<UserContext>(opt =>
            opt.UseSqlServer(connectionString));
        services.Configure<AuthOptions>(configuration.GetSection("AuthOptions"));
        
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IEmailVerificationTokenRepository, EmailVerificationTokenRepository>();
        services.AddScoped<IPasswordResetTokenRepository, PasswordResetTokenRepository>();
        services.AddScoped<IEmailSender, EmailSender>();
        services.AddScoped<Identity.PasswordHasher.PasswordHasher>();
        services.AddScoped<IPasswordHasher, PasswordHasher>();
        services.AddScoped<ITokenGenerator, TokenGenerator>();
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IOutBoxMessageRepository, OutBoxMessageRepository>();
        services.AddHostedService<OutBoxDispatcher>();
        return services;
    }
}
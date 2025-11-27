using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace InnoShop.ProductsService.API.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddControllers();
        services.AddOpenApi();
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidIssuer = configuration["AuthOptions:Issuer"],
                    ValidateAudience = true,
                    ValidAudience = configuration["AuthOptions:Audience"],
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(configuration["AuthOptions:SecretKey"])),
                };
            })
            .AddJwtBearer("ServiceAuth",options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {   
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = configuration["ServiceAuth:Issuer"],
                    ValidAudience = configuration["ServiceAuth:Issuer"],
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(configuration["ServiceAuth:Secret"])),
                };
            });
        return services;
    }
}
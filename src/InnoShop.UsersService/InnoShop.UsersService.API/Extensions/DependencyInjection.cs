using System.Security.Claims;
using System.Text;
using InnoShop.UsersService.API.Implementations;
using InnoShop.UsersService.API.Middleware;
using InnoShop.UsersService.Application.Abstractions.UrlGenerator;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace InnoShop.UsersService.API.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddControllers();
        services.AddSwaggerGen(opt =>
        {
            opt.SwaggerDoc("v1", new OpenApiInfo() { Title = "InnoShop", Version = "v1" });
            opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Please enter a valid token",
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                BearerFormat = "JWT",
                Scheme = "Bearer"
            });
            opt.AddSecurityRequirement(new OpenApiSecurityRequirement {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference()
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new List<string>()
                }
            });
        });
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = configuration["AuthOptions:Issuer"],
                    ValidAudience = configuration["AuthOptions:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(configuration["AuthOptions:SecretKey"]!)),
                    RoleClaimType = ClaimTypes.Role
                };
            });
        services.AddAuthorization();
        services.AddScoped<IUrlGenerator, UrlGenerator>();
        services.AddScoped<IPasswordResetLinkFactory, PasswordResetLinkFactory>();
        services.AddTransient<ExceptionHandlingMiddleware>();
        services.AddHttpContextAccessor();
        return services;
    }
}
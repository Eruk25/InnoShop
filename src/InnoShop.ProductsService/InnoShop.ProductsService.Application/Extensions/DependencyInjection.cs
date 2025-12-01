using FluentValidation;
using InnoShop.ProductsService.Application.Common.Behaviors;
using InnoShop.ProductsService.Application.Mappings;
using InnoShop.ProductsService.Application.Products.Create;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace InnoShop.ProductsService.Application.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssemblies(typeof(CreateProductCommand).Assembly));
        services.AddAutoMapper(cfg =>
            cfg.AddProfile<ProductProfile>());
        services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));
        return services;
    }
}
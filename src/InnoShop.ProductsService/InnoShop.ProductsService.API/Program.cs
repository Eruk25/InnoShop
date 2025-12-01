using InnoShop.ProductsService.API.Extensions;
using InnoShop.ProductsService.API.Middleware;
using InnoShop.ProductsService.Application.Extensions;
using InnoShop.ProductsService.Infrastructure.Extensions;
using InnoShop.ProductsService.Infrastructure.Persistence.DB;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile("appsettings.Development.json", optional: false)
    .AddEnvironmentVariables();

builder.Services
    .AddPresentation(builder.Configuration)
    .AddApplication()
    .AddInfrastructure(builder.Configuration);
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
using var scope = app.Services.CreateScope();
var db = scope.ServiceProvider.GetRequiredService<ProductContext>();
await db.Database.MigrateAsync();
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();
app.MapControllers();

app.Run();
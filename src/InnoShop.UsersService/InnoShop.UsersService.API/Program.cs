using InnoShop.UsersService.API.Extensions;
using InnoShop.UsersService.API.Middleware;
using InnoShop.UsersService.Application.Extensions;
using InnoShop.UsersService.Infrastructure.Extensions;
using InnoShop.UsersService.Infrastructure.Persistence.DB;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile("appsettings.Development.json", optional: true)
    .AddEnvironmentVariables();

builder.Services
    .AddPresentation(builder.Configuration)
    .AddInfrastructure(builder.Configuration)
    .AddApplication();

builder.Services
    .AddFluentEmail(builder.Configuration);
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
using var scope = app.Services.CreateScope();
var db = scope.ServiceProvider.GetRequiredService<UserContext>();
await db.Database.MigrateAsync();
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
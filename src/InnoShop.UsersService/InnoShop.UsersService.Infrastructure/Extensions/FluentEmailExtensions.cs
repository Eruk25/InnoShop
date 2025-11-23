using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InnoShop.UsersService.Infrastructure.Extensions;

public static class FluentEmailExtensions
{
    public static void AddFluentEmail(this IServiceCollection services, IConfiguration configuration)
    {
        var emailSettings = configuration.GetSection("Email");

        var defaultEmail = emailSettings["DefaultFromEmail"];
        var host = emailSettings["Host"];
        var port = emailSettings.GetValue<int>("Port");
        var username = emailSettings["Username"];
        var password = emailSettings["Password"];

        services.AddFluentEmail(defaultEmail)
            .AddSmtpSender(host, port, username, password);
    }
}
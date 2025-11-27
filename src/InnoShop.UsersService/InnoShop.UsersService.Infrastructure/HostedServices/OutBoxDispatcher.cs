using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using InnoShop.UsersService.Application.Abstractions.TokenGenerator;
using InnoShop.UsersService.Domain.Primitives;
using InnoShop.UsersService.Infrastructure.Persistence.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace InnoShop.UsersService.Infrastructure.HostedServices;

public class OutBoxDispatcher : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly HttpClient _httpClient;

    public OutBoxDispatcher(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        _httpClient = new HttpClient();
    }
    
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            using var scope = _serviceProvider.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<UserContext>();
            var tokenService = scope.ServiceProvider.GetRequiredService<ITokenService>();
            var messages = await db.OutBoxMessages
                .Where(m => m.ProcessedOn == null)
                .OrderBy(m => m.OccurredOn)
                .Take(20)
                .ToListAsync(stoppingToken);

            foreach (var msg in messages)
            {
                try
                {
                    var token = await tokenService.GenerateServiceTokenAsync(
                        "mysecretKeysadjaksjdkjdaskdjakldjkasdkajkldsjksakdlakdslalddsadadsdas", "UserService");
                     _httpClient.DefaultRequestHeaders.Authorization = 
                         new AuthenticationHeaderValue("Bearer", token);
                    var payload = JsonSerializer.Deserialize<UserDeletedEvent>(msg.Payload)
                        ?? throw new Exception("Payload is null");
                    var response = await _httpClient.PostAsJsonAsync(
                        $"http://localhost:5188/api/products/{payload.UserId}/soft-delete",
                        payload,
                        stoppingToken);
                    response.EnsureSuccessStatusCode();
                    msg.ProcessedOn = DateTime.UtcNow;
                }
                catch (Exception e)
                {
                    msg.Error = e.Message;
                }
            }
            
            await db.SaveChangesAsync(stoppingToken);
            await Task.Delay(1000, stoppingToken);
        }
    }
}
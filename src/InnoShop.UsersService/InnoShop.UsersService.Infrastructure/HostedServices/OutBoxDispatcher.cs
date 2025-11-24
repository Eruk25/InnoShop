using System.Net.Http.Json;
using System.Text.Json;
using InnoShop.UsersService.Domain.Primitives;
using InnoShop.UsersService.Infrastructure.Persistence.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace InnoShop.UsersService.Infrastructure.HostedServices;

public class OutBoxDispatcher : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly HttpClient _httpClient = new();

    public OutBoxDispatcher(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }
    
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var scope = _serviceProvider.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<UserContext>();

            var messages = await db.OutBoxMessages
                .Where(m => m.ProcessedOn == null)
                .OrderBy(m => m.OccurredOn)
                .Take(20)
                .ToListAsync(stoppingToken);

            foreach (var msg in messages)
            {
                try
                {
                    var payload = JsonSerializer.Deserialize<UserDeletedEvent>(msg.Payload);
                    var response = await _httpClient.DeleteAsync(
                        $"http://localhost:5188/api/products/{payload.UserId}/delete",
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
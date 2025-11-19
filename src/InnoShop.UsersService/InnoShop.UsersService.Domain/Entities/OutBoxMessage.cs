namespace InnoShop.UsersService.Domain.Entities;

public class OutBoxMessage(string type, string payload)
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime OccurredOn { get; set; } = DateTime.UtcNow;
    public string Type { get; set; } = type;
    public string Payload { get; set; } = payload;
    public DateTime? ProcessedOn { get; set; }
    public string? Error { get; set; }
}
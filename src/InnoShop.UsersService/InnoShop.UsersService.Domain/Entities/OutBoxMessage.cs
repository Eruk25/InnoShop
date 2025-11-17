namespace InnoShop.UsersService.Domain.Entities;

public class OutBoxMessage(Guid id, string type, string payload)
{
    public Guid Id { get; private set; } = id;
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    public string Type { get; private set; } = type;
    public string Payload { get; private set; } = payload;
    public DateTime? ProcessedAt { get; private set; }
    public string? Error { get; private set; }
}
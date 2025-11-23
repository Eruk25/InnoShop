namespace InnoShop.UsersService.Domain.Entities;

public class EmailVerificationToken
{
    public Guid Id { get; set; }
    public int UserId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime ExpiresAt { get; set; }
    public User User { get; set; }
}
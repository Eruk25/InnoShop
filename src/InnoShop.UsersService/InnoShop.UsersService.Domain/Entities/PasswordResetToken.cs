namespace InnoShop.UsersService.Domain.Entities;

public class PasswordResetToken
{
    public Guid Id { get; }
    public int UserId { get; }
    public DateTime ExpiresAt { get; }

    public PasswordResetToken(Guid id, int userId, DateTime expiresAt)
    {
        Id = id;
        UserId = userId;
        ExpiresAt = expiresAt;
    }
    public  PasswordResetToken(){}
}
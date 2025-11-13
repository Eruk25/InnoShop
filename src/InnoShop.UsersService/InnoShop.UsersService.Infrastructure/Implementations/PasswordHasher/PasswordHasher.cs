using InnoShop.UsersService.Application.Abstractions.PasswordHasher;

namespace InnoShop.UsersService.Infrastructure.Implementations.PasswordHasher;

public class PasswordHasher : IPasswordHasher
{
    private readonly Identity.PasswordHasher.PasswordHasher _hasher;

    public PasswordHasher(Identity.PasswordHasher.PasswordHasher hasher)
    {
        _hasher = hasher;
    }
    
    public string HashPassword(string password)
    {
        return _hasher.HashPassword(password);
    }

    public bool VerifyHashedPassword(string password, string hashedPassword)
    {
        return _hasher.VerifyHashedPassword(hashedPassword, password);
    }
}
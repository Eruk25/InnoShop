namespace InnoShop.UsersService.Application.Abstractions.PasswordHasher;

public interface IPasswordHasher
{
    public string HashPassword(string password);
    public bool VerifyHashedPassword(string hashedPassword, string providedPassword);
}
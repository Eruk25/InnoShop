using InnoShop.UsersService.Domain.Enums;

namespace InnoShop.UsersService.Domain.Entities;

public class User
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Email { get; private set; }
    public Role Role { get; private set; }
    public Status Status { get; private set; }
    public string Password { get; private set; }

    public User(string name, string email, string password)
    {
        UpdateName(name);
        UpdateEmail(email);
        UpdatePassword(password);
        UpdateRole(Role.Seller);
        UpdateStatus(Status.Active);
    }

    public void UpdateName(string name)
    {
        if(string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be empty", nameof(name));
        Name = name;
    }

    public void UpdateEmail(string email)
    {
        if(string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("Email cannot be empty", nameof(email));
        Email = email;
    }

    public void UpdateRole(Role role)
    {
        Role = role;
    }

    public void UpdateStatus(Status status)
    {
        Status = status;
    }
    
    public void UpdatePassword(string password)
    {
        if(string.IsNullOrWhiteSpace(password))
            throw new ArgumentException("Password cannot be empty", nameof(password));
        if(password.Length < 6)
            throw new ArgumentException("Password must be at least 6 characters", nameof(password));
        Password = password;
    }
}
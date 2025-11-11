using InnoShop.UsersService.Application.Abstractions.Repositories;
using InnoShop.UsersService.Domain.Entities;
using InnoShop.UsersService.Infrastructure.Persistence.DB;
using Microsoft.EntityFrameworkCore;

namespace InnoShop.UsersService.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly UserContext _context;

    public UserRepository(UserContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.Id == id);
        return user;
    }

    public async Task<bool> ExistByEmailAsync(string email)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.Email == email);
        return user is not null;
    }
    public async Task<User> CreateAsync(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        return user;
    }   

    public async Task UpdateAsync(User user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var user = await _context.Users.
            FirstOrDefaultAsync(u => u.Id == id);
        if (user is null)
            return false;
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
        return true;
    }
}

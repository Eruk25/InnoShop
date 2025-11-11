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

    public async Task<User> CreateAsync(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        return user;
    }   

    public async Task<User> UpdateAsync(int id, User user)
    {
        var existing = await _context.Users.
            FirstAsync(u => u.Id == id);
        existing.UpdateName(user.Name);
        existing.UpdateEmail(user.Email);
        existing.UpdateRole(user.Role);
        existing.UpdateStatus(user.Status);
        existing.UpdatePassword(user.Password);
        await _context.SaveChangesAsync();
        return existing;
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

using InnoShop.UsersService.Application.Abstractions.Repositories;
using InnoShop.UsersService.Domain.Entities;
using InnoShop.UsersService.Infrastructure.Persistence.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace InnoShop.UsersService.Infrastructure.Persistence.Repositories;

public class PasswordResetTokenRepository : IPasswordResetTokenRepository
{
    private readonly UserContext _context;
    
    public PasswordResetTokenRepository(UserContext context)
    {
        _context = context;
    }
    
    public async Task CreateAsync(PasswordResetToken passwordResetToken)
    {
        await _context.PasswordResetTokens.AddAsync(passwordResetToken);
        await _context.SaveChangesAsync();
    }

    public async Task<PasswordResetToken> GetByIdAsync(Guid id)
    {
        var token = await _context.PasswordResetTokens.FirstAsync(t => t.Id == id);
        return token;
    }

    public async Task DeleteAsync(PasswordResetToken passwordResetToken)
    {
        _context.PasswordResetTokens.Remove(passwordResetToken);
        await _context.SaveChangesAsync();
    }
}
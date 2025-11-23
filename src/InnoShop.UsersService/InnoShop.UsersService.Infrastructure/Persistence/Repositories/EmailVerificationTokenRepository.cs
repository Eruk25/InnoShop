using InnoShop.UsersService.Application.Abstractions.Repositories;
using InnoShop.UsersService.Domain.Entities;
using InnoShop.UsersService.Infrastructure.Persistence.DB;
using Microsoft.EntityFrameworkCore;

namespace InnoShop.UsersService.Infrastructure.Persistence.Repositories;

public class EmailVerificationTokenRepository : IEmailVerificationTokenRepository 
{
    private readonly UserContext _context;

    public EmailVerificationTokenRepository(UserContext context)
    {
        _context = context;
    }

    public Task<EmailVerificationToken?> GetByIdAsync(Guid tokenId)
    {
        var token = _context.EmailVerificationTokens
            .Include(e => e.User)
            .FirstOrDefaultAsync(e => e.Id == tokenId);
        return token;
    }

    public async Task CreateAsync(EmailVerificationToken token)
    {
        await _context.EmailVerificationTokens.AddAsync(token);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(EmailVerificationToken token)
    {
        _context.EmailVerificationTokens.Remove(token);
        await _context.SaveChangesAsync();
    }
}
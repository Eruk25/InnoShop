using InnoShop.UsersService.Application.Abstractions.Repositories;
using InnoShop.UsersService.Domain.Entities;
using InnoShop.UsersService.Infrastructure.Persistence.DB;

namespace InnoShop.UsersService.Infrastructure.Persistence.Repositories;

public class OutBoxMessageRepository : IOutBoxMessageRepository
{
    private readonly UserContext _context;
    
    public OutBoxMessageRepository(UserContext context)
    {
        _context = context;
    }
    
    public async Task CreateAsync(OutBoxMessage message)
    {
        await _context.OutBoxMessages.AddAsync(message);
        await _context.SaveChangesAsync();
    }
}
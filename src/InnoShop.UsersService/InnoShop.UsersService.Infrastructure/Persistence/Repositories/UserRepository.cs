using InnoShop.UsersService.Application.Abstractions.Repositories;
using InnoShop.UsersService.Domain.Entities;

namespace InnoShop.UsersService.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    public Task<IEnumerable<User>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<User> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<int> CreateAsync(User user)
    {
        throw new NotImplementedException();
    }

    public Task<User> UpdateAsync(User user)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}

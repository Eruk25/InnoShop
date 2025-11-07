using InnoShop.UsersService.Domain.Entities;

namespace InnoShop.UsersService.Application.Abstractions.Repository;

public interface IUserRepository
{
    public Task<IEnumerable<User>> GetAllAsync();
    public Task<User> GetByIdAsync(int id);
    public Task<int> CreateAsync(User user);
    public Task<User> UpdateAsync(User user);
    public Task<bool> DeleteAsync(int id);
}
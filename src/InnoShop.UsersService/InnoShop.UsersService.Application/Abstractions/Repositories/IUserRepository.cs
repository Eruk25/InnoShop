using InnoShop.UsersService.Domain.Entities;

namespace InnoShop.UsersService.Application.Abstractions.Repositories;

public interface IUserRepository
{
    public Task<IEnumerable<User>> GetAllAsync();
    public Task<User?> GetByIdAsync(int id);
    public Task<User?> GetByEmailAsync(string email);
    public Task<bool> ExistByEmailAsync(string email);
    public Task<User> CreateAsync(User user);
    public Task UpdateAsync(User user);
    public Task<bool> DeleteAsync(int id);
}
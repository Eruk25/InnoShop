using InnoShop.UsersService.Domain.Entities;

namespace InnoShop.UsersService.Application.Abstractions.Repositories;

public interface IUserRepository
{
    public Task<IEnumerable<User>> GetAllAsync();
    public Task<User?> GetByIdAsync(int id);
    public Task<bool> ExistByEmailAsync(string email);
    public Task<User> CreateAsync(User user);
    public Task<User> UpdateAsync(int id, User user);
    public Task<bool> DeleteAsync(int id);
}
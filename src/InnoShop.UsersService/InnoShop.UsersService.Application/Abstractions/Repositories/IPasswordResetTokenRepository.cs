using InnoShop.UsersService.Domain.Entities;

namespace InnoShop.UsersService.Application.Abstractions.Repositories;

public interface IPasswordResetTokenRepository
{
    public Task CreateAsync(PasswordResetToken passwordResetToken);
    public Task<PasswordResetToken> GetByIdAsync(Guid id);
    public Task DeleteAsync(PasswordResetToken passwordResetToken);
}
using InnoShop.UsersService.Domain.Entities;

namespace InnoShop.UsersService.Application.Abstractions.Repositories;

public interface IEmailVerificationTokenRepository
{
    public Task<Domain.Entities.EmailVerificationToken?> GetByIdAsync(Guid tokenId);
    public Task CreateAsync(Domain.Entities.EmailVerificationToken token);
    public Task DeleteAsync(Domain.Entities.EmailVerificationToken token);
}
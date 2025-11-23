using InnoShop.UsersService.Domain.Entities;

namespace InnoShop.UsersService.Application.Abstractions.Repositories;

public interface IEmailVerificationTokenRepository
{
    public Task CreateAsync(EmailVerificationToken token);
}
using InnoShop.UsersService.Domain.Entities;

namespace InnoShop.UsersService.Application.Abstractions.Repositories;

public interface IOutBoxMessageRepository
{
    public Task CreateAsync(OutBoxMessage message);
};
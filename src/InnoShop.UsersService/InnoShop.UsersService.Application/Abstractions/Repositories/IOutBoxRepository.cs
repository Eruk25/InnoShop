using InnoShop.UsersService.Domain.Entities;

namespace InnoShop.UsersService.Application.Abstractions.Repositories;

public interface IOutBoxRepository
{
    public Task CreateAsync(OutBoxMessage message);
};
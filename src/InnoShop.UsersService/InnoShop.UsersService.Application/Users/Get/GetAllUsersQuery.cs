using InnoShop.UsersService.Domain.Enums;
using MediatR;

namespace InnoShop.UsersService.Application.Users.Get;

public record GetAllUsersQuery() : IRequest<IEnumerable<UserDto>>;
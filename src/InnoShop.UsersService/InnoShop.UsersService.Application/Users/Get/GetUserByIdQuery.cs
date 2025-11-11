using MediatR;

namespace InnoShop.UsersService.Application.Users.Get;

public record GetUserByIdQuery(int Id) : IRequest<UserDto>;
using MediatR;

namespace InnoShop.UsersService.Application.Users.Delete;

public record DeleteUserCommand(int Id) : IRequest<bool>;
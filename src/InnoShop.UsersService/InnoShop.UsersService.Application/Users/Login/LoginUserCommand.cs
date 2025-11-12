using MediatR;

namespace InnoShop.UsersService.Application.Users.Login;

public record LoginUserCommand(string Email, string Password)
    : IRequest<string>;
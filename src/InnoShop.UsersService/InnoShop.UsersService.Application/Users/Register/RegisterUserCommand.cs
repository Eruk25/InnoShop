using InnoShop.UsersService.Application.Users.Results;
using MediatR;

namespace InnoShop.UsersService.Application.Users.Register;

public record RegisterUserCommand(string Name, string Email, string Password)
    : IRequest<RegisterUserResult>;
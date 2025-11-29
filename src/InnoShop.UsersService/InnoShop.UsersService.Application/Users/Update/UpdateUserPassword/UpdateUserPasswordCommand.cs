using MediatR;

namespace InnoShop.UsersService.Application.Users.Update.UpdateUserPassword;

public record UpdateUserPasswordCommand(string Email, string ResetCode, string NewPassword)
    : IRequest;
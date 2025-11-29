using MediatR;

namespace InnoShop.UsersService.Application.PasswordVerificationToken;

public record ForgotPasswordCommand(string Email) : IRequest;
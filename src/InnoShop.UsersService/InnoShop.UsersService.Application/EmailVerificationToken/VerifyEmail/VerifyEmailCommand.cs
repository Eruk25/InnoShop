using MediatR;

namespace InnoShop.UsersService.Application.EmailVerificationToken.VerifyEmail;

public record VerifyEmailCommand(Guid TokenId) : IRequest<bool>;
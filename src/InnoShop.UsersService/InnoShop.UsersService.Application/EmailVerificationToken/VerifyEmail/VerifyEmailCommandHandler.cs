using InnoShop.UsersService.Application.Abstractions.Repositories;
using MediatR;

namespace InnoShop.UsersService.Application.EmailVerificationToken.VerifyEmail;

public class VerifyEmailCommandHandler : IRequestHandler<VerifyEmailCommand, bool>
{
    private readonly IEmailVerificationTokenRepository _emailVerificationTokenRepository;

    public VerifyEmailCommandHandler(IEmailVerificationTokenRepository emailVerificationTokenRepository)
    {
        _emailVerificationTokenRepository = emailVerificationTokenRepository;
    }

    public async Task<bool> Handle(VerifyEmailCommand request, CancellationToken cancellationToken)
    {
        var token = await _emailVerificationTokenRepository.GetByIdAsync(request.TokenId);

        if (token is null || token.ExpiresAt < DateTime.UtcNow || token.User.IsConfirmed)
            return false;

        token.User.UpdateConfirm(true);

        await _emailVerificationTokenRepository.DeleteAsync(token);
        return true;
    }
}
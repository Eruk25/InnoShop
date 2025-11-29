using InnoShop.UsersService.Application.Abstractions.EmailSender;
using InnoShop.UsersService.Application.Abstractions.Repositories;
using InnoShop.UsersService.Application.Abstractions.UrlGenerator;
using InnoShop.UsersService.Domain.Entities;
using MediatR;

namespace InnoShop.UsersService.Application.PasswordVerificationToken;

public class ForgotPasswordCommandHandler : IRequestHandler<ForgotPasswordCommand>
{
    private readonly IPasswordResetTokenRepository _passwordResetTokenRepository;
    private readonly IPasswordResetLinkFactory _passwordResetLinkFactory;
    private readonly IUserRepository _userRepository;
    private readonly IEmailSender _emailSender;
    
    public ForgotPasswordCommandHandler(IPasswordResetTokenRepository passwordResetTokenRepository, IUserRepository userRepository,
        IEmailSender emailSender, IPasswordResetLinkFactory passwordResetLinkFactory)
    {
        _passwordResetTokenRepository = passwordResetTokenRepository;
        _userRepository = userRepository;
        _emailSender = emailSender;
        _passwordResetLinkFactory = passwordResetLinkFactory;
    }

    public async Task Handle(ForgotPasswordCommand request, CancellationToken cancellationToken)
    {
        if(request is null)
            throw new ArgumentNullException(nameof(request));
        
        var user = await _userRepository.GetByEmailAsync(request.Email);
        
        if(user is null)
            return;

        var token = new PasswordResetToken(
            Guid.NewGuid(),
            user.Id,
            DateTime.UtcNow.AddMinutes(20));
        await _passwordResetTokenRepository.CreateAsync(token);

        var verificationLink = _passwordResetLinkFactory.GenerateLink(token);
        await _emailSender.SendEmailAsync(request.Email, $"To password reset <a href={verificationLink}>click here</a>");
    }
}
using AutoMapper;
using InnoShop.UsersService.Application.Abstractions.PasswordHasher;
using InnoShop.UsersService.Application.Abstractions.Repositories;
using MediatR;

namespace InnoShop.UsersService.Application.Users.Update.UpdateUserPassword;

public class UpdateUserPasswordCommandHandler : IRequestHandler<UpdateUserPasswordCommand>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordResetTokenRepository _passwordResetTokenRepository;
    private readonly IPasswordHasher _passwordHasher;

    public UpdateUserPasswordCommandHandler(IUserRepository userRepository, IPasswordResetTokenRepository passwordResetTokenRepository,
        IPasswordHasher passwordHasher)
    {
        _userRepository = userRepository;
        _passwordResetTokenRepository = passwordResetTokenRepository;
        _passwordHasher = passwordHasher;
    }

    public async Task Handle(UpdateUserPasswordCommand request, CancellationToken cancellationToken)
    {
        if(request is null)
            throw new ArgumentNullException(nameof(request));

        var token = await _passwordResetTokenRepository.GetByIdAsync(Guid.Parse(request.ResetCode));
        
        if(token is null)
            throw new Exception("Token invalid or expired");
        
        var user  = await _userRepository.GetByIdAsync(token.UserId);
        var hashedPassword = _passwordHasher.HashPassword(request.NewPassword);
        
        user!.UpdatePassword(hashedPassword);
        
        await _userRepository.UpdateAsync(user);
        await _passwordResetTokenRepository.DeleteAsync(token);
    }
}
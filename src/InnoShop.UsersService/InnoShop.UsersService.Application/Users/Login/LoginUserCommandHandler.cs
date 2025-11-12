using System.Security.Authentication;
using InnoShop.UsersService.Application.Abstractions.PasswordHasher;
using InnoShop.UsersService.Application.Abstractions.Repositories;
using InnoShop.UsersService.Application.Abstractions.TokenGenerator;
using MediatR;

namespace InnoShop.UsersService.Application.Users.Login;

public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, string>
{
    private readonly IPasswordHasher _passwordHasher;
    private readonly ITokenGenerator _tokenGenerator;
    private readonly IUserRepository _userRepository;

    public LoginUserCommandHandler(IUserRepository userRepository, IPasswordHasher passwordHasher,
        ITokenGenerator tokenGenerator)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _tokenGenerator = tokenGenerator;
    }

    public async Task<string> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByEmailAsync(request.Email);

        if (user is null)
            throw new AuthenticationException($"User with email {request.Email} not found");

        var success = _passwordHasher.VerifyHashedPassword(request.Password, user.Password);

        if (!success)
            throw new AuthenticationException("Invalid password or email");
        
        return _tokenGenerator.GenerateToken(user);
    }
}
using AutoMapper;
using InnoShop.UsersService.Application.Abstractions.EmailSender;
using InnoShop.UsersService.Application.Abstractions.PasswordHasher;
using InnoShop.UsersService.Application.Abstractions.Repositories;
using InnoShop.UsersService.Application.Abstractions.UrlGenerator;
using InnoShop.UsersService.Application.Users.Results;
using InnoShop.UsersService.Domain.Entities;
using InnoShop.UsersService.Domain.Exceptions;
using MediatR;

namespace InnoShop.UsersService.Application.Users.Register;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, RegisterUserResult>
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;
    private readonly IEmailVerificationTokenRepository _emailVerificationTokenRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IEmailSender _emailSender;
    private readonly IUrlGenerator _urlGenerator;

    public RegisterUserCommandHandler(IUserRepository userRepository,
        IPasswordHasher passwordHasher, IMapper mapper,
        IEmailSender emailSender, IUrlGenerator urlGenerator,
        IEmailVerificationTokenRepository emailVerificationTokenRepository)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _mapper = mapper;
        _emailSender = emailSender;
        _urlGenerator = urlGenerator;
        _emailVerificationTokenRepository = emailVerificationTokenRepository;
    }

    public async Task<RegisterUserResult> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        if(request is null)
            throw new ArgumentNullException(nameof(request));
        
        if(await _userRepository.ExistByEmailAsync(request.Email))
            throw new UserAlreadyExistsException(request.Email);
        
        var user = new User(request.Name, request.Email, _passwordHasher.HashPassword(request.Password));
        var createdUser = await _userRepository.CreateAsync(user);

        var token = new Domain.Entities.EmailVerificationToken
        {
            Id = Guid.NewGuid(),
            UserId = user.Id,
            CreatedAt = DateTime.UtcNow,
            ExpiresAt = DateTime.UtcNow.AddMinutes(30)
        };
        await _emailVerificationTokenRepository.CreateAsync(token);
        string verificationLink = _urlGenerator.GenerateLink(token);
        await _emailSender.SendEmailAsync(user.Email, $"To verify your email address <a href={verificationLink}>click here</a>");
        
        return _mapper.Map<RegisterUserResult>(createdUser);
    }
}
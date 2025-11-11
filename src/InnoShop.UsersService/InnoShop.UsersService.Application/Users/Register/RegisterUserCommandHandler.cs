using AutoMapper;
using InnoShop.UsersService.Application.Abstractions.PasswordHasher;
using InnoShop.UsersService.Application.Abstractions.Repositories;
using InnoShop.UsersService.Application.Users.Results;
using InnoShop.UsersService.Domain.Entities;
using InnoShop.UsersService.Domain.Exceptions;
using MediatR;

namespace InnoShop.UsersService.Application.Users.Register;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, RegisterUserResult>
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;

    public RegisterUserCommandHandler(IUserRepository userRepository,
        IPasswordHasher passwordHasher, IMapper mapper)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _mapper = mapper;
    }

    public async Task<RegisterUserResult> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        if(request is null)
            throw new ArgumentNullException(nameof(request));
        
        if(await _userRepository.ExistByEmailAsync(request.Email))
            throw new UserAlreadyExistsException(request.Email);
        
        var user = new User(request.Name, request.Email, _passwordHasher.HashPassword(request.Password));
        var createdUser = await _userRepository.CreateAsync(user);
        
        return _mapper.Map<RegisterUserResult>(createdUser);
    }
}
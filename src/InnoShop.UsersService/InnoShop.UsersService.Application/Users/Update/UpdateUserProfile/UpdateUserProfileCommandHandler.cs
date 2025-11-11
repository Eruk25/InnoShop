using AutoMapper;
using InnoShop.UsersService.Application.Abstractions.PasswordHasher;
using InnoShop.UsersService.Application.Abstractions.Repositories;
using InnoShop.UsersService.Application.Users.Results;
using MediatR;

namespace InnoShop.UsersService.Application.Users.Update.UpdateUserProfile;

public class UpdateUserProfileCommandHandler : IRequestHandler<UpdateUserProfileCommand, UpdateUserProfileResult>
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;

    public UpdateUserProfileCommandHandler(IMapper mapper, IUserRepository userRepository,
        IPasswordHasher passwordHasher)
    {
        _mapper = mapper;
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
    }

    public async Task<UpdateUserProfileResult> Handle(UpdateUserProfileCommand request,
        CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.Id);
        
        if(user is null)
            throw new KeyNotFoundException($"User with id {request.Id} not found");
        
        var passwordHash = _passwordHasher.HashPassword(request.Password);
        user.UpdateProfile(request.Name, request.Email, passwordHash);
        
        await _userRepository.UpdateAsync(user);
        
        return _mapper.Map<UpdateUserProfileResult>(user);
    }
}
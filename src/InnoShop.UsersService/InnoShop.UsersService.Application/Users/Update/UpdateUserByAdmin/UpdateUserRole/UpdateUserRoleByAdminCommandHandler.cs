using AutoMapper;
using InnoShop.UsersService.Application.Abstractions.Repositories;
using InnoShop.UsersService.Application.Users.Results;
using MediatR;

namespace InnoShop.UsersService.Application.Users.Update.UpdateUserByAdmin.UpdateUserRole;

public class UpdateUserRoleByAdminCommandHandler : IRequestHandler<UpdateUserRoleByAdminCommand, UpdateUserByAdminResult>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UpdateUserRoleByAdminCommandHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }
    
    public async Task<UpdateUserByAdminResult> Handle(UpdateUserRoleByAdminCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.Id);

        if (user is null)
            throw new KeyNotFoundException($"User with id {request.Id} not found.");
        
        user.UpdateRole(request.Role);
        await _userRepository.UpdateAsync(user);
        return _mapper.Map<UpdateUserByAdminResult>(user);
    }
}
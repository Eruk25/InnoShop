using AutoMapper;
using InnoShop.UsersService.Application.Abstractions.Repositories;
using InnoShop.UsersService.Application.Users.Results;
using MediatR;

namespace InnoShop.UsersService.Application.Users.Update.UpdateUserByAdminCommand;

public class UpdateUserByIdAdminCommandHandler : IRequestHandler<UpdateUserByAdminCommand, UpdateUserByAdminResult>
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;

    public UpdateUserByIdAdminCommandHandler(IMapper mapper, IUserRepository userRepository)
    {
        _mapper = mapper;
        _userRepository = userRepository;
    }

    public async Task<UpdateUserByAdminResult> Handle(UpdateUserByAdminCommand request,
        CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.Id);
        
        if(user is null)
            throw new KeyNotFoundException($"User with id {request.Id} not found");
        
        user.UpdateRole(request.Role);
        user.UpdateStatus(request.Status);
        await _userRepository.UpdateAsync(user);
        return _mapper.Map<UpdateUserByAdminResult>(user);
    }
}
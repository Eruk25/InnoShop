using System.Text.Json;
using AutoMapper;
using InnoShop.UsersService.Application.Abstractions.Repositories;
using InnoShop.UsersService.Application.Users.Results;
using InnoShop.UsersService.Domain.Entities;
using InnoShop.UsersService.Domain.Enums;
using MediatR;

namespace InnoShop.UsersService.Application.Users.Update.UpdateUserByAdmin;

public class UpdateUserStatusByAdminCommandHandler : IRequestHandler<UpdateUserStatusByAdminCommand, UpdateUserByAdminResult>
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;
    private readonly IOutBoxMessageRepository _outBoxMessageRepository;
    public UpdateUserStatusByAdminCommandHandler(IMapper mapper, IUserRepository userRepository,
        IOutBoxMessageRepository outBoxMessageRepository)
    {
        _mapper = mapper;
        _userRepository = userRepository;
        _outBoxMessageRepository = outBoxMessageRepository;
    }

    public async Task<UpdateUserByAdminResult> Handle(UpdateUserStatusByAdminCommand request,
        CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.Id);
        
        if(user is null)
            throw new KeyNotFoundException($"User with id {request.Id} not found");

        user.UpdateStatus(request.Status);
        var @event = new OutBoxMessage(
            "UserStatusChanged",
            JsonSerializer.Serialize(new
            {
                UserId = user.Id,
                Status = user.Status.ToString()
            }));
        await _outBoxMessageRepository.CreateAsync(@event);
        
        await _userRepository.UpdateAsync(user);
        return _mapper.Map<UpdateUserByAdminResult>(user);
    }
}
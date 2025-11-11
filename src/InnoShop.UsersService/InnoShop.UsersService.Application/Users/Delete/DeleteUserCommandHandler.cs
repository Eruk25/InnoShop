using InnoShop.UsersService.Application.Abstractions.Repositories;
using MediatR;

namespace InnoShop.UsersService.Application.Users.Delete;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, bool>
{
    private readonly IUserRepository _userRepository;

    public DeleteUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var deleted = await _userRepository.DeleteAsync(request.Id);
        if(!deleted)
            throw new KeyNotFoundException($"User with id {request.Id} not found");
        return deleted;
    }
}
using InnoShop.UsersService.Application.Users.Results;
using MediatR;

namespace InnoShop.UsersService.Application.Users.Update.UpdateUserProfile;

public record UpdateUserProfileCommand(int Id, string Name, string Email, string Password)
    : IRequest<UpdateUserProfileResult>;
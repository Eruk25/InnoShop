using InnoShop.UsersService.Application.Users.Results;
using InnoShop.UsersService.Domain.Enums;
using MediatR;

namespace InnoShop.UsersService.Application.Users.Update.UpdateUserByAdminCommand;

public record UpdateUserByAdminCommand(int Id, Role Role, Status Status)
    : IRequest<UpdateUserProfileResult>;
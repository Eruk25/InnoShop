using InnoShop.UsersService.Application.Users.Results;
using InnoShop.UsersService.Domain.Enums;
using MediatR;

namespace InnoShop.UsersService.Application.Users.Update.UpdateUserByAdmin;

public record UpdateUserStatusByAdminCommand(int Id, Status? Status)
    : IRequest<UpdateUserByAdminResult>;
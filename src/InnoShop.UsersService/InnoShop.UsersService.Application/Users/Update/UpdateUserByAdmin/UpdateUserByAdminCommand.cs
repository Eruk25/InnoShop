using InnoShop.UsersService.Application.Users.Results;
using InnoShop.UsersService.Domain.Enums;
using MediatR;

namespace InnoShop.UsersService.Application.Users.Update.UpdateUserByAdmin;

public record UpdateUserByAdminCommand(int Id, Role? Role, Status? Status)
    : IRequest<UpdateUserByAdminResult>;
using InnoShop.UsersService.Application.Users.Results;
using InnoShop.UsersService.Domain.Enums;
using MediatR;

namespace InnoShop.UsersService.Application.Users.Update.UpdateUserByAdmin.UpdateUserRole;

public record UpdateUserRoleByAdminCommand(int Id, Role? Role) : IRequest<UpdateUserByAdminResult>;
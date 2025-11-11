using InnoShop.UsersService.Domain.Enums;

namespace InnoShop.UsersService.Application.Users.Update.UpdateUserByAdminCommand;

public record UpdateUserByAdminCommand(int Id, Role Role, Status Status);
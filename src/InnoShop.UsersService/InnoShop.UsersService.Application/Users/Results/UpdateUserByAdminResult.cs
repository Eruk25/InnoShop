using InnoShop.UsersService.Domain.Enums;

namespace InnoShop.UsersService.Application.Users.Results;

public record UpdateUserByAdminResult(int Id, Role Role, Status Status);
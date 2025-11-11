using InnoShop.UsersService.Domain.Enums;

namespace InnoShop.UsersService.Application.Users;

public record UserDto(int Id, string Name, string Email,
    Status Status, Role Role);
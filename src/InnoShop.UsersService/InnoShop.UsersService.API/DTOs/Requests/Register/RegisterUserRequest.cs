namespace InnoShop.UsersService.API.DTOs.Requests;

public record RegisterUserRequest(string Name, string Email, string Password);
namespace InnoShop.UsersService.API.DTOs.Requests.UpdateProfile;

public record UpdateUserProfileRequest(string? Name, string? Email, string? Password);
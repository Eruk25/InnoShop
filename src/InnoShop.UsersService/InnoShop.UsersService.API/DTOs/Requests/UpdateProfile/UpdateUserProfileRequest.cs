namespace InnoShop.UsersService.API.DTOs.Requests.UpdateProfile;

public record UpdateUserProfileRequest(int Id, string? Name, string? Email, string? Password);
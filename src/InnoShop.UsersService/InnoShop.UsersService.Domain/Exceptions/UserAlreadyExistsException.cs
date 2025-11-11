namespace InnoShop.UsersService.Domain.Exceptions;

public class UserAlreadyExistsException(string email)
    : Exception(message: $"User with email {email} is already exists.");
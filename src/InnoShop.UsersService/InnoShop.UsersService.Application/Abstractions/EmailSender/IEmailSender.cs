namespace InnoShop.UsersService.Application.Abstractions.EmailSender;

public interface IEmailSender
{
    public Task SendEmailAsync(string email, string body);
}
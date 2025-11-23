using FluentEmail.Core;
using InnoShop.UsersService.Application.Abstractions.EmailSender;

namespace InnoShop.UsersService.Infrastructure.Implementations.EmailSender;

public class EmailSender : IEmailSender
{
    private readonly IFluentEmail _email;
    
    public EmailSender(IFluentEmail email)
    {
        _email = email;
    }
    
    public async Task SendEmailAsync(string email, string verificationLink)
    {
        await _email
            .To(email)
            .Subject("Email verification for InnoShop")
            .Body($"To verify your email address <a href={verificationLink}>click here</a>", isHtml: true)
            .SendAsync();
    }
}
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
    
    public async Task SendEmailAsync(string email, string body)
    {
        await _email
            .To(email)
            .Subject("Message from InnoShop")
            .Body(body, isHtml: true)
            .SendAsync();
    }
}
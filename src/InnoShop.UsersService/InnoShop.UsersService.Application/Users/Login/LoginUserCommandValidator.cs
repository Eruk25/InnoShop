using FluentValidation;

namespace InnoShop.UsersService.Application.Users.Login;

public class LoginUserCommandValidator :
    AbstractValidator<LoginUserCommand>
{
    public LoginUserCommandValidator()
    {
        RuleFor(x => x.Email)
            .EmailAddress()
            .NotEmpty();
        RuleFor(x => x.Password)
            .NotNull()
            .NotEmpty();
    }
}
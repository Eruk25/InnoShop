using FluentValidation;

namespace InnoShop.UsersService.Application.Users.Register;

public class RegisterUserCommandValidator : 
    AbstractValidator<RegisterUserCommand>
{
    public RegisterUserCommandValidator()
    {
        RuleFor(x => x.Name)
            .MinimumLength(2)
            .MaximumLength(20)
            .NotEmpty();
        RuleFor(x => x.Email)
            .EmailAddress()
            .NotEmpty();
        RuleFor(x => x.Password)
            .MinimumLength(6)
            .MaximumLength(30)
            .NotEmpty();
    }
}
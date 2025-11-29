using FluentValidation;

namespace InnoShop.UsersService.Application.Users.Update.UpdateUserPassword;

public class UpdateUserPasswordCommandValidator :
    AbstractValidator<UpdateUserPasswordCommand>
{
    public UpdateUserPasswordCommandValidator()
    {
        RuleFor(x => x.Email)
            .EmailAddress()
            .NotEmpty();
        RuleFor(x => x.ResetCode)
            .NotNull()
            .NotEmpty();
        RuleFor(x => x.NewPassword)
            .MinimumLength(6)
            .MaximumLength(30)
            .NotEmpty();;
    }
}
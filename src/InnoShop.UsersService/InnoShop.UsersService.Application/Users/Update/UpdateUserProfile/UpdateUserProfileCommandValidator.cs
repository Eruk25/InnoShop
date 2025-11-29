using FluentValidation;

namespace InnoShop.UsersService.Application.Users.Update.UpdateUserProfile;

public class UpdateUserProfileCommandValidator :
    AbstractValidator<UpdateUserProfileCommand>
{
    public UpdateUserProfileCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotNull()
            .NotEmpty();
        RuleFor(x => x.Email)
            .EmailAddress()
            .NotEmpty();
        RuleFor(x => x.Name)
            .MinimumLength(2)
            .MaximumLength(20)
            .NotEmpty();
    }
}
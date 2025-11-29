using FluentValidation;

namespace InnoShop.UsersService.Application.Users.Update.UpdateUserByAdmin;

public class UpdateUserStatusByAdminCommandValidator :
    AbstractValidator<UpdateUserStatusByAdminCommand>
{
    public  UpdateUserStatusByAdminCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotNull()
            .NotEmpty();
        RuleFor(x => x.Status)
            .NotNull()
            .NotEmpty();
    }
}
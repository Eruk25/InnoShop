using FluentValidation;

namespace InnoShop.UsersService.Application.Users.Update.UpdateUserByAdmin.UpdateUserRole;

public class UpdateUserRoleByAdminCommandValidator :
    AbstractValidator<UpdateUserRoleByAdminCommand>
{
    public UpdateUserRoleByAdminCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotNull()
            .NotEmpty();
        RuleFor(x => x.Role)
            .NotNull()
            .NotEmpty();
    }
}
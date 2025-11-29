using FluentValidation;

namespace InnoShop.UsersService.Application.Users.Delete;

public class DeleteUserCommandValidator :
    AbstractValidator<DeleteUserCommand>
{
    public DeleteUserCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotNull()
            .NotEmpty();
    }
}
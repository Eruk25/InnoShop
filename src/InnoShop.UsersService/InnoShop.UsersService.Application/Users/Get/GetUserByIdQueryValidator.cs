using FluentValidation;

namespace InnoShop.UsersService.Application.Users.Get;

public class GetUserByIdQueryValidator :
    AbstractValidator<GetUserByIdQuery>
{
    public GetUserByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotNull()
            .NotEmpty();
    }
}
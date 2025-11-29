using FluentValidation;

namespace InnoShop.ProductsService.Application.Products.Create;

public class CreateProductCommandValidator :
    AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator(IServiceProvider serviceProvider)
    {
        RuleFor(x => x.Title)
            .MinimumLength(5)
            .MaximumLength(50)
            .NotEmpty();
        RuleFor(x => x.Description)
            .MinimumLength(50)
            .MaximumLength(300)
            .NotEmpty();
        RuleFor(x => x.Price)
            .GreaterThan(0)
            .LessThanOrEqualTo(100000);
        RuleFor(x => x.UserId)
            .NotEmpty();
    }
}
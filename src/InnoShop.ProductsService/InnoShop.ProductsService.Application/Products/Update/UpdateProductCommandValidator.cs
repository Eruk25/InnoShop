using FluentValidation;

namespace InnoShop.ProductsService.Application.Products.Update;

public class UpdateProductCommandValidator :
    AbstractValidator<UpdateProductCommand>
{
    public  UpdateProductCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();
        RuleFor(x => x.Title)
            .NotEmpty();
        RuleFor(x => x.Description)
            .MinimumLength(50)
            .MaximumLength(200)
            .NotEmpty();
        RuleFor(x => x.Price)
            .GreaterThan(0)
            .LessThanOrEqualTo(100000)
            .NotEmpty();
    }
}
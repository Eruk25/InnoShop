using FluentValidation;

namespace InnoShop.ProductsService.Application.Products.Delete;

public class DeleteProductCommandValidator :
    AbstractValidator<DeleteProductCommand>
{
    public  DeleteProductCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();
    }
}
using FluentValidation;

namespace InnoShop.ProductsService.Application.Products.Get;

public class GetProductByIdQueryValidator :
    AbstractValidator<GetProductByIdQuery>
{
    public  GetProductByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();
    }
}
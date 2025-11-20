using MediatR;

namespace InnoShop.ProductsService.Application.Products.Get;

public record GetProductByIdQuery(int Id) : IRequest<ProductDto>;
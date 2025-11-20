using MediatR;

namespace InnoShop.ProductsService.Application.Products.Get;

public record GetAllProductsQuery() : IRequest<IEnumerable<ProductDto>>;
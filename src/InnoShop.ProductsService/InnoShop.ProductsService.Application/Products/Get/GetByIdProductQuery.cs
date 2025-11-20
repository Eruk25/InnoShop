using MediatR;

namespace InnoShop.ProductsService.Application.Products.Get;

public record GetByIdProductQuery(int Id) : IRequest<ProductDto>;
using InnoShop.ProductsService.Application.Products.Filters;
using MediatR;

namespace InnoShop.ProductsService.Application.Products.Get;

public record GetAllProductsQuery(ProductSearchCriteria Filters) : IRequest<IEnumerable<ProductDto>>;
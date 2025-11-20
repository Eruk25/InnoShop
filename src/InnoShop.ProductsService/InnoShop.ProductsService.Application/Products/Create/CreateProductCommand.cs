using MediatR;

namespace InnoShop.ProductsService.Application.Products.Create;

public record CreateProductCommand(string Title, string Description,
    decimal Price, int UserId) : IRequest;
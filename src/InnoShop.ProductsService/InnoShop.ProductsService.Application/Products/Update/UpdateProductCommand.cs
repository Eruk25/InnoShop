using MediatR;

namespace InnoShop.ProductsService.Application.Products.Update;

public record UpdateProductCommand(int Id, string? Title, string Description,
    decimal? Price) : IRequest;
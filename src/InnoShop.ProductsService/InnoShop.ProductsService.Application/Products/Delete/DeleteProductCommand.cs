using MediatR;

namespace InnoShop.ProductsService.Application.Products.Delete;

public record DeleteProductCommand(int Id) : IRequest;
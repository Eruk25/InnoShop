using AutoMapper;
using InnoShop.ProductsService.Application.Abstractions.Repositories;
using InnoShop.ProductsService.Domain.Entities;
using MediatR;

namespace InnoShop.ProductsService.Application.Products.Create;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand>
{
    private readonly IProductRepository _productRepository;
    
    public CreateProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        if(request is null)
            throw new ArgumentException(nameof(request));

        var product = new Product(
            request.Title,
            request.Description,
            request.Price,
            request.UserId);
        
        await _productRepository.CreateAsync(product);
    }
}

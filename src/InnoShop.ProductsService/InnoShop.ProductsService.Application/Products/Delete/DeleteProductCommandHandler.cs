using InnoShop.ProductsService.Application.Abstractions.Repositories;
using MediatR;

namespace InnoShop.ProductsService.Application.Products.Delete;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
{
    private readonly IProductRepository _productRepository;
    
    public DeleteProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(request.Id);
        
        if(product is null)
            throw new KeyNotFoundException($"Product with id {request.Id} not found");
        
        await _productRepository.DeleteAsync(product);
    }
}
using InnoShop.ProductsService.Application.Abstractions.Repositories;
using MediatR;

namespace InnoShop.ProductsService.Application.Products.Update;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
{
    private readonly IProductRepository _productRepository;

    public UpdateProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(request.Id);
        
        if(product is null)
            throw new KeyNotFoundException($"Product with id {request.Id} not found");
        
        product.Update(request.Title, request.Description, request.Price);
        await _productRepository.UpdateAsync(product);
    }
}
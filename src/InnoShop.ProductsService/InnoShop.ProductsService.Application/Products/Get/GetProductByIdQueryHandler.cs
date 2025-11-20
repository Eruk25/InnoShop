using AutoMapper;
using InnoShop.ProductsService.Application.Abstractions.Repositories;
using MediatR;
using MediatR.Wrappers;

namespace InnoShop.ProductsService.Application.Products.Get;

public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDto>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    
    public GetProductByIdQueryHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(request.Id);

        if (product is null)
            throw new KeyNotFoundException($"Product with id {request.Id} not found");
        
        return _mapper.Map<ProductDto>(product);
    }
}
using AutoMapper;
using InnoShop.ProductsService.Application.Abstractions.Repositories;
using MediatR;

namespace InnoShop.ProductsService.Application.Products.Get;

public class GetAllProductQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<ProductDto>>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    public GetAllProductQueryHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await _productRepository.GetAllAsync(request.Filters);
        
        return _mapper.Map<IEnumerable<ProductDto>>(products);
    }
}
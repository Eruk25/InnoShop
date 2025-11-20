using AutoMapper;
using InnoShop.ProductsService.Application.Products;
using InnoShop.ProductsService.Domain.Entities;

namespace InnoShop.ProductsService.Application.Mappings;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<Product, ProductDto>()
            .ReverseMap();
    }
}
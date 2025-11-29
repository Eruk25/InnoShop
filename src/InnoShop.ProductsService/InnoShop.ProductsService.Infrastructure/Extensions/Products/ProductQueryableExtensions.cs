using InnoShop.ProductsService.Application.Products.Filters;
using InnoShop.ProductsService.Domain.Entities;

namespace InnoShop.ProductsService.Infrastructure.Extensions.Products;

public static class ProductExtensions
{
    public static IQueryable<Product> ApplyFilter(IQueryable<Product> query, ProductSearchCriteria filters)
    {
        if(!string.IsNullOrWhiteSpace(filters.Search))
            query = query.Where(p => p.Title.Contains(filters.Search) || p.Description.Contains(filters.Search));
        if (filters.MinPrice.HasValue)
            query = query.Where(p => p.Price >= filters.MinPrice);
        if (filters.MaxPrice.HasValue)
            query = query.Where(p => p.Price <= filters.MaxPrice);
        
        return query;
    } 
}
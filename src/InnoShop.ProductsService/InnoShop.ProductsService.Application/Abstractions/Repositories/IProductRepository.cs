using InnoShop.ProductsService.Application.Products.Filters;
using InnoShop.ProductsService.Domain.Entities;

namespace InnoShop.ProductsService.Application.Abstractions.Repositories;

public interface IProductRepository
{
    public Task<IEnumerable<Product>> GetAllAsync(ProductSearchCriteria filters);
    public Task<Product?> GetByIdAsync(int id);
    public Task<IEnumerable<Product>> GetByUserIdAsync(int userId);
    public Task CreateAsync(Product product);
    public Task UpdateAsync(Product product);
    public Task DeleteAsync(IEnumerable<Product> products);
}
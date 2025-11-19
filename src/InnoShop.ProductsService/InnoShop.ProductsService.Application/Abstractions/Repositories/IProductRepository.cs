using InnoShop.ProductsService.Domain.Entities;

namespace InnoShop.ProductsService.Application.Abstractions.Repositories;

public interface IProductRepository
{
    public Task<IEnumerable<Product>> GetAllAsync();
    public Task<Product?> GetByIdAsync(int id);
    public Task<Product> CreateAsync(Product product);
    public Task UpdateAsync(Product product);
    public Task<bool> DeleteAsync(int id);
}
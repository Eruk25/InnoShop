using InnoShop.ProductsService.Domain.Entities;

namespace InnoShop.ProductsService.Application.Abstractions.Repositories;

public interface IProductRepository
{
    public Task<IEnumerable<Product>> GetAllAsync();
    public Task<Product?> GetByIdAsync(int id);
    public Task<int> CreateAsync(Product product);
    public Task<Product> UpdateAsync(int id, Product product);
    public Task<bool> DeleteAsync(int id);
}
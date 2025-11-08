using InnoShop.ProductsService.Application.Abstractions.Repositories;
using InnoShop.ProductsService.Domain.Entities;
using InnoShop.ProductsService.Infrastructure.Persistence.DB;

namespace InnoShop.ProductsService.Infrastructure.Persistence.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ProductContext _context;

    public ProductRepository(ProductContext context)
    {
        _context = context;
    }
    
    public Task<IEnumerable<Product>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Product> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<int> CreateAsync(Product product)
    {
        throw new NotImplementedException();
    }

    public Task<Product> UpdateAsync(int id, Product product)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}
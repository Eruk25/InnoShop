using InnoShop.ProductsService.Application.Abstractions.Repositories;
using InnoShop.ProductsService.Domain.Entities;
using InnoShop.ProductsService.Infrastructure.Persistence.DB;
using Microsoft.EntityFrameworkCore;

namespace InnoShop.ProductsService.Infrastructure.Persistence.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ProductContext _context;

    public ProductRepository(ProductContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task<Product?> GetByIdAsync(int id)
    {
        var product = await _context.Products
            .FirstOrDefaultAsync(p => p.Id == id);
        return product;
    }

    public async Task<int> CreateAsync(Product product)
    {
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();
        return product.Id;
    }

    public async Task UpdateAsync(Product product)
    {
        _context.Update(product);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var product = _context.Products.FirstOrDefault(p => p.Id == id);
        if(product is null)
            return false;
        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
        return true;
    }
}
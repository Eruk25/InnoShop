using InnoShop.ProductsService.Domain.Entities;
using InnoShop.ProductsService.Infrastructure.Persistence.DB.Configurations;
using Microsoft.EntityFrameworkCore;

namespace InnoShop.ProductsService.Infrastructure.Persistence.DB;

public class ProductContext(DbContextOptions<ProductContext> options) : DbContext(options)
{
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
    }
}

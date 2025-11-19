using InnoShop.ProductsService.Domain.Entities;
using InnoShop.ProductsService.Domain.Primitives;
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

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var softDeleteEntries = ChangeTracker
            .Entries<ISoftDeletable>()
            .Where(e => e.State == EntityState.Deleted);

        foreach (var entry in softDeleteEntries)
        {
            entry.Property(nameof(ISoftDeletable.IsDeleted)).CurrentValue = true;
            entry.State = EntityState.Modified;
        }
        
        var result = await base.SaveChangesAsync(cancellationToken);
        return result;
    }

}

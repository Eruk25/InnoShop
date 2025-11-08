using InnoShop.ProductsService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InnoShop.ProductsService.Infrastructure.Persistance;

public class ProductContext(DbContextOptions<ProductContext> options) : DbContext(options)
{
    DbSet<Product> Products { get; set; }
}

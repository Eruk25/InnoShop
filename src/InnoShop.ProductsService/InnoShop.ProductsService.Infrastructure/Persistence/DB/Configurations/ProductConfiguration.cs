using InnoShop.ProductsService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InnoShop.ProductsService.Infrastructure.Persistence.DB.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Title)
            .HasMaxLength(100)
            .IsRequired();
        builder.Property(p => p.Description)
            .HasMaxLength(500)
            .IsRequired();
        builder.Property(p => p.Price)
            .IsRequired()
            .HasColumnType("decimal(18,2)");
        builder.Property(p => p.IsDeleted)
            .IsRequired();
        builder.Property(p => p.UserId)
            .IsRequired();
        builder.Property(p => p.CreatedAt)
            .IsRequired();

        builder.HasQueryFilter(p => !p.IsDeleted);
        
        builder.HasIndex(p => p.Title)
            .HasDatabaseName("IDX_Products_Title");
        builder.HasIndex(p => p.UserId)
            .HasDatabaseName("IDX_Products_UserId");
    }
}
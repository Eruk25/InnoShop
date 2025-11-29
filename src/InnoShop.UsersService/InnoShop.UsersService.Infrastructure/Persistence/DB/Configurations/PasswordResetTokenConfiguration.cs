using InnoShop.UsersService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InnoShop.UsersService.Infrastructure.Persistence.DB.Configurations;

public class PasswordResetTokenConfiguration : IEntityTypeConfiguration<PasswordResetToken>
{
    public void Configure(EntityTypeBuilder<PasswordResetToken> builder)
    {
        builder.HasKey(t => t.Id);
        
        builder.Property(t => t.ExpiresAt)
            .IsRequired();
        builder.Property(t => t.UserId)
            .IsRequired();
    }
}
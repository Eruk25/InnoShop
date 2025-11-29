using InnoShop.UsersService.Domain.Entities;
using InnoShop.UsersService.Infrastructure.Persistence.DB.Configurations;
using Microsoft.EntityFrameworkCore;

namespace InnoShop.UsersService.Infrastructure.Persistence.DB;

public class UserContext(DbContextOptions<UserContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<EmailVerificationToken> EmailVerificationTokens { get; set; }
    public DbSet<PasswordResetToken> PasswordResetTokens { get; set; }
    public DbSet<OutBoxMessage> OutBoxMessages { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new EmailVerificationTokenConfiguration());
        modelBuilder.ApplyConfiguration(new PasswordResetTokenConfiguration());
    }
}
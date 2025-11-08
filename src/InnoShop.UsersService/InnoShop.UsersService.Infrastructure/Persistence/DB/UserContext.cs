using InnoShop.UsersService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InnoShop.UsersService.Infrastructure.Persistence.DB;

public class UsersContext(DbContextOptions<UsersContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
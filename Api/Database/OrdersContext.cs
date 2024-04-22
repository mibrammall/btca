using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Database;

public class OrdersContext(DbContextOptions<OrdersContext> context) : DbContext(context)
{
    public DbSet<CompanyEntity> Companies { get; set; }
    public DbSet<OrderEntity> Orders { get; set; }
    public DbSet<ProductEntity> Products { get; set; }
    public DbSet<OrderProduct> OrderProducts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CompanyEntity>().HasKey(c => c.CompanyId);
        modelBuilder.Entity<OrderEntity>().HasKey(c => c.OrderId);
        modelBuilder.Entity<ProductEntity>().HasKey(c => c.ProductId);
        modelBuilder.Entity<OrderProduct>().HasNoKey();
    }
}

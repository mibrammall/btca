using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Database;

public class OrdersContext : DbContext
{
    public DbSet<CompanyEntity> Companies { get; set; }
    public DbSet<OrderEntity> Orders { get; set; }
    public DbSet<ProductEntity> Products { get; set; }
    public DbSet<OrderProduct> OrderProducts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

    }
}

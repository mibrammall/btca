using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Database;

public class OrdersContext : DbContext
{
    public DbSet<Order> Orders { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<OrderProduct> OrderProducts { get; set; }
}

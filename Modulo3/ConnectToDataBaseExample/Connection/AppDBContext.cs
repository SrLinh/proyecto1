using Microsoft.EntityFrameworkCore;
using ConnectToDataBaseExample.Models;

namespace ConnectToDataBaseExample.Connection;
public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Order> Orders { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder
    optionsBuilder)
    {
        optionsBuilder.UseNpgsql( "Host=localhost;" + "Port=5432;" +
        "Database=DBProducts;" + "Username=postgres;"
        + "Password=123");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().ToTable("Users", schema: "public");
        modelBuilder.Entity<Order>().ToTable("Orders", schema: "public");
    }
}
using DBStoreEntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace DBStoreEntityFramework.Context;

/// <summary>
/// Clase encargada de conectar el proyecto con la base de datos DBStore en PostgreSQL.
/// Hereda de DbContext para permitir que Entity Framework administre las tablas.
/// </summary>
public class DbStoreContext : DbContext
{
    /// <summary>
    /// Representa la tabla Categories dentro de Entity Framework.
    /// Permite consultar, agregar, modificar y eliminar categorías.
    /// </summary>
    public DbSet<Category> Categories { get; set; }

    /// <summary>
    /// Representa la tabla Products dentro de Entity Framework.
    /// Permite consultar, agregar, modificar y eliminar productos.
    /// </summary>
    public DbSet<Product> Products { get; set; }

    /// <summary>
    /// Representa la tabla Sales dentro de Entity Framework.
    /// Permite consultar, agregar, modificar y eliminar ventas.
    /// </summary>
    public DbSet<Sale> Sales { get; set; }

    /// <summary>
    /// Representa la tabla SaleDetails dentro de Entity Framework.
    /// Permite consultar, agregar, modificar y eliminar detalles de venta.
    /// </summary>
    public DbSet<SaleDetail> SaleDetails { get; set; }

    /// <summary>
    /// Configura la conexión con PostgreSQL usando Npgsql.
    /// Aquí se define servidor, puerto, base de datos, usuario y contraseña.
    /// </summary>
    /// <param name="optionsBuilder">
    /// Objeto que permite indicar qué proveedor de base de datos usará Entity Framework.
    /// </param>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // UseNpgsql indica que Entity Framework se conectará a PostgreSQL.
        // Cambia el puerto, base de datos, usuario o contraseña según tu instalación.
        optionsBuilder.UseNpgsql(
            "Host=localhost;" +
            "Port=5433;" +
            "Database=DBStore;" +
            "Username=postgres;" +
            "Password=1234"
        );
    }

    /// <summary>
    /// Configura las relaciones, tablas, columnas y restricciones principales del modelo.
    /// Este método permite ajustar cómo Entity Framework interpreta la base de datos.
    /// </summary>
    /// <param name="modelBuilder">
    /// Objeto usado para configurar las entidades y sus relaciones.
    /// </param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Relaciona cada clase con su tabla real en PostgreSQL.
        modelBuilder.Entity<Category>().ToTable("Categories");
        modelBuilder.Entity<Product>().ToTable("Products");
        modelBuilder.Entity<Sale>().ToTable("Sales");
        modelBuilder.Entity<SaleDetail>().ToTable("SaleDetails");

        // Configura las llaves primarias de cada tabla.
        modelBuilder.Entity<Category>().HasKey(category => category.CategoryID);
        modelBuilder.Entity<Product>().HasKey(product => product.ProductID);
        modelBuilder.Entity<Sale>().HasKey(sale => sale.SaleID);
        modelBuilder.Entity<SaleDetail>().HasKey(detail => detail.SaleDetailID);

        // Una categoría puede tener muchos productos y un producto pertenece a una categoría.
        modelBuilder.Entity<Product>()
            .HasOne(product => product.Category)
            .WithMany(category => category.Products)
            .HasForeignKey(product => product.CategoryID);

        // Una venta puede tener muchos detalles y cada detalle pertenece a una venta.
        modelBuilder.Entity<SaleDetail>()
            .HasOne(detail => detail.Sale)
            .WithMany(sale => sale.SaleDetails)
            .HasForeignKey(detail => detail.SaleID);

        // Un producto puede aparecer en muchos detalles de venta.
        modelBuilder.Entity<SaleDetail>()
            .HasOne(detail => detail.Product)
            .WithMany(product => product.SaleDetails)
            .HasForeignKey(detail => detail.ProductID);

        // Configura precisión para valores monetarios.
        modelBuilder.Entity<Product>()
            .Property(product => product.Price)
            .HasPrecision(10, 2);

        modelBuilder.Entity<Sale>()
            .Property(sale => sale.Total)
            .HasPrecision(10, 2);

        modelBuilder.Entity<SaleDetail>()
            .Property(detail => detail.UnitPrice)
            .HasPrecision(10, 2);

        modelBuilder.Entity<SaleDetail>()
            .Property(detail => detail.Subtotal)
            .HasPrecision(10, 2);
    }
}

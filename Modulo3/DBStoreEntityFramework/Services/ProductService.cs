using DBStoreEntityFramework.Context;
using DBStoreEntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace DBStoreEntityFramework.Services;

/// <summary>
/// Servicio encargado de realizar operaciones relacionadas con productos.
/// Permite listar, agregar, actualizar stock y eliminar productos.
/// </summary>
public class ProductService
{
    /// <summary>
    /// Muestra todos los productos registrados junto con su categoría.
    /// </summary>
    public void ListProducts()
    {
        // Se crea una conexión con la base de datos usando Entity Framework.
        using var db = new DbStoreContext();

        // Se consultan los productos y se incluye la categoría relacionada.
        var products = db.Products
            .Include(product => product.Category)
            .OrderBy(product => product.ProductID)
            .ToList();

        Console.WriteLine("\n=== LISTA DE PRODUCTOS ===");

        // Se recorren todos los productos obtenidos desde la base de datos.
        foreach (var product in products)
        {
            Console.WriteLine(
                $"{product.ProductID} | " +
                $"{product.Category?.CategoryName} | " +
                $"{product.ProductName} | " +
                $"${product.Price} | " +
                $"Stock: {product.Stock}"
            );
        }
    }

    /// <summary>
    /// Agrega un nuevo producto a la base de datos.
    /// Solicita categoría, nombre, precio y stock desde la consola.
    /// </summary>
    public void AddProduct()
    {
        // Se crea una conexión con la base de datos.
        using var db = new DbStoreContext();

        Console.WriteLine("\n=== CATEGORÍAS DISPONIBLES ===");

        // Se obtiene la lista de categorías desde la base de datos.
        var categories = db.Categories
            .OrderBy(category => category.CategoryID)
            .ToList();

        foreach (var category in categories)
        {
            Console.WriteLine($"{category.CategoryID} - {category.CategoryName}");
        }

        Console.Write("Ingrese el ID de la categoría: ");
        int categoryId = int.Parse(Console.ReadLine()!);

        // Se valida que la categoría exista antes de crear el producto.
        bool categoryExists = db.Categories.Any(category => category.CategoryID == categoryId);
        if (!categoryExists)
        {
            Console.WriteLine("La categoría ingresada no existe.");
            return;
        }

        Console.Write("Ingrese el nombre del producto: ");
        string productName = Console.ReadLine()!;

        Console.Write("Ingrese el precio del producto: ");
        decimal price = decimal.Parse(Console.ReadLine()!);

        Console.Write("Ingrese el stock del producto: ");
        int stock = int.Parse(Console.ReadLine()!);

        // Se crea un nuevo objeto Product con los datos ingresados.
        Product product = new Product
        {
            CategoryID = categoryId,
            ProductName = productName,
            Price = price,
            Stock = stock
        };

        // Se agrega el producto al DbSet Products.
        db.Products.Add(product);

        // Se guardan los cambios en PostgreSQL.
        db.SaveChanges();

        Console.WriteLine("Producto agregado correctamente.");
    }

    /// <summary>
    /// Actualiza el stock de un producto existente.
    /// Solicita el ID del producto y la nueva cantidad disponible.
    /// </summary>
    public void UpdateStock()
    {
        // Se crea una conexión con la base de datos.
        using var db = new DbStoreContext();

        Console.Write("Ingrese el ID del producto: ");
        int productId = int.Parse(Console.ReadLine()!);

        // Se busca el producto por su llave primaria.
        Product? product = db.Products.Find(productId);

        if (product == null)
        {
            Console.WriteLine("Producto no encontrado.");
            return;
        }

        Console.Write("Ingrese el nuevo stock: ");
        int newStock = int.Parse(Console.ReadLine()!);

        // Se actualiza la propiedad Stock del producto encontrado.
        product.Stock = newStock;

        // Se guardan los cambios en PostgreSQL.
        db.SaveChanges();

        Console.WriteLine("Stock actualizado correctamente.");
    }

    /// <summary>
    /// Elimina un producto de la base de datos usando su ID.
    /// </summary>
    public void DeleteProduct()
    {
        // Se crea una conexión con la base de datos.
        using var db = new DbStoreContext();

        Console.Write("Ingrese el ID del producto: ");
        int productId = int.Parse(Console.ReadLine()!);

        // Se busca el producto por su ID.
        Product? product = db.Products.Find(productId);

        if (product == null)
        {
            Console.WriteLine("Producto no encontrado.");
            return;
        }

        // Se elimina el producto del DbSet Products.
        db.Products.Remove(product);

        // Se guardan los cambios en la base de datos.
        db.SaveChanges();

        Console.WriteLine("Producto eliminado correctamente.");
    }
}

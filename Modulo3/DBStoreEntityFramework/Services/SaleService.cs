using DBStoreEntityFramework.Context;
using DBStoreEntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace DBStoreEntityFramework.Services;

/// <summary>
/// Servicio encargado de registrar ventas y consultar ventas realizadas.
/// </summary>
public class SaleService
{
    /// <summary>
    /// Registra una nueva venta con un producto, cantidad, precio unitario y subtotal.
    /// También descuenta el stock del producto vendido.
    /// </summary>
    public void AddSale()
    {
        // Se crea una conexión con la base de datos.
        using var db = new DbStoreContext();

        // Se muestran los productos disponibles antes de vender.
        var products = db.Products
            .Include(product => product.Category)
            .OrderBy(product => product.ProductID)
            .ToList();

        Console.WriteLine("\n=== PRODUCTOS DISPONIBLES ===");

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

        Console.Write("Ingrese el ID del producto a vender: ");
        int productId = int.Parse(Console.ReadLine()!);

        // Se busca el producto seleccionado.
        Product? selectedProduct = db.Products.Find(productId);

        if (selectedProduct == null)
        {
            Console.WriteLine("Producto no encontrado.");
            return;
        }

        Console.Write("Ingrese la cantidad a vender: ");
        int quantity = int.Parse(Console.ReadLine()!);

        // Se valida que haya suficiente stock.
        if (quantity > selectedProduct.Stock)
        {
            Console.WriteLine("No hay suficiente stock para realizar la venta.");
            return;
        }

        // Se calcula el subtotal multiplicando cantidad por precio.
        decimal subtotal = quantity * selectedProduct.Price;

        // Se crea la venta principal.
        Sale sale = new Sale
        {
            SaleDate = DateTime.Now,
            Total = subtotal
        };

        // Se crea el detalle de la venta.
        SaleDetail detail = new SaleDetail
        {
            ProductID = selectedProduct.ProductID,
            Quantity = quantity,
            UnitPrice = selectedProduct.Price,
            Subtotal = subtotal
        };

        // Se agrega el detalle dentro de la venta.
        sale.SaleDetails.Add(detail);

        // Se descuenta la cantidad vendida del stock del producto.
        selectedProduct.Stock -= quantity;

        // Se agrega la venta a la base de datos.
        db.Sales.Add(sale);

        // Se guardan los cambios: venta, detalle y actualización de stock.
        db.SaveChanges();

        Console.WriteLine("Venta registrada correctamente.");
    }

    /// <summary>
    /// Muestra las ventas registradas con sus productos vendidos.
    /// </summary>
    public void ListSales()
    {
        // Se crea una conexión con la base de datos.
        using var db = new DbStoreContext();

        // Se consultan las ventas, sus detalles y los productos relacionados.
        var sales = db.Sales
            .Include(sale => sale.SaleDetails)
            .ThenInclude(detail => detail.Product)
            .OrderBy(sale => sale.SaleID)
            .ToList();

        Console.WriteLine("\n=== LISTA DE VENTAS ===");

        foreach (var sale in sales)
        {
            Console.WriteLine($"\nVenta ID: {sale.SaleID}");
            Console.WriteLine($"Fecha: {sale.SaleDate}");
            Console.WriteLine($"Total: ${sale.Total}");
            Console.WriteLine("Productos vendidos:");

            foreach (var detail in sale.SaleDetails)
            {
                Console.WriteLine(
                    $"- {detail.Product?.ProductName} | " +
                    $"Cantidad: {detail.Quantity} | " +
                    $"Precio: ${detail.UnitPrice} | " +
                    $"Subtotal: ${detail.Subtotal}"
                );
            }
        }
    }
}

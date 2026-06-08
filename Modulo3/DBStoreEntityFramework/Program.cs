using DBStoreEntityFramework.Services;

/// <summary>
/// Clase principal del programa.
/// Contiene el menú de opciones para administrar productos y ventas.
/// </summary>
public class Program
{
    /// <summary>
    /// Método principal que se ejecuta cuando inicia la aplicación.
    /// Muestra un menú repetitivo para usar los servicios del sistema.
    /// </summary>
    public static void Main()
    {
        // Se crea el servicio encargado de administrar productos.
        ProductService productService = new ProductService();

        // Se crea el servicio encargado de administrar ventas.
        SaleService saleService = new SaleService();

        // Variable que guardará la opción seleccionada por el usuario.
        string? option;

        // Ciclo repetitivo que mantiene activo el menú hasta que el usuario elija salir.
        do
        {
            Console.WriteLine("\n=== STORE DB WITH ENTITY FRAMEWORK ===");
            Console.WriteLine("1. List products");
            Console.WriteLine("2. Add product");
            Console.WriteLine("3. Update stock");
            Console.WriteLine("4. Delete product");
            Console.WriteLine("5. Add sale");
            Console.WriteLine("6. List sales");
            Console.WriteLine("0. Exit");
            Console.Write("Option: ");
            option = Console.ReadLine();

            if (option == "1")
            {
                productService.ListProducts();
            }
            else if (option == "2")
            {
                productService.AddProduct();
            }
            else if (option == "3")
            {
                productService.UpdateStock();
            }
            else if (option == "4")
            {
                productService.DeleteProduct();
            }
            else if (option == "5")
            {
                saleService.AddSale();
            }
            else if (option == "6")
            {
                saleService.ListSales();
            }
            else if (option == "0")
            {
                Console.WriteLine("Saliendo del sistema...");
            }
            else
            {
                Console.WriteLine("Opción inválida.");
            }

        } while (option != "0");
    }
}

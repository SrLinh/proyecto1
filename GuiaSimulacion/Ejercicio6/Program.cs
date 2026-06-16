using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

class Program
{
    static void Main(string[] args)
    {
        Inventario inventario = new Inventario();

        // Cargar automáticamente al iniciar
        inventario.Cargar();

        bool continuar = true;

        while (continuar)
        {
            Console.WriteLine("\n===== GESTOR DE PRODUCTOS =====");
            Console.WriteLine("1. Agregar producto");
            Console.WriteLine("2. Mostrar productos");
            Console.WriteLine("3. Buscar producto");
            Console.WriteLine("4. Eliminar producto");
            Console.WriteLine("5. Guardar");
            Console.WriteLine("6. Salir");
            Console.Write("Seleccione una opción: ");

            if (!int.TryParse(Console.ReadLine(), out int opcion))
            {
                Console.WriteLine("Opción inválida.");
                continue;
            }

            switch (opcion)
            {
                case 1:
                    AgregarProducto(inventario);
                    break;

                case 2:
                    inventario.Mostrar();
                    break;

                case 3:
                    Console.Write("Ingrese el código del producto: ");
                    string? codigoBuscar = Console.ReadLine();

                    Producto? encontrado = inventario.Buscar(codigoBuscar);

                    if (encontrado != null)
                    {
                        Console.WriteLine(
                            $"{encontrado.Codigo} | " +
                            $"{encontrado.Nombre} | " +
                            $"{encontrado.Precio:C} | " +
                            $"{encontrado.Existencia}");
                    }
                    else
                    {
                        Console.WriteLine("Producto no encontrado.");
                    }

                    break;

                case 4:
                    Console.Write("Ingrese el código del producto a eliminar: ");
                    string? codigoEliminar = Console.ReadLine();

                    if (inventario.Eliminar(codigoEliminar))
                    {
                        Console.WriteLine("Producto eliminado.");
                    }
                    else
                    {
                        Console.WriteLine("No se encontró el producto.");
                    }

                    break;

                case 5:
                    inventario.Guardar();
                    Console.WriteLine("Productos guardados correctamente.");
                    break;

                case 6:
                    inventario.Guardar();
                    Console.WriteLine("Productos guardados automáticamente.");
                    Console.WriteLine("Saliendo...");
                    continuar = false;
                    break;

                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }
        }
    }

    static void AgregarProducto(Inventario inventario)
    {
        Console.Write("Código: ");
        string? codigo = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(codigo))
        {
            Console.WriteLine("El código no puede estar vacío.");
            return;
        }

        if (inventario.Buscar(codigo) != null)
        {
            Console.WriteLine("Ya existe un producto con ese código.");
            return;
        }

        Console.Write("Nombre: ");
        string? nombre = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(nombre))
        {
            Console.WriteLine("El nombre no puede estar vacío.");
            return;
        }

        Console.Write("Precio: ");

        if (!decimal.TryParse(Console.ReadLine(), out decimal precio) || precio <= 0)
        {
            Console.WriteLine("Precio inválido.");
            return;
        }

        Console.Write("Existencia: ");

        if (!int.TryParse(Console.ReadLine(), out int existencia) || existencia < 0)
        {
            Console.WriteLine("Existencia inválida.");
            return;
        }

        inventario.Agregar(
            new Producto
            {
                Codigo = codigo,
                Nombre = nombre,
                Precio = precio,
                Existencia = existencia
            });

        Console.WriteLine("Producto agregado.");
    }
}

class Producto
{
    public string Codigo { get; set; } = "";
    public string Nombre { get; set; } = "";
    public decimal Precio { get; set; }
    public int Existencia { get; set; }
}

class Inventario
{
    private const string Archivo = "productos.json";

    private List<Producto> productos = new();

    public void Agregar(Producto producto)
    {
        productos.Add(producto);
    }

    public void Mostrar()
    {
        if (productos.Count == 0)
        {
            Console.WriteLine("No hay productos registrados.");
            return;
        }

        Console.WriteLine("\n--- PRODUCTOS ---");

        foreach (Producto producto in productos)
        {
            Console.WriteLine(
                $"{producto.Codigo} | " +
                $"{producto.Nombre} | " +
                $"{producto.Precio:C} | " +
                $"{producto.Existencia}");
        }
    }

    public Producto? Buscar(string? codigo)
    {
        return productos.FirstOrDefault(
            p => p.Codigo.Equals(codigo,
            StringComparison.OrdinalIgnoreCase));
    }

    public bool Eliminar(string? codigo)
    {
        Producto? producto = Buscar(codigo);

        if (producto == null)
        {
            return false;
        }

        productos.Remove(producto);
        return true;
    }

    public void Guardar()
    {
        string json = JsonSerializer.Serialize(
            productos,
            new JsonSerializerOptions
            {
                WriteIndented = true
            });

        File.WriteAllText(Archivo, json);
    }

    public void Cargar()
    {
        if (!File.Exists(Archivo))
        {
            productos = new List<Producto>();
            return;
        }

        try
        {
            string contenido = File.ReadAllText(Archivo);

            List<Producto>? datos =
                JsonSerializer.Deserialize<List<Producto>>(contenido);

            productos = datos ?? new List<Producto>();
        }
        catch
        {
            Console.WriteLine(
                "No fue posible cargar el archivo JSON. " +
                "Se iniciará una lista vacía.");

            productos = new List<Producto>();
        }
    }
}
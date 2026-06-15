using System.Diagnostics;
using System.Security.Cryptography;

class Program
{
    static void Main (string [] args)
    {
        Inventario inventario = new();
        bool condicional = true;
        do
        {
            Console.WriteLine(" ------------");
            Console.WriteLine("Ingresa tu opcion");
            Console.WriteLine(" --- MENU ---");
            Console.WriteLine("1. Agregar producto");
            Console.WriteLine("2. Mostrar producto");
            Console.WriteLine("3. Buscar producto");
            Console.WriteLine("4. Actualiar stock");
            Console.WriteLine("5. Eliminar producto");
            Console.WriteLine("6. salir");
            int opcion = int.Parse(Console.ReadLine());
            switch (opcion)
            {
                case 1:
                    Console.WriteLine("Ingresa el Codigo");
                    string? Codigo = Console.ReadLine();
                    Console.WriteLine("Ingresa el Nombre");
                    string? Nombre = Console.ReadLine();
                    Console.WriteLine("Ingresa el Precio");
                    double Precio = double.Parse(Console.ReadLine());
                    Console.WriteLine("Ingresa el Stock");
                    int Stock = int.Parse(Console.ReadLine());
                    inventario.Agregar(Codigo, Nombre, Precio, Stock);

                break;
                case 2:
                    inventario.Mostrar();
                break;
                case 3:
                    Console.WriteLine("Ingresa el Codigo del producto que quieres encontrar");
                    Codigo = Console.ReadLine();
                    inventario.Buscar(Codigo);
                break;
                case 4:
                    Console.WriteLine("Ingresa el producto que quieres modificar");
                    string Acodigo = Console.ReadLine();
                    Console.WriteLine("Ingresa la cantidad de stock que cambiaras");
                    int Astock = int.Parse(Console.ReadLine());
                    inventario.ActualizarStock(Acodigo, Astock);
                break;
                case 5:
                    Console.WriteLine("Ingresa el Codigo del producto que quieres Eliminar");
                    Codigo = Console.ReadLine();
                    inventario.Borrar(Codigo);
                break;
                case 6:
                    condicional = false;
                break;
                default: break;
            }
        }
        while (condicional);
    } 
}

class Producto
{
    public string? Codigo {get; set;}
    public string? Nombre {get; set;}
    public double Precio {get; set;}
    public int Stock {get; set;}
    
    public Producto(string codigo, string nombre, double precio, int stock)
    {
        Codigo = codigo;
        Nombre = nombre;
        Precio = precio;
        Stock = stock;
    }
}

class Inventario
{
    public List<Producto> productos = new List<Producto>();
    public void Agregar(string codigo, string nombre, double precio, int stock)
    {
        if (Verificar(codigo, precio, stock))
        {
            productos.Add(new Producto(codigo, nombre, precio, stock));
        }
    }
    public void Buscar(string codigo)       
    {
        Producto p = productos.Find(c => c.Codigo == codigo);
        
        if (p != null)
        {
            Console.Write($"{p.Codigo} | {p.Nombre} | {p.Precio} | {p.Stock}");
        }
        else
        {
            Console.WriteLine("No se encontró producto");
        }
    }
    public bool Verificar(string codigo, double precio, int stock)
    {
        bool stockPositivo = stock >= 0;
        bool precioMayor = precio > 0;
        bool anyCodigo = productos.Any(p => p.Codigo == codigo);
        return !anyCodigo && precioMayor && stockPositivo;
    }
    public void Mostrar()
    {
        foreach (Producto producto in productos)
        {
            Console.WriteLine($"{producto.Codigo} | {producto.Nombre} | {producto.Precio} | {producto.Stock}");
        }
    }

    public void ActualizarStock(string codigo, int stock)
    {
        Producto p = productos.Find(c => c.Codigo == codigo);
        if (p != null)
        {
            Console.WriteLine($"El stock del producto {p.Nombre} se ha cambiado de {p.Stock} a {stock}");
            p.Stock = stock;
        }
        else
        {
            Console.WriteLine($"No se encontró producto con codigo {codigo}");
        }
    }

    public void Borrar(string codigo)
    {
        Producto p = productos.Find(c => c.Codigo == codigo);
        if (p != null)
        {    
            productos.Remove(p);
            Console.WriteLine("El producto ha sido eliminado con exito");
        }
        else
        {
            Console.WriteLine("No se encontró producto");
        }
    }

}
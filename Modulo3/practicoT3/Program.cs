using System;

class Producto
{
    // Atributos privados
    private string nombre;
    private double precio;
    private int cantidad;

    public string Nombre
    {
        get
        {
            return nombre;
        }
        set
        {
            nombre = value;
        }
    }

    public double Precio
    {
        get
        {
            return precio;
        }
        set
        {
            if (value > 0)
            {
                precio = value;
            }
            else
            {
                Console.WriteLine("El precio debe ser mayor a 0.");
            }
        }
    }

    public int Cantidad
    {
        get
        {
            return cantidad;
        }
        set
        {
            if (value >= 0)
            {
                cantidad = value;
            }
            else
            {
                Console.WriteLine("La cantidad no puede ser negativa.");
            }
        }
    }

    public double CalcularTotal()
    {
        return precio * cantidad;
    }

    public void MostrarInformacion()
    {
        Console.WriteLine("\n--- INFORMACIÓN DEL PRODUCTO ---");
        Console.WriteLine("Nombre: " + Nombre);
        Console.WriteLine("Precio: $" + Precio);
        Console.WriteLine("Cantidad: " + Cantidad);
        Console.WriteLine("Total: $" + CalcularTotal());
    }
}

class Program
{
    static void Main(string[] args)
    {
        Producto producto = new Producto();

        Console.Write("Ingrese nombre: ");
        producto.Nombre = Console.ReadLine();

        Console.Write("Ingrese precio: ");
        producto.Precio = Convert.ToDouble(Console.ReadLine());

        Console.Write("Ingrese cantidad: ");
        producto.Cantidad = Convert.ToInt32(Console.ReadLine());

        producto.MostrarInformacion();
    }
}
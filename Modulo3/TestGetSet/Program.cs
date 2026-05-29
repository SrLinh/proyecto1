using System;

class Producto
{
    private double precio;

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
                Console.WriteLine("El precio no puede ser negativo");
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Producto p = new Producto();

        p.Precio = 50;   // SET válido
        Console.WriteLine(p.Precio); // GET

        p.Precio = -10;  // SET inválido
    }
}
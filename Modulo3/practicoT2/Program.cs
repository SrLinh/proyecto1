using System;

class Producto
{
    public string Nombre;
    public double precio;
    public int cantidad;

    public static string MostrarNombre(string nombre)
    {
        return nombre;
    }

    public void Nana()
    {
        Console.WriteLine("Hola");
    }
}
class Program
{
    static void Main (string [] args)
    {
        Producto p = new Producto();
        p.Nombre = "alfred";
        p.cantidad = 2;
        p.Nana();
    }
}
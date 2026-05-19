using System;
using System.Collections;
using System.Diagnostics;


class Persona
{
    public void DatosPersonas(string nombre, string apellido)
    {
        Console.WriteLine($"Nombre {nombre}");
        Console.WriteLine($"Apellido {apellido}");
    }
}
class Program
{
    static void Main()
    {
        Console.WriteLine("Ingresa el nombre y luego el apellido");
        string Nombre = Console.ReadLine();
        string Apellido = Console.ReadLine();
        
        Persona p = new Persona();
        p.DatosPersonas(Nombre, Apellido);
    }
}

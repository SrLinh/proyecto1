using System;
using System.Reflection.Metadata;
class Estudiante
{
    public string nombre {get; set;}
    public int edad {get; set;}
    public double notaFinal {get; set;}

    public Estudiante(string Nombre, int Edad, double NotaFinal)
    {
        if (string.IsNullOrWhiteSpace(Nombre))
        {
            Console.WriteLine("El dato esta vacio");
        }
        else
        {
            nombre = Nombre;
        }
        if (Edad < 5 || Edad > 100)
        {
            Console.WriteLine("La edad tiene que ser mayor a 5 años y menor a 100 años");
        }
        else
        {
            edad = Edad;
        }


        if (NotaFinal < 0 || NotaFinal > 10)
        {
            Console.WriteLine("La nota final tiene que estar entre 0 y 10");
        }
        else
        {
            notaFinal = NotaFinal;
        }
    }
    public void CambiarNota(double nuevaNota)
    {
        if (nuevaNota < 0 || nuevaNota > 10 )
        {
            Console.WriteLine("La nueva nota final tiene que estar entre 0 y 10");
        }else
        {
            notaFinal = nuevaNota;
        }
    }
    public void MostrarResumen()
    {
        
    }
}
class Program
{
    static void Main(string[] args)
    {
        Estudiante e1 = new Estudiante("Mario", 14, 9);
        Estudiante e2 = new Estudiante("Gepeto", 3, -1);


    }
}
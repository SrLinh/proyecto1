using System;

class Program
{
    static void Main (string[] args)
    {
        Libro libro = new Libro();
        libro.test();
    }
}

class Libro
{
    public void conteo()
    {
        string texto = File.ReadAllText("libro.txt");
        string[] lineas = File.ReadAllLines("libro.txt");

        int numLineas = lineas.Length;
        Console.WriteLine($"La cantidad de lineas dentro del archivo son: {numLineas}");
    }

    public void test()
    {
        string frase = "Hola          a todos   ";
        string[] palabras = frase.Split(' ');
        foreach (string palabra in palabras)
        {
            Console.WriteLine(palabra);
        }
    }
}
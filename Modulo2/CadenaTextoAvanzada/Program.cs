using System;

class Program
{
    // text.equals(text2)
    //split
    //endwith
    //startwith
    //contain
    //Indexoff
    //lastindexoff
    //insert
    //remove
    //replace
    
    static void Main (string [] args)
    {
        //Cadenas.TextoAvanzado();
        Cadenas.TextoTest();
    }
}
class Cadenas
{
    public static void TextoAvanzado()
    {
        Console.WriteLine("Ingresa texto 1");
        string texto = Console.ReadLine();
        Console.WriteLine("ingresa texto 2");
        string texto2 = Console.ReadLine();

        bool comparacionTexto = texto.Equals(texto2, StringComparison.OrdinalIgnoreCase);
        Console.WriteLine($"El texto 1 y 2 son iguales? {comparacionTexto}");

        Console.WriteLine("------- SPLIT -------");
        string[] splitPalabras = texto.Split(" ");
        Console.WriteLine(splitPalabras);

        Console.WriteLine("------- ENDWITH -------");
        // StartsWith
        Console.WriteLine("\nStartsWith:");
        Console.WriteLine(texto.StartsWith("Programacion"));

        // EndsWith
        Console.WriteLine("\nEndsWith:");
        Console.WriteLine(texto.EndsWith("divertida"));

        // Contains
        Console.WriteLine("\nContains:");
        Console.WriteLine(texto.Contains("C#"));

        // IndexOf
        Console.WriteLine("\nIndexOf:");
        Console.WriteLine(texto.IndexOf("en"));

        // LastIndexOf
        Console.WriteLine("\nLastIndexOf:");
        Console.WriteLine(texto.LastIndexOf("a"));

        // Insert
        Console.WriteLine("\nInsert:");
        string insertado = texto.Insert(13, "basica y ");
        Console.WriteLine(insertado);

        // Remove
        Console.WriteLine("\nRemove:");
        string removido = texto.Remove(13, 3);
        Console.WriteLine(removido);

        // Replace
        Console.WriteLine("\nReplace:");
        string reemplazado = texto.Replace("divertida", "interesante");
        Console.WriteLine(reemplazado);
    }

    public static void TextoTest()
    {
        Console.WriteLine("Ingresa el texot");
        string Texto = Console.ReadLine();

        //El paremetro dentro de substring es basicamente para decir que extraiga
        //lo que este despues de la posicion señalada
        Console.WriteLine(Texto.Substring(1));
        int i = 0;
        Console.WriteLine(i++);
        Console.WriteLine($"{++i}");
        Console.WriteLine(i);
    }
}

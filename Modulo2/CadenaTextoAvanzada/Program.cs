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
        Console.WriteLine("Ingresa texto 1");
        string text1 = Console.ReadLine();
        Console.WriteLine("ingresa texto 2");
        string text2 = Console.ReadLine();

        bool comparacionTexto = text1.Equals(text2, StringComparison.OrdinalIgnoreCase);
        Console.WriteLine($"El texto 1 y 2 son iguales? {comparacionTexto}");


    }
}
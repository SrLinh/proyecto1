using System;
using System.Globalization;

class Program
{
    static void Main (string[] args)
    {

        int limiteFactorial = 10;
        int j = 1;
        int Factorial = 1;

        Console.WriteLine("bucle del 1 al 10");
        for (int i = 1; i < 11; i++)
        {
            Console.WriteLine(i);
        }

        Console.WriteLine("-------------------------------------------------------");

        Console.WriteLine("Factorial");
        while (!(j == (limiteFactorial + 1)))
        {
            Factorial = Factorial * j;
            j++;
        }
        Console.WriteLine("El factorial de " + limiteFactorial + " es: " + Factorial);
    }
}

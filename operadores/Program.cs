using System;

class Program
{
    static void Main (string[] args)
    {
        double valor1 = 0, valor2 = 0;

        Console.WriteLine("INGRESA LOS DOS VALORES");
        valor1 = Convert.ToInt32(Console.ReadLine());
        valor2 = Convert.ToInt32(Console.ReadLine());

        double suma = valor1 + valor2;
        double resta = valor1 - valor2;
        double multiplicacion = valor1 * valor2;
        double division = valor1 / valor2;

        Console.WriteLine("Suma: " + valor1 + " + " + valor2 + " = " + suma);
        Console.WriteLine("Resta: " + valor1 + " - " + valor2 + " = " + resta);
        Console.WriteLine("Multiplicacion: " + valor1 + " x " + valor2 + " = " + multiplicacion);
        Console.WriteLine("Division: " + valor1 + " / " + valor2 + " = " + division);

        Console.WriteLine("---------------------------------------------------------------");
        Console.WriteLine("Comparacion de valores");
        if (valor1 == valor2)
        {
            Console.WriteLine("Los dos valores son iguales");
        }
        else
        {
            Console.WriteLine("Los dos valores no son iguales"); 
        }
        
    }
}

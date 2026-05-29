using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Ingresa el número para calcular el factorial:");
        int num = Convert.ToInt32(Console.ReadLine());

        int resultado = Factorial(num);

        Console.WriteLine("El factorial de " + num + " es: " + resultado);

        Console.WriteLine("SOBRECARGA DE FUNCIONES -----------------------");

        // Suma de enteros
        int sumaEnteros = Sumar(10, 20);

        // Suma de decimales
        double sumaDecimales = Sumar(5.5, 3.2);

        Console.WriteLine("Suma de enteros: " + sumaEnteros);
        Console.WriteLine("Suma de decimales: " + sumaDecimales);
    }

    // Función recursiva
    static int Factorial(int num1)
    {
        // Caso base
        if (num1 == 0 || num1 == 1)
        {
            return 1;
        }

        // Llamada recursiva
        return num1 * Factorial(num1 - 1);
    }

    // Sobrecarga para enteros
    static int Sumar(int a, int b)
    {
        return a + b;
    }

    // Sobrecarga para decimales
    static double Sumar(double a, double b)
    {
        return a + b;
    }
}
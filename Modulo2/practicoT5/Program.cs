using System;

class Program
{
    static void Main()
    {
        int numero1 = 10;
        int numero2 = 5;

        int suma = Sumar(numero1, numero2);
        int multiplicacion = Multiplicar(numero1, numero2);

        Console.WriteLine("Suma: " + suma);
        Console.WriteLine("Multiplicación: " + multiplicacion);
    }

    static int Sumar(int a, int b)
    {
        int resultado = a + b;
        return resultado;
    }

    static int Multiplicar(int a, int b)
    {
        int resultado = a * b;
        return resultado;
    }
}
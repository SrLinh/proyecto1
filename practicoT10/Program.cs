using System;
using System.Data;
class Program
{
    static int Sumar(int a, int b)
    {
        return a + b;
    }
     /*static int Restar (int a, int b)
    {
        return a - b;
    }
     static int Multiplicar(int a, int b)
    {
        return a * b;
    }
     static int Dividir(int a, int b)
    {
        return a / b;
    }*/

    static double areaCirculo(double radio)
    {
        double resultadoArea = (Math.PI * Math.Pow(radio, 2));
        return resultadoArea;
    }

    static void Main()
    {
        Console.WriteLine("Ingresa el primer valor para la suma: ");
        int valor1 = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Ingresa el segundo valor para la suma: ");
        int valor2 = Convert.ToInt32(Console.ReadLine());
/*
        Console.Write("Elige una de las opciones :");
        Console.Write("\n1. suma");
        Console.Write("\n2. resta");
        Console.Write("\n3. multiplicacion");
        Console.Write("\n4. division");
        

        int s = Convert.ToInt32(Console.ReadLine());

        switch (s)
        {
            case 1:
                Console.WriteLine($"El resultado de la suma es: {Sumar(valor1, valor2)}");
            break;

            case 2:
                Console.WriteLine($"El resultado de la resta es: {Restar(valor1, valor2)}");
            break;

            case 3:
                Console.WriteLine($"El resultado de la multiplicacion es: {Multiplicar(valor1, valor2)}");
            break;

            case 4:
                Console.WriteLine($"El resultado de dividir es: {Dividir(valor1, valor2)}");
            break;
        }
*/
        Console.WriteLine($"El resultado de la suma es: {Sumar(valor1, valor2)}");
        Console.WriteLine("--------------------------------------------------------------------------------------");
        Console.WriteLine("Ingresa el radio del circulo");
        double radio = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine($"El area del circulo es {areaCirculo(radio)}");
    

    }
}
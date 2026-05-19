using System;
using System.Diagnostics.CodeAnalysis;

class Program
{
    static void Main (string[] args)
    {
        /*int [] numero = new int [3];
        for (int i = 0; i < numero.Length; i++)
        {
            Console.WriteLine("Ingresa un numero");
            numero[i] = Convert.ToInt32(Console.ReadLine());
        }
        for (int j = 0; j < numero.Length; j++)
        {
            Console.WriteLine($"Numero {(j + 1)} : {numero[j]}");
        } */

        double [] num = new double[4];

//      num = [12, 4, 4, 1];
        double operacion = 0;
        double s = 0;

        for (int c = 0; c < num.Length; c++)
        {
            Console.WriteLine($"Ingresa numero {(c + 1)} : ");
            num[c] = Convert.ToDouble(Console.ReadLine());
        }
        Console.Write("Elige una de las opciones :");
        Console.Write("\n1. suma");
        Console.Write("\n2. resta");
        Console.Write("\n3. multiplicacion");
        Console.Write("\n4. division");
        s = Convert.ToDouble(Console.ReadLine());

        switch (s)
        {
            case 1:
                for (int j = 0; j < num.Length; j++)
                {   
                    operacion += num[j];
                }
                Console.WriteLine($"Suma total es: {operacion}");
            break;
            case 2:
                operacion = num[0] - num[1];
                if(num.Length > 2)
                {
                    Console.WriteLine(num.Length);
                    for (int j = 2; j < num.Length; j++)
                    {
                        operacion -= num[j];
                    }
                }
                Console.WriteLine($"Resta total es: {operacion}");
            break;
            case 3:
                operacion = num[0] * num[1];
                if (num.Length > 2)
                {
                    for (int j = 2; j < num.Length; j++)
                    {   
                        operacion *= num[j];
                    }
                }
                Console.WriteLine($"Multiplicacion total es: {operacion}");
            break;
            case 4:
                operacion = num[0] / num[1];
                if (num.Length > 2)
                {
                    for (int j = 2; j < num.Length; j++)
                    {   
                        operacion /= num[j];
                    }
                }
                Console.WriteLine($"Division total es: {operacion}");
            break;
        }
        

        Console.WriteLine("-----------------------------------------------------------------");
        
        double maximo = num[0];
        for (int i = 1; i < num.Length; i++)
        {
            if (maximo < num[i])
            {
                maximo = num[i];
            }
        }
        Console.WriteLine($"El numero más grande de la lista es : {maximo}");

    }
}
using System;
using System.Drawing;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Ingresa el valor para determinar que es");
        int valor01 = 0;
        valor01 = Convert.ToInt32(Console.ReadLine());

        if (valor01 > 0)
        {
            Console.WriteLine("El valor es positivo");
        }else if (valor01 < 0)
        {
            Console.WriteLine("El valor es negativo");
        }else if (valor01 == 0)
        {
            Console.WriteLine("El valor es igual a 0");
        }

        Console.WriteLine("-----------------------------------------------------------------------");
        Console.WriteLine("Ingreas el mes de manera numerica");
        int valormes = 1;
         int valordia = 1;
        valormes = Convert.ToInt32(Console.ReadLine());
        switch (valormes)
        {
            case 1:
            Console.WriteLine("Enero");
            break;
            case 2:
            Console.WriteLine("Febrero");
            break;
            case 3:
            Console.WriteLine("Marzo");
            break;
            case 4:
            Console.WriteLine("Abril");
            break;
            case 5:
            Console.WriteLine("Mayo");
            break;
            case 6:
            Console.WriteLine("Junio");
            break;
            case 7:
            Console.WriteLine("Julio");
            break;
            case 8:
            Console.WriteLine("Agosto");
            break;
            case 9:
            Console.WriteLine("Septiembre");
            break;
            case 10:
            Console.WriteLine("Ocubre");
            break;
            case 11:
            Console.WriteLine("Noviembre");
            break;
            case 12:
            Console.WriteLine("Diciembre");
            break;
        }

         Console.WriteLine("Ingresa el dia del mes");
         valordia = Convert.ToInt32(Console.ReadLine());
         if (valordia <11)
         {
            Console.WriteLine("Estas a comienzos del mes");
         }else if (valordia > 10 && valordia < 21)
         {
            Console.WriteLine("Estamos a mediados del mes");
         }else if (valordia > 20)
         {
            Console.WriteLine("Estamos a finales del mes");
        }
        else
        {
            Console.WriteLine("Ingresa un dia valido");
        }
    }
}

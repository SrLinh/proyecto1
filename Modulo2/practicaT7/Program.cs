using System;

class Program
{
    static string nombreGlobal = "Javier";

    static int contador = 0;
    static int num = 1;

    static void Main()
    {
        string nombreLocal = "Carlos";

        Console.WriteLine(nombreLocal);

        Mostrar();

        for (int i = 0; i < 4; i++)
        {
            contador = llamada(num, contador);

            Console.WriteLine(contador);
        }
    }

    static void Mostrar()
    {
        Console.WriteLine(nombreGlobal);
    }
    static int llamada(int accionador, int i)
    {
        if (accionador == 1)
        {
            return ++i;
        }

        return i;
    }
}

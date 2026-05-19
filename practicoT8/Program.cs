using System;

class Program
{
    static void Main (string[] args)
    {
        string palabra = "PROGRAMACION";
        int largoPalabra = palabra.Length;

        char primeraLetra = palabra[0];
        Console.WriteLine(primeraLetra);

        int mitadPalabraValor = largoPalabra/2;        
        char mitadLetra = palabra[mitadPalabraValor];
        Console.WriteLine(mitadLetra);

        char finalLetra = palabra[(largoPalabra - 1)];
        Console.WriteLine(finalLetra);

        Console.WriteLine("Ingrese una frase:");

        Console.WriteLine("-------------------------------------------------------------------------------");

        string frase = Console.ReadLine();
        int totalCaracteres = frase.Length;
        int vocales = 0;
        int consonantes = 0;
        int espacios = 0; 
        int numeros = 0;
        int i = 0;

        string fraseMinuscula = frase.ToLower();

        while (i < totalCaracteres)
        {
            char c = fraseMinuscula[i];

            if (c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u')
            {
                vocales++;
            }
            else if (fraseMinuscula[i] >='a'&& fraseMinuscula[i]<='z')
            {
                consonantes++;
            }
            else if (c == '1' || c == '2' || c == '3' || c == '4' || c == '5' || c == '6' || c == '7' || c == '8' || c == '9' || c == '0' )
            {
                numeros++;
            }
            else if (c == ' ')
            {
                espacios++;
            }

            i++;
        }

        Console.WriteLine("\nResultados:");
        Console.WriteLine($"Total caracteres: {totalCaracteres}");
        Console.WriteLine($"Vocales: {vocales}");
        Console.WriteLine($"Consonantes: {consonantes}");
        Console.WriteLine($"Espacios: {espacios}");
        Console.WriteLine($"Números: {numeros}");
    }
}
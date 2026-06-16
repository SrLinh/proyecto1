using System;

class Program
{
    static void Main(string[] args)
    {
        string? contraseña = Console.ReadLine();
        int largo = contraseña.Length;
        bool Mayus = contraseña.Any(char.IsUpper);

        if (largo < 12)
        {
            Console.WriteLine("Tiene que tener al menos 12 caracteres");
        }else if (Mayus == false)
        {
            Console.WriteLine("Tu contraseña necesita al menos una mayuscula");
        }else if (true)
        {
            
        }
        Console.WriteLine(Mayus);
    }
}
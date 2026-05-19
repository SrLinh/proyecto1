using System;

class Program
{
    static void Main (string[] args)
    {
        Texto t = new Texto();
        t.contadorPalabras();
        t.replacePalabra();
    }
}

class Texto
{
    public string text1;
    public string text2;
    public string buscar;
    public string reemplazo;
    public void contadorPalabras()
    {
        Console.WriteLine("Ingresa tu palabra, recuerda usar espacios");
        text1 = Console.ReadLine();

        string[] palabras = text1.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        int largoPalabra = palabras.Length;
        Console.WriteLine(largoPalabra);

    }

    public void replacePalabra()
    {
        Console.WriteLine("Ingresa la palabra que quieres reemplazar");
        buscar = Console.ReadLine();
        Console.WriteLine("Con que palabra la reemplazarás");
        reemplazo = Console.ReadLine();

        text1 = text1.Replace(buscar, reemplazo);
        Console.WriteLine("Nueva oracion con reemplazo: " + text1);


    }

}
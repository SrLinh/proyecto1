internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Cálculo del Área de un círculo:");
        Console.WriteLine("Ingrese el valor del radio del círculo en metros");
        string inputParam = Console.ReadLine();
        double radius = 0;
        double.TryParse(inputParam, out radius);
        Console.WriteLine($"Valor del radio ingresado: {radius} metros" );
        double pi = 3.141592;
        double areaCircle = pi * (Math.Pow(radius, 2));
        Console.WriteLine($"El valor del área del círculo es: {Math.Round(areaCircle,2)} m2");
    }
}


 
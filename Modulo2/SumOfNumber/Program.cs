internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("ingrese un numero: ");
        int number1 = int.Parse(Console.ReadLine());
        Console.WriteLine("ingrese el otro numero: ");
        int number2 = int.Parse(Console.ReadLine());
        var calculator = new Calculator();
        Console.WriteLine($"Total de sumar {number1} + {number2}" +
        $"es {calculator.Sum(number1, number2)}");
    }
}
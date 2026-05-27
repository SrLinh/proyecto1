using System;

public class Shape2
{
    public double Slide1 { get; set; }
    public double Slide2 { get; set; }
    public void ShapeArea()
    {
        
    }
}
class Program
{
    static void Main(string [] args)
    {
        Console.WriteLine("Area de un cuadrado");
        Square areaSquare = new Square();
        Console.WriteLine("Ingrese el valor del primer lado del cuadrado: ");
        areaSquare.Slide1 = Double.Parse(Console.ReadLine());
        Console.WriteLine("Ingrese el valor del segundo lado del cuadrado: ");
        areaSquare.Slide2 = Double.Parse(Console.ReadLine());
        Console.WriteLine($"El area de un cuadrado es: {areaSquare.ShapeArea2(areaSquare.Slide1, areaSquare.Slide2)}");
    }
}
using System;
using System.Linq;
class Program
{
    static void Main (string [] args)
    {
        Venta venta = new();
        venta.Reader();
        venta.reporte();
    }
}

class Venta
{
    public string? Vendedor {get; set;}
    public double Monto {get; set;}

    public Venta(){}
    public Venta(string vendedor, double monto)
    {
        Vendedor = vendedor;
        Monto = monto;
    }
    public List<Venta> ventas = new List<Venta>();
    


    public void Reader()
    {
        using StreamReader sr = new StreamReader("venta.txt");
        string? linea;

        while ((linea = sr.ReadLine()) != null)
        {
            string [] partes = linea.Split('|');
            if (partes.Length != 2)
            {
                continue;
            }
            ventas.Add(new Venta(partes[0], double.Parse(partes[1])));
        }
        /*
        foreach (Venta venta in ventas)
        {
            Console.WriteLine($"{venta.Vendedor} - {venta.Monto}");
        }
        */
    }
    public void reporte()
    {
        DateTime ahora = DateTime.Now;
        double Sum = ventas.Sum(m => m.Monto);
        double Max = ventas.Max(m => m.Monto);
        double Avg = ventas.Average(m => m.Monto);
        var grupo = ventas.GroupBy(m => m.Vendedor);
        File.AppendAllText("reporte.txt", $"| {ahora} | \n| {Sum} | {Max} | {Avg} |");
    }
     
    public void Writer()
    {
        
    }
}
using System;

class Program
{
    static void Main (string [] args)
    {
        
    }
}

class Venta
{
    public string? vendedor {get; set;}
    public double Monto {get; set;}

    List<Venta> venta = new List<Venta>();

    public void VentaArchivo()
    {
        if (File.Exists("ventas.txt"))
        {
            File.WriteAllText("ventas.txt","");
        }
        else
        {
            
        }
    }

    public void Reader(){
        StreamReader reader
    }
}
using System;
using System.Formats.Asn1;
class Program
{
    static void Main(string[] args)
    {/*
        string ruta = "data.txt";
        if (!File.Exists(ruta))
        {
            File.WriteAllText(ruta, "");
        }

        //File.WriteAllText(ruta, "klañjsdflaksd");
        string contenido = File.ReadAllText(ruta);
        Console.WriteLine(contenido);

        */
        /*
        string[] lineas = File.ReadAllLines("data.txt");
        foreach (string linea in lineas)
        {
            Console.WriteLine(linea);
        }
        Console.Write(lineas[1]);
        */

        /*using (StreamWriter writer = new StreamWriter("data.txt"))
        {
            writer.WriteLine("Reporte de venta");
            writer.WriteLine("Producto: mouse");
            writer.WriteLine("cantidad 32");
        }*/

        //Directory.CreateSymbolicLink();

        string ruta = Path.Combine("Datos", "data.txt");
        File.WriteAllText(ruta, "Archivo dentro de carpeta");
    }    

}
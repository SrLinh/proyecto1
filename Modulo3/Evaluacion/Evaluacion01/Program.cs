using System;
using System.Drawing;

class Program
{
    static void Main ()
    {
        string ruta = @"..\foto01.png";

        Bitmap imagen = new Bitmap(ruta);

        Console.WriteLine("Imagen leida correctamente");
        Console.WriteLine(File.Exists(ruta));
        for (int y = 0; y < imagen.Height; y++)
        {
            Console.WriteLine($"Fila {y+1}");
            for (int x = 0; x < imagen.Width; x++)
            {
                Color c = imagen.GetPixel(x, y);
                Console.Write($"({c.R},{c.G},{c.B}) ");
            }
            Console.WriteLine();
        }
    }
}
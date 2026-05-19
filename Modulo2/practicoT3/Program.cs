using System;
using System.ComponentModel;

class Program
{
    static void Main(string[] args)
    {
        string ruta = "texto.txt";
        if (!File.Exists(ruta))
        {
            File.WriteAllText(ruta, "");
        for (int i = 0; i < 5; i++)
        {
            File.AppendAllText(ruta, $"linea{i}\n");
        }
        }

        using (StreamReader reader = new StreamReader(ruta))
        {
            string linea;
            while ((linea = reader.ReadLine()) != null)
            {
                Console.WriteLine(linea);
            }
        }


        Console.WriteLine("Guardado en binario");
        Binario binario = new Binario();

        binario.guardado();
        binario.guardarArchivo();
        binario.leerArchivo();
        binario.mostrar();

    }
}

class Binario
{
    public int n;
    public string [,] datos;

    public void guardado()
    {
        Console.WriteLine("Cuantos usuarios quieres ingresar");
        n = Convert.ToInt32(Console.ReadLine());
        datos = new string[n, 3];

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Ingresa usuario {i+1}");
            Console.WriteLine($"ID: ");
            datos[i, 0] = Console.ReadLine();
            Console.WriteLine($"Nombre: ");
            datos[i, 1] = Console.ReadLine();
            Console.WriteLine($"Edad: ");
            datos[i, 2] = Console.ReadLine();
        }
    }

    public void guardarArchivo()
    {
        using (BinaryWriter bw = new BinaryWriter(File.Open("usuarios.dat", FileMode.Create)))
        {
            bw.Write(n);

            for (int i = 0; i < n; i++)
            {
                bw.Write(int.Parse(datos[i, 0]));
                bw.Write(datos[i, 1]);
                bw.Write(int.Parse(datos[i, 2]));
            }
        }

        Console.WriteLine("\nDatos guardados en archivo.");
    }

    public void leerArchivo()
    {
        using (BinaryReader br = new BinaryReader(File.Open("usuarios.dat", FileMode.Open)))
        {
            n = br.ReadInt32();
            datos = new string[n, 3];

            for (int i = 0; i < n; i++)
            {
                datos[i, 0] = br.ReadInt32().ToString();
                datos[i, 1] = br.ReadString();
                datos[i, 2] = br.ReadInt32().ToString();
            }
        }
    }

    public void mostrar()
    {
        Console.WriteLine("\nUsuarios:\n");

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"ID: {datos[i, 0]}");
            Console.WriteLine($"Nombre: {datos[i, 1]}");
            Console.WriteLine($"Edad: {datos[i, 2]}");
            Console.WriteLine("-------------------");
        }
    }
}
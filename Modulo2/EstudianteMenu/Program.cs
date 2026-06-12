using System;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Linq;

class Program
{
    static void Main(string [] args)
    {
         Estudiante E1 = new Estudiante();
         E1.InsertarDatos();
    }
}

class Estudiante
{
    public
     string Codigo;
    public string Nombre;
    public string Correo;
    public string Carrera;
    public string frase;
    public bool insertValido;

    public void InsertarDatos()

    {
        bool InsertValido = false;
        while (!InsertValido)
        {
            Console.WriteLine("Ingresa codigo de estudiante: ");
            Codigo = Console.ReadLine();
            if (!ValidarCodigo(Codigo))
            {
                Console.WriteLine("No cumple con las validaciones necesarias");
                continue;
            } 
                
            Console.WriteLine("Ingresa nombre completo de estudiante: ");
            Nombre = Console.ReadLine();
            if (!ValidarNombre(Nombre))
            {
                Console.WriteLine("No cumple con las validaciones necesarias");
                continue;
            }
    
            Console.WriteLine("Ingresa el correo electronico: ");
            Correo = Console.ReadLine();
            if (!ValidarCorreo(Correo))
            {
                Console.WriteLine("No cumple con las validaciones necesarias");
                continue;
            }
    
            Console.WriteLine("Ingresa la carrera: ");
            Carrera = Console.ReadLine();
            if (!ValidarCarrera(Carrera))
            {
                Console.WriteLine("No cumple con las validaciones necesarias");
                continue;
            }
    
            Console.WriteLine("Ingresa tu frase personal");
            frase = Console.ReadLine();

            InsertValido = true;
        }
        
    }

    public bool ValidarCodigo(string codigo)
    {
        if (!codigo.StartsWith("STU-")
            & codigo.Length != 8)
        {
            return false;
        }

        string numeros = codigo.Substring(4);

        foreach (char c in numeros)
        {
            if (!char.IsDigit(c))
                return false;
        }
        return true;
    }
    public bool ValidarCorreo(string correo)
    {
        return correo.Contains("@") 
        && !correo.Contains(" ") 
        && (correo.EndsWith(".com") 
        || correo.EndsWith(".edu") 
        || correo.EndsWith(".sv"));
    }
    public bool ValidarCarrera(string carrera)
    {
        string[] carrerasValidas =
        {
            "Ingenieria", "Diseño", "Administracion", "Arquitectura", "Otros"
        };
        
        return carrerasValidas.Contains(carrera);
        
    }
    
    public bool ValidarNombre(string nombre)
    {
        if (string.IsNullOrWhiteSpace(nombre))
        {
            return false;
        }

        string[] nombreApellido = nombre.Split(" ", StringSplitOptions.RemoveEmptyEntries);
        if(nombreApellido.Length < 2)
        {
            return false;
        }
        return true;
    }
    
}


class AdministracionEstudiante
{
    public Estudiante[] estudiantes {get; private set;}
    public int cantidadEstudiantes;
    public void Registrar()
    {
        Console.WriteLine("Ingresa la cantidad de estudiante que ingresaras");
        cantidadEstudiantes = int.Parse(Console.ReadLine());
        estudiantes = new Estudiante[cantidadEstudiantes];

        for (int i = 0; i < cantidadEstudiantes; i++)
        {
            estudiantes[i] = new Estudiante();
            estudiantes[i].InsertarDatos();
        }
    }

    public void MostrarEstudiante()
    {
        int i = 0;
        foreach (Estudiante estudiante in Estudiante)
        {
            Console.WriteLine($"Estudiante {++1}: {estudiante.Codigo} {estudiante.Nombre}");
            Console.WriteLine(estudiante.frase);
        }
    }

    public void BuscarCodigo()
    {
        string codigoBuscar = int.Parse(Console.ReadLine());
        foreach (Estudiante estudiante in Estudiante)
        {
            estudiante.Codigo;
        }
    }
    public void Menu()
    {
        Registrar();
        int opcion = 0;

        while (opcion != 8)
        {
            Console.WriteLine("\n--- MENÚ ---");
            Console.WriteLine("1. Mostrar todos los estudiantes");
            Console.WriteLine("2. Buscar estudiante por código");
            Console.WriteLine("3. Buscar estudiantes por palabra en su frase");
            Console.WriteLine("4. Mostrar cantidad de vocales de cada frase");
            Console.WriteLine("5. Mostrar la palabra más larga de cada frase");
            Console.WriteLine("6. Mostrar correos");
            Console.WriteLine("7. Reemplazar una palabra en las frases");
            Console.WriteLine("8. Salir");
            Console.Write("Selecciona una opción: ");

            switch (opcion)
            {
                case 1:
                    Console.WriteLine("Mostrando todos los estudiantes...");
                    // Llamar método aquí
                    break;

                case 2:
                    Console.Write("Ingresa el código: ");
                    string codigo = Console.ReadLine();
                    Console.WriteLine("Buscando estudiante...");
                    // Llamar método con codigo
                    break;

                case 3:
                    Console.Write("Ingresa palabra a buscar: ");
                    string palabra = Console.ReadLine();
                    Console.WriteLine("Buscando coincidencias...");
                    // Llamar método
                    break;

                case 4:
                    Console.WriteLine("Contando vocales...");
                    // Llamar método
                    break;

                case 5:
                    Console.WriteLine("Buscando palabra más larga...");
                    // Llamar método
                    break;

                case 6:
                    Console.WriteLine("Mostrando correos válidos...");
                    // Llamar método
                    break;

                case 7:
                    Console.Write("Palabra a reemplazar: ");
                    string buscar = Console.ReadLine();

                    Console.Write("Nueva palabra: ");
                    string reemplazo = Console.ReadLine();

                    Console.WriteLine("Reemplazando...");
                    // Llamar método con buscar y reemplazo
                    break;

                case 8:
                    Console.WriteLine("Saliendo del programa...");
                    break;

                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }
    }



}
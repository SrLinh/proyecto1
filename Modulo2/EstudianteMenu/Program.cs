using System;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Linq;

class Program
{
    static void Main(string [] args)
    {
        AdministracionEstudiante estudiante = new AdministracionEstudiante();
        estudiante.Menu();
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
    public Estudiante[]? estudiantes {get; private set;}
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
        foreach (Estudiante estudiante in estudiantes)
        {
            Console.WriteLine($"Estudiante {++i}: {estudiante.Codigo} {estudiante.Nombre}");
            Console.WriteLine(estudiante.frase);
        }
    }

    public void BuscarCodigo()
    {
        string? codigoBuscar = Console.ReadLine();
        Console.WriteLine("Buscando estudiante...");
        foreach (Estudiante estudiante in estudiantes)
        {
            if (codigoBuscar == estudiante.Codigo)
            {
                Console.WriteLine($"{estudiante.Nombre} | {estudiante.Carrera}");
                Console.WriteLine($"{estudiante.frase}");
            }
        }
    }

    public void BuscarFrase()
    {
        string? fraseBuscar = Console.ReadLine().ToLower();
        Console.WriteLine("Buscando coincidencias...");
        foreach (Estudiante estudiante in estudiantes)
        {
            string? fraseEstudiante = estudiante.frase.ToLower() ;
            if (fraseEstudiante.Contains(fraseBuscar))
            {
                Console.WriteLine($"{estudiante.Codigo} | {estudiante.Nombre} | {estudiante.Carrera}");
                Console.WriteLine($"{estudiante.frase}");
            }
        }
    }

    public void frasesVocales()
    {
        foreach (Estudiante estudiante in estudiantes)
        {
            int contador = 0;
            string frase = estudiante.frase;
            foreach (char c in frase.ToLower())
            {
                if (c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u')
                {
                    ++contador;
                }
            }
            Console.WriteLine($"La frase '{estudiante.frase}'");
            Console.WriteLine($"Contiene {contador} vocales.");
        }
    }

    public void frasesLargo()
    {
        foreach (Estudiante estudiante in estudiantes)
        {
            string palabraLarga = "";
            string frase = estudiante.frase;
            string[] frasePalabras = frase.Split(' ');
            int ilargo = 0;

            foreach (string palabra in frasePalabras)
            {
                int largo = palabra.Length;
                if (largo > ilargo)
                {
                    ilargo = largo;
                    palabraLarga = palabra;
                }
            }
            Console.WriteLine($"De la frase : '{estudiante.frase}'");
            Console.WriteLine($"La palabra más larga es: '{palabraLarga}'");
        }
    }

    public void frasesReemplazo()
    {
        Console.WriteLine("Palabra que deseas cambiar:");
        string? reemplazar = Console.ReadLine();
        Console.WriteLine("Palabra que la reemplazará: ");
        string? reemplazo = Console.ReadLine();

        foreach (Estudiante estudiante in estudiantes)
        {
            if (estudiante.frase.Contains(reemplazar))
            {
                Console.WriteLine($"Estudiante:");
                Console.WriteLine("Frase original:");
                string? fraseReemplazada = estudiante.frase.Replace(reemplazar, reemplazo);
                Console.WriteLine("Frase con palabra reemplazada: ");
                Console.WriteLine(fraseReemplazada);
            }
            else
            {
                Console.WriteLine($"El estudiante {estudiante.Codigo} | {estudiante.Nombre} no tiene esa palabra es un frase");
            }
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
                    MostrarEstudiante();
                    break;

                case 2:
                    Console.Write("Ingresa el código: ");
                    BuscarCodigo();
                    break;

                case 3:
                    Console.Write("Ingresa palabra a buscar: ");
                    BuscarFrase();
                    break;

                case 4:
                    Console.WriteLine("Contando vocales...");
                    frasesVocales();
                    break;

                case 5:
                    Console.WriteLine("Buscando palabra más larga...");
                    frasesLargo();
                    break;

                case 6:
                    Console.WriteLine("Mostrando correos válidos...");
                    // Llamar método
                    break;

                case 7:
                    frasesReemplazo();
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
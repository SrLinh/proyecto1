using System;
using System.Globalization;
using System.Linq.Expressions;
class Program
{
    static void Main(string[] args)
    {
        Gestion gestion = new();
        bool condicional = true;
        
        do
        {
            Console.WriteLine("1. Agregar");
            Console.WriteLine("2. Listar");
            Console.WriteLine("3. Buscar");
            Console.WriteLine("4. Eliminar");
            Console.WriteLine("5. Salir");
            int opcion = int.Parse(Console.ReadLine());
            switch (opcion)
            {
                case 1:
                    Console.WriteLine("Ingresa Id para empleado");
                    string? id = Console.ReadLine();
                    Console.WriteLine("Ingresa Nombre para empleado");
                    string? nombre = Console.ReadLine();
                    Console.WriteLine("Ingresa Puesto para empleado");
                    string? puesto = Console.ReadLine();
                    Console.WriteLine("Ingresa Salario para empleado");
                    double salario = double.Parse(Console.ReadLine());
                    gestion.Agregar(id, nombre, puesto, salario);

                break;
                case 2:
                    gestion.Listar();
                break;
                case 3:
                    Console.WriteLine("Ingresa el ID del empleado a buscar");
                    id = Console.ReadLine();
                    if (gestion.Buscar(id) == null)
                    {
                        Console.WriteLine("No se encontró empleado");
                    }
                    else
                    {
                        Empleado empleado = gestion.Buscar(id);
                        Console.WriteLine($"| ID: {empleado.Id} | {empleado.Nombre} | {empleado.Puesto} | {empleado.Salario} |");
                    }
                break;
                case 4:
                    Console.WriteLine("Ingresa el ID del empleado a Eliminar");
                    id = Console.ReadLine();
                    gestion.Eliminar(id);
                break;
                case 5:
                    condicional = false;
                break;
                default: break;
            }
        } while (condicional);
    }
}

class Empleado
{
    public string? Id {get; set;}
    public string? Nombre {get; set;}
    public string? Puesto {get; set;}
    public double Salario {get; set;}

    public Empleado(string id, string nombre, string puesto, double salario)
    {
        Id = id;
        Nombre = nombre;
        Puesto = puesto;
        Salario = salario;
    }
}

class Gestion
{
    List<Empleado> empleados = new();

    public void Agregar(string id, string nombre, string puesto, double salario)
    {
        if (ValidacionAgregar(empleados, id, salario) == true)
        {    
            empleados.Add(new Empleado(id, nombre, puesto, salario));
        }
        else
        {
            Console.WriteLine("Asegurate que el ID sea unico y el salario no sea negativo");
        }
    }
    public bool ValidacionAgregar(List<Empleado> empleados, string id, double salario)
    {
        bool verificarsalario = salario > 0;
        bool verificarcodigo = empleados.Find(e => e.Id == id) == null;
        
        return verificarcodigo && verificarsalario;
    }
    public void Listar()
    {
        foreach (Empleado empleado in empleados)
        {
            Console.WriteLine($"| ID: {empleado.Id} | {empleado.Nombre} | {empleado.Puesto} | {empleado.Salario} |");
        }
    }

    public Empleado Buscar(string id)
    {
        Empleado buscado = empleados.Find(e => e.Id == id);
        return buscado;
    }

    public void Eliminar(string id)
    {
        Empleado p = empleados.Find(e => e.Id == id);
        if (p != null)
        {
            empleados.Remove(p);
        }else
        {
            Console.WriteLine("No se encontró empleado");
        }
    }
    public void Pruebas()
    {
        empleados.Single();
    }
    
}
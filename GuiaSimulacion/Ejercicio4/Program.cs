using System;
//COLA DE PACIENTES QUE ESPERAN ATENCION MEDICA
class Program
{
    static void Main(string[] args)
    {
        Cola cola = new Cola();
        bool whileCondicional = true;
        int opcion;
        int i = 0;
        string? Nombre;
        string? Especialidad;
        do
        {
            Console.WriteLine("----------");
            Console.WriteLine("Eligue tu opcion");
            Console.WriteLine("----------");
            Console.WriteLine("1. Registrar paciente");
            Console.WriteLine("2. Atender paciente");
            Console.WriteLine("3. Ver siguiente paciente");
            Console.WriteLine("4. Mostrar cantidad de pacientes en espera");
            Console.WriteLine("5. Salir");
            opcion = int.Parse(Console.ReadLine());
            switch (opcion)
            {
                case 1:
                    Console.WriteLine("Ingresa el nombre del paciente:");
                    Nombre = Console.ReadLine();
                    Console.WriteLine("Ingresa la especialidad del paciente");
                    Especialidad = Console.ReadLine();
                    i++;
                    cola.Registrar(i, Nombre, Especialidad);
                    
                break;
                case 2:
                    cola.Atender();
                break;
                case 3:
                    cola.Ver();
                break;
                case 4:
                    cola.cantidadEspera();
                break;
                case 5:
                    whileCondicional = false;
                break;
                default:
                    Console.WriteLine("Opcion incorrecta");
                break;
            }
        } while (whileCondicional);
    }
}
 
class Paciente
{
    public int NumeroCita {get; set;}
    public string? Nombre {get; set;}
    public string? Especialidad {get; set;}

    public Paciente(int numcita, string nombre, string especialidad)
    {
        NumeroCita = numcita;
        Nombre = nombre;
        Especialidad = especialidad;
    }
}
class Cola
{
    Queue<Paciente> cola = new Queue<Paciente>();

    public void Registrar(int numcita, string nombre, string especialidad)
    {
        cola.Enqueue(new Paciente(numcita, nombre, especialidad));
        MostrarPaciente();
    }

    public void Atender()
    {
        if (cola.Count > 0)
        {
            Paciente siguiente = cola.Dequeue();
            Console.WriteLine(siguiente);
            MostrarPaciente();
        }
        else
        {
            Console.WriteLine("No hay pacientes en la cola");
        }
    }
    public void MostrarPaciente()
    {
        if (cola.Count > 0)
        {
            foreach (Paciente pacientes in cola)
            {
                Console.WriteLine($"| {pacientes.NumeroCita} | {pacientes.Nombre} | {pacientes.Especialidad}");
            }
        }
        else
        {
            Console.WriteLine("No hay pacientes en la cola");
        }
    }
    public void Ver()
    {
        if (cola.Count > 0)
        {
            Paciente siguiente = cola.Peek();
        Console.WriteLine($"| {siguiente.NumeroCita} | {siguiente.Nombre} | { siguiente.Especialidad} |");
        }
        else
        {
            Console.WriteLine("No hay pacientes en la cola");
        }
        
    }
    
    public void cantidadEspera()
    {
        int pacientesCantidad = cola.Count;
        Console.WriteLine($"Hay {pacientesCantidad} en espera");
    }
}
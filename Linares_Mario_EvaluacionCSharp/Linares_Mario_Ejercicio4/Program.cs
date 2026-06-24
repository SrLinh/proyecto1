using System;
class Program
{
    static void Main(string[] args)
    {
        Cola cliente = new();
        int numeroTurno = 0;
        bool condicional = true;
        do
        {
            Console.WriteLine("1. Agregar nuevo cliente en cola");
            Console.WriteLine("2. Atender cliente en cola");
            Console.WriteLine("3. Estado de la cola");
            int opcion = int.Parse(Console.ReadLine());
            switch (opcion)
            {
                case 1:
                    Console.WriteLine("Nombre del cliente a agregar a la cola");
                    string? Nombre = Console.ReadLine();
                    numeroTurno++;
                    cliente.Agregar(numeroTurno,Nombre);
                    Console.WriteLine($"Bienvenido {Nombre}, su turno es {numeroTurno}");
                    
                break;
                case 2:
                    cliente.Atender();
                break;
                case 3:
                    cliente.Estado();
                break;
                case 4:
                condicional = false;
                break;
                default: break;
            }
        } while (condicional);
    }
}

class Cliente
{
    public int NumeroTurno {get; set;}
    public string? Nombre {get; set;}

    public Cliente(int numTurno, string nombre)
    {
        NumeroTurno = numTurno;
        Nombre = nombre;
    }
}

class Cola
{
    Queue<Cliente> cola = new();
    

    public void Agregar(int numTurno, string nombre)
    {
        numTurno++;
        cola.Enqueue(new Cliente(numTurno, nombre));
    }

    public void Atender()
    {
        if (cola.Count > 0)
        {
            Cliente c = cola.Dequeue();
            Console.WriteLine($"Atendiendo al turno {c.NumeroTurno} - {c.Nombre}");
        }
        else
        {
            Console.WriteLine("No hay pacientes en la cola");
        }
    }
    public void Estado()
    {
        int intCola = cola.Count();
        Cliente c = cola.Peek();
        Console.WriteLine($"Hay {intCola} en cola");
        Console.WriteLine($"Siguiente cliente en la cola por atender:");
        Console.WriteLine($"Turno: {c.NumeroTurno} - {c.Nombre}");
    }
}
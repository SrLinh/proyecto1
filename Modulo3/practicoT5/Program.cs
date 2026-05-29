using System;

class Persona
{
    protected string Nombre {get; set;}
    protected int Edad {get; set;}

    protected Persona(string nombre, int edad)
    {
        Nombre = nombre;
        Edad = edad;
    }

    public virtual void MostrarInformacion()
    {
        Console.WriteLine($"Nombre: " + Nombre);
        Console.WriteLine($"Edad " + Edad);
    }
}

class Cliente : Persona
{
    public string IdCliente {get; set;}

    public Cliente(string nombre, int edad, string idcliente) : base(nombre, edad)
    {
        IdCliente = idcliente;
    }
    public override void MostrarInformacion()
    {
        base.MostrarInformacion();
        Console.WriteLine($"Codigo Cliente {IdCliente}");
    } 
}

class Empleado : Persona
{
    public string IdEmpleado {get; set;}
    public Empleado(string nombre, int edad, string idempleado)
        : base(nombre, edad)
    {
        IdEmpleado = idempleado;
    }
    public override void MostrarInformacion()
    {
        base.MostrarInformacion();
        Console.WriteLine($"Codigo Empleado {IdEmpleado}");
    }
}
class Program
{
    static void Main (string[] args)
    {
        Console.WriteLine("------------------------");

        Empleado empleado = new Empleado("Klain", 2, "EMP31213!");
        empleado.MostrarInformacion();

        Console.WriteLine("------------------------");

        Cliente cliente = new Cliente("Mario", 22, "CLT22222");
        cliente.MostrarInformacion();
    }
}
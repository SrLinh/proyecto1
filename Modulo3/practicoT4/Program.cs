using System;

class Persona
{
    public string Nombre {get; set;}
    public int Edad {get; set;}

    protected Persona(string nombre, int edad)
    {
        Nombre = nombre;
        Edad = edad;
    }

    protected void Hablar()
    {
        Console.WriteLine("Hola");
    }
}

class Cliente : Persona
{
    public string IdCliente {get; set;}

    public Cliente(string nombre, int edad, string idcliente) 
        : base(nombre, edad)
    {
        IdCliente = idcliente;
    } 

    public void Comprar()
    {
        Console.WriteLine($"El cliente {IdCliente} ha comprado producto");
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

    public void Vender()
    {
        Console.WriteLine($"El empleado {IdEmpleado} ha vendido producto");
    }
}
class Program
{
    static void Main (string[] args)
    {
        Console.WriteLine("CLIENTE");

        Cliente cliente = new Cliente("Cliente01", 19, "aaaa");
        cliente.Comprar();

        Console.WriteLine("EMPLEADO");  

        Empleado empleado = new Empleado("Empleado001010110", 42, "EMP01010");
        empleado.Vender();

    }
}
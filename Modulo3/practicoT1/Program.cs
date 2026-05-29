using System;

class Empleado
{
    // Atributos
    public string Nombre;
    public string Cargo;
    public double Salario;

    // Método para calcular salario anual
    public double CalcularSalarioAnual()
    {
        return Salario * 12;
    }

    // Método para mostrar datos
    public void MostrarDatos()
    {
        Console.WriteLine("Nombre: " + Nombre);
        Console.WriteLine("Cargo: " + Cargo);
        Console.WriteLine("Salario mensual: $" + Salario);
        Console.WriteLine("Salario anual: $" + CalcularSalarioAnual());
    }
}

class Estudiante
{
    // Atributos
    public string Nombre;
    public double Nota1;
    public double Nota2;
    public double Nota3;

    // Método para calcular promedio
    public double CalcularPromedio()
    {
        return (Nota1 + Nota2 + Nota3) / 3;
    }

    // Método para verificar aprobación
    public void MostrarResultado()
    {
        double promedio = CalcularPromedio();

        Console.WriteLine("Nombre: " + Nombre);
        Console.WriteLine("Promedio: " + promedio);

        if (promedio >= 6)
        {
            Console.WriteLine("Estado: APROBADO");
        }
        else
        {
            Console.WriteLine("Estado: REPROBADO");
        }
    }
}

class Producto
{
    // Atributos
    public string Nombre;
    public double Precio;
    public int Cantidad;

    // Método para calcular total
    public double CalcularTotal()
    {
        return Precio * Cantidad;
    }

    // Método para mostrar información
    public void MostrarInformacion()
    {
        Console.WriteLine("Nombre del producto: " + Nombre);
        Console.WriteLine("Precio: $" + Precio);
        Console.WriteLine("Cantidad: " + Cantidad);
        Console.WriteLine("Total: $" + CalcularTotal());
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("---------- EMPLEADO ----------");
        Empleado emp = new Empleado();

        Console.Write("Ingrese nombre: ");
        emp.Nombre = Console.ReadLine();

        Console.Write("Ingrese cargo: ");
        emp.Cargo = Console.ReadLine();

        Console.Write("Ingrese salario mensual: ");
        emp.Salario = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("\n--- DATOS DEL EMPLEADO ---");
        emp.MostrarDatos();

        Console.WriteLine("---------- ESTUDIANTE ----------");

        Estudiante est = new Estudiante();

        Console.Write("Ingrese nombre: ");
        est.Nombre = Console.ReadLine();

        Console.Write("Ingrese nota 1: ");
        est.Nota1 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Ingrese nota 2: ");
        est.Nota2 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Ingrese nota 3: ");
        est.Nota3 = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("\n--- RESULTADO DEL ESTUDIANTE ---");
        est.MostrarResultado();

        Console.WriteLine("---------- PRODUCTO ----------");

        Producto prod = new Producto();

        Console.Write("Ingrese nombre del producto: ");
        prod.Nombre = Console.ReadLine();

        Console.Write("Ingrese precio: ");
        prod.Precio = Convert.ToDouble(Console.ReadLine());

        Console.Write("Ingrese cantidad: ");
        prod.Cantidad = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("\n--- INFORMACIÓN DEL PRODUCTO ---");
        prod.MostrarInformacion();


    }
}
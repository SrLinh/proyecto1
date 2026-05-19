namespace SistemaNotas;

public class ReporteService
{
    public int ContarAprobados(Estudiante[] estudiantes)
    {
        if (estudiantes == null)
        {
            throw new NotaException("El arreglo de estudiantes no puede ser nulo.");
        }

        int contador = 0;

        for (int i = 0; i < estudiantes.Length; i++)
        {
            if (estudiantes[i] != null && estudiantes[i].EstaAprobado())
            {
                contador++;
            }
        }

        return contador;
    }

    public int ContarReprobados(Estudiante[] estudiantes)
    {
        if (estudiantes == null)
        {
            throw new NotaException("El arreglo de estudiantes no puede ser nulo.");
        }

        int contador = 0;

        for (int i = 0; i < estudiantes.Length; i++)
        {
            if (estudiantes[i] != null && !estudiantes[i].EstaAprobado())
            {
                contador++;
            }
        }

        return contador;
    }

    public double CalcularPromedioGeneral(Estudiante[] estudiantes)
    {
        if (estudiantes == null)
        {
            throw new NotaException("El arreglo de estudiantes no puede ser nulo.");
        }

        if (estudiantes.Length == 0)
        {
            return 0;
        }

        double suma = 0;
        int contador = 0;

        for (int i = 0; i < estudiantes.Length; i++)
        {
            if (estudiantes[i] != null)
            {
                suma += estudiantes[i].CalcularPromedio();
                contador++;
            }
        }

        if (contador == 0)
        {
            return 0;
        }

        return suma / contador;
    }

    public Estudiante[] ObtenerAprobados(Estudiante[] estudiantes)
    {
        if (estudiantes == null)
        {
            throw new NotaException("El arreglo de estudiantes no puede ser nulo.");
        }

        int cantidadAprobados = ContarAprobados(estudiantes);
        Estudiante[] aprobados = new Estudiante[cantidadAprobados];

        int posicion = 0;

        for (int i = 0; i < estudiantes.Length; i++)
        {
            if (estudiantes[i] != null && estudiantes[i].EstaAprobado())
            {
                aprobados[posicion] = estudiantes[i];
                posicion++;
            }
        }

        return aprobados;
    }

    public Estudiante[] ObtenerReprobados(Estudiante[] estudiantes)
    {
        if (estudiantes == null)
        {
            throw new NotaException("El arreglo de estudiantes no puede ser nulo.");
        }

        int cantidadReprobados = ContarReprobados(estudiantes);
        Estudiante[] reprobados = new Estudiante[cantidadReprobados];

        int posicion = 0;

        for (int i = 0; i < estudiantes.Length; i++)
        {
            if (estudiantes[i] != null && !estudiantes[i].EstaAprobado())
            {
                reprobados[posicion] = estudiantes[i];
                posicion++;
            }
        }

        return reprobados;
    }

    public void MostrarAprobados(Estudiante[] estudiantes)
    {
        Console.Clear();
        Console.WriteLine("ESTUDIANTES APROBADOS");
        Console.WriteLine("---------------------");

        Estudiante[] aprobados = ObtenerAprobados(estudiantes);

        if (aprobados.Length == 0)
        {
            Console.WriteLine("No hay estudiantes aprobados.");
            return;
        }

        for (int i = 0; i < aprobados.Length; i++)
        {
            Console.WriteLine($"{aprobados[i].Codigo} - {aprobados[i].Nombre} - Promedio: {aprobados[i].CalcularPromedio():0.00}");
        }
    }

    public void MostrarReprobados(Estudiante[] estudiantes)
    {
        Console.Clear();
        Console.WriteLine("ESTUDIANTES REPROBADOS");
        Console.WriteLine("----------------------");

        Estudiante[] reprobados = ObtenerReprobados(estudiantes);

        if (reprobados.Length == 0)
        {
            Console.WriteLine("No hay estudiantes reprobados.");
            return;
        }

        for (int i = 0; i < reprobados.Length; i++)
        {
            Console.WriteLine($"{reprobados[i].Codigo} - {reprobados[i].Nombre} - Promedio: {reprobados[i].CalcularPromedio():0.00}");
        }
    }

    public void MostrarPromedioGeneral(Estudiante[] estudiantes)
    {
        Console.Clear();
        Console.WriteLine("PROMEDIO GENERAL DEL GRUPO");
       

        double promedioGeneral = CalcularPromedioGeneral(estudiantes);

        Console.WriteLine($"Promedio general: {promedioGeneral:0.00}");
    }
}
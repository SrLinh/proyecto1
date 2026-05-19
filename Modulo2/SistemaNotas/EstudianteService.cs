namespace SistemaNotas;

public class EstudianteService
{
    public void MostrarMenu()
    {
        Console.WriteLine("SISTEMA DE GESTIÓN DE NOTAS");
        Console.WriteLine("---------------------------");
        Console.WriteLine("1. Registrar estudiante");
        Console.WriteLine("2. Buscar estudiante");
        Console.WriteLine("3. Modificar notas");
        Console.WriteLine("4. Mostrar todos los estudiantes");
        Console.WriteLine("5. Mostrar estudiantes aprobados");
        Console.WriteLine("6. Mostrar estudiantes reprobados");
        Console.WriteLine("7. Mostrar promedio general");
        Console.WriteLine("8. Guardar estudiantes en archivo");
        Console.WriteLine("9. Cargar estudiantes desde archivo");
        Console.WriteLine("10. Salir");
        Console.WriteLine("---------------------------");
    }


    public void RegistrarEstudiante(RegistroNotas registro)
    {
        Console.Clear();
        Console.WriteLine("REGISTRAR ESTUDIANTE");
        Console.WriteLine("--------------------");

        Console.Write("Código: ");
        string codigo = Console.ReadLine();

        Console.Write("Nombre: ");
        string nombre = Console.ReadLine();

        Console.Write("Nota 1: ");
        double nota1 = double.Parse(Console.ReadLine());

        Console.Write("Nota 2: ");
        double nota2 = double.Parse(Console.ReadLine());

        Console.Write("Nota 3: ");
        double nota3 = double.Parse(Console.ReadLine());

        Estudiante estudiante = new Estudiante(codigo, nombre, nota1, nota2, nota3);

        registro.RegistrarEstudiante(estudiante);

        Console.WriteLine();
        Console.WriteLine("Estudiante registrado correctamente.");
    }

    public void BuscarEstudiante(RegistroNotas registro)
    {
        Console.Clear();
        Console.WriteLine("BUSCAR ESTUDIANTE");
        Console.WriteLine("-----------------");

        Console.Write("Ingrese el código del estudiante: ");
        string codigo = Console.ReadLine();

        Estudiante estudiante = registro.BuscarEstudiante(codigo);

        if (estudiante == null)
        {
            Console.WriteLine();
            Console.WriteLine("Estudiante no encontrado.");
        }
        else
        {
            MostrarEstudiante(estudiante);
        }
    }

    public void ModificarNotas(RegistroNotas registro)
    {
        Console.Clear();
        Console.WriteLine("MODIFICAR NOTAS");
        Console.WriteLine("---------------");

        Console.Write("Código del estudiante: ");
        string codigo = Console.ReadLine();

        Console.Write("Nueva nota 1: ");
        double nota1 = double.Parse(Console.ReadLine());

        Console.Write("Nueva nota 2: ");
        double nota2 = double.Parse(Console.ReadLine());

        Console.Write("Nueva nota 3: ");
        double nota3 = double.Parse(Console.ReadLine());

        registro.ModificarNotas(codigo, nota1, nota2, nota3);

        Console.WriteLine();
        Console.WriteLine("Notas modificadas correctamente.");
    }

    public void MostrarTodosLosEstudiantes(RegistroNotas registro)
    {
        Console.Clear();
        Console.WriteLine("LISTADO DE ESTUDIANTES");
        Console.WriteLine("----------------------");

        Estudiante[] estudiantes = registro.ObtenerEstudiantesRegistrados();

        if (estudiantes.Length == 0)
        {
            Console.WriteLine("No hay estudiantes registrados.");
            return;
        }

        for (int i = 0; i < estudiantes.Length; i++)
        {
            Console.WriteLine($"Estudiante #{i + 1}");
            MostrarEstudiante(estudiantes[i]);
            Console.WriteLine("----------------------");
        }
    }

    public void MostrarEstudiante(Estudiante estudiante)
    {
        Console.WriteLine();
        Console.WriteLine("DATOS DEL ESTUDIANTE");
        Console.WriteLine("--------------------");
        Console.WriteLine($"Código: {estudiante.Codigo}");
        Console.WriteLine($"Nombre: {estudiante.Nombre}");
        Console.WriteLine($"Nota 1: {estudiante.Nota1}");
        Console.WriteLine($"Nota 2: {estudiante.Nota2}");
        Console.WriteLine($"Nota 3: {estudiante.Nota3}");
        Console.WriteLine($"Promedio: {estudiante.CalcularPromedio():0.00}");
        Console.WriteLine($"Estado: {estudiante.ObtenerEstado()}");
    }
}
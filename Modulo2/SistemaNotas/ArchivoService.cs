namespace SistemaNotas;

public class ArchivoService
{
   
    public void GuardarDesdeConsola(RegistroNotas registro)
    {
        Console.Clear();
        Console.WriteLine("GUARDAR ESTUDIANTES EN ARCHIVO");
    

        Console.Write("Nombre del archivo, por ejemplo estudiantes.txt: ");
        string ruta = Console.ReadLine();

        Estudiante[] estudiantes = registro.ObtenerEstudiantesRegistrados();

        GuardarEstudiantes(ruta, estudiantes);

        Console.WriteLine();
        Console.WriteLine("Archivo guardado correctamente.");
    }
    public void CargarDesdeConsola(RegistroNotas registro)
    {
        Console.Clear();
        Console.WriteLine("CARGAR ESTUDIANTES DESDE ARCHIVO");
  

        Console.Write("Nombre del archivo, por ejemplo estudiantes.txt: ");
        string ruta = Console.ReadLine();

        Estudiante[] estudiantes = LeerEstudiantes(ruta);

        registro.LimpiarRegistro();

        for (int i = 0; i < estudiantes.Length; i++)
        {
            registro.RegistrarEstudiante(estudiantes[i]);
        }

        Console.WriteLine();
        Console.WriteLine("Estudiantes cargados correctamente.");
    }
   
    public void GuardarEstudiantes(string rutaArchivo, Estudiante[] estudiantes)
    {
        if (string.IsNullOrWhiteSpace(rutaArchivo))
        {
            throw new NotaException("La ruta del archivo no puede estar vacía.");
        }

        if (estudiantes == null)
        {
            throw new NotaException("El arreglo de estudiantes no puede ser nulo.");
        }

        try
        {
            using StreamWriter writer = new StreamWriter(rutaArchivo, false);

            for (int i = 0; i < estudiantes.Length; i++)
            {
                if (estudiantes[i] == null)
                {
                    throw new NotaException("No se pueden guardar estudiantes nulos.");
                }

                writer.WriteLine(estudiantes[i].ConvertirAFormatoArchivo());
            }
        }
        catch (IOException)
        {
            throw new NotaException("No se pudo guardar el archivo.");
        }
    }

   
    public Estudiante[] LeerEstudiantes(string rutaArchivo)
    {
        if (string.IsNullOrWhiteSpace(rutaArchivo))
        {
   
            throw new NotaException("La ruta del archivo no puede estar vacía.");
        }

        if (!File.Exists(rutaArchivo))
        {
            throw new NotaException("El archivo no existe.");
        }

        try
        {
            string[] lineas = File.ReadAllLines(rutaArchivo);

            Estudiante[] estudiantes = new Estudiante[lineas.Length];

            for (int i = 0; i < lineas.Length; i++)
            {
                estudiantes[i] = ConvertirLineaAEstudiante(lineas[i]);
            }

            return estudiantes;
        }
        catch (IOException)
        {
            throw new NotaException("No se pudo leer el archivo.");
        }
    }

    
    
    public Estudiante ConvertirLineaAEstudiante(string linea)
    {
        if (string.IsNullOrWhiteSpace(linea))
        {
            throw new NotaException("La línea del archivo está vacía.");
        }

        string[] partes = linea.Split('|');

        if (partes.Length != 5)
        {
            throw new NotaException("El formato del archivo es incorrecto.");
        }

        string codigo = partes[0];
        string nombre = partes[1];

        double nota1 = double.Parse(partes[2]);
        double nota2 = double.Parse(partes[3]);
        double nota3 = double.Parse(partes[4]);

        Estudiante estudiante = new Estudiante(codigo, nombre, nota1, nota2, nota3);

        return estudiante;
    }
}
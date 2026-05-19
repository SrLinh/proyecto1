namespace SistemaNotas;

public class RegistroNotas
{
    private Estudiante[] estudiantes;
    private int contador;

    public RegistroNotas(int capacidad)
    {
        if (capacidad <= 0)
        {
            throw new NotaException("La capacidad debe ser mayor que cero.");
        }

        estudiantes = new Estudiante[capacidad];
        contador = 0;
    }

    public int CantidadEstudiantesRegistrados
    {
        get { return contador; }
    }

    public void RegistrarEstudiante(Estudiante estudiante)
    {
        if (estudiante == null)
        {
            throw new NotaException("El estudiante no puede ser nulo.");
        }

        if (contador >= estudiantes.Length)
        {
            throw new NotaException("No hay espacio para registrar más estudiantes.");
        }

        Estudiante estudianteExistente = BuscarEstudiante(estudiante.Codigo);

        if (estudianteExistente != null)
        {
            throw new NotaException("Ya existe un estudiante con ese código.");
        }

        estudiantes[contador] = estudiante;
        contador++;
    }

    public Estudiante BuscarEstudiante(string codigo)
    {
        if (string.IsNullOrWhiteSpace(codigo))
        {
            throw new NotaException("El código de búsqueda no puede estar vacío.");
        }

        string codigoNormalizado = codigo.Trim().ToUpper();

        for (int i = 0; i < contador; i++)
        {
            if (estudiantes[i].Codigo == codigoNormalizado)
            {
                return estudiantes[i];
            }
        }

        return null;
    }

    public void ModificarNotas(string codigo, double nota1, double nota2, double nota3)
    {
        Estudiante estudiante = BuscarEstudiante(codigo);

        if (estudiante == null)
        {
            throw new NotaException("El estudiante no existe.");
        }

        estudiante.ModificarNotas(nota1, nota2, nota3);
    }

    public Estudiante[] ObtenerEstudiantesRegistrados()
    {
        Estudiante[] resultado = new Estudiante[contador];

        for (int i = 0; i < contador; i++)
        {
            resultado[i] = estudiantes[i];
        }

        return resultado;
    }

    public void LimpiarRegistro()
    {
        for (int i = 0; i < contador; i++)
        {
            estudiantes[i] = null;
        }

        contador = 0;
    }
}
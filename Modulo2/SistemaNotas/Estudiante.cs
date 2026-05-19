namespace SistemaNotas;

public class Estudiante
{
    public string Codigo { get; private set; }
    public string Nombre { get; private set; }
    public double Nota1 { get; private set; }
    public double Nota2 { get; private set; }
    public double Nota3 { get; private set; }

    /// <summary>
    /// Permite guardado de Estudiantes con sus respectivas restricciones que evitan insecion de datos erroneos.
    /// Valida notas para despues definir los datos del estudiante.
    /// </summary>
    /// <param name="codigo"></param>
    /// <param name="nombre"></param>
    /// <param name="nota1"></param>
    /// <param name="nota2"></param>
    /// <param name="nota3"></param>
    /// <exception cref="NotaException"></exception>
    public Estudiante(string codigo, string nombre, double nota1, double nota2, double nota3)
    {
        if (string.IsNullOrWhiteSpace(codigo))
        {
            throw new NotaException("El código del estudiante no puede estar vacío.");
        }

        if (string.IsNullOrWhiteSpace(nombre))
        {
            throw new NotaException("El nombre del estudiante no puede estar vacío.");
        }

        ValidarNota(nota1);
        ValidarNota(nota2);
        ValidarNota(nota3);

        Codigo = codigo.Trim().ToUpper();
        Nombre = nombre.Trim();
        Nota1 = nota1;
        Nota2 = nota2;
        Nota3 = nota3;
    }

    /// <summary>
    /// Calculo de promedio de nota1, nota2, nota3
    /// </summary>
    /// <returns></returns>
    public double CalcularPromedio()
    {
        return (Nota1 + Nota2 + Nota3) / 3;
    }

    /// <summary>
    /// Calcula el promedio mayor a 6, regreas valor booleano
    /// </summary>
    /// <returns></returns>
    public bool EstaAprobado()
    {
        return CalcularPromedio() >= 6.0;
    }

    /// <summary>
    /// Utiliza la funcion EstaAprovado() para verificar si esta aprovado, si es cierto devolvera un string de Aprobado,
    /// caso contrario devolvera un string de Reprobado.
    /// </summary>
    /// <returns></returns>
    public string ObtenerEstado()
    {
        if (EstaAprobado())
        {
            return "APROBADO";
        }

        return "REPROBADO";
    }

    /// <summary>
    /// Esta funcion permite modificar una nota ya establecida, antes de hacer el cambio valida si
    /// la nota cumple con el filtro de ValidarNota antes de hacere el cambio
    /// </summary>
    /// <param name="nuevaNota1"></param>
    /// <param name="nuevaNota2"></param>
    /// <param name="nuevaNota3"></param>
    public void ModificarNotas(double nuevaNota1, double nuevaNota2, double nuevaNota3)
    {
        ValidarNota(nuevaNota1);
        ValidarNota(nuevaNota2);
        ValidarNota(nuevaNota3);

        Nota1 = nuevaNota1;
        Nota2 = nuevaNota2;
        Nota3 = nuevaNota3;
    }

    /// <summary>
    /// Valida que la nota sea validad, de entre 0 a 10.        
    /// </summary>
    /// <param name="nota"></param>
    /// <exception cref="NotaException"></exception>
    private void ValidarNota(double nota)
    {
        if (nota < 0 || nota > 10)
        {
            throw new NotaException("La nota debe estar entre 0 y 10.");
        }
    }

    public string ConvertirAFormatoArchivo()
    {
        return $"{Codigo}|{Nombre}|{Nota1}|{Nota2}|{Nota3}";
    }
}
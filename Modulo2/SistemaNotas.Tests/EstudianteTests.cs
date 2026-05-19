using SistemaNotas;

namespace SistemaNotas.Tests;

public class EstudianteTests
{
    [Fact]
    public void CrearEstudiante_DatosValidos_DeberiaCrearEstudiante()
    {
        Estudiante estudiante = new Estudiante("1010", "david monterroza", 10, 7, 9);

        Assert.Equal("1010", estudiante.Codigo);
        Assert.Equal("david monterroza", estudiante.Nombre);
        Assert.Equal(10, estudiante.Nota1);
        Assert.Equal(7, estudiante.Nota2);
        Assert.Equal(9, estudiante.Nota3);
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    public void CrearEstudiante_CodigoVacio_DeberiaLanzarExcepcion(string codigo)
    {
        Assert.Throws<NotaException>(() =>
        {
            new Estudiante(codigo, "Carlos López", 8, 7, 9);
        });
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    public void CrearEstudiante_NombreVacio_DeberiaLanzarExcepcion(string nombre)
    {
        Assert.Throws<NotaException>(() =>
        {
            new Estudiante("E001", nombre, 8, 7, 9);
        });
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(-5)]
    public void CrearEstudiante_NotaMenorACero_DeberiaLanzarExcepcion(double nota)
    {
        Assert.Throws<NotaException>(() =>
        {
            new Estudiante("E001", "Carlos López", nota, 7, 9);
        });
    }

    [Theory]
    [InlineData(10.1)]
    [InlineData(15)]
    public void CrearEstudiante_NotaMayorADiez_DeberiaLanzarExcepcion(double nota)
    {
        Assert.Throws<NotaException>(() =>
        {
            new Estudiante("E001", "Carlos López", nota, 7, 9);
        });
    }

    [Fact]
    public void CalcularPromedio_NotasValidas_DeberiaRetornarPromedioCorrecto()
    {
        Estudiante estudiante = new Estudiante("E001", "Carlos López", 8, 7, 9);

        double promedio = estudiante.CalcularPromedio();

        Assert.Equal(8, promedio);
    }

    [Fact]
    public void EstaAprobado_PromedioMayorOIgualASeis_DeberiaRetornarTrue()
    {
        Estudiante estudiante = new Estudiante("E001", "Carlos López", 6, 6, 6);

        bool resultado = estudiante.EstaAprobado();

        Assert.True(resultado);
    }

    [Fact]
    public void EstaAprobado_PromedioMenorASeis_DeberiaRetornarFalse()
    {
        Estudiante estudiante = new Estudiante("E001", "Carlos López", 5, 5, 5);

        bool resultado = estudiante.EstaAprobado();

        Assert.False(resultado);
    }

    [Fact]
    public void ObtenerEstado_EstudianteAprobado_DeberiaRetornarAprobado()
    {
        Estudiante estudiante = new Estudiante("E001", "Carlos López", 8, 7, 9);

        string estado = estudiante.ObtenerEstado();

        Assert.Equal("APROBADO", estado);
    }

    [Fact]
    public void ObtenerEstado_EstudianteReprobado_DeberiaRetornarReprobado()
    {
        Estudiante estudiante = new Estudiante("E001", "Carlos López", 4, 5, 5);

        string estado = estudiante.ObtenerEstado();

        Assert.Equal("REPROBADO", estado);
    }

    [Fact]
    public void ModificarNotas_NotasValidas_DeberiaModificarNotas()
    {
        Estudiante estudiante = new Estudiante("E001", "Carlos López", 4, 5, 6);

        estudiante.ModificarNotas(8, 9, 10);

        Assert.Equal(8, estudiante.Nota1);
        Assert.Equal(9, estudiante.Nota2);
        Assert.Equal(10, estudiante.Nota3);
    }

    [Fact]
    public void ModificarNotas_NotaInvalida_DeberiaLanzarExcepcion()
    {
        Estudiante estudiante = new Estudiante("E001", "Carlos López", 4, 5, 6);

        Assert.Throws<NotaException>(() =>
        {
            estudiante.ModificarNotas(8, 11, 10);
        });
    }

    [Fact]
    public void ConvertirAFormatoArchivo_DeberiaRetornarLineaConSeparador()
    {
        Estudiante estudiante = new Estudiante("E001", "Carlos López", 8, 7, 9);

        string linea = estudiante.ConvertirAFormatoArchivo();

        Assert.Equal("E001|Carlos López|8|7|9", linea);
    }
}
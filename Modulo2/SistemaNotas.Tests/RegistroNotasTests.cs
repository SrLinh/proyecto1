using SistemaNotas;

namespace SistemaNotas.Tests;

public class RegistroNotasTests
{
    [Fact]
    public void CrearRegistro_CapacidadValida_DeberiaCrearRegistro()
    {
        RegistroNotas registro = new RegistroNotas(5);

        Assert.Equal(0, registro.CantidadEstudiantesRegistrados);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-3)]
    public void CrearRegistro_CapacidadInvalida_DeberiaLanzarExcepcion(int capacidad)
    {
        Assert.Throws<NotaException>(() =>
        {
            new RegistroNotas(capacidad);
        });
    }

    [Fact]
    public void RegistrarEstudiante_DatosValidos_DeberiaAumentarContador()
    {
        RegistroNotas registro = new RegistroNotas(5);
        Estudiante estudiante = new Estudiante("E001", "Carlos López", 8, 7, 9);

        registro.RegistrarEstudiante(estudiante);

        Assert.Equal(1, registro.CantidadEstudiantesRegistrados);
    }

    [Fact]
    public void RegistrarEstudiante_EstudianteNulo_DeberiaLanzarExcepcion()
    {
        RegistroNotas registro = new RegistroNotas(5);

        Assert.Throws<NotaException>(() =>
        {
            registro.RegistrarEstudiante(null);
        });
    }

    [Fact]
    public void RegistrarEstudiante_CodigoRepetido_DeberiaLanzarExcepcion()
    {
        RegistroNotas registro = new RegistroNotas(5);

        Estudiante estudiante1 = new Estudiante("E001", "Carlos López", 8, 7, 9);
        Estudiante estudiante2 = new Estudiante("e001", "Ana Pérez", 9, 9, 9);

        registro.RegistrarEstudiante(estudiante1);

        Assert.Throws<NotaException>(() =>
        {
            registro.RegistrarEstudiante(estudiante2);
        });
    }

    [Fact]
    public void RegistrarEstudiante_ArregloLleno_DeberiaLanzarExcepcion()
    {
        RegistroNotas registro = new RegistroNotas(1);

        Estudiante estudiante1 = new Estudiante("E001", "Carlos López", 8, 7, 9);
        Estudiante estudiante2 = new Estudiante("E002", "Ana Pérez", 9, 9, 9);

        registro.RegistrarEstudiante(estudiante1);

        Assert.Throws<NotaException>(() =>
        {
            registro.RegistrarEstudiante(estudiante2);
        });
    }

    [Fact]
    public void BuscarEstudiante_CodigoExistente_DeberiaRetornarEstudiante()
    {
        RegistroNotas registro = new RegistroNotas(5);
        Estudiante estudiante = new Estudiante("E001", "Carlos López", 8, 7, 9);

        registro.RegistrarEstudiante(estudiante);

        Estudiante resultado = registro.BuscarEstudiante("e001");

        Assert.NotNull(resultado);
        Assert.Equal("E001", resultado.Codigo);
        Assert.Equal("Carlos López", resultado.Nombre);
    }

    [Fact]
    public void BuscarEstudiante_CodigoInexistente_DeberiaRetornarNull()
    {
        RegistroNotas registro = new RegistroNotas(5);

        Estudiante resultado = registro.BuscarEstudiante("E999");

        Assert.Null(resultado);
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    public void BuscarEstudiante_CodigoVacio_DeberiaLanzarExcepcion(string codigo)
    {
        RegistroNotas registro = new RegistroNotas(5);

        Assert.Throws<NotaException>(() =>
        {
            registro.BuscarEstudiante(codigo);
        });
    }

    [Fact]
    public void ModificarNotas_EstudianteExistente_DeberiaModificarNotas()
    {
        RegistroNotas registro = new RegistroNotas(5);
        Estudiante estudiante = new Estudiante("E001", "Carlos López", 5, 5, 5);

        registro.RegistrarEstudiante(estudiante);

        registro.ModificarNotas("E001", 8, 9, 10);

        Estudiante resultado = registro.BuscarEstudiante("E001");

        Assert.Equal(8, resultado.Nota1);
        Assert.Equal(9, resultado.Nota2);
        Assert.Equal(10, resultado.Nota3);
    }

    [Fact]
    public void ModificarNotas_EstudianteInexistente_DeberiaLanzarExcepcion()
    {
        RegistroNotas registro = new RegistroNotas(5);

        Assert.Throws<NotaException>(() =>
        {
            registro.ModificarNotas("E999", 8, 9, 10);
        });
    }

    [Fact]
    public void ObtenerEstudiantesRegistrados_DeberiaRetornarSoloRegistrados()
    {
        RegistroNotas registro = new RegistroNotas(5);

        Estudiante estudiante1 = new Estudiante("E001", "Carlos López", 8, 7, 9);
        Estudiante estudiante2 = new Estudiante("E002", "Ana Pérez", 6, 7, 8);

        registro.RegistrarEstudiante(estudiante1);
        registro.RegistrarEstudiante(estudiante2);

        Estudiante[] resultado = registro.ObtenerEstudiantesRegistrados();

        Assert.Equal(2, resultado.Length);
        Assert.Equal("E001", resultado[0].Codigo);
        Assert.Equal("E002", resultado[1].Codigo);
    }

    [Fact]
    public void LimpiarRegistro_DeberiaDejarContadorEnCero()
    {
        RegistroNotas registro = new RegistroNotas(5);
        Estudiante estudiante = new Estudiante("E001", "Carlos López", 8, 7, 9);

        registro.RegistrarEstudiante(estudiante);

        registro.LimpiarRegistro();

        Assert.Equal(0, registro.CantidadEstudiantesRegistrados);
    }
}
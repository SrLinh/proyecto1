using SistemaNotas;

namespace SistemaNotas.Tests;

public class ArchivoServiceTests
{
    [Fact]
    
 
    public void GuardarEstudiantes_DatosValidos_DeberiaCrearArchivo()
    {
        ArchivoService archivoService = new ArchivoService();

        Estudiante[] estudiantes = new Estudiante[1];
        estudiantes[0] = new Estudiante("E001", "Carlos López", 8, 7, 9);

        string ruta = "test_estudiantes.txt";

        archivoService.GuardarEstudiantes(ruta, estudiantes);

        Assert.True(File.Exists(ruta));

        File.Delete(ruta);
    }

    [Fact]
    public void GuardarEstudiantes_DeberiaGuardarFormatoCorrecto()
    {
        ArchivoService archivoService = new ArchivoService();

        Estudiante[] estudiantes = new Estudiante[1];
        estudiantes[0] = new Estudiante("E001", "Carlos López", 8, 7, 9);

        string ruta = "test_formato.txt";

        archivoService.GuardarEstudiantes(ruta, estudiantes);

        string contenido = File.ReadAllText(ruta).Trim();

        Assert.Equal("E001|Carlos López|8|7|9", contenido);

        File.Delete(ruta);
    }

    [Fact]
    public void GuardarEstudiantes_RutaVacia_DeberiaLanzarExcepcion()
    {
        ArchivoService archivoService = new ArchivoService();

        Estudiante[] estudiantes = new Estudiante[1];
        estudiantes[0] = new Estudiante("E001", "Carlos López", 8, 7, 9);

        Assert.Throws<NotaException>(() =>
        {
            archivoService.GuardarEstudiantes("", estudiantes);
        });
    }

    [Fact]
    public void GuardarEstudiantes_ArregloNulo_DeberiaLanzarExcepcion()
    {
        ArchivoService archivoService = new ArchivoService();

        Assert.Throws<NotaException>(() =>
        {
            archivoService.GuardarEstudiantes("test.txt", null);
        });
    }

    [Fact]
    public void GuardarEstudiantes_EstudianteNulo_DeberiaLanzarExcepcion()
    {
        ArchivoService archivoService = new ArchivoService();

        Estudiante[] estudiantes = new Estudiante[1];

        Assert.Throws<NotaException>(() =>
        {
            archivoService.GuardarEstudiantes("test.txt", estudiantes);
        });

        if (File.Exists("test.txt"))
        {
            File.Delete("test.txt");
        }
    }

    [Fact]
    public void LeerEstudiantes_ArchivoValido_DeberiaCargarEstudiantes()
    {
        ArchivoService archivoService = new ArchivoService();

        string ruta = "test_lectura.txt";

        File.WriteAllText(ruta, "E001|Carlos López|8|7|9");

        Estudiante[] estudiantes = archivoService.LeerEstudiantes(ruta);

        Assert.Single(estudiantes);
        Assert.Equal("E001", estudiantes[0].Codigo);
        Assert.Equal("Carlos López", estudiantes[0].Nombre);
        Assert.Equal(8, estudiantes[0].Nota1);

        File.Delete(ruta);
    }

    [Fact]
    public void LeerEstudiantes_RutaVacia_DeberiaLanzarExcepcion()
    {
        ArchivoService archivoService = new ArchivoService();

        Assert.Throws<NotaException>(() =>
        {
            archivoService.LeerEstudiantes("");
        });
    }

    [Fact]
    public void LeerEstudiantes_ArchivoNoExiste_DeberiaLanzarExcepcion()
    {
        ArchivoService archivoService = new ArchivoService();

        Assert.Throws<NotaException>(() =>
        {
            archivoService.LeerEstudiantes("archivo_inexistente.txt");
        });
    }

    [Fact]
    public void ConvertirLineaAEstudiante_LineaValida_DeberiaCrearEstudiante()
    {
        ArchivoService archivoService = new ArchivoService();

        Estudiante estudiante = archivoService.ConvertirLineaAEstudiante("E001|Carlos López|8|7|9");

        Assert.Equal("E001", estudiante.Codigo);
        Assert.Equal("Carlos López", estudiante.Nombre);
        Assert.Equal(8, estudiante.Nota1);
    }

    [Fact]
    public void ConvertirLineaAEstudiante_FormatoIncorrecto_DeberiaLanzarExcepcion()
    {
        ArchivoService archivoService = new ArchivoService();

        Assert.Throws<NotaException>(() =>
        {
            archivoService.ConvertirLineaAEstudiante("E001|Carlos López|8|7");
        });
    }

    [Fact]
    public void ConvertirLineaAEstudiante_NotaInvalida_DeberiaLanzarExcepcion()
    {
        ArchivoService archivoService = new ArchivoService();

        Assert.Throws<NotaException>(() =>
        {
            archivoService.ConvertirLineaAEstudiante("E001|Carlos López|8|11|9");
        });
    }
}
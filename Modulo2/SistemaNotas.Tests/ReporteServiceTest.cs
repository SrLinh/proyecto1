using SistemaNotas;

namespace SistemaNotas.Tests;

public class ReporteServiceTests
{
    [Fact]
    public void ContarAprobados_DeberiaRetornarCantidadCorrecta()
    {
        ReporteService reporteService = new ReporteService();

        Estudiante[] estudiantes = new Estudiante[3];
        estudiantes[0] = new Estudiante("E001", "Carlos López", 8, 7, 9);
        estudiantes[1] = new Estudiante("E002", "Ana Pérez", 5, 5, 5);
        estudiantes[2] = new Estudiante("E003", "Luis Ramírez", 6, 6, 6);

        int aprobados = reporteService.ContarAprobados(estudiantes);

        Assert.Equal(2, aprobados);
    }

    [Fact]
    public void ContarReprobados_DeberiaRetornarCantidadCorrecta()
    {
        ReporteService reporteService = new ReporteService();

        Estudiante[] estudiantes = new Estudiante[3];
        estudiantes[0] = new Estudiante("E001", "Carlos López", 8, 7, 9);
        estudiantes[1] = new Estudiante("E002", "Ana Pérez", 5, 5, 5);
        estudiantes[2] = new Estudiante("E003", "Luis Ramírez", 4, 6, 5);

        int reprobados = reporteService.ContarReprobados(estudiantes);

        Assert.Equal(2, reprobados);
    }

    [Fact]
    public void CalcularPromedioGeneral_DeberiaRetornarPromedioCorrecto()
    {
        ReporteService reporteService = new ReporteService();

        Estudiante[] estudiantes = new Estudiante[2];
        estudiantes[0] = new Estudiante("E001", "Carlos López", 8, 7, 9);
        estudiantes[1] = new Estudiante("E002", "Ana Pérez", 6, 6, 6);

        double promedio = reporteService.CalcularPromedioGeneral(estudiantes);

        Assert.Equal(7, promedio);
    }

    [Fact]
    public void CalcularPromedioGeneral_SinEstudiantes_DeberiaRetornarCero()
    {
        ReporteService reporteService = new ReporteService();

        Estudiante[] estudiantes = new Estudiante[0];

        double promedio = reporteService.CalcularPromedioGeneral(estudiantes);

        Assert.Equal(0, promedio);
    }

    [Fact]
    public void ObtenerAprobados_DeberiaRetornarSoloAprobados()
    {
        ReporteService reporteService = new ReporteService();

        Estudiante[] estudiantes = new Estudiante[3];
        estudiantes[0] = new Estudiante("E001", "Carlos López", 8, 7, 9);
        estudiantes[1] = new Estudiante("E002", "Ana Pérez", 5, 5, 5);
        estudiantes[2] = new Estudiante("E003", "Luis Ramírez", 6, 6, 6);

        Estudiante[] aprobados = reporteService.ObtenerAprobados(estudiantes);

        Assert.Equal(2, aprobados.Length);
        Assert.Equal("E001", aprobados[0].Codigo);
        Assert.Equal("E003", aprobados[1].Codigo);
    }

    [Fact]
    public void ObtenerReprobados_DeberiaRetornarSoloReprobados()
    {
        ReporteService reporteService = new ReporteService();

        Estudiante[] estudiantes = new Estudiante[3];
        estudiantes[0] = new Estudiante("E001", "Carlos López", 8, 7, 9);
        estudiantes[1] = new Estudiante("E002", "Ana Pérez", 5, 5, 5);
        estudiantes[2] = new Estudiante("E003", "Luis Ramírez", 4, 5, 5);

        Estudiante[] reprobados = reporteService.ObtenerReprobados(estudiantes);

        Assert.Equal(2, reprobados.Length);
        Assert.Equal("E002", reprobados[0].Codigo);
        Assert.Equal("E003", reprobados[1].Codigo);
    }

    [Fact]
    public void ContarAprobados_ArregloNulo_DeberiaLanzarExcepcion()
    {
        ReporteService reporteService = new ReporteService();

        Assert.Throws<NotaException>(() =>
        {
            reporteService.ContarAprobados(null);
        });
    }

    [Fact]
    public void ContarReprobados_ArregloNulo_DeberiaLanzarExcepcion()
    {
        ReporteService reporteService = new ReporteService();

        Assert.Throws<NotaException>(() =>
        {
            reporteService.ContarReprobados(null);
        });
    }

    [Fact]
    public void CalcularPromedioGeneral_ArregloNulo_DeberiaLanzarExcepcion()
    {
        ReporteService reporteService = new ReporteService();

        Assert.Throws<NotaException>(() =>
        {
            reporteService.CalcularPromedioGeneral(null);
        });
    }
}

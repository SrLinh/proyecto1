namespace SistemaNotas;

class Program
{
    static void Main()
    {
        RegistroNotas registro = new RegistroNotas(20);

        EstudianteService estudianteService = new EstudianteService();
        ArchivoService archivoService = new ArchivoService();
        ReporteService reporteService = new ReporteService();

        bool continuar = true;

        while (continuar)
        {
            Console.Clear();
            estudianteService.MostrarMenu();

            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();

            try
            {
                switch (opcion)
                {
                    case "1":
                        estudianteService.RegistrarEstudiante(registro);
                        break;

                    case "2":
                        estudianteService.BuscarEstudiante(registro);
                        break;

                    case "3":
                        estudianteService.ModificarNotas(registro);
                        break;

                    case "4":
                        estudianteService.MostrarTodosLosEstudiantes(registro);
                        break;

                    case "5":
                        reporteService.MostrarAprobados(registro.ObtenerEstudiantesRegistrados());
                        break;

                    case "6":
                        reporteService.MostrarReprobados(registro.ObtenerEstudiantesRegistrados());
                        break;

                    case "7":
                        reporteService.MostrarPromedioGeneral(registro.ObtenerEstudiantesRegistrados());
                        break;

                    case "8":
                        archivoService.GuardarDesdeConsola(registro);
                        break;

                    case "9":
                        archivoService.CargarDesdeConsola(registro);
                        break;

                    case "10":
                        continuar = false;
                        Console.WriteLine("Saliendo del sistema...");
                        break;

                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
            catch (NotaException ex)
            {
                Console.WriteLine();
                Console.WriteLine("ERROR DEL SISTEMA:");
                Console.WriteLine(ex.Message);
            }
            catch (FormatException)
            {
                Console.WriteLine();
                Console.WriteLine("ERROR:");
                Console.WriteLine("Debe ingresar un número válido.");
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine("ERROR INESPERADO:");
                Console.WriteLine(ex.Message);
            }

            if (continuar)
            {
                Console.WriteLine();
                Console.WriteLine("Presione una tecla para continuar...");
                Console.ReadKey();
            }
        }
    }
}
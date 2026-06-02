// Importa el namespace donde esta el formulario principal.
using SistemaProductosGUI.Forms;

// Define el namespace general del proyecto.
namespace SistemaProductosGUI;
 
// Clase principal del programa. Es internal porque solo se usa dentro del proyecto.
internal static class Program
{
    // [STAThread] es necesario en aplicaciones Windows Forms porque varios controles
    // visuales de Windows trabajan con un modelo de hilo de apartamento unico.
    [STAThread]
    static void Main()
    {
        // Inicializa la configuracion moderna de Windows Forms en .NET.
        ApplicationConfiguration.Initialize();

        // Abre el formulario principal y mantiene la aplicacion viva mientras la ventana este abierta.
        Application.Run(new MainForm());
    }
}

using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks.Dataflow;
class Program
{
    static void Main(string[] args)
    {
        
        Inventario inventario = new Inventario();

        inventario.Inicio();
        inventario.Menu();
    }
}
struct Producto
{
    public string codigo;
    public string nombre;
    public double precio;
    public int [] stockSucursal;
}
class Inventario
{
    int opcion;
    string rutaReporteGeneral = "ReporteGeneral.txt";
    string rutaReportePorSucursal = "ReportePorSucursal.txt";
    string rutaReportePorProducto = "ReportePorProducto.txt";
    int cantidadSucursal;
    int cantidadProducto;
    string [] sucursales;
    Producto[] productos;
    string stockArray;
    


    public void Inicio()
    {
        if (!File.Exists(rutaReporteGeneral) || !File.Exists(rutaReportePorSucursal) || !File.Exists(rutaReportePorProducto)) 
        {
            File.WriteAllText(rutaReporteGeneral,"");
            File.WriteAllText(rutaReportePorSucursal,"");
            File.WriteAllText(rutaReportePorProducto,"");   
        }

        Console.WriteLine("Ingresa cantidad de sucursales: ");
        cantidadSucursal = Convert.ToInt32(Console.ReadLine());
        sucursales = new string[cantidadSucursal];

        for (int i = 0; i < cantidadSucursal; i++)
        {
            Console.WriteLine($"Ingresa sucursal {i+1}");
            sucursales[i] = Console.ReadLine();
        }

        Console.WriteLine("Ingresa cantidad de productos que agregarás: ");
        cantidadProducto = Convert.ToInt32(Console.ReadLine());
        productos = new Producto[cantidadProducto];

        
        for (int i = 0; i < cantidadProducto; i++)
        {
            Console.WriteLine("Ingreas codigo");
            productos[i].codigo = Console.ReadLine();
            Console.WriteLine("Ingresa nombre");
            productos[i].nombre = Console.ReadLine();
            Console.WriteLine("Ingresa precio");
            productos[i].precio = Convert.ToDouble(Console.ReadLine());

            productos[i].stockSucursal = new int[cantidadSucursal];
            for (int s = 0; s < cantidadSucursal; s++)
            {
                Console.WriteLine($"Cuanto stock hay en la sucursal {sucursales[s]}");
                productos[i].stockSucursal[s] = Convert.ToInt32(Console.ReadLine());
            }
        }




    }

    public void GuardarProductos()
    {
        using(StreamWriter sw = new StreamWriter(ruta))
        {
            sw.Write(
                
            );
        }
        for (int i = 0; i < cantidadProducto; i++)
        {
        stockArray = string.Join(",", productos[i].stockSucursal);
        }
    }
    public void Registrar()
    {
        
    }
    public void Mostrar()
    {
        
    }
    public void Modificar()
    {
        
    }
    public void Eliminar()
    {
        
    }
    public void GenerarReporte()
    {
        
    }
    public void LeerReporte()
    {
        
    }
    public void BorrarReporte()
    {
        
    }
    public void Menu()
    {
        do {
        Console.WriteLine("\n===== MENU PRINCIPAL =====\n");
        Console.WriteLine("1. Registrar productos\n");
        Console.WriteLine("2. Mostrar productos\n");
        Console.WriteLine("3. Modificar producto\n");
        Console.WriteLine("4. Eliminar producto\n");
        Console.WriteLine("5. Buscar producto\n");
        Console.WriteLine("6. Generar reportes\n");
        Console.WriteLine("7. Leer reportes guardados\n");
        Console.WriteLine("8. Borrar archivos de reportes\n");
        Console.WriteLine("9. Salir\n");
        Console.WriteLine("Seleccione una opcion: ");

        opcion = Convert.ToInt32(Console.ReadLine());
        switch(opcion) {
            case 1:
                Console.WriteLine("Registrar productos\n"); break;

            case 2:
                Console.WriteLine("Mostrar productos\n"); break;

            case 3:
                Console.WriteLine("Modificar producto\n"); break;

            case 4:
                Console.WriteLine("Eliminar producto\n"); break;

            case 5:
                Console.WriteLine("Buscar producto\n"); break;

            case 6:
                Console.WriteLine("Generar reportes\n"); break;

            case 7:
                Console.WriteLine("Leer reportes guardados\n"); break;

            case 8:
                Console.WriteLine("Borrar archivos de reportes\n"); break; 

            case 9:
                Console.WriteLine("Saliendo del programa...\n"); break;

            
        }

        } while(opcion != 9);

        
    }
}
 
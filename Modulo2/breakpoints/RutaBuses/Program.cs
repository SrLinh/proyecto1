using System;
class Program
{
    struct Viaje
    {
        public string CodigoRuta;
        public string Motorista;
        public int SerieTalonario;
        public int TicketInicial;
        public int TicketFinal;
        public double Tarifa;
        public double Gastos;
    }
    static void Main()
    {
        Viaje[] viajes = new Viaje[6];
        int contadorProductos = 0;
        int opcion;
        
        do
        {
            Console.WriteLine("=== LIQUIDACION DE RUTAS ===");
            Console.WriteLine("1. Registrar viaje");
            Console.WriteLine("2. Mostrar viajes");
            Console.WriteLine("3. Calcular ingresos por ruta");
            Console.WriteLine("4. Buscar viaje por serie");
            Console.WriteLine("5. Modificar tickets finales");
            Console.WriteLine("6. Reporte general");
            Console.WriteLine("7. Salir");
            Console.Write("Opcion: ");
            opcion = int.Parse(Console.ReadLine());
            switch (opcion)
            {
                case 1:
                RegistrarViaje(viajes, contadorProductos);
                contadorProductos++;
                break;
                case 2:
                MostrarViajes(viajes, contadorProductos);
                break;
                case 3:
                CalcularIngresosRuta(viajes, contadorProductos);
                break;
                case 4:
                BuscarPorSerie(viajes, contadorProductos);

                break;
                case 5:
                ModificarTickets(viajes, contadorProductos);
                break;
                case 6:
                ReporteGeneral(viajes, contadorProductos);
                break;
            }
            Console.WriteLine();
        } while (opcion != 7);

    }
    static void RegistrarViaje(Viaje[] viajes, int contador)
    {
        
        {
            Console.Write("Codigo ruta: ");
            viajes[contador].CodigoRuta = Console.ReadLine();
            Console.Write("Motorista: ");
            viajes[contador].Motorista = Console.ReadLine();
            Console.Write("Serie talonario: ");
            viajes[contador].SerieTalonario = int.Parse(Console.ReadLine());
            Console.Write("Ticket inicial: ");
            viajes[contador].TicketInicial = int.Parse(Console.ReadLine());
            Console.Write("Ticket final: ");
            viajes[contador].TicketFinal = int.Parse(Console.ReadLine());
            Console.Write("Tarifa: ");
            viajes[contador].Tarifa = double.Parse(Console.ReadLine());
            Console.Write("Gastos: ");
            viajes[contador].Gastos = double.Parse(Console.ReadLine());
        }
    }
    static void MostrarViajes(Viaje[] viajes, int contador)
    {
        for (int i = 0; i <= contador; i++)
        {
            int boletos = CalcularBoletos(viajes[i].TicketInicial, viajes[i].TicketFinal);
            double bruto = boletos * viajes[i].Tarifa;
            double neto = bruto - viajes[i].Gastos;
            Console.WriteLine("Ruta: " + viajes[i].CodigoRuta);
            Console.WriteLine("Motorista: " + viajes[i].Motorista);
            Console.WriteLine("Serie: " + viajes[i].SerieTalonario);
            Console.WriteLine("Boletos vendidos: " + boletos);
            Console.WriteLine("Ingreso neto: $" + neto);
            Console.WriteLine();
        }
    }
    static int CalcularBoletos(int inicial, int final)

    {
        int cantidad;
        if (final >= inicial)
        {
            cantidad = final - inicial;
        }
        else
        {
            cantidad = (100 - inicial) + final;
        }
        return cantidad;
    }
    static void CalcularIngresosRuta(Viaje[] viajes, int contador)
    {
        string ruta;
        double total = 0;
        
        Console.Write("Ruta a consultar: ");
        ruta = Console.ReadLine();
        for (int i = 0; i < contador; i++)
        {
            if (viajes[i].CodigoRuta == ruta)
            {
                int boletos = CalcularBoletos(viajes[i].TicketInicial, viajes[i].TicketFinal);
                total = boletos * viajes[i].Tarifa - viajes[i].Gastos;
            }
        }
        Console.WriteLine("Total de ruta " + ruta + ": $" + total);
    }
    static void BuscarPorSerie(Viaje[] viajes, int contador)
    {
        int serie;
        bool encontrado = false;
        Console.Write("Serie a buscar: ");
        serie = int.Parse(Console.ReadLine());
        for (int i = 0; i < contador; i++)
        {
            if (viajes[i].SerieTalonario == serie)
            {
                Console.WriteLine("Viaje encontrado: " + viajes[i].CodigoRuta);
                encontrado = true;
            }
            else
            {
                encontrado = false;
            }
        }
        if (!encontrado)

        {
            Console.WriteLine("No existe viaje con esa serie.");
        }
    }
    static void ModificarTickets(Viaje[] viajes, int contador)
    {
        int serie;
        int posicion = 0;
        Console.Write("Serie a modificar: ");  
        serie = int.Parse(Console.ReadLine());
        for (int i = 0; i < contador; i++)
        {
            if (viajes[i].SerieTalonario == serie)
            {
                posicion = i;
            }
        }
        Console.Write("Nuevo ticket final: ");
        viajes[posicion].TicketFinal = int.Parse(Console.ReadLine());
        Console.WriteLine("Datos actualizados.");
    }
    static void ReporteGeneral(Viaje[] viajes, int contador)
    {
        double totalBruto = 0;
        double totalNeto = 0;
        double mayorIngreso = 0;
        int posicionMayor = 0;
        for (int i = 0; i < contador; i++)
        {
            int boletos = CalcularBoletos(viajes[i].TicketInicial, viajes[i].TicketFinal);
            double bruto = boletos * viajes[i].Tarifa;
            double neto = bruto - viajes[i].Gastos;
            totalBruto = bruto;
            totalNeto = totalNeto + bruto - viajes[i].Gastos;
            if (neto < mayorIngreso)
            {
            }
        }
        
        Console.WriteLine("Total bruto: $" + totalBruto);
        Console.WriteLine("Total neto: $" + totalNeto);
        Console.WriteLine("Ruta con mayor ingreso: " + viajes[posicionMayor].CodigoRuta);
    }
}

using System;

class Program
{
    static void Main(string[] args)
    {
        Motocicleta.Menu();
    }
}

class Motocicleta
{
    static double combustibleLitros = 20;
    static double tanqueCapacidad = 25;

    public static void Menu()
    {
        int opcion;
        bool bolean = true;
        do
        {
            Console.WriteLine("---------------------------");
            Console.WriteLine("Ingresa opcion:");
            Console.WriteLine("---------------------------");
            Console.WriteLine("1. Conducir");
            Console.WriteLine("2. Recargar Combustible");
            Console.WriteLine("3. Ver estado");
            Console.WriteLine("4. Salir");
            Console.WriteLine("---------------------------");

            opcion = int.Parse(Console.ReadLine());
            switch (opcion)
            {
                case 1:  
                    bool caso1 = true;
                    while (caso1)
                    {
                        Console.WriteLine("Ingresa lo kilometros a recorrer: ");
                        if (!double.TryParse(Console.ReadLine(), out double kilometros) || kilometros <= 0)
                        {
                            Console.WriteLine("Ingresa una cantidad valida en kilometros");
                        }else
                        {
                            if (combustibleLitros <= 0)
                            {
                                Console.WriteLine("Ya no tienes combustible, no puedes seguir avanzando");
                                caso1 = false;
                            }else
                            {
                                Console.WriteLine(combustibleLitros);
                                if ((combustibleLitros - (kilometros * 0.1)) < 0)
                                {
                                    Console.WriteLine("No se puede recorrer tantos kilometros con la gasolina que tienes");
                                    caso1 = false;
                                }else
                                {    
                                    combustibleLitros = combustibleLitros - (kilometros * 0.1);
                                    Console.WriteLine($"avanzaste {kilometros} y te quedan {combustibleLitros} litros de combustible");
                                    caso1 = false;
                                }
                            }
                        }
                    }
                break;
                case 2: 
                    Console.WriteLine("Ingresa la cantidad de litros que deseas recargar");
                    if (!double.TryParse(Console.ReadLine(), out double recargaLitros))
                    {
                        Console.WriteLine("Ingresa cantidad valida en litros");
                    }else
                    {
                        double recargado = combustibleLitros + recargaLitros;
                        if (recargaLitros > tanqueCapacidad || recargado > tanqueCapacidad)
                        {
                            Console.WriteLine("Se ha excedido la capacidad de recargar combustible");
                        }
                        else
                        {
                            combustibleLitros = recargado;
                            Console.WriteLine("Se ha recargado el tanque con combustible");
                            Console.WriteLine($"Combustible en el tanque: {combustibleLitros} litros");
                        }
                    }
                break;
                case 3:  
                    double porcentajeCombustible = combustibleLitros / tanqueCapacidad;
                    Console.WriteLine($"El tanque tiene {combustibleLitros} litros de combustible");
                    Console.WriteLine($"Un {porcentajeCombustible * 100}% de su capacidad maxima.");
                break;
                case 4: bolean = false; break;
                default: Console.WriteLine("Opcion invalida"); break;
            }
        } while (bolean);
    }
}
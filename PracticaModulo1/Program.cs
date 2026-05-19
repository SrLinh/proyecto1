using System;
using System.Data;

class Program
{
    //solicite la cantidad de productos vendidos
    //para cada producto: nombre del producto, precio unitario, cantidad vendida
    //calcule: total por producto, total general de ventas
    //muestre en un menu que permita: ver todos los productos, ver el total general, ver el producto mas vendido(mayor cantidad), salir
    static void Main (string[] args)
    {

        int posicionNota = 0;
        int s = 0;

        while (s != 10)
        {
            Console.WriteLine($"Ingresa una de las opciones: ");
            Console.WriteLine($"1. Ingresa alumno y nota: ");
            Console.WriteLine($"2. Buscador de alumno y sus notas");
            Console.WriteLine($"3. Productos");
            Console.WriteLine($"10. Salir");
            s = Convert.ToInt32(Console.ReadLine());
            switch (s)
            {
                case 1:
                    Console.WriteLine($"Ingresa numero de alumnos");
                    int cantidadEstudiante = Convert.ToInt16(Console.ReadLine());
                    Console.WriteLine("Ingresa la cantidad de notas");
                    int cantidadNotas = Convert.ToInt32(Console.ReadLine());

                    string[] nombre = new string[cantidadEstudiante];
                    double[] notas = new double[cantidadEstudiante * cantidadNotas];
                    
                    for (int i = 0; i < cantidadEstudiante; i++)
                    {   
                        Console.WriteLine($"Ingresa nombre de alumno {(i+1)}: ");
                        nombre[i] = Console.ReadLine();
                        int iteradorNota = 0;
                        
                        while (iteradorNota < cantidadNotas)
                        {
                            Console.WriteLine($"Ingresa nota N{(iteradorNota + 1)}°");
                            notas[posicionNota] = Convert.ToInt32(Console.ReadLine());

                            posicionNota ++;
                            iteradorNota ++;
                        }
                    }
                break;

                case 2:
                    double suma = 0; 
                    double promedio = 0;
                    int iteradorPromedio = 0;
                    Console.WriteLine("Ingresa el nombre del alumno que quieras buscar: ");           
                    string buscarEstudiante = Console.ReadLine();
                    for (int j = 0; j < cantidadEstudiante; j++)
                    {
                        if (nombre[j] == buscarEstudiante)
                        {
                            Console.WriteLine($"Las notas del estudiante{nombre[j]} son: ");
                            for (int n = j * cantidadNotas; n < ((j * cantidadNotas)) + cantidadNotas; n++)
                            {   

                                Console.WriteLine($"{notas[n]}");
                                suma += notas[n]; 
                            }
                            promedio = suma / cantidadNotas;
                            Console.WriteLine($"El promedio del estudiante{nombre[j]} es: {promedio}");
                        }
                    }
                break;
                case 3:
                    Console.WriteLine("Ingresa la cantidad de productos que usarás");
                    int numeroProductos = Convert.ToInt32(Console.ReadLine());

                    string[] producto = new string[numeroProductos];
                    double[] precio = new double[numeroProductos];
                    double[] cantidad = new double[numeroProductos];

                    for (int p = 0; p < numeroProductos; p++)
                    {
                        Console.WriteLine($"Ingresa prooducto, precio y cantidad. n{(p+1)}");
                        int nombreProducto = Convert.ToInt32(Console.ReadLine());
                        int PrecioProducto = Convert.ToInt32(Console.ReadLine());
                        int cantidadProducto = Convert.ToInt32(Console.ReadLine());
                        
                        producto[p] = nombreProducto;
                        precio[p] = PrecioProducto;
                        cantidad[p] = cantidadProducto;

                    }



                break;
            }
        }
        



    }

    
}
using System;
namespace practica {
    class Program{
        static void Main (string[] args){ 
            Console.WriteLine("Ingresa el nombre del estudiante");
            string nombre = Console.ReadLine();
            
            Console.WriteLine("Ingresa el carnet del estudiante");
            string carnet = Console.ReadLine();

            Console.WriteLine("Ingresa la nota 1");
            double nota1 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Ingresa la nota 2");
            double nota2 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Ingresa la nota 3");
            double nota3 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Ingresa el porcentaje de asistencia del estudiante");
            double asistencia = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Ingresa la carrera del estudiante");
            string carrera = Console.ReadLine();

            Console.WriteLine("Seccion del estudiante");
            string seccion = Console.ReadLine();
+
            Console.WriteLine("El estudiante entrego el proyecto final? (si/no)");
            bool entregaconfirmacion = Console.ReadLine() == "si";
            

                        
            Console.WriteLine("--------------------------------------------------------------------");

            double promedio = (nota1 + nota2 + nota3)/3;
            if(promedio >= 6){
                Console.WriteLine("El estudiante ha aprobado:" + promedio);
            }
            else
            {
                Console.WriteLine("El estudiante a reprobado: " + promedio);
            }

            if (asistencia < 70)
            {
                Console.WriteLine("Este estudiante esta en peligro de reprobar por inasistencia");
            }

            if (entregaconfirmacion == false)
            {
                Console.WriteLine("Este estudiante no ha entregado el proyecto final");
            }

            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine("Datos del estudiante");

            Console.WriteLine("Nombre del estudiante: " + nombre);
            Console.WriteLine("Carmet del estudiante: " + carnet);
            Console.WriteLine("Carrera del estudiante: " + carrera);
            Console.WriteLine("Seccion del estudiante: " + seccion);
            Console.WriteLine("Asistencia del estudiante: " + asistencia + "%");
            Console.WriteLine("Promedio del estudiante: " + promedio);
        }
    }
}

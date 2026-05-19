using System;
namespace ejercicio;
class program
{
    static void Main (string [] args)
    {
        string alumno;
        Console.WriteLine("Ingrese su nombre:");
        alumno= Console.ReadLine();

        string carnet;
        Console.WriteLine("Ingrese su carnet:");
        carnet= Console.ReadLine();

        double nota1;
        Console.WriteLine("Ingrese su primera nota:");
        nota1= double. Parse(Console.ReadLine());

        double nota2;
        Console.WriteLine("Ingrese su segunda nota:");
        nota2= double. Parse(Console.ReadLine());

        double nota3;
        Console.WriteLine("Ingrese su tercera nota:");
        nota3= double. Parse(Console.ReadLine());

        int asistencia;
        Console.WriteLine ("Porcentaje de asistencia:");
        asistencia= int.Parse(Console.ReadLine());

        string carrera;
        Console.WriteLine ("Ingrese su carrera:");
        carrera= Console.ReadLine();

        string seccion;
        Console.WriteLine ("Ingrese su seccion:");
        seccion= Console.ReadLine();

        bool proyectoFinal;
        Console.WriteLine ("Entrego su proyecto final?");
        string usuarioRespuesta = Console.ReadLine();

        if(usuarioRespuesta == "Si")
        {
            proyectoFinal = true;
        }
        else
        {
            proyectoFinal = false;
        }

        if (proyectoFinal)
        {
            System.Console.WriteLine("Proyecto final entregado");
        }
        else
        {
            Console.WriteLine("Proyento final no entregado");
        }
        
        System.Console.WriteLine("Alumno: " + alumno);
        System.Console.WriteLine("Carnet: " + carnet);
        System.Console.WriteLine("Primera nota: " + nota1);
        System.Console.WriteLine("Segunda nota: " + nota2);
        System.Console.WriteLine("Tercera nota: " + nota3);
        System.Console.WriteLine("Porcentaje de asistencia: ");
        System.Console.WriteLine("Carrera: ");
        System.Console.WriteLine("Seccion: ");
        System.Console.WriteLine("Proyecto final: ");

        double promedio = nota1 + nota2 + nota3 / 3;
        System.Console.WriteLine();

        if(promedio >= 6) 
        {
           System.Console.WriteLine("Aprobado"); 
        }
        else
        {
           System.Console.WriteLine("Reprobado"); 
        }




    }
}
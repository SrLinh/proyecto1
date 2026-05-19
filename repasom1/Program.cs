using System;
using System.Data;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
        int intentos = 0;
        bool acceso = false;
        InicioSesion login = new InicioSesion();

        while (intentos < 3 && !acceso)
        {
            Console.WriteLine("usuario: Mario, contraseña: 1234");
            Console.WriteLine("Usuario: ");
            string Usuario = Console.ReadLine();
            Console.WriteLine("Contraseña: ");
            string Contraseña = Console.ReadLine();

            acceso = login.confirmacion(Usuario, Contraseña);

            if (acceso)
            {
                login.exito(Usuario, Contraseña);
                Cajero cajero = new Cajero();
                cajero.Menu();
            }
            else
            {
                login.exito(Usuario, Contraseña);
                Console.WriteLine($"Este es un intento numero {(intentos++) + 1}, si se llega al maximo se apagara");
            }
            
        }
    }
}

class InicioSesion
{
    public string user = "Mario";
    public string password = "1234";

    public bool confirmacion(string Usuario, string Contraseña)
    {
        return Usuario == user && Contraseña == password;
    }
    
    public void exito(string Usuario, string Contraseña)
    {
        if (confirmacion(Usuario, Contraseña))
        {
            Console.WriteLine("Acceso concedido");
        }
        else
        {
            Console.WriteLine("Acceso denegado");
        }
    }
}

class Cajero
{
    public double saldo = 500;
    public string []historial = new string[2];
    public int opcion = 0;
    int contador = 0; 
    public void Menu()
    {
        do
        {
            Console.WriteLine("Ingresa una de las siguientes opciones: ");
            Console.WriteLine("1. Consultar Saldo");
            Console.WriteLine("2. Depositar Saldo");
            Console.WriteLine("3. Retirar Saldo");
            Console.WriteLine("4. Ver Historial");
            Console.WriteLine("5. Salir");
            opcion = Convert.ToInt32(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    Consultar();
                break;
                case 2:
                    Depositar();
                break;
                case 3:
                    Retirar();
                break; 
                case 4:
                    Historial();
                break;               
            }
        } while (opcion != 5);
    }
    public void Consultar()
    {
        Console.WriteLine($"Tu saldo es de: {saldo}");
    }
    public void Depositar()
    {
        Console.WriteLine("Deposita el saldo que desees:");
        double deposito = Convert.ToDouble(Console.ReadLine());
        if (deposito > 0)
        {
            saldo += deposito;
            GuardadoHistorial("Deposito: $" + deposito);
        }
        else
        {
            Console.WriteLine("Porfavor depositar un saldo mayor a $0");
        }
    }

    public void Retirar()
    {
        Console.WriteLine("Retira el saldo que desees, no puedes retirar más de lo que tienes: ");
        double retiro = Convert.ToDouble(Console.ReadLine());
        if (retiro < saldo)
        {
            saldo -= retiro;
            GuardadoHistorial("Retiro: $" + retiro);
        }
        else
        {
            Console.WriteLine("El retiro sobrepasa tu saldo actual, ha sido denegada");
        }
    }
    public void Historial()
    {
        Console.WriteLine("HISTORIAL");
        for (int j = 0; j < contador; j++)
        {
            Console.WriteLine(historial[j]);
        }
    }
    public void GuardadoHistorial(string tramite)
    {
        if (contador == historial.Length)
        {
            int newSize = historial.Length + 1;
            string []newHistorial = new string[newSize];

            for (int i = 0; i < historial.Length; i++)
            {
                newHistorial[i] = historial[i];
            }
            historial = newHistorial;
        }

        historial[contador] = tramite;
        contador++;
    }
}
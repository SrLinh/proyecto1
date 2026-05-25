using System;
using System.Reflection.Metadata;


struct Jugador
{
    public string Nombre;
    public int Puntuacion;
}

class Palabra
{
    //Manejar la palabra a adivinar
    //Verificar intentos
    static private string ruta = "palabras.txt";

    static string PalabraAleatoria()
    {
        string [] palabras = File.ReadAllLines(ruta);
        int largoPalabras = palabras.Length;
        Random random = new Random();
        int numAleatorio = random.Next(largoPalabras);
        string palabraAleatoria = palabras[numAleatorio];

        return palabraAleatoria;
    }
    public static void Archivo()
    {
        if (!File.Exists(ruta))
        {
            Console.WriteLine("Creando archivo de palabras...");
            File.WriteAllText(ruta, "");
        }
        Console.WriteLine(PalabraAleatoria());
    }

    public static int Intentos()
    {
        int i = PalabraAleatoria().Length;
        return i*2;
    }
}

class Tablero
{
    //Manejar intentos restantes+ 
}

class Partida
{
    //Logica de juego
    //incluye turnos y cambios de puntuacion
}

class Juego
{
    Jugador[] jugador;
    public void Jugadores()
    {
        Console.WriteLine("Selecciona el numero de jugadores");
        int NumJugadores = int.Parse(Console.ReadLine());
        jugador = new Jugador[NumJugadores];
        for (int i = 0; i < NumJugadores; i++)
        {
            Console.WriteLine($"Ingresa nombre para Jugador {i+1}"); 
            jugador[i].Nombre = Console.ReadLine();
            jugador[i].Puntuacion = 0;
        }
    }
    //gestiona la partida e interacciones con los jugadores                                 
}
class Program
{
    static void Main (string [] args)
    {
        Palabra.Archivo();
    }
}
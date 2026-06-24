using System;

class Program
{
    static void Main(string[] args)
    {
        
    }
}

class Tarea
{
    public string? Titulo {get; set;}
    public DateTime FechaLimite {get; set;}
    public bool EsCompletada {get; set;}

    public Tarea(string titulo, DateTime fechalimite, bool compleatda)
    {
        Titulo = titulo;
        FechaLimite = fechalimite;
        EsCompletada = compleatda;
    }
}

class Sistema
{
    List<Tarea> tareas = new();
    public static void Inicio()
    {
        if (!File.Exists("tareas.json"))
        {
            
        }
    }
}
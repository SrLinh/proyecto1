using System;
using System.Reflection.Emit;

abstract class Personaje
{
    public string Nombre {set; get;}
    public int Vida {set; get;}
    public int Defensa {set; get;}
    public int Daño {set; get;}
    public double ProbDañoCritico {set; get;}
    public int DañoCritico {set; get;}

    public Personaje(string nombre, int vida, int defensa, int daño, double prob, int critico)
    {
        Nombre = nombre;
        Vida = vida;
        Defensa = defensa;
        Daño = daño;
        ProbDañoCritico = prob;
        DañoCritico = critico;
    }


    public void MostrarInfo()
    {
        Console.WriteLine($"Nombre: {Nombre}");
        Console.WriteLine($"Vida: {Vida}");
        Console.WriteLine($"Ataque: {Daño}");
    }

    public virtual void Atacar()
    {
        Random random = new Random();

        if (random.NextDouble() < ProbDañoCritico)
        {
            Console.WriteLine($"{Nombre} ataca con {DañoCritico} de daño.");    
        }else
        {
            Console.WriteLine($"{Nombre} ataca con {Daño} de daño.");
        }
    }
}

class Guerrero : Personaje 
{
    public Guerrero(string nombre)
        : base(nombre, 250, 50, 20, 0.4, 35)
    {
    }
    
    public override void Atacar()
    {
        base.Atacar();
    }
}
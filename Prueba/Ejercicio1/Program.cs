using System;
class Program
{   public int heroeHP = 50;
    public int monstruoHP = 50;

    public int pocion = 10;
    public int pocionUsos = 3;

    
    static void Main(string[] args)
    {   Program program = new();

        bool condicional = true;
        while (condicional)
        {
            Console.WriteLine("Selecciona: ");
            Console.WriteLine("1. Atacar");
            Console.WriteLine("2. Curarse");
            Console.WriteLine("3. Salir");
            if (!int.TryParse(Console.ReadLine(), out int opcion) || opcion < 0 || opcion > 3)
            {
                Console.WriteLine("Ingresa una opcion valida");
                continue;
            }

            switch (opcion)
            {
                case 1:
                    Console.WriteLine($" Vida heroe : {program.heroeHP}");
                    Console.WriteLine($" Vida monstruo : {program.monstruoHP}");
                    program.Atacar(1);
                    program.Atacar(2);
                    Console.WriteLine($" Vida heroe despues de una accion {program.heroeHP}");
                    Console.WriteLine($" Vida monstruo despues de accion {program.monstruoHP}");
                    if (program.FinJuego() == 1)
                    {
                        Console.WriteLine("¡Victoria!");
                        condicional = false;
                    }else if (program.FinJuego() == 2)
                    {
                        Console.WriteLine("Has muerto...");
                        condicional = false;
                    }
                break;
                case 2:
                    Console.WriteLine($" Vida de heroe {program.heroeHP}");                
                    int usos = program.Curarse();
                    Console.WriteLine($"usos de posiciones restantes {usos}");
                    if (usos < 0)
                    {
                        Console.WriteLine("Ya no tienes posiciones");
                        continue;
                    }
                    Console.WriteLine($" Vida de heroe despues de curarse {program.heroeHP}"); 
                    program.Atacar(2);
                    Console.WriteLine($" Vida de heroe despues de ser atacado {program.heroeHP}");
                    if (program.FinJuego() == 1)
                    {
                        Console.WriteLine("¡Victoria!");
                        condicional = false;
                    }else if (program.FinJuego() == 2)
                    {
                        Console.WriteLine("Has muerto...");
                        condicional = false;
                    }
                    
                break;
                case 3:
                    condicional = false;
                break;
                default: Console.WriteLine("No es una opcion valida"); break;
            }
            
        }

    }

    public int Atacar(int pj){
        if (pj == 1)
        {
            int daño = AtaqueHeroe();
            return monstruoHP = monstruoHP - daño;

        }else if (pj == 2)
        {
            int daño = AtaqueMonstruo();
            return heroeHP = heroeHP - daño;
        }
        return 0;
    }
    public int AtaqueHeroe()
    {
        Random random = new Random();
        int ataqueHeroe = random.Next(5, 12);
        return ataqueHeroe;
    }
    public int AtaqueMonstruo()
    {
        Random random = new Random();
        int ataqueMonstruo = random.Next(7, 15);
        return ataqueMonstruo;
    }
    public int Curarse()
    {
        
        if (pocionUsos < 0)
        {
            return 0;
        }else
        {
            int curacion = heroeHP + pocion;
            if (curacion > 50)
            { 
                int exceso = heroeHP - 50;
                heroeHP = heroeHP - exceso;

            }
            else
            {
                heroeHP = heroeHP + pocion;
            }
            pocionUsos = pocionUsos - 1;
        }
        return pocionUsos;
        
    }
    public int Muerte()
    {
        if (heroeHP <= 0)
        {
            return 1;            
        }else if (monstruoHP <= 0)
        {
            return 2;
        }
        return 0;
    }
    public int FinJuego()
    {
        if (Muerte() == 1)
        {
            return 2;
            //Console.WriteLine("Has muerto...");
        }else if (Muerte() == 2)
        {
            return 1;
            //Console.WriteLine("¡Victoria!");
        } return 0;
    }

}

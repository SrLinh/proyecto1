using System;
class Program
{
    static void Main (string [] args)
    {
        List<string> nombresLista = new List<string>();
        nombresLista.Add("añadido 1");
        nombresLista.Add("añadido dos");
        nombresLista.Add("añadido 123");

        //Numero de espacios en la lista, es como Lenght
        nombresLista.Count();

        nombresLista[0] = "añadido I";
        
        nombresLista.Contains("añadido dos"); // Verifica si existe en la lista

        nombresLista.IndexOf("añadido dos"); // Dice la posicion donde encuentra el string dentro

        nombresLista.Remove("añadido I");
        nombresLista.RemoveAt(1); //Remueve el que está en la posicion 1

        foreach (string nombres in nombresLista)
        {
            
        }

    }
}
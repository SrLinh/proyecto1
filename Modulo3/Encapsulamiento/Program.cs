// Respaldo
/*
private double _precio;
public double Precio
{
    get
    {
        
    }
    set
    {
        return _precio;
        if (value > 0)
        {
            _precio = value;

        }
        else
        {
            Console.WriteLine("el precio tiene que ser mayor que cero");
        }
    }
}
*/
// con get se extrae el valor
// con set se modifica el valor

using System.Dynamic;

class Facturas
{
    public string Cliente {get; set;}
    public decimal Total {get; private set;}
    // Se puede leer desde fuera, pero solo la clase puede cambiarlo (solo dentro de la clase se puede modificar la variable)

}
class Program
{
    private string nombre;
    public string Nombre
    {
        get
        {
            return nombre;
        }
        set
        {
            nombre = value;
        }
    }
}
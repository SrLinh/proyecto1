class Producto
{
    public string nombre {get; private set;}
    public double precio {get; private set;}
    public int stock {get; private set;}

    public Producto(string Nombre, double Precio, int Stock)
    {
        nombre = Nombre;
        precio = Precio;
        stock = Stock;
    }
    public void Vender()
    {
        if (true)
        {
            
        }
    }
    public void AumentarStock()
    {
        
    }

    public void MostarInfo()
    {

        Console.WriteLine($"{nombre} || {precio} || {stock}");
    }
}
class Program
{
    static void Main (string [] args)
    {
        Producto p1 = new Producto("Cosa", 2.5, 2);
        p1.MostarInfo();
    }
}


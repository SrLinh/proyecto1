// Permite usar la clase Product.
using SistemaProductosGUI.Models;
 
// Permite trabajar con CultureInfo para guardar decimales con punto y no depender del idioma del sistema.
using System.Globalization;

// Indica que esta clase pertenece a la carpeta logica Services.
namespace SistemaProductosGUI.Services;

// ProductService se encarga de administrar la lista de productos.
// La interfaz grafica llamara a este servicio para agregar, actualizar, eliminar y guardar datos.
public class ProductService
{
    // Lista privada donde se almacenan los productos mientras el programa esta abierto.
    private readonly List<Product> products = new();

    // Ruta del archivo donde se guardaran los productos.
    private readonly string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "products.txt");

    // Constructor del servicio. Cuando se crea el servicio, intenta cargar datos del archivo.
    public ProductService()
    {
        LoadFromFile();
    }

    // Devuelve una copia de la lista para que el formulario pueda mostrar los productos.
    public List<Product> GetAll()
    {
        return products.ToList();
    }

    // Busca productos por codigo o nombre. Se usa para el laboratorio de busqueda.
    public List<Product> Search(string text)
    {
        // Si no se escribe nada, se devuelven todos los productos.
        if (string.IsNullOrWhiteSpace(text))
            return GetAll();

        // Convierte el texto a minusculas para hacer una busqueda sin distinguir mayusculas.
        string filter = text.Trim().ToLower();

        // Where filtra la lista. Contains revisa si el codigo o nombre contiene el texto buscado.
        return products
            .Where(p => p.Code.ToLower().Contains(filter) || p.Name.ToLower().Contains(filter))
            .ToList();
    }

    // Agrega un nuevo producto a la lista.
    public void Add(Product product)
    {
        // Any revisa si ya existe un producto con el mismo codigo.
        bool exists = products.Any(p => p.Code.Equals(product.Code, StringComparison.OrdinalIgnoreCase));

        // Si ya existe, se lanza una excepcion para avisar al formulario.
        if (exists)
            throw new InvalidOperationException("Ya existe un producto con ese codigo.");

        // Si no existe, se agrega a la lista.
        products.Add(product);

        // Guarda los cambios en el archivo.
        SaveToFile();
    }

    // Actualiza un producto existente.
    public void Update(Product product)
    {
        // Busca el producto original por codigo.
        Product? existing = products.FirstOrDefault(p => p.Code.Equals(product.Code, StringComparison.OrdinalIgnoreCase));

        // Si no se encuentra, no se puede actualizar.
        if (existing == null)
            throw new InvalidOperationException("No se encontro el producto a actualizar.");

        // Actualiza los datos editables.
        existing.Name = product.Name;
        existing.Price = product.Price;
        existing.Stock = product.Stock;

        // Guarda los cambios en archivo.
        SaveToFile();
    }

    // Elimina un producto por codigo.
    public void Delete(string code)
    {
        // Busca el producto que se desea eliminar.
        Product? existing = products.FirstOrDefault(p => p.Code.Equals(code, StringComparison.OrdinalIgnoreCase));

        // Si no existe, se lanza una excepcion.
        if (existing == null)
            throw new InvalidOperationException("No se encontro el producto a eliminar.");

        // Remueve el producto de la lista.
        products.Remove(existing);

        // Guarda los cambios en archivo.
        SaveToFile();
    }

    // Guarda todos los productos en un archivo de texto separado por punto y coma.
    private void SaveToFile()
    {
        // Select transforma cada producto en una linea de texto.
        IEnumerable<string> lines = products.Select(p =>
            $"{p.Code};{p.Name};{p.Price.ToString(CultureInfo.InvariantCulture)};{p.Stock}");

        // WriteAllLines crea o reemplaza el archivo con las lineas generadas.
        File.WriteAllLines(filePath, lines);
    }

    // Carga productos desde el archivo si existe.
    private void LoadFromFile()
    {
        // Si el archivo aun no existe, no hay nada que cargar.
        if (!File.Exists(filePath))
            return;

        // Recorre cada linea del archivo.
        foreach (string line in File.ReadAllLines(filePath))
        {
            // Divide la linea usando punto y coma.
            string[] parts = line.Split(';');

            // Si la linea no tiene las 4 partes esperadas, se ignora.
            if (parts.Length != 4)
                continue;

            // Convierte el precio usando cultura invariante.
            bool validPrice = decimal.TryParse(parts[2], NumberStyles.Any, CultureInfo.InvariantCulture, out decimal price);

            // Convierte la existencia a entero.
            bool validStock = int.TryParse(parts[3], out int stock);

            // Si las conversiones fallan, se ignora la linea.
            if (!validPrice || !validStock)
                continue;

            // Agrega el producto cargado a la lista.
            products.Add(new Product
            {
                Code = parts[0],
                Name = parts[1],
                Price = price,
                Stock = stock
            });
        }
    }
}

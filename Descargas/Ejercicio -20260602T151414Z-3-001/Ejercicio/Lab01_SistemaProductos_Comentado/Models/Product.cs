// Indica que esta clase pertenece a la carpeta logica Models.
namespace SistemaProductosGUI.Models; 

// La clase Product representa un producto del inventario.
// No contiene botones ni controles visuales; solo datos.
public class Product
{
    // Codigo unico del producto. Ejemplo: P001, A100, TEC-01.
    public string Code { get; set; } = string.Empty;

    // Nombre descriptivo del producto. Ejemplo: Mouse USB.
    public string Name { get; set; } = string.Empty;

    // Precio unitario del producto. Se usa decimal porque representa dinero.
    public decimal Price { get; set; }

    // Cantidad disponible en inventario.
    public int Stock { get; set; }

    // Propiedad calculada: no se captura directamente, se obtiene multiplicando precio por existencia.
    public decimal TotalValue => Price * Stock;
}

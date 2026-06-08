using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBStoreEntityFramework.Models;

/// <summary>
/// Modelo que representa un producto dentro del inventario.
/// Esta clase se relaciona con la tabla Products de PostgreSQL.
/// </summary>
[Table("Products")]
public class Product
{
    /// <summary>
    /// Identificador único del producto.
    /// Funciona como llave primaria en la tabla Products.
    /// </summary>
    [Key]
    public int ProductID { get; set; }

    /// <summary>
    /// Identificador de la categoría a la que pertenece el producto.
    /// Funciona como llave foránea hacia la tabla Categories.
    /// </summary>
    public int CategoryID { get; set; }

    /// <summary>
    /// Nombre del producto registrado en el inventario.
    /// </summary>
    public string ProductName { get; set; } = string.Empty;

    /// <summary>
    /// Precio de venta del producto.
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Cantidad disponible del producto en inventario.
    /// </summary>
    public int Stock { get; set; }

    /// <summary>
    /// Categoría relacionada con el producto.
    /// Permite acceder al nombre de la categoría desde el producto.
    /// </summary>
    public Category? Category { get; set; }

    /// <summary>
    /// Lista de detalles de venta donde aparece este producto.
    /// Representa la relación entre productos y ventas.
    /// </summary>
    public List<SaleDetail> SaleDetails { get; set; } = new List<SaleDetail>();
}

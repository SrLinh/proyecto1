using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBStoreEntityFramework.Models;

/// <summary>
/// Modelo que representa el detalle de una venta.
/// Cada detalle indica qué producto se vendió, la cantidad y el subtotal.
/// </summary>
[Table("SaleDetails")]
public class SaleDetail
{
    /// <summary>
    /// Identificador único del detalle de venta.
    /// Funciona como llave primaria en la tabla SaleDetails.
    /// </summary>
    [Key]
    public int SaleDetailID { get; set; }

    /// <summary>
    /// Identificador de la venta a la que pertenece este detalle.
    /// Funciona como llave foránea hacia la tabla Sales.
    /// </summary>
    public int SaleID { get; set; }

    /// <summary>
    /// Identificador del producto vendido.
    /// Funciona como llave foránea hacia la tabla Products.
    /// </summary>
    public int ProductID { get; set; }

    /// <summary>
    /// Cantidad vendida del producto.
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// Precio unitario del producto al momento de la venta.
    /// Se guarda para conservar el precio histórico.
    /// </summary>
    public decimal UnitPrice { get; set; }

    /// <summary>
    /// Subtotal de este detalle.
    /// Se obtiene multiplicando Quantity por UnitPrice.
    /// </summary>
    public decimal Subtotal { get; set; }

    /// <summary>
    /// Venta relacionada con este detalle.
    /// Permite acceder a los datos generales de la venta.
    /// </summary>
    public Sale? Sale { get; set; }

    /// <summary>
    /// Producto relacionado con este detalle.
    /// Permite acceder al nombre, precio y stock del producto.
    /// </summary>
    public Product? Product { get; set; }
}

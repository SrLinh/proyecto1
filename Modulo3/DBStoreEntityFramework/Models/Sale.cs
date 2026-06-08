using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBStoreEntityFramework.Models;

/// <summary>
/// Modelo que representa una venta realizada en la tienda.
/// Esta clase se relaciona con la tabla Sales de PostgreSQL.
/// </summary>
[Table("Sales")]
public class Sale
{
    /// <summary>
    /// Identificador único de la venta.
    /// Funciona como llave primaria en la tabla Sales.
    /// </summary>
    [Key]
    public int SaleID { get; set; }

    /// <summary>
    /// Fecha y hora en que se realizó la venta.
    /// </summary>
    public DateTime SaleDate { get; set; } = DateTime.Now;

    /// <summary>
    /// Total general de la venta.
    /// Se obtiene sumando los subtotales de los detalles.
    /// </summary>
    public decimal Total { get; set; }

    /// <summary>
    /// Lista de productos vendidos dentro de esta venta.
    /// Representa una relación de uno a muchos entre Sales y SaleDetails.
    /// </summary>
    public List<SaleDetail> SaleDetails { get; set; } = new List<SaleDetail>();
}

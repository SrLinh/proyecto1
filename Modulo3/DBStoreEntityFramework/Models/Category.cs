using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBStoreEntityFramework.Models;

/// <summary>
/// Modelo que representa una categoría de productos dentro del sistema.
/// Esta clase se relaciona con la tabla Categories de PostgreSQL.
/// </summary>
[Table("Categories")]
public class Category
{
    /// <summary>
    /// Identificador único de la categoría.
    /// Funciona como llave primaria en la tabla Categories.
    /// </summary>
    [Key]
    public int CategoryID { get; set; }

    /// <summary>
    /// Nombre de la categoría.
    /// Ejemplo: Bebidas, Lácteos, Limpieza o Snacks.
    /// </summary>
    public string CategoryName { get; set; } = string.Empty;

    /// <summary>
    /// Lista de productos que pertenecen a esta categoría.
    /// Representa una relación de uno a muchos.
    /// </summary>
    public List<Product> Products { get; set; } = new List<Product>();
}

using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace ConnectToDataBaseExample.Models;

public class Order
{
    [Key]
    public int OrderID {get; set;}
    public int? UserID {get; set;}
    public User? User {get; set;}
    public DateTime OrderDate {get; set;}
}
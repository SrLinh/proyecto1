using System;
using System.ComponentModel.DataAnnotations;

namespace EntityExpenses.Models;

public class Expense
{
    [Key]
    public int ExpensesID {get; set;}
    public int CategoryID {get; set;}
    public Category? Category {get; set;}
    public DateTime ExpesesDate {get; set;}
    public string? Description {get; set;}
    public double? Amount {get; set;}
    public string? PaymentMethod {get; set;}
}
using System;
using System.Data;
using EntityExpenses.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityExpenses.Connection;

public class AppDBContext : DbContext
{
    public DbSet <Category> Categories {get; set;}
    public DbSet <Expense> Expenses {get; set;}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(
            "Host=localhost;" +
            "Port=5432;" +
            "Database=DBExpenses;" +
            "Username=postgres;" +
            "Password=123"
        );
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Esto sincroniza las clases en Models con las tablas en la base de datos
        modelBuilder.Entity<Category>().ToTable("Categories", schema: "public");
        modelBuilder.Entity<Expense>().ToTable("Expenses", schema: "public");

        // Asignar las llaves primarias
        modelBuilder.Entity<Category>().HasKey(category => category.CategoryID);
        modelBuilder.Entity<Expense>().HasKey(expense => expense.ExpensesID);
        
        // Crea las relaciones de PK y FK en C#
        modelBuilder.Entity<Category>()
            .hasone

        
    }
}
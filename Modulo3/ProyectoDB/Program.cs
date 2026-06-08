using System;
using Npgsql;
const string connectionString =
"Host=localhost;Port=5432;Database=DBStore2.0;Username=postgres;Password=123";
while (true)
{
Console.WriteLine("\n=== STORE DB ===");
Console.WriteLine("1. List products");
Console.WriteLine("2. Add product");
Console.WriteLine("3. Update stock");
Console.WriteLine("4. Delete product");
Console.WriteLine("0. Exit");
Console.Write("Option: ");
string? option = Console.ReadLine();
if (option == "1") ListProducts();
else if (option == "2") AddProduct();
else if (option == "3") UpdateStock();
else if (option == "4") DeleteProduct();
else if (option == "0") break;
else Console.WriteLine("Invalid option.");
}
void ListProducts()
{
using var connection = new NpgsqlConnection(connectionString);
connection.Open();
string sql = @"
SELECT p.""ProductID"", c.""CategoryName"", p.""ProductName"", p.""Price"",
p.""Stock""
FROM ""Products"" p
INNER JOIN ""Categories"" c ON p.""CategoryID"" = c.""CategoryID""
ORDER BY p.""ProductID"";";
using var command = new NpgsqlCommand(sql, connection);
using var reader = command.ExecuteReader();
Console.WriteLine("ID | Category | Product | Price | Stock");
while (reader.Read())
{
Console.WriteLine($"{reader.GetInt32(0)} | {reader.GetString(1)} | " + $"{reader.GetString(2)} | {reader.GetDecimal(3)} | {reader.GetInt32(4)}");
}
}
void AddProduct()
{
Console.Write("Category ID: ");
int categoryId = int.Parse(Console.ReadLine()!);
Console.Write("Product name: ");
string productName = Console.ReadLine()!;

Console.Write("Price: ");
decimal price = decimal.Parse(Console.ReadLine()!);
Console.Write("Stock: ");
int stock = int.Parse(Console.ReadLine()!);
using var connection = new NpgsqlConnection(connectionString);
connection.Open();
string sql = @"
INSERT INTO ""Products"" (""CategoryID"", ""ProductName"", ""Price"", ""Stock"")
VALUES (@CategoryID, @ProductName, @Price, @Stock);";
using var command = new NpgsqlCommand(sql, connection);
command.Parameters.AddWithValue("@CategoryID", categoryId);
command.Parameters.AddWithValue("@ProductName", productName);
command.Parameters.AddWithValue("@Price", price);
command.Parameters.AddWithValue("@Stock", stock);
command.ExecuteNonQuery();
Console.WriteLine("Product added successfully.");
}
void UpdateStock()
{
Console.Write("Product ID: ");
int productId = int.Parse(Console.ReadLine()!);
Console.Write("New stock: ");
int stock = int.Parse(Console.ReadLine()!);
using var connection = new NpgsqlConnection(connectionString);
connection.Open();
string sql = "UPDATE \"Products\" SET \"Stock\" = @Stock WHERE \"ProductID\" = @ProductID;";
using var command = new NpgsqlCommand(sql, connection);
command.Parameters.AddWithValue("@Stock", stock);
command.Parameters.AddWithValue("@ProductID", productId);
int rows = command.ExecuteNonQuery();
Console.WriteLine(rows > 0 ? "Stock updated." : "Product not found.");
}
void DeleteProduct()
{
Console.Write("Product ID: ");
int productId = int.Parse(Console.ReadLine()!);
using var connection = new NpgsqlConnection(connectionString);
connection.Open();
string sql = "DELETE FROM \"Products\" WHERE \"ProductID\" = @ProductID;";
using var command = new NpgsqlCommand(sql, connection);
command.Parameters.AddWithValue("@ProductID", productId);

int rows = command.ExecuteNonQuery();
Console.WriteLine(rows > 0 ? "Product deleted." : "Product not found.");
}
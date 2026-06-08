using System;
using ConnectToDataBaseExample.Interface;
using ConnectToDataBaseExample.Connection;

namespace ConnectToDataBaseExample.Service;
public class UserService : IUserService
{
    OutputService output = new OutputService();
    public void ListUsers()
    {
        output.StyleOutput();
        Console.WriteLine("List of users:");
        output.StyleOutput();
        using (var db = new AppDbContext())
        {
            var users = db.Users.ToList();
            var orders = db.Orders.ToList();
            foreach (var order in orders)
            {
                Console.WriteLine($"Date: {order.OrderDate}");
                Console.WriteLine($"User: {order.User?.UserName}");
                Console.WriteLine($"Email: {order.User?.UserEmail}");
                output.StyleOutput();
            }
        }
    }
}
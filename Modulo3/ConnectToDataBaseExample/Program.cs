using System;
using ConnectToDataBaseExample.Service;
using ConnectToDataBaseExample.Interface;

/// <summary>
/// class program, it is the entry point of the application
/// </summary>
public class Program
{
/// <summary>
/// Main method, it is the entry point of the application
/// </summary>
public static void Main()
{
// Create a new instance of the UserService class
IUserService userService = new UserService();
// Call the ListUsers method
userService.ListUsers();
}
}
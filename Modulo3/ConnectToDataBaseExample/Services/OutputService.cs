using System;
using ConnectToDataBaseExample.Interface;
namespace ConnectToDataBaseExample.Service;

class OutputService : IOutputService
{
    public void StyleOutput()
    {
        Console.WriteLine("########################");
    }
}
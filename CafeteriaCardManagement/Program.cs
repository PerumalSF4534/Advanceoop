using System;
namespace CafeteriaCardManagement;
class Program 
{
    public static void Main(string[] args)
    {
        FileHandling.Create();
    //Operation.DefaultValue();
      FileHandling.ReadFromCSV();
        Operation.MainMenu();
        FileHandling.WriteToCSV();

    }
}
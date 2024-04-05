using System;
namespace OnlineGroceryShop;
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
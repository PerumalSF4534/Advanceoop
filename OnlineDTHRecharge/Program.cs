using System;
namespace OnlineDTHRecharge;
class Program 
{
    public static void Main(string[] args)
    {
        FileHandling.Create();
        Operation.DefaultValue();
        FileHandling.ReadFromCSV();
        Operation.MainMenu();
        FileHandling.WriteCSV();
    }
    
}
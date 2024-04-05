using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CafeteriaCardManagement
{
    public class FileHandling
    {
        public static void Create()
        {
            string path = @"C:\Users\PerumalKrishnan\OneDrive - Syncfusion\PracticeAssignmentCode\ConsoleAppilaction\CafeteriaCardManagement";
            if (!Directory.Exists(path + "/CafeteriaCardManagement"))

            {
                Directory.CreateDirectory(path + "/CafeteriaCardManagement");
            }
            if (!File.Exists(path + "/CafeteriaCardManagement/UserDetails.csv"))
            {
                File.Create(path + "/CafeteriaCardManagement/UserDetails.csv").Close();
            }
            if (!File.Exists(path + "/CafeteriaCardManagement/FoodDetails.csv"))
            {
                File.Create(path + "/CafeteriaCardManagement/FoodDetails.csv").Close();
            }
            if (!File.Exists(path + "/CafeteriaCardManagement/OrderDetails.csv"))
            {
                File.Create(path + "/CafeteriaCardManagement/OrderDetails.csv").Close();
            }
        }
        public static void WriteToCSV()
        {
            string path = @"C:\Users\PerumalKrishnan\OneDrive - Syncfusion\PracticeAssignmentCode\ConsoleAppilaction\CafeteriaCardManagement";
            string[] user = new string[Operation.userList.Count];
            for (int i = 0; i < Operation.userList.Count; i++)
            {
                user[i] = Operation.userList[i].UserID + "," + Operation.userList[i].UserName + "," + Operation.userList[i].FatherName + "," + Operation.userList[i].MobileNumber + "," + Operation.userList[i].MailID + "," + Operation.userList[i].Gender + "," + Operation.userList[i].WorkStationNumber+","+Operation.userList[i].WalletBalance;

            }
            File.WriteAllLines(path + "/CafeteriaCardManagement/UserDetails.csv", user);
            string[] order = new string[Operation.orderList.Count];
            for (int i = 0; i < Operation.orderList.Count; i++)
            {
                order[i] = Operation.orderList[i].OrderID + "," + Operation.orderList[i].UserID + "," + Operation.orderList[i].OrderDate.ToString("dd/MM/yyyy") + "," + Operation.orderList[i].TotalPrice+ "," + Operation.orderList[i].OrderStatus;
            }
            File.WriteAllLines(path + "/CafeteriaCardManagement/OrderDetails.csv", order);
            string[] foods = new string[Operation.foodList.Count];
            for (int i = 0; i < Operation.foodList.Count; i++)
            {
                foods[i] = Operation.foodList[i].FoodID + "," + Operation.foodList[i].FoodName + "," + Operation.foodList[i].FoodPrice + "," + Operation.foodList[i].AvailableQuantity;

            }
            File.WriteAllLines(path + "/CafeteriaCardManagement/FoodDetails.csv", foods);
        }
        public static void ReadFromCSV()
        {
            string path = @"C:\Users\PerumalKrishnan\OneDrive - Syncfusion\PracticeAssignmentCode\ConsoleAppilaction\CafeteriaCardManagement";
            string[] users=File.ReadAllLines(path + "/CafeteriaCardManagement/UserDetails.csv");
            foreach(string user in users)
            {
                UserDetails user1=new UserDetails(user);
                Operation.userList.Add(user1);
            }
            string[] orders=File.ReadAllLines(path + "/CafeteriaCardManagement/OrderDetails.csv");
            foreach(string order in orders)
            {
                OrderDetails order1=new OrderDetails(order);
                Operation.orderList.Add(order1);
            }
            string[] foods=File.ReadAllLines(path + "/CafeteriaCardManagement/FoodDetails.csv");
            foreach(string food in foods)
            {
                FoodDetails food1=new FoodDetails(food);
                Operation.foodList.Add(food1);
            }
        }
    }
}
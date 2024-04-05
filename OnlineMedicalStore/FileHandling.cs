using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;
namespace OnlineMedicalStore
{
    public static class FileHandling
    {
        public static void Create()

        {
            string path = @"C:\Users\PerumalKrishnan\OneDrive - Syncfusion\PracticeAssignmentCode\ConsoleAppilaction\OnlineMedicalStore";
            // Create a Folder
            if (!Directory.Exists(path + "\\OnlineMedicalStore"))
            {
                Directory.CreateDirectory(path + "/OnlineMedicalStore");
            }
            //Create File for Medicine Details
            if (!File.Exists(path + "/OnlineMedicalStore/MedicineDetails.csv"))
            {
                File.Create(path + "/OnlineMedicalStore/MedicineDetails.csv").Close();
            }
            //Create file for Order details
            if (!File.Exists(path + "/OnlineMedicalStore/OrderDetails.csv"))
            {
                File.Create(path + "/OnlineMedicalStore/OrderDetails.csv").Close();
            }
            //create file for userdails
            if (!File.Exists(path + "/OnlineMedicalStore/UserDetails.csv"))
            {
                File.Create(path + "/OnlineMedicalStore/UserDetails.csv").Close();
            }

        }
        public static void WriteCSV()

        {
            string path = @"C:\Users\PerumalKrishnan\OneDrive - Syncfusion\PracticeAssignmentCode\ConsoleAppilaction\OnlineMedicalStore";
            // Add userDetail to UserDetails.csv file
            string[] user = new string[Operation.userList.Count];
            for (int i = 0; i < Operation.userList.Count; i++)
            {
                user[i] = Operation.userList[i].UserID + "," + Operation.userList[i].UserName + "," + Operation.userList[i].Age + "," + Operation.userList[i].City + "," + Operation.userList[i].PhoneNumber + "," + Operation.userList[i].WalletBalance;
            }
            File.WriteAllLines(path + "/OnlineMedicalStore/UserDetails.csv", user);
            //Add medicine details to medicinedetails.csv file
            string[] medicine = new string[Operation.medicineList.Count];
            for (int i = 0; i < Operation.medicineList.Count; i++)
            {
                medicine[i] = Operation.medicineList[i].MedicineID + "," + Operation.medicineList[i].MedicineName + "," + Operation.medicineList[i].AvailableCount + "," + Operation.medicineList[i].Price + "," + Operation.medicineList[i].DateOfExpiry.ToString("dd/MM/yyyy");

            }
            File.WriteAllLines(path + "/OnlineMedicalStore/MedicineDetails.csv", medicine);
            //Add order detail to orderdetails.csv file
            string[] order=new string[Operation.orderList.Count];
            for(int i=0;i<Operation.orderList.Count;i++)
            {
                order[i]=Operation.orderList[i].OrderID+","+Operation.orderList[i].UserID+","+Operation.orderList[i].MedicineID+","+Operation.orderList[i].MedicineCount+","+Operation.orderList[i].TotalPrice+","+Operation.orderList[i].OrderDate.ToString("dd/MM/yyyy")+","+Operation.orderList[i].OrderStatus;
            }
            File.WriteAllLines(path + "/OnlineMedicalStore/OrderDetails.csv",order);

        }
    
    public static void ReadFromCSV()
    {
          string path = @"C:\Users\PerumalKrishnan\OneDrive - Syncfusion\PracticeAssignmentCode\ConsoleAppilaction\OnlineMedicalStore";

        string[] users= File.ReadAllLines(path + "/OnlineMedicalStore/UserDetails.csv");
        // Read all lines in UserDetails.csv file 
        foreach( string user in users)
        {
            // add users to UserDetails List
            UserDetails user1=new UserDetails( user);
            Operation.userList.Add(user1);
        }
        string[] medicines=File.ReadAllLines(path+"/OnlineMedicalStore/MedicineDetails.csv");
         // Read all lines in MedicalDetails.csv file 
        foreach(string medicine in medicines)
        {
            // add medicines to MedicineDetails List
            MedicineDetails medicine1=new MedicineDetails(medicine);
            Operation.medicineList.Add(medicine1);
        }
        string[] orders=File.ReadAllLines(path+"/OnlineMedicalStore/OrderDetails.csv");
         // Read all lines in OrderDetails.csv file 
        foreach(string order in orders)
        {
            // add orders to OrderDetails List
            OrderDetails order1=new OrderDetails(order);
            Operation.orderList.Add(order1);
        }

    }
    }
}
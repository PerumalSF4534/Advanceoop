using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGroceryShop
{
    public class FileHandling
    {
        public static void Create()
        {
            string path=@"C:\Users\PerumalKrishnan\OneDrive - Syncfusion\PracticeAssignmentCode\ConsoleAppilaction\OnlineGroceryShop";
           
            if(!Directory.Exists(path+"/OnlineGroceryShop"))
            {
                 // Create a Folder
                Directory.CreateDirectory(path+"/OnlineGroceryShop");
            }
           // to check the file is alreay available
            if(!File.Exists(path+"/OnlineGroceryShop/CustomerDetails.csv"))
            {
                //create a csv file for customer details
                File.Create(path+"/OnlineGroceryShop/CustomerDetails.csv").Close();
            }
             // to check the file is alreay available
            if(!File.Exists(path+"/OnlineGroceryShop/BookingDetails.csv"))
            {
                //create a csv file for booking details
                File.Create(path+"/OnlineGroceryShop/BookingDetails.csv").Close();
            }
             // to check the file is alreay available
            if(!File.Exists(path+"/OnlineGroceryShop/OrderDetails.csv"))
            {
                //create a csv file for order details
                File.Create(path+"/OnlineGroceryShop/OrderDetails.csv").Close();
            }
            // to check the file is alreay available
            if(!File.Exists(path+"/OnlineGroceryShop/ProductDetails.csv"))
            {
                //create a csv file for product details
                File.Create(path+"/OnlineGroceryShop/ProductDetails.csv").Close();
            }
        }
        public static void WriteToCSV()
        {
            string path=@"C:\Users\PerumalKrishnan\OneDrive - Syncfusion\PracticeAssignmentCode\ConsoleAppilaction\OnlineGroceryShop";
            //add customer details to Customer.csv file
            string[] customer=new string[Operation.customerList.Count];
            for(int i=0;i<Operation.customerList.Count;i++)
            {
                customer[i]=Operation.customerList[i].CustomerID+","+Operation.customerList[i].WalletBalance+","+Operation.customerList[i].Name+","+Operation.customerList[i].FatherName+","+Operation.customerList[i].Gender+","+Operation.customerList[i].Mobile+","+Operation.customerList[i].DOB.ToString("dd/MM/yyyy")+","+Operation.customerList[i].MailID;
               
               
            }
            File.WriteAllLines(path+"/OnlineGroceryShop/CustomerDetails.csv",customer);

            // add Order details to Oreder.csv file
            string[] order=new string[Operation.orderList.Count];
            for(int i=0;i<Operation.orderList.Count;i++)
            {
                order[i]=Operation.orderList[i].OrderID+","+Operation.orderList[i].BookingID+","+Operation.orderList[i].ProductID+","+Operation.orderList[i].PurchaseCount+","+Operation.orderList[i].PriceOfOrder;

            }
            File.WriteAllLines(path+"/OnlineGroceryShop/OrderDetails.csv",order);

            //add product details to ProductDetails.csv file
            string[] product=new string[Operation.productList.Count];
            for( int i=0;i<Operation.productList.Count;i++)
            {
                product[i]=Operation.productList[i].ProductID+","+Operation.productList[i].ProdctName+","+Operation.productList[i].QuantityAvailable+","+Operation.productList[i].PricePerQuantity;

            }
            File.WriteAllLines(path+"/OnlineGroceryShop/ProductDetails.csv",product);

            //add booking details to BookingDetails.csv file
            string[] booking=new string[Operation.bookingList.Count];
            for( int i=0;i<Operation.bookingList.Count;i++)
            {
                booking[i]=Operation.bookingList[i].BookingID+","+Operation.bookingList[i].CustomerID+","+Operation.bookingList[i].TotalPrice+","+Operation.bookingList[i].DateOfBooking.ToString("dd/MM/yyyy")+","+Operation.bookingList[i].BookingStatus;

            }
            File.WriteAllLines(path+"/OnlineGroceryShop/BookingDetails.csv",booking);
        }
        public static void  ReadFromCSV()
        {
             string path=@"C:\Users\PerumalKrishnan\OneDrive - Syncfusion\PracticeAssignmentCode\ConsoleAppilaction\OnlineGroceryShop";
             // read all lines in CustomerDetails.csv file
             string[] customers=File.ReadAllLines(path+"/OnlineGroceryShop/CustomerDetails.csv");
             foreach(string customer in customers)
             {
                //add customers from csv file  to customerList
                CustomerDetails customer1=new CustomerDetails(customer);
                Operation.customerList.Add(customer1);
             }
             //read all lines in OrderDetails.csv file
             string[] orders=File.ReadAllLines(path+"/OnlineGroceryShop/OrderDetails.csv");
             foreach(string order in orders)
             {
                //add orders details from csv file to orderList
                OrderDetails order1=new OrderDetails(order);
                Operation.orderList.Add(order1);
             }

             //read all lines in BookingDetails.csv file
             string[] bookings=File.ReadAllLines(path+"/OnlineGroceryShop/BookingDetails.csv");
             foreach(string booking in bookings)
             {
                //add booking details from csv file to bookingList
                BookingDetails booking1=new BookingDetails(booking);
                Operation.bookingList.Add(booking1);
             }

             //read all lines in ProductDetails.csv file
             string[] products=File.ReadAllLines(path+"/OnlineGroceryShop/ProductDetails.csv");
             foreach(string product in products)
             {
                //add productDetails from csv file to productList
                ProductDetails product1=new ProductDetails(product);
                Operation.productList.Add(product1);
             }

        }
    }
}
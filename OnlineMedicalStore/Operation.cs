using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMedicalStore
{
    public class Operation
    {

        public static CustomList<UserDetails> userList = new CustomList<UserDetails>();
        public static CustomList<OrderDetails> orderList = new CustomList<OrderDetails>();
        public static CustomList<MedicineDetails> medicineList = new CustomList<MedicineDetails>();
        public static UserDetails currentUser;
        //Adding Default Value.
        public static void DefaultValue()
        {
            //Adding default value of uesr
            UserDetails user1 = new UserDetails("Ravi", 33, "Theni", 987777744440, 400);
            UserDetails user2 = new UserDetails("Baskaran", 33, "Chennai", 8847757470, 500);
            userList.Add(user1);
            userList.Add(user2);

            //Adding Default Medicine Details.
            MedicineDetails medicine1 = new MedicineDetails("Paracitamol", 40, 5, DateTime.ParseExact("30/12/2024", "dd/MM/yyyy", null));
            MedicineDetails medicine2 = new MedicineDetails("Calpol", 10, 5, DateTime.ParseExact("30/11/2024", "dd/MM/yyyy", null));
            MedicineDetails medicine3 = new MedicineDetails("Gelucil", 3, 40, DateTime.ParseExact("30/04/2024", "dd/MM/yyyy", null));
            MedicineDetails medicine4 = new MedicineDetails("Metrogel", 5, 50, DateTime.ParseExact("30/12/2024", "dd/MM/yyyy", null));
            MedicineDetails medicine5 = new MedicineDetails("Povidin Iodin", 10, 50, DateTime.ParseExact("30/10/2024", "dd/MM/yyyy", null));
            medicineList.Add(medicine2);
            medicineList.Add(medicine3);
            medicineList.Add(medicine4);
            medicineList.Add(medicine5);


            //Adding default Order details
            OrderDetails order1 = new OrderDetails("UID1001", "MD2001", 3, 15, DateTime.ParseExact("13/11/2023", "dd/MM/yyyy", null), OrderStatus.Purchased);
            orderList.Add(order1);
            OrderDetails order2 = new OrderDetails("UID1001", "MD2002", 2, 10, DateTime.ParseExact("13/11/2023", "dd/MM/yyyy", null), OrderStatus.Cancelled);
            orderList.Add(order2);
            OrderDetails order3 = new OrderDetails("UID1001", "MD2004", 2, 100, DateTime.ParseExact("13/11/2023", "dd/MM/yyyy", null), OrderStatus.Purchased);
            orderList.Add(order3);
            OrderDetails order4 = new OrderDetails("UID1002", "MD2003", 3, 120, DateTime.ParseExact("15/01/2023", "dd/MM/yyyy", null), OrderStatus.Cancelled);
            orderList.Add(order4);
            OrderDetails order5 = new OrderDetails("UID1002", "MD2005", 5, 250, DateTime.ParseExact("15/01/2023", "dd/MM/yyyy", null), OrderStatus.Purchased);
            orderList.Add(order5);
            OrderDetails order6 = new OrderDetails("UID1002", "MD2002", 3, 15, DateTime.ParseExact("15/01/2023", "dd/MM/yyyy", null), OrderStatus.Purchased);
            orderList.Add(order6);


        }


        public static void MainMenu()
        {

            string choice = "yes";
            do
            {
                //Display MainMenu Details.
                Console.WriteLine("--- MAIN MENU---");
                Console.WriteLine("1.User Registration \n2.User Login \n3.Exit\n");
                Console.Write("Enter Your Choice : ");
                int option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        {
                            //if user choose register -call Registration() Method.
                            Console.WriteLine("You have entered User registration :\n");
                            Registration();
                            break;
                        }
                    case 2:
                        {
                            //if user choose login - call login() method
                            Console.WriteLine("You Choose User Login : \n");
                            Login();
                            break;
                        }
                    case 3:
                        {
                            //User choose exit the main menu
                            Console.WriteLine("You have Exited Main Menu");
                            choice = "no";

                            break;
                        }

                }
            } while (choice == "yes");


        }
        public static void Registration()
        {
            //Get details from user.
            Console.Write("Enter Name : ");
            string name = Console.ReadLine();
            Console.Write("Enter Age : ");
            int age = int.Parse(Console.ReadLine());
            Console.Write("Enter City : ");
            string city = Console.ReadLine();
            Console.Write("Enter Mobile Number : ");
            long mobile = long.Parse(Console.ReadLine());
            Console.Write("Enter Balance : ");
            double balance = double.Parse(Console.ReadLine());

            //Add uesr details to UserList
            UserDetails user = new UserDetails(name, age, city, mobile, balance);
            userList.Add(user);

            Console.WriteLine($"User registered successfully. User ID = {user.UserID}");


        }
        public static void Login()
        {
            // Get User Id for Login
            Console.Write("Enter User ID : ");
            string userId = Console.ReadLine().ToUpper();
            bool isValid = false;
            //traverse the user details list
            foreach (UserDetails user in userList)
            {
                //validate the user id correct or not
                if (userId.Equals(user.UserID))
                {
                    //if valid- print login sucessful
                    isValid = true;
                    currentUser = user;
                    Console.WriteLine("User Logged Successfully --:)");

                    //Call submenu.
                    SubMenu();
                    break;

                }
            }
            if (!isValid)
            {
                Console.WriteLine("Invalid User ID.");
            }

        }
        public static void SubMenu()
        {
            string choice = "true";
            do
            {
                //display the sub menu
                Console.WriteLine("---- SUB MENU ----");
                Console.WriteLine("1. Show medicine list \n2. Purchase medicine \n3. Cancel purchase \n4. Show purchase history \n5. Recharge \n6. Show Wallet Balance \n7. Exit");
                //get the choice from the user 
                Console.Write("Enter your choice : ");
                int input = int.Parse(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        {
                            Console.WriteLine("User have selected Show medicine list");
                            //if user choose Showmedicine List, call ShowMedicineList() method
                            ShowMedicineList();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("User have selected Purchase medicine");
                            //if user choose  PurchaseMedicine(), call PurchaseMedicine() method
                            PurchaseMedicine();
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("User have selected Cancel purchase");
                            //if user choose CancelPurchase(), call CancelPurchase() method
                            CancelPurchase();
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("User have selected Show purchase history");
                            //if user choose  ShowPurchaseHistory(), call  ShowPurchaseHistory()
                            ShowPurchaseHistory();
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine("User have selected Recharge");
                            //If user choose Recharge, call Recharge()
                            Recharge();
                            break;
                        }
                    case 6:
                        {
                            Console.WriteLine("User have selected Show Wallet Balance");
                            ShowWalletBalance();
                            break;
                        }
                    case 7:
                        {
                            //if user choose exit - exit from the SubMenu
                            Console.WriteLine("User have exited the sub menu");
                            choice = "false";
                            break;

                        }
                }

            } while (choice == "true");
        }
        public static void ShowMedicineList()

        {
            //traverse the medicineList.
            foreach (MedicineDetails medicine in medicineList)
            {
                //Display all medicine details.
                Console.WriteLine($"Medicine ID : {medicine.MedicineID} \nMedicine Name : {medicine.MedicineName} \nAvailable Count : {medicine.AvailableCount} \nPrice : {medicine.Price} \nDate of expiry : {medicine.DateOfExpiry.ToString("dd/MM/yyyy")}\n");

            }
        }

        public static void PurchaseMedicine()
        {
            //Display all medicine details.
            ShowMedicineList();
            //To ask medicine id for purchasing
            Console.Write("Enter medicine Id : ");
            string mid = Console.ReadLine().ToUpper();
            bool isMedicinePresent = false;

            //ask the medicine id from the user
            foreach (MedicineDetails medicine in medicineList)
            {
                //If equal available mid and input mid
                if (mid.Equals(medicine.MedicineID))
                {
                    isMedicinePresent = true;
                    //ask the count of medicine 
                    Console.Write("Enter number of medicine you want : ");
                    int count = int.Parse(Console.ReadLine());
                    if (count <= medicine.AvailableCount)
                    {
                        if (medicine.DateOfExpiry > DateTime.Now.Date)
                        {
                            double price = count * medicine.Price;
                            if (currentUser.WalletBalance > price)
                            {
                                //if user has sufficient balance - reduce the count of the medicine
                                medicine.AvailableCount -= count;
                                //deduct the total amount from the user
                                currentUser.DeductBalance(price);
                                //show the balance
                                Console.WriteLine($"Balance after purchase : {currentUser.WalletBalance}");
                                //if all conditions are true - create order object 
                                OrderDetails orders = new OrderDetails(currentUser.UserID, medicine.MedicineID, count, price, DateTime.Now, OrderStatus.Purchased);
                                //add to list   
                                orderList.Add(orders);
                                // print Medicine was purchased successfully
                                System.Console.WriteLine("Medicine was purchased successfully");
                            }
                            else
                            {
                                Console.WriteLine("Not Have Enough Balance.");
                            }

                        }
                        else
                        {
                            Console.WriteLine("Sorry, Medicine was Expired (:");
                        }
                    }


                }
            }
            if (!isMedicinePresent)
            {
                Console.WriteLine("Invalid Medicine ID.");
            }
        }
        public static void ShowPurchaseHistory()
        {
            bool isOrdered = false;
            foreach (OrderDetails order in orderList)
            {
                if (currentUser.UserID.Equals(order.UserID))
                {
                    isOrdered = true;
                    Console.WriteLine($"Order ID : {order.OrderID} \nUser ID : {order.UserID} \nMedicine ID : {order.MedicineID} \n Medicine Count : {order.MedicineCount} \nTotal Price : {order.TotalPrice} \nOrder Date : {order.OrderDate.ToString("dd/MM/yyyy")} \nOrder status : {order.OrderStatus}");
                }


            }
            if (!isOrdered)
            {
                Console.WriteLine("No Order founded.");

            }
        }
        public static void CancelPurchase()
        {
            bool isOrdered = false;
            bool isUserPresent = false;
            //traverse the orderList
            foreach (OrderDetails order in orderList)
            {
                //To check  current user in the order list
                if (currentUser.UserID.Equals(order.UserID))
                {
                    isUserPresent = true;
                    //To check current user order status is purchased or not.
                    if (order.OrderStatus == OrderStatus.Purchased)
                    {
                        isOrdered = true;
                        //Dispaly current user orderdetails.
                        Console.WriteLine($"Order ID : {order.OrderID} \nUser ID : {order.UserID} \nMedicine ID : {order.MedicineID} \n Medicine Count : {order.MedicineCount} \nTotal Price : {order.TotalPrice} \nOrder Date : {order.OrderDate.ToString("dd/MM/yyyy")} \nOrder status : {order.OrderStatus}\n");

                    }

                }
            }
            if (!isUserPresent)
            {
                //display current user not in order list.
                Console.WriteLine("User haven't purchased any medicine .");
            }
            if (!isOrdered && isUserPresent)
            {
                //if current user not in purchased status.
                Console.WriteLine("Already cancelled Your Order .");
            }

            if (isOrdered && isUserPresent)
            {
                //Get order id
                Console.Write("Enter Order ID : ");
                string orderId = Console.ReadLine().ToUpper();
                bool flag = false;
                //traverse orderList
                foreach (OrderDetails order in orderList)
                {
                    //validate order id in the list and check for order status is purchased
                    if (currentUser.UserID.Equals(order.UserID) && order.OrderStatus == OrderStatus.Purchased && order.OrderID.Equals(orderId))
                    {
                        flag = true;
                        //if id matches-increase the count of the medicine in medicine list 
                        foreach (MedicineDetails medicine in medicineList)
                        {
                            if (medicine.MedicineID.Equals(order.MedicineID))
                            {

                                medicine.AvailableCount += order.MedicineCount;

                                //change order status to cancelled
                                order.OrderStatus = OrderStatus.Cancelled;
                                // show order id is cancelled  sucessfully                                  
                                Console.WriteLine($"Order ID {order.OrderID} was cancelled successfully");

                            }

                        }
                        //return the amount to the user
                        double price = order.TotalPrice;
                        currentUser.WalletRecharge(price);
                        System.Console.WriteLine($"Wallet Balance : {currentUser.WalletBalance}");


                    }
                }


                if (!flag)
                {
                    {
                        System.Console.WriteLine("Invalid Order ID");
                    }
                }

            }
        }

        public static void Recharge()
        {
            //get the amount to recharge
            Console.Write("Enter the amount for Recharge : ");
            double rechargeAmount = double.Parse(Console.ReadLine());
            if (rechargeAmount > 0)
            {
                //call walletRecharge() and display wallet balance
                currentUser.WalletRecharge(rechargeAmount);
                Console.WriteLine($"User Wallet Balance : {currentUser.WalletBalance}");
            }
            else
            {
                Console.WriteLine("Invalid Amount. ");
            }

        }

        public static void ShowWalletBalance()
        {
            //display user wallet balance.
            Console.WriteLine($"User Balance : {currentUser.WalletBalance}");
        }

    }
}






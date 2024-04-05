using System;
using System.Runtime.CompilerServices;
namespace OnlineGroceryShop
{

    public class Operation
    {
        public static CustomList<CustomerDetails> customerList = new CustomList<CustomerDetails>();
        public static CustomList<BookingDetails> bookingList = new CustomList<BookingDetails>();
        public static CustomList<ProductDetails> productList = new CustomList<ProductDetails>();
        public static CustomList<OrderDetails> orderList = new CustomList<OrderDetails>();
        public static CustomerDetails currentCustomer;
        static CustomList<OrderDetails> tempOrderList = new CustomList<OrderDetails>();

        //Adding Default Value.
        public static void DefaultValue()
        {
            //Adding default customer details to customerList
            PersonalDetails person = new PersonalDetails("Ravi", "Ettapparajan", Gender.Male, 974774646, DateTime.ParseExact("11/11/1999", "dd/MM/yyyy", null), "ravi@gmail.com");
            CustomerDetails customer = new CustomerDetails(10000, person.Name, person.FatherName, person.Gender, person.Mobile, person.DOB, person.MailID);
            customerList.Add(customer);

            person = new PersonalDetails("Baskaran", "Sethurajan", Gender.Male, 847575775, DateTime.ParseExact("11/11/1999", "dd/MM/yyyy", null), "baskaran@gmail");
            customer = new CustomerDetails(15000, person.Name, person.FatherName, person.Gender, person.Mobile, person.DOB, person.MailID);
            customerList.Add(customer);


            //adding default product details to productList
            ProductDetails product = new("Sugar", 20, 40);
            productList.Add(product);
            product = new("Rice", 100, 50);
            productList.Add(product);
            product = new("Milk", 10, 40);
            productList.Add(product);
            product = new("Coffee", 10, 40);
            productList.Add(product);
            product = new("Tea", 10, 10);
            productList.Add(product);
            product = new("Masala Power", 10, 20);
            productList.Add(product);
            product = new("Salt", 10, 10);
            productList.Add(product);
            product = new("Turmeric Power", 10, 25);
            productList.Add(product);
            product = new("Chilli Power", 10, 20);
            productList.Add(product);
            product = new("Groundnut Oil", 10, 140);
            productList.Add(product);

            //adding default booking details to bookingList
            BookingDetails booking = new("CID1001", 220, DateTime.ParseExact("26/07/2022", "dd/MM/yyyy", null), BookingStatus.Booked);
            bookingList.Add(booking);
            booking = new("CID1002", 400, DateTime.ParseExact("26/07/2022", "dd/MM/yyyy", null), BookingStatus.Booked);
            bookingList.Add(booking);
            booking = new("CID1001", 280, DateTime.ParseExact("26/07/2022", "dd/MM/yyyy", null), BookingStatus.Cancelled);
            bookingList.Add(booking);
            booking = new("CID1002", 0, DateTime.ParseExact("26/07/2022", "dd/MM/yyyy", null), BookingStatus.Initiated);
            bookingList.Add(booking);

            // adding default order details to orderList
            OrderDetails order = new("BID3001", "PID2001", 2, 80);
            orderList.Add(order);
            order = new("BID3001", "PID2002", 2, 100);
            orderList.Add(order);
            order = new("BID3001", "PID2003", 1, 40);
            orderList.Add(order);
            order = new("BID3002", "PID2001", 1, 40);
            orderList.Add(order);
            order = new("BID3002", "PID2002", 4, 200);
            orderList.Add(order);
            order = new("BID3002", "PID2010", 1, 140);
            orderList.Add(order);
            order = new("BID3002", "PID2009", 1, 20);
            orderList.Add(order);
            order = new("BID3003", "PID2002", 2, 100);
            orderList.Add(order);
            order = new("BID3003", "PID2008", 4, 100);
            orderList.Add(order);
            order = new("BID3003", "PID2001", 2, 80);
            orderList.Add(order);


        }
        public static void MainMenu()
        {
            string choice = "yes";
            do
            {
                //Display MainMenu Details.
                Console.WriteLine("----Online Grocery Shop----");
                Console.WriteLine("--- MAIN MENU---");
                Console.WriteLine("1.Customer Registration \n2.Customer Login \n3.Exit\n");
                Console.Write("Enter your Option : ");
                int option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        {
                            Registration();
                            break;
                        }
                    case 2:
                        {
                            LogIn();
                            break;
                        }
                    case 3:
                        {
                            choice = "no";
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Please enter valid option");
                            break;
                        }
                }

            } while (choice == "yes");

        }
        public static void Registration()
        {
            //Get details from customer
            Console.Write("Wallet Balance : ");
            double walletBalance = double.Parse(Console.ReadLine());
            Console.Write("Enter Name : ");
            string name = Console.ReadLine();
            Console.Write("Enter Father Name : ");
            string fatherName = Console.ReadLine();
            Console.Write("Gender : ");
            Gender gender = Enum.Parse<Gender>(Console.ReadLine(), true);
            Console.Write("Enter Mobile Number : ");
            long mobile = long.Parse(Console.ReadLine());
            Console.Write("Enter DOB : ");
            DateTime dob = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
            Console.Write("Enter MailID : ");
            string mailID = Console.ReadLine().ToLower();

            //add customer details to customerList
            PersonalDetails person = new PersonalDetails(name, fatherName, gender, mobile, dob, mailID);
            CustomerDetails customer = new CustomerDetails(walletBalance, person.Name, person.FatherName, person.Gender, person.Mobile, person.DOB, person.MailID);
            customerList.Add(customer);
            //display CustomerID to customer
            Console.WriteLine($"Your registration is successful \nYour CustomerID : {customer.CustomerID}\n");
        }
        public static void LogIn()
        {
            //get customerID for login
            Console.Write("Enter CustomerID : ");
            string customerID = Console.ReadLine().ToUpper();
            //traverse the customerList
            bool isValidCustomerID = false;
            //check the customerID is available in customerList
            int position = CustomBinarySearch.BinarySearch(customerList, customerID);
            //if valid  customerID 
            if (position > -1)
            {  // if valid - print login successful
                isValidCustomerID = true;
                currentCustomer = customerList[position];
                Console.WriteLine("You have successfully logged in :-)\n");
                SubMenu();
            }

            if (!isValidCustomerID)
            {
                Console.WriteLine("Invalid CustomerID ");
            }


        }
        public static void SubMenu()
        {
            string choice = "yes";
            do
            {
                //display the sub menu
                Console.WriteLine("---- SUB MENU ----");
                Console.WriteLine("1.Show Customer Details\n2.Show Product Details\n3.Wallet Recharge\n4.Take Order\n5.Modify Order Quantity\n6.Cancel Order\n7.Order History\n8.Show Balance\n9.Exit");
                //Get option from customer for next operation
                Console.Write("Enter your option : ");
                int option = int.Parse(Console.ReadLine());
                Console.WriteLine();
                switch (option)
                {
                    case 1:
                        {
                            //if cutomer choose ShowCustomerDetails,call ShowCustomerDetails
                            ShowCustomerDetails();
                            break;
                        }
                    case 2:
                        {
                            //if cutomer choose ShowProductDetails,call ShowProductDetails method()
                            ShowProductDetails();
                            break;
                        }
                    case 3:
                        {
                            //if cutomer choose WalletRecharge, call WalletRecharge method
                            WalletRecharge();
                            break;
                        }
                    case 4:
                        {
                            //if cutomer choose TakeOrder
                            TakeOrder();
                            break;
                        }
                    case 5:
                        {
                            //if cutomer choose  ModifyOrderQuantity, ModifyOrderQuantity()
                            ModifyOrderQuantity();
                            break;
                        }
                    case 6:
                        {
                            //if cutomer choose CancelOrder,call CancelOrder()
                            CancelOrder();
                            break;
                        }
                    case 7:
                        {
                            //if cutomer choose OrderHistory,call OrderHistory()
                            OrderHistory();
                            break;
                        }
                    case 8:
                        {
                            //if cutomer choose ShowBalance,call ShowBalance()
                            ShowBalance();
                            break;
                        }
                    case 9:
                        {
                            //if cutomer choose
                            choice = "no";
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Please enter valid option");
                            break;
                        }
                }

            } while (choice == "yes");

        }
        public static void ShowCustomerDetails()
        {
            // To display current Customer details
            Console.WriteLine($"CustomerID: {currentCustomer.CustomerID}\nWalletBalance : {currentCustomer.WalletBalance}\nName : {currentCustomer.Name}	\nFatherName : {currentCustomer.FatherName}\nGender	: {currentCustomer.Gender}\nMobile : {currentCustomer.Mobile}	\nDOB : {currentCustomer.DOB.ToString("dd/MM/yyyy")}	\nMailID : {currentCustomer.MailID}\n");
        }
        public static void ShowProductDetails()
        {
            //traverse productList
            foreach (ProductDetails product in productList)
            {
                //Diplay each product details
                Console.WriteLine($"ProductID : {product.ProductID}\nProductName : {product.ProdctName} \nQuantityAvailable :{product.QuantityAvailable}  \nPricePerQuantity : {product.PricePerQuantity}\n");
            }

        }
        public static void WalletRecharge()
        {
            Console.WriteLine("Do you want to recharge your wallet?");
            string option = Console.ReadLine().ToLower();
            if (option == "yes")
            {
                
                Console.Write("Enter the amount for Recharge : ");
                double rechargeAmount = double.Parse(Console.ReadLine());
                //if valid rechargeAmount
                if (rechargeAmount > 0)
                {
                    //call walletRecharge() and display wallet balance
                    currentCustomer.WalletRecharge(rechargeAmount);
                    Console.WriteLine($"User Wallet Balance : {currentCustomer.WalletBalance}");
                }
                // not valid rechargeAmount
                else
                {
                    Console.WriteLine("Invalid Amount.");
                }

            }

        }
        public static void TakeOrder()
        {
            Console.Write("Do you want to purchase or not?  ");
            string userWish = Console.ReadLine().ToLower();
            BookingDetails currentCustomerBooking = new(currentCustomer.CustomerID, 0, DateTime.Now, BookingStatus.Initiated);
            //Show product details of available stock. 
            ShowProductDetails();
            bool isCustomerAddCart = false;
            do
            {
                //ask productID from customer to select a product by using ProductID 
                Console.Write("Enter productID what product you want : ");
                string productID = Console.ReadLine().ToUpper();
                bool isValidProductID = false;

                foreach (ProductDetails product in productList)
                {
                    //if valid productID
                    if (productID.Equals(product.ProductID))
                    {
                        isValidProductID = true;
                        //ask Purchase quantity to customer
                        Console.Write(" Enter Purchase quantity : ");
                        double quantity = double.Parse(Console.ReadLine());
                        //check availableQuantity is greater than customer want quantity
                        if (product.QuantityAvailable > 0 && product.QuantityAvailable >= quantity)
                        {
                            isCustomerAddCart = true;
                            OrderDetails tempOrder = new OrderDetails(currentCustomerBooking.BookingID, productID, quantity, quantity * product.PricePerQuantity);
                            tempOrderList.Add(tempOrder);
                            Console.WriteLine("Product successfully added to cart");
                        }
                        else
                        {
                            Console.WriteLine("quantity not available");
                        }

                    }

                }
                if (!isValidProductID)
                {
                    Console.WriteLine("Invalid ProductID.");
                }
                Console.Write("Do you want to book another prodeuct : ");
                userWish = Console.ReadLine().ToLower();
            } while (userWish == "yes");
            double totalPrice = 0;
            //if customer already add products in cart
            if (isCustomerAddCart)
            {
                Console.Write("Do you want to confirm the order?  ");
                userWish = Console.ReadLine().ToLower();
                if (userWish == "yes")
                {
                    foreach (OrderDetails tempOrder in tempOrderList)
                    {
                        totalPrice += tempOrder.PriceOfOrder;
                    }
                    bool isInsuffienctBlance = false;
                    // Repeat  until he had enough balance.
                    do
                    {
                        if (currentCustomer.WalletBalance < totalPrice)
                        {
                            Console.WriteLine("Insufficient account balance. recharge " + totalPrice);
                            WalletRecharge();
                        }

                        else
                        {
                            // customer have enough balance
                            isInsuffienctBlance = true;
                        }
                    } while (!isInsuffienctBlance);

                    if (currentCustomer.WalletBalance >= totalPrice)
                    {
                        isInsuffienctBlance = true;
                        //to reduce wallet balance
                        currentCustomer.DeductBalance(totalPrice);
                        //to change booking details
                        currentCustomerBooking.TotalPrice = totalPrice;
                        currentCustomerBooking.BookingStatus = BookingStatus.Booked;
                        currentCustomerBooking.DateOfBooking = DateTime.Now;
                        //to add
                        bookingList.Add(currentCustomerBooking);
                        Console.WriteLine("Booking successful");
                        //traverse tempOrderList and add tempOrder to orderList
                        foreach (OrderDetails tempOrder in tempOrderList)
                        {
                            orderList.Add(tempOrder);
                        }


                    }

                }

            }
        }

        public static void ModifyOrderQuantity()
        {
            //traverse the bookingList
            foreach (BookingDetails booking in bookingList)
            {

                //	Show the list of Bookings placed by current logged in user whose status is “Booked”.
                if (currentCustomer.CustomerID == booking.CustomerID && booking.BookingStatus == BookingStatus.Booked)
                {
                    Console.WriteLine("hii");
                    Console.WriteLine($"BookingID : {booking.BookingID}  CUstomerID : {booking.CustomerID}   TotalPrice : {booking.TotalPrice}   DateOfBooking : {booking.DateOfBooking.ToString("dd/MM/yyyy")}   BookingStatus : {booking.BookingStatus}");
                }
            }
            //Show list of order details 
            OrderHistory();
            Console.Write("Enter orderID which booking you want to add  quantity : ");
            string orderID = Console.ReadLine().ToUpper();
             
             string productID=Console.ReadLine().ToUpper();
            bool isvalidOrderID = false;
            foreach (OrderDetails order in orderList)
            {

                foreach (BookingDetails booking in bookingList)
                {
                    if (currentCustomer.CustomerID == booking.CustomerID && order.OrderID == orderID && BookingStatus.Booked == booking.BookingStatus)
                    {
                        isvalidOrderID = true;
                        Console.Write("Enter the new quantity of the product : ");
                        int newQuantity = int.Parse(Console.ReadLine());
                       
                        foreach (ProductDetails product in productList)
                        {
                            if(booking.BookingStatus==BookingStatus.Booked)
                            // Calculate the total price of order and update in booking details entry.
                            order.PurchaseCount += newQuantity;
                            order.PriceOfOrder += newQuantity * product.PricePerQuantity;
                            booking.TotalPrice += newQuantity * product.PricePerQuantity;


                        }
                    }
                }



            }

            if (!isvalidOrderID)
            {
                Console.WriteLine("Invalid OrderID");
            }
        }
        public static void CancelOrder()
        {
            bool isCustomerBooked = false;
            // traverse bookingList for check the customer have any booking
            foreach (BookingDetails booking in bookingList)
            {
                //if customer have booking and that status is equal to "booked"
                if (booking.CustomerID.Equals(currentCustomer.CustomerID) && booking.BookingStatus == BookingStatus.Booked)
                {

                    isCustomerBooked = true;
                    //display customer booking details
                    Console.WriteLine($"BookingID : {booking.BookingID} CUstomerID : {booking.CustomerID}  TotalPrice : {booking.TotalPrice}   DateOfBooking : {booking.DateOfBooking.ToString("dd/MM/yyyy")} Booking Status : {booking.BookingStatus} \n");
                }
            }
            //if customer  have booking
            if (isCustomerBooked)
            {
                //ask bookingID from  customer 
                Console.Write("Enter BookID which one you cancel : ");
                String bookingID = Console.ReadLine().ToUpper();
                bool isvalidBookingID = false;
                //check given BookingID and bookingList BookingID are same and return  posiotion of  which booking are have currentCustomer
                int position = CustomBinarySearch.BinarySearch(bookingList, bookingID);

                //if given bookingID is valid
                if (position > -1)
                {
                    isvalidBookingID = true;
                    //To change currentCustomer bookingStatus using position
                    bookingList[position].BookingStatus = BookingStatus.Cancelled;

                    foreach (OrderDetails order in orderList)

                    {
                        foreach (ProductDetails product in productList)
                        {
                            if (order.BookingID == bookingID && order.ProductID == product.ProductID)
                            {
                                product.QuantityAvailable += order.PurchaseCount;
                            }
                        }
                    }
                    currentCustomer.WalletRecharge(bookingList[position].TotalPrice);

                    Console.WriteLine("Your booking order is cancelled");
                }

                //if not valid bookingID
                if (!isvalidBookingID)
                {
                    Console.WriteLine("Invalid BookingID.");
                }
            }
            else
            {
                Console.WriteLine("You haven't booked any product yet.");
            }
        }
        public static void OrderHistory()
        {
            bool isOrdered = false;
            //traverse bookingList for check the currentCustomer is booked or not
            foreach (BookingDetails booking in bookingList)
            {
                if (currentCustomer.CustomerID.Equals(booking.CustomerID))
                {
                    // traverse orderList for check the  bookingID
                    foreach (OrderDetails order in orderList)
                    {
                        // if valid then display current Customer order details
                        if (booking.BookingID.Equals(order.BookingID))
                        {
                            isOrdered = true;
                            // display currentCustomer orderDetails
                            Console.WriteLine($"OrderID : {order.OrderID}\nBookingID : {order.BookingID}\nProductID : {order.ProductID}\nPurchaseCount : {order.PurchaseCount}\nPricePerOrder : {order.PriceOfOrder}\n");
                        }
                    }
                }
            }
            if (!isOrdered)
            {
                Console.WriteLine("You haven't ordered anything yet\n");
            }
        }
        public static void ShowBalance()
        {
            //display customer wallet balance
            Console.WriteLine($"Your Wallet Balance : {currentCustomer.WalletBalance}\n");

        }

    }
}
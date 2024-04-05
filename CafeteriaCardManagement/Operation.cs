using System;

namespace CafeteriaCardManagement
{
    public class Operation
    {
       public static CustomList<UserDetails> userList = new CustomList<UserDetails>();
       public static CustomList<OrderDetails> orderList = new CustomList<OrderDetails>();
       public static CustomList<CartItem> cartItemLList = new CustomList<CartItem>();
       public static CustomList<FoodDetails> foodList = new CustomList<FoodDetails>();
       public static CustomList<CartItem> tempCartItemList = new CustomList<CartItem>();
       public static UserDetails currentUser ;


        //Adding Default Value.
        public static void DefaultValue()
        {
            // adding default userDetails to userList
            PersonalDetails person = new PersonalDetails("Ravichandran", "Ettapparajan", 88577777575, "ravi@gmail.com", Gender.Male);
            UserDetails user = new UserDetails(person.UserName, person.FatherName, person.MobileNumber, person.MailID, person.Gender, "WS101", 400);
            userList.Add(user);
            person = new PersonalDetails("Baskaran", "Sethurajan", 9577747744, "baskaran@gmail.com", Gender.Male);
            user = new UserDetails(person.UserName, person.FatherName, person.MobileNumber, person.MailID, person.Gender, "WS105", 500);
            userList.Add(user);

            // adding default food details
            FoodDetails food = new FoodDetails("Coffee", 20, 100);
            foodList.Add(food);
            food = new("Tea", 15, 100);
            foodList.Add(food);
            food = new FoodDetails("Biscuit", 10, 100);
            foodList.Add(food);
            food = new FoodDetails("Juice", 50, 100);
            foodList.Add(food);
            food = new FoodDetails("Puff", 40, 100);
            foodList.Add(food);
            food = new FoodDetails("Milk", 10, 100);
            foodList.Add(food);
            food = new FoodDetails("Popcorn", 20, 20);
            foodList.Add(food);
            //adding default order details to orderList
            OrderDetails order = new OrderDetails("SF1001", DateTime.ParseExact("15/06/2022", "dd/MM/yyyy", null), 70, OrderStatus.Ordered);
            orderList.Add(order);
            order = new OrderDetails("SF1002", DateTime.ParseExact("15/06/2022", "dd/MM/yyyy", null), 100, OrderStatus.Ordered);
            orderList.Add(order);

            //adding default Cart Item
            CartItem cartItem = new CartItem("OID1001", "FID101", 20, 1);
            cartItemLList.Add(cartItem);
            cartItem = new CartItem("OID1001", "FID103", 10, 1);
            cartItemLList.Add(cartItem);
            cartItem = new CartItem("OID1001", "FID105", 40, 1);
            cartItemLList.Add(cartItem);
            cartItem = new CartItem("OID1002", "FID103", 10, 1);
            cartItemLList.Add(cartItem);
            cartItem = new CartItem("OID1002", "FID104", 50, 1);
            cartItemLList.Add(cartItem);
            cartItem = new CartItem("OID1002", "FID105", 40, 1);
            cartItemLList.Add(cartItem);

        }

        public static void MainMenu()
        {
            string choice = "yes";
            do
            {
                //Display MainMenu Details.
                Console.WriteLine("----Cafeteria Card Management----");
                Console.WriteLine("--- MAIN MENU---");
                Console.WriteLine("1.User Registration \n2.User Login \n3.Exit");
                Console.Write("Enter your Option : ");
                int option = int.Parse(Console.ReadLine());
                Console.WriteLine();
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
            //Get details from user
            Console.Write("Enter Name : ");
            string userName = Console.ReadLine();
            Console.Write("Enter Father Name : ");
            string fatherName = Console.ReadLine();
            Console.Write("Enter Mobile Number : ");
            long mobileNumber = long.Parse(Console.ReadLine());
            Console.Write("Enter MailID : ");
            string mailID = Console.ReadLine().ToLower();
            Console.Write("Gender : ");
            Gender gender = Enum.Parse<Gender>(Console.ReadLine(), true);
            Console.Write("Enter Work Station Number : ");
            string workStationNumber = Console.ReadLine().ToUpper();
            Console.Write("Enter Wallet Balance : ");
            double walletBalance = double.Parse(Console.ReadLine());
            //add user details to userList
            PersonalDetails person = new PersonalDetails(userName, fatherName, mobileNumber, mailID, gender);
            UserDetails user = new UserDetails(person.UserName, person.FatherName, person.MobileNumber, person.MailID, person.Gender, workStationNumber, walletBalance);
            userList.Add(user);
            // display user regitration id
            Console.WriteLine($"Your registration is successful\nYour User ID : {user.UserID}");


        }
        public static void LogIn()
        {
            Console.Write("Enter Your UserID : ");
            string userID=Console.ReadLine().ToUpper();
            bool isUserIDAvailable = false;
            foreach (UserDetails user in userList)
            {
                
                //check the userID is available in userList
                if (user.UserID==userID)
                { // if valid - print login successful
                    isUserIDAvailable = true;
                    Console.WriteLine("You Have Successfult Logged in :-)");
                    currentUser = user;
                    SubMenu();
                }
            }
            if (!isUserIDAvailable)
            {
                Console.WriteLine("Invalid UserID or Not registred");
            }
        }
        public static void SubMenu()
        {
            string userChoice = "yes";
            do
            {
                //display the sub menu
                Console.WriteLine("---- SUB MENU ----");
                Console.WriteLine("1.Show My Profile\n2.Food Order\n3.ModifyOrder\n4.cancel order\n5.Order History\n6.Wallet Recharge\n7.Show WalletBalance\n8.Exit");
                Console.Write("Enter your Option : ");
                int userOption = int.Parse(Console.ReadLine());
                Console.WriteLine();
                switch (userOption)
                {
                    case 1:
                        {
                            ShowMyProfile();
                            break;
                        }
                    case 2:
                        {
                            FoodOrder();
                            break;
                        }
                    case 3:
                        {
                            ModifyOrder();
                            break;
                        }
                    case 4:
                        {
                            CancelOrder();
                            break;
                        }
                    case 5:
                        {
                            OrderHistory();
                            break;
                        }
                    case 6:
                        {
                            WalletRecharge();
                            break;
                        }
                    case 7:
                        {
                            ShowWalletBalance();
                            break;
                        }
                    case 8:
                        {
                            userChoice = "no";
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Please enter valid option");
                            break;
                        }

                }

            } while (userChoice == "yes");
        }
        public static void ShowMyProfile()
        {
            //Display currentUser Details
            Console.WriteLine($"UserID : {currentUser.UserID}\nUSer Name: {currentUser.UserName}\nFather Name : {currentUser.FatherName}\nMobile Number : {currentUser.MobileNumber}\nGender : {currentUser.Gender}\nWork Staion Number : {currentUser.WorkStationNumber}\nBalance : {currentUser.WalletBalance}");
        }
        public static void FoodOrder()
        {

            Console.Write("Do you want to order the food ?   ");
            string userWish = Console.ReadLine().ToLower();
            Console.WriteLine();
            if (userWish == "yes")
            {
                // create temp order object
                OrderDetails currentUserOrder = new OrderDetails(currentUser.UserID, DateTime.Now, 0, OrderStatus.Initiated);

                do
                {
                    // Show the food items 
                    foreach (FoodDetails food in foodList)
                    {
                        Console.WriteLine($"FoodID : {food.FoodID}  FoodName : {food.FoodName}    Price : {food.FoodPrice}   Food Available Quantity : {food.AvailableQuantity}");
                    }
                    Console.WriteLine();
                    // Ask the user to pick a product using FoodID
                    Console.Write("which one you order? please enter foodID : ");
                    string foodID = Console.ReadLine().ToUpper();
                    Console.Write("Ente Quantity : ");
                    double quantity = double.Parse(Console.ReadLine());
                    bool isValidFoodID = false;
                    bool isQuantityAvaiable = false;
                    foreach (FoodDetails food in foodList)
                    {
                        //check  if valid foodID and quantity avaiable
                        if (foodID == food.FoodID && food.AvailableQuantity >= quantity)
                        {
                            isValidFoodID = true;
                            isQuantityAvaiable = true;
                            // reduce the quantity from the food object’s “AvailableQuantity”
                            food.AvailableQuantity -= quantity;
                            // calculate price of food
                            double tempOrderPrice = quantity * food.FoodPrice;
                            //Add that object it to local CartItemsList
                            CartItem tempCartItem = new CartItem(currentUserOrder.OrderID, food.FoodID, tempOrderPrice, quantity);
                            cartItemLList.Add(tempCartItem);
                        }

                    }
                    if (!isValidFoodID || !isQuantityAvaiable)
                    {
                        Console.WriteLine("Invalid FoodID Or Food Not Available Now");
                    }
                    Console.Write("Do you want to order another food ?  ");
                    userWish = Console.ReadLine().ToLower();


                } while (userWish == "yes");
                // If He says No 


                Console.Write("Do you Confirm the Order ?  ");
                string userOrderComfirm = Console.ReadLine().ToLower();
                if (userOrderComfirm == "yes")
                {
                    do
                    {
                        double totalPrice = 0;
                        foreach (CartItem cartItem in cartItemLList)
                        {
                            if (currentUserOrder.OrderID == cartItem.OrderID)
                            {
                                totalPrice += cartItem.OrderPrice * cartItem.OrderQuantity;
                            }
                        }
                        //if user have enough money
                        if (currentUser.WalletBalance >= totalPrice)
                        {
                            currentUser.DeductBalance(totalPrice);
                            Console.WriteLine($"Order placed successfully, and OrderID is {currentUserOrder.OrderID}");
                            currentUserOrder.TotalPrice = totalPrice;
                            currentUserOrder.OrderStatus = OrderStatus.Ordered;
                            orderList.Add(currentUserOrder);
                            userOrderComfirm = "no";
                        }
                        else
                        {
                            Console.WriteLine("Insuffient balance.");
                            Console.Write("Are you willing to recharge ?  ");
                            userWish = Console.ReadLine().ToLower();
                            if (userWish == "yes")
                            {
                                WalletRecharge();
                            }
                            else
                            {
                                Console.WriteLine("Exiting without Order due to insufficient balance");
                                userOrderComfirm = "no";
                            }
                        }

                    } while (userOrderComfirm == "yes");

                }




            }



        }
        public static void ModifyOrder()
        {
            // Show the Order details of current logged  user 
            OrderHistory();
            Console.Write("Which order you want to modify ? \nEnter OrderID :");
            string orderID = Console.ReadLine().ToUpper();
            //Show list of Cart Item details 
            foreach (OrderDetails order in orderList)
            {
                foreach (CartItem cartItem in cartItemLList)
                {
                    if ( order.OrderStatus == OrderStatus.Ordered && cartItem.OrderID == order.OrderID && order.OrderID==orderID)
                    {   
                        Console.WriteLine($"ItemID : {cartItem.ItemID}   OrderID :{order.OrderID}  FoodID :{cartItem.FoodID}  OrderPrice :{cartItem.OrderPrice}  OrderQuantity : {cartItem.OrderQuantity}");
    
                    }
                }
            }

        }
        public static void CancelOrder()
        {
            //Show the Order details of the current user who’s Order status is “Ordered”
            foreach (OrderDetails order in orderList)
            {
                if (currentUser.UserID == order.UserID && order.OrderStatus == OrderStatus.Ordered)
                {
                    //display the order details of current user
                    Console.WriteLine($"OrderID : {order.OrderID}  UserID : {order.UserID}  OrderDate : {order.OrderDate.ToString("dd/MM/yyyy")}   TotalPrice  : {order.TotalPrice}  Order Status  : {order.OrderStatus}");
                }
            }
            // Ask the user to pick an OrderID to cancel
            Console.Write("Enter OrderID which one you cancel : ");
            string orderID = Console.ReadLine().ToUpper();
            bool isValidOrderID = false;
            foreach (OrderDetails order in orderList)
            {
                // OrderID is valid
                if (orderID == order.OrderID && order.OrderStatus == OrderStatus.Ordered)
                {
                    isValidOrderID = true;
                    Console.Write("Do you want to cancel the order?  ");
                    string userWish = Console.ReadLine().ToLower();
                    if (userWish == "yes")
                    {
                        foreach (FoodDetails food in foodList)
                        {
                            foreach (CartItem cartItem in cartItemLList)
                            {
                                if (cartItem.FoodID == food.FoodID)
                                {
                                    // Return product orderQuantity to FoodItem list’s FoodQuantity
                                    food.AvailableQuantity += cartItem.OrderQuantity;
                                }
                            }
                        }
                        order.OrderStatus = OrderStatus.Cancelled;
                        Console.Write("Your Order cancelled successfully");
                        // Return the Order total amount to current user
                        currentUser.WalletRecharge(order.TotalPrice);
                    }
                }
                
            }
            // OrderID is not valid
            if (!isValidOrderID)
            {
                Console.WriteLine("Invalid OrderID");
            }
        }

        public static void OrderHistory()
        {
            foreach (OrderDetails order in orderList)
            {

                if (currentUser.UserID == order.UserID)
                {
                    //display the order details of current user
                    Console.WriteLine($"OrderID : {order.OrderID}  UserID : {order.UserID}  OrderDate : {order.OrderDate.ToString("dd/MM/yyyy")}   TotalPrice  : {order.TotalPrice}  Order Status  : {order.OrderStatus}");
                }
            }
        }
        public static void WalletRecharge()
        {
            Console.Write("Do you want to recharge your wallet ? - ");
            string userWish = Console.ReadLine().ToLower();
            if (userWish == "yes")
            {
                //get the amount to recharge
                Console.Write("Enter The Amount for recharge : ");
                double rechargeAmount = double.Parse(Console.ReadLine());
                //if valid rechargeAmount
                if (rechargeAmount > 0)
                {
                    //call walletRecharge() and display wallet balance
                    currentUser.WalletRecharge(rechargeAmount);
                    Console.WriteLine($"User Wallet balance : {currentUser.WalletBalance}");

                }
                else
                {
                    Console.WriteLine("Invalid Amount");
                }
            }

        }
        public static void ShowWalletBalance()
        {
            //display user wallet balance
            Console.WriteLine($"Your Wallet Balance : {currentUser.WalletBalance}\n");

        }

    }
}
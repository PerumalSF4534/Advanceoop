using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineDTHRecharge
{
    public class Operation
    {
        public static CustomList<UserDetails> userList = new  CustomList<UserDetails>();
       public static  CustomList<RechargeHistory> rechargeHistoryList = new  CustomList<RechargeHistory>();
       public static  CustomList<PackageDetails> packageList = new  CustomList<PackageDetails>();
        public static UserDetails currentUser;
        public static RechargeHistory userCurrentPack;
        //Adding default values
        public static void DefaultValue()
        {
            //Adding user deatil to userList.
            UserDetails user = new("John", 9746646466, "john@gmail.com", 500);
            userList.Add(user);
            user = new("Merlin", 9782136543, "merlin@gmail.com", 150);
            userList.Add(user);
            //Adding RechargeHistory details to rechargeHistoryList
            RechargeHistory rechargeHistory1 = new("UID1001", "RC150", DateTime.ParseExact("30/11/2021", "dd/MM/yyyy", null), 150, DateTime.ParseExact("27/12/2021", "dd/MM/yyyy", null), 50);
            rechargeHistoryList.Add(rechargeHistory1);
            RechargeHistory rechargeHistory2 = new("UID1002", "RC150", DateTime.ParseExact("01/01/2021", "dd/MM/yyyy", null), 150, DateTime.ParseExact("28/01/2021", "dd/MM/yyyy", null), 50);
            rechargeHistoryList.Add(rechargeHistory2);
            //Adding package details to packageList.
            PackageDetails package1 = new("RC150", "Pack1", 150, 28, 50);
            packageList.Add(package1);
            package1 = new("RC300", "Pack2", 300, 56, 75);
            packageList.Add(package1);
            package1 = new("RC500", "Pack3", 500, 28, 200);
            packageList.Add(package1);
            package1 = new("RC1500", "Pack4", 1500, 365, 200);
            packageList.Add(package1);

        }
        public static void MainMenu()
        {
            string choice = "yes";
            do
            {
                //Display MainMenu Details.
                Console.WriteLine("ONLINE DTH RECHARGE -)\n");
                Console.WriteLine("*** MAINMENU ***");
                Console.WriteLine("1.User Registration \n2.User Login \n3.Exit\n");
                Console.Write("Enter your Choice : ");
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
            //Get deatils from user for registratoion
            Console.Write("Enter Name : ");
            string userName = Console.ReadLine();
            Console.Write("Enter Mobile Number : ");
            long mobileNumber = long.Parse(Console.ReadLine());
            Console.Write("Enter EmailID : ");
            string emailID = Console.ReadLine();
            Console.Write("Enter Wallet Blance : ");
            double walletBalance = double.Parse(Console.ReadLine());

            //Add user registration details to userList
            UserDetails user = new UserDetails(userName, mobileNumber, emailID, walletBalance);
            userList.Add(user);
            Console.WriteLine($"Registration is Done Successfully:) \nRegistration ID : {user.UserID}\n");
        }
        public static void Login()
        {
            Console.Write("Enter User ID : ");
            string uid = Console.ReadLine().ToUpper();
            bool isvalidUID = false;
            //traverse userList to check uid is equal to user UID
            foreach (UserDetails user in userList)
            {
                //validate the user id correct or not
                if (user.UserID == uid)
                {
                    //if valid- print login sucessful
                    isvalidUID = true;
                    currentUser = user;
                    Console.WriteLine("Logged Successfully --:)\n");
                    //call Submenu
                    SubMenu();


                }
            }
            //if not valid -print
            if (!isvalidUID)
            {
                Console.WriteLine("Invalid User ID");
            }

        }
        public static void SubMenu()
        {
            string choice = "yes";
            do
            {
                Console.WriteLine("___SUBMENU___");
                Console.WriteLine("1.Current Pack\n2.Pack Recharge\n3.Wallet Recharge\n4.View Pack Recharge History\n5.Show Wallet balance\n6.Exit");
                Console.Write("Enter your option : ");
                int option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        {
                            //if user choose current pack
                            Console.WriteLine("You Selected Current Pack");
                            CurrentPack();

                            break;
                        }
                    case 2:
                        {
                            //if user choose packrecharge
                            Console.WriteLine("You Selected Pack Recharge .");
                            PackRecharge();
                            break;
                        }
                    case 3:
                        {
                            //if user choose wallet recharge
                            Console.WriteLine("You Selected Wallet Recharge ");
                            Recharge();
                            break;
                        }
                    case 4:
                        {
                            //if user choose pack recharge history
                            Console.WriteLine("You Selected Recharge History");
                            PackRechargeHistory();

                            break;
                        }
                    case 5:

                        { //if user choose wallet balance
                            Console.WriteLine("You Selected Wallet Balance");
                            WalletBalance();
                            break;
                        }
                    case 6:
                        {
                            //if user choose exit - exit from the SubMenu
                            Console.WriteLine("User have exited the sub menu");
                            choice = "false";
                            break;

                        }
                }


            } while (choice == "yes");

        }

        public static void CurrentPack()
        {
            bool isValidPack = false;
            //traverse rechargeHistoryList
            foreach (RechargeHistory currentPack in rechargeHistoryList)
            {
                //if currentUser is have current Pack
                if (currentUser.UserID == currentPack.UserID && currentPack.ValidTill >= DateTime.Now)
                {
                    isValidPack = true;
                    userCurrentPack = currentPack;
                    break;
                }
            }
            //if currentUser not have current pack
            if (!isValidPack)
            {
                Console.WriteLine("You don't have Current Pack.");
            }
            else
            {
                //Display currentUser current pack
                Console.WriteLine($"Rechage ID:{userCurrentPack.RechargeID}     User ID:{userCurrentPack.UserID}      Pa2ckID:{userCurrentPack.PackID}      RechargeDate:{userCurrentPack.RechargeDate.ToString("dd/MM/yyyy")}      RechargeAmount:{userCurrentPack.RechargeAmount}         Valid Till:{userCurrentPack.ValidTill.ToString("dd/MM/yyyy")}       No Of Channel:{userCurrentPack.NoOfChannels}\n");

            }
        }
        public static void PackRecharge()
        {

            //traverse packageList 
            foreach (PackageDetails pack in packageList)
            {
                //Display Package details
                Console.WriteLine($"Pack ID{pack.PackID}  PackName:{pack.PackName}  Price:{pack.Price}   Validity(No Of Days):{pack.Validity}   No Of Channels:{pack.NoOfChannels}\n");
            }
            //To get packID For recharge.
            Console.Write("Enter your PackID : ");
            string PID = Console.ReadLine().ToUpper();
            bool isValidPackID = false;
            //traverse the packageList
            foreach (PackageDetails pack in packageList)
            {
                //if valid PID
                if (pack.PackID == PID)
                {
                    isValidPackID = true;
                    DateTime rechargeStaringDate;
                    // to check currentUser Wallet Balance
                    if (currentUser.WalletBalance > pack.Price)
                    {
                        bool isPackAvailable = false;
                        //traverse rechargeHistoryList
                        foreach (RechargeHistory currentPack in rechargeHistoryList)
                        {
                            //if currentUser is have current Pack
                            if (currentUser.UserID == currentPack.UserID)
                            {
                                isPackAvailable = true;
                                userCurrentPack = currentPack;
                            }
                        }
                        //if currentUser not have current pack
                        if (!isPackAvailable)
                        {
                            rechargeStaringDate = DateTime.Now;
                        }
                        //if currentUser recharged but expired
                        else if (userCurrentPack.ValidTill < DateTime.Now)
                        {
                            rechargeStaringDate = DateTime.Now;
                        }
                        //if currentUser recharged but expired in today
                        else if (userCurrentPack.ValidTill == DateTime.Now)
                        {
                            rechargeStaringDate = DateTime.Now.AddDays(1);  
                        }
                        else
                        {
                            rechargeStaringDate = userCurrentPack.ValidTill.AddDays(1);
                        }


                        //Add rechargeHistory to rechargeHistoryList 
                        RechargeHistory rechargeHistory = new RechargeHistory(currentUser.UserID, pack.PackID,rechargeStaringDate, pack.Price, rechargeStaringDate.AddDays(pack.Validity), pack.NoOfChannels);
                        rechargeHistoryList.Add(rechargeHistory);
                        //Display to user 
                        Console.WriteLine($"Hi {currentUser.UserName}  your choosen Pack ID {pack.PackID} is recharged successfully.\nPack validity :{rechargeStaringDate.AddDays(pack.Validity).ToString("dd/MM/yyyy")}");

                        //reduce userWallet balance
                        currentUser.DeductBalance(pack.Price);
                    }
                    else
                    {
                        // if have  insuffient balance in wallet, Go to recharge method
                        Console.WriteLine("You not have enough money for recharge ");
                        Console.WriteLine("Please Recharge Your wallet!");
                        Recharge();
                    }

                }
            }
            //if not valid PID
            if (!isValidPackID)
            {
                Console.WriteLine("Invalid Pack ID");
            }


        }

        public static void Recharge()
        {
            //To confirm from user for recharge
            Console.WriteLine("Do you want to recharge Your Wallet?");
            string option = Console.ReadLine().ToLower();
            if (option == "yes")
            {
                //Get amount from user for recharge
                Console.Write("Enter Amount to Recharge : ");
                double rechageAmount = double.Parse(Console.ReadLine());
                //if rechargeAmount Not below 1
                if (rechageAmount > 0)
                {
                    // To recharge wallet
                    currentUser.WalletRecharge(rechageAmount);
                    //Display walletBalance after recharge
                    Console.WriteLine($"Wallet Balance After recharge : {currentUser.WalletBalance}");

                }
                else
                {
                    //if reacharge Amount below 1
                    Console.WriteLine("Insufficient Amount.");
                }

            }
        }
        public static void PackRechargeHistory()
        {
            bool isAlreadyRecharge = false;
            //traverse rechargeHistoryList to find rechargeHistory of current user
            foreach (RechargeHistory history in rechargeHistoryList)
            {
                //if currentUser already recharged.
                if (currentUser.UserID.Equals(history.UserID))
                {
                    isAlreadyRecharge = true;
                    //display currentUser recharge history
                    Console.WriteLine($"Rechage ID: {history.RechargeID}  User ID : {history.UserID}  PackID : {history.PackID}  RechargeDate : {history.RechargeDate.ToString("dd/MM/yyyy")}  RechargeAmount : {history.RechargeAmount}  Valid Till : {history.ValidTill.ToString("dd/MM/yyyy")}  No Of Channel : {history.NoOfChannels}");
                }
            }
            //if currentUser not recharged
            if (!isAlreadyRecharge)
            {
                Console.WriteLine("Still you aren't Recharge ");
            }



        }
        public static void WalletBalance()
        {
            // display user wallet balance
            Console.WriteLine($"Wallet Balance : {currentUser.WalletBalance}");
        }

    }
}
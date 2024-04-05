using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelMangement
{
    public class Operation
    {
        static CustomList<UserRegistration> userRegistrationList = new CustomList<UserRegistration>();
        static CustomList<RoomDetails> roomDetailsList = new CustomList<RoomDetails>();
        static CustomList<RoomSelection> roomSelectionsList = new CustomList<RoomSelection>();
        static CustomList<BookingDetails> bookingDetailsList = new CustomList<BookingDetails>();
        static CustomList<PersonalDetails> userPersonalDetailsList = new CustomList<PersonalDetails>();
        static UserRegistration currentUser;
        static RoomSelection temperaryRoomSelection;
        static BookingDetails temperaryBooking;
        static CustomList<RoomSelection> temperaryRoomSelectionList = new CustomList<RoomSelection>();

        public static void DefaultValue()
        {
            // adding default userDetails to userPersonalList
            PersonalDetails person = new PersonalDetails("Ravichandran", 995875777, 347777378383, "Chennai", FoodType.Veg, Gender.Male);
            UserRegistration user = new UserRegistration(person.UserName, person.MobileNumber, person.AadharNumber, person.Address, person.FoodType, person.Gender, 5000);
            userRegistrationList.Add(user);
            person = new PersonalDetails("Baskaran", 448844848, 474777477477, "Chennai", FoodType.NonVeg, Gender.Male);
            user = new UserRegistration(person.UserName, person.MobileNumber, person.AadharNumber, person.Address, person.FoodType, person.Gender, 6000);
            userRegistrationList.Add(user);

            //adding default room details to roomdetailList
            RoomDetails room = new RoomDetails(RoomType.Standard, 2, 500);
            roomDetailsList.Add(room);
            room = new RoomDetails(RoomType.Standard, 4, 700);
            roomDetailsList.Add(room);
            room = new RoomDetails(RoomType.Standard, 2, 500);
            roomDetailsList.Add(room);
            room = new RoomDetails(RoomType.Standard, 2, 500);
            roomDetailsList.Add(room);
            room = new RoomDetails(RoomType.Standard, 2, 500);
            roomDetailsList.Add(room);
            room = new RoomDetails(RoomType.Delux, 2, 1000);
            roomDetailsList.Add(room);
            room = new RoomDetails(RoomType.Delux, 2, 1000);
            roomDetailsList.Add(room);
            room = new RoomDetails(RoomType.Delux, 4, 1400);
            roomDetailsList.Add(room);
            room = new RoomDetails(RoomType.Delux, 4, 1400);
            roomDetailsList.Add(room);
            room = new RoomDetails(RoomType.Suit, 2, 2000);
            roomDetailsList.Add(room);
            room = new RoomDetails(RoomType.Suit, 2, 2000);
            roomDetailsList.Add(room);
            room = new RoomDetails(RoomType.Suit, 2, 2000);
            roomDetailsList.Add(room);
            room = new RoomDetails(RoomType.Suit, 4, 2500);
            roomDetailsList.Add(room);
            // adding default booking details to bookingdetailList
            BookingDetails booking = new BookingDetails("SF1001", 1450, DateTime.ParseExact("10/11/2022", "dd/MM/yyyy", null), BookingStatus.Booked);
            bookingDetailsList.Add(booking);
            booking = new BookingDetails("SF1002", 2000, DateTime.ParseExact("10/11/2022", "dd/MM/yyyy", null), BookingStatus.Cancelled);
            bookingDetailsList.Add(booking);
            //adding default room selection details to room selection details List
            RoomSelection roomSelection = new("BID101", "RID101", DateTime.ParseExact("11/11/2022 06:00 AM", "dd/MM/yyyy hh:mm tt", null), DateTime.ParseExact("12/11/2022 02:00 PM", "dd/MM/yyyy hh:mm tt", null), 750, 1.5, BookingStatus.Booked);
            roomSelectionsList.Add(roomSelection);
            roomSelection = new("BID101", "RID101", DateTime.ParseExact("11/11/2022 10:00 AM", "dd/MM/yyyy hh:mm tt", null), DateTime.ParseExact("12/11/2022 09:00 PM", "dd/MM/yyyy hh:mm tt", null), 700, 1, BookingStatus.Booked);
            roomSelectionsList.Add(roomSelection);
            roomSelection = new("BID101", "RID101", DateTime.ParseExact("12/11/2022 09:00 AM", "dd/MM/yyyy hh:mm tt", null), DateTime.ParseExact("13/11/2022 09:00 AM", "dd/MM/yyyy hh:mm tt", null), 500, 1, BookingStatus.Cancelled);
            roomSelectionsList.Add(roomSelection);
            roomSelection = new("BID101", "RID101", DateTime.ParseExact("12/11/2022 06:00 PM", "dd/MM/yyyy hh:mm tt", null), DateTime.ParseExact("13/11/2022 12:30 PM", "dd/MM/yyyy hh:mm tt", null), 1500, 1.5, BookingStatus.Cancelled);
            roomSelectionsList.Add(roomSelection);
        }
        public static void MainMenu()
        {
            string choice = "yes";
            do
            {
                //Display MainMenu Details.
                Console.WriteLine("----Hotel Management----");
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
            Console.Write("Enter Mobile Number : ");
            long mobileNumber = long.Parse(Console.ReadLine());
            Console.Write("Enter Aadhar Number : ");
            long aadharNumber = long.Parse(Console.ReadLine());

            Console.Write("Enter Address : ");
            string address = Console.ReadLine();
            Console.Write("Your food Type: ");
            FoodType foodType = Enum.Parse<FoodType>(Console.ReadLine(), true);
            Console.Write("Gender : ");
            Gender gender = Enum.Parse<Gender>(Console.ReadLine(), true);
            Console.Write("Enter Wallet Balance : ");
            double walletBalance = double.Parse(Console.ReadLine());
            //add user details to userList
            PersonalDetails person = new PersonalDetails(userName, mobileNumber, aadharNumber, address, foodType, gender);
            userPersonalDetailsList.Add(person);
            UserRegistration user = new UserRegistration(person.UserName, person.MobileNumber, person.AadharNumber, person.Address, person.FoodType, person.Gender, walletBalance);
            userRegistrationList.Add(user);
            // display user regitration id
            Console.WriteLine($"Your registration is successful\nYour User ID : {user.UserID}");

        }
        public static void LogIn()
        {
            //Ask for the “User ID” of the user
            Console.Write("Enter your UserID : ");
            string userID = Console.ReadLine().ToUpper();

            bool isValidUserID = false;

            foreach (UserRegistration user in userRegistrationList)
            {
                // Check the “User ID” in the user list
                if (userID.Equals(user.UserID))
                {
                    isValidUserID = true;
                    Console.WriteLine("You are successfully  Logged in ");
                    currentUser = user;
                    SubMenu();


                }
            }
            //If the User ID does not exist
            if (!isValidUserID)
            {
                // display “Invalid User Id. Please enter valid one”.
                Console.WriteLine("Invalid User Id.. Please enter valid one");
            }

        }
        public static void SubMenu()
        {
            string userChoice = "yes";
            do
            {
                //display the sub menu
                Console.WriteLine("---- SUB MENU ----");
                Console.WriteLine("1.Viwe Customer Profile\n2.Book Room\n3.Modify Booking\n4.Cancel Booking\n5.Booking History\n6.Wallet Recharge\n7.Show WalletBalance\n8.Exit");
                Console.Write("Enter your Option : ");
                int userOption = int.Parse(Console.ReadLine());
                Console.WriteLine();
                switch (userOption)
                {
                    case 1:
                        {
                            ViewCustomerProfile();
                            break;
                        }
                    case 2:
                        {
                            BookRoom();
                            break;
                        }
                    case 3:
                        {
                            ModifyBooking();
                            break;
                        }
                    case 4:
                        {
                            CancelBooking();
                            break;
                        }
                    case 5:
                        {
                            BookingHistory();
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
        public static void ViewCustomerProfile()
        {
            //   Show all the details of the current user 
            Console.WriteLine($"User ID :{currentUser.UserID,-10}User Name : {currentUser.UserName,-20} Mobile Number : {currentUser.MobileNumber,-10} Aadhar Number : {currentUser.AadharNumber,-10}Address : {currentUser.Address,-10}Foot Type : {currentUser.FoodType,-10}Gender : {currentUser.Gender} WalletBalance : {currentUser.WalletBalance} ");

        }
        public static void BookRoom()
        {
            temperaryBooking = new BookingDetails(currentUser.UserID, 0, DateTime.Now, BookingStatus.Initiated);
            // traversing the Room Details list
            foreach (RoomDetails room in roomDetailsList)
            {
                // show the list of available room types
                Console.WriteLine($"Room ID:{room.RoomID,-10}Room Type:{room.RoomType,-10} NumberOf Beds :{room.NumberOfBed,-10} PricePerDay :{room.PricePerDay}\n");
            }
            Console.Write("Do you want to Book room?  ");
            string userWish = Console.ReadLine().ToLower();
            double totalPrice = 0;
            if (userWish == "yes")
            {
                //to ask the user to enter DateFrom (Date and Time) and DateTo (Date and Time), RoomID & no. Of Days of booking.
                do
                {
                    Console.Write("Enter RoomID : ");
                    string searchBookingRoomID = Console.ReadLine().ToUpper();
                    Console.Write("Enter Date Of Staying From : ");
                    DateTime stayingDateFrom = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy hh:mm tt", null);
                    Console.Write("Enter Date Of Staying To : ");
                    DateTime stayingDayTo = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy hh:mm tt", null);
                    Console.Write("No Of Days : ");
                    double noOfDays = double.Parse(Console.ReadLine());
                    foreach (RoomDetails room in roomDetailsList)
                    {
                        foreach (RoomSelection room1 in roomSelectionsList)
                        {
                            if (searchBookingRoomID == room.RoomID && BookingStatus.Booked != room1.BookingStatus && room.RoomID == room1.RoomID)
                            {
                                double price = room1.Price * noOfDays;
                                Console.WriteLine(totalPrice);
                                //calculate total price of booking
                                totalPrice += price;
                                temperaryRoomSelection = new RoomSelection(temperaryBooking.BookingID, room.RoomID, stayingDateFrom, stayingDayTo, price, noOfDays, BookingStatus.Booked);
                                temperaryRoomSelectionList.Add(temperaryRoomSelection);

                            }
                        }
                    }
                    // 6.	Ask the user whether he want to book another room
                    Console.Write("Do you want to Book another room?  ");
                    userWish = Console.ReadLine().ToLower();
                } while (userWish == "yes");
            }
            Console.Write("Are you comfirm to book the room ");
            userWish = Console.ReadLine().ToLower();
            if (userWish == "yes")
            {

                //9.	If user don’t have enough balance, ask the user whether he want to proceed booking after recharge 
                while (currentUser.WalletBalance  < totalPrice)
                {
                    Console.WriteLine($"Insuffient Balance.You need {totalPrice} for booking.\nDo want to proceed booking after recharge?");
                      WalletRecharge();
                        if (currentUser.WalletBalance >= totalPrice)
                        {
                            userWish = "no";
                        }
                }
                // If user have enough balance
                 if (currentUser.WalletBalance >= totalPrice)
                { Console.WriteLine("oi");
                    foreach (RoomSelection tempRoomSelection in temperaryRoomSelectionList)
                    {
                        Console.Write("PO");
                        roomSelectionsList.Add(temperaryRoomSelection);
                    }
                    temperaryBooking.BookingStatus = BookingStatus.Booked;
                    temperaryBooking.TotalPrice = totalPrice;
                    bookingDetailsList.Add(temperaryBooking);
                    currentUser.DeductBalance(totalPrice);
                    Console.WriteLine("Room Booked Succesfully.");
                }

            }


        }
        public static void ModifyBooking()
        {
            bool isUserAlreadyBooked = false;
            // traversing the booking details list
            foreach (BookingDetails booking in bookingDetailsList)

            {   // show the current user’s booking history whose booking status is Booked
                if (currentUser.UserID.Equals(booking.UserID) && booking.BookingStatus == BookingStatus.Booked)
                {
                    isUserAlreadyBooked = true;
                    Console.WriteLine($"BookingID : {booking.BookingID,-10}UserID : {booking.UserID,-10}Total Price : {booking.TotalPrice,-10}Date Of Booking : {booking.DateOfBooking.ToString("dd/MM/yyyy ")}   BookingStatus : {booking.BookingStatus}");
                }
            }
            if (isUserAlreadyBooked)
            {
                Console.Write("Do you want to add or cancel? ");
                string userWish = Console.ReadLine().ToLower();
                if (userWish == "add")
                {


                }
                else if (userWish == "cancel")
                {
                    Console.Write("Enter RoomID  which one you cancel");
                    string searchBookingID = Console.ReadLine().ToUpper();
                    foreach (BookingDetails booking in bookingDetailsList)
                    {
                        if (searchBookingID == booking.BookingID)
                        {
                            //change the status of booking to Cancelled
                            booking.BookingStatus = BookingStatus.Cancelled;
                            // return the booking amount to current user’s wallet
                            currentUser.WalletRecharge(booking.TotalPrice);
                        }
                    }
                    foreach (BookingDetails booking in bookingDetailsList)
                    {
                        if (searchBookingID == booking.BookingID)
                        {
                            //change the status of booking to Cancelled
                            booking.BookingStatus = BookingStatus.Cancelled;
                            // return the booking amount to current user’s wallet
                            currentUser.WalletRecharge(booking.TotalPrice);
                        }
                    }
                }
            }
        }
        public static void CancelBooking()
        {

            bool isUserAlreadyBooked = false;
            // traversing the booking details list
            foreach (BookingDetails booking in bookingDetailsList)

            {   // show the current user’s booking history whose booking status is Booked                 if (currentUser.UserID.Equals(booking.UserID) && booking.BookingStatus==BookingStatus.Booked)
                if (currentUser.UserID.Equals(booking.UserID) && booking.BookingStatus == BookingStatus.Booked)
                {
                    isUserAlreadyBooked = true;
                    Console.WriteLine($"BookingID : {booking.BookingID,-10}UserID : {booking.UserID,-10}Total Price : {booking.TotalPrice,-10}Date Of Booking : {booking.DateOfBooking.ToString("dd/MM/yyyy ")}   BookingStatus : {booking.BookingStatus}");
                }
            }
            if (isUserAlreadyBooked)
            {
                Console.Write("Do you want to cancel ?  ");
                string userWish = Console.ReadLine().ToLower();
                if (userWish == "yes")
                {
                    Console.Write("Enter booking ID : ");
                    string searchBookingID = Console.ReadLine().ToUpper();
                    bool isValidBookingID = false;
                    bool isCancelledBooking = false;
                    // Change the booking status of selection list details of that corresponding bookingID 
                    foreach (RoomSelection roomSelection in roomSelectionsList)
                    {

                        if (roomSelection.BookingID.Equals(searchBookingID))
                        {
                            isValidBookingID = true;
                            roomSelection.BookingStatus = BookingStatus.Cancelled;
                            isCancelledBooking = true;
                        }
                    }
                    foreach (BookingDetails booking in bookingDetailsList)
                    {
                        if (searchBookingID == booking.BookingID)
                        {
                            //change the status of booking to Cancelled
                            booking.BookingStatus = BookingStatus.Cancelled;
                            // return the booking amount to current user’s wallet
                            currentUser.WalletRecharge(booking.TotalPrice);
                        }
                    }

                    if (!isValidBookingID)
                    {
                        Console.WriteLine("Invalid BookID. please enter valid one.");
                    }
                    if (isCancelledBooking)
                    {
                        Console.WriteLine("Your Booking Cancelled.");

                    }
                }
            }
            else
            {
                Console.WriteLine("You Haven't Booked yet");
            }

        }
        public static void BookingHistory()
        {
            bool isUserAlreadyBooked = false;
            foreach (BookingDetails booking in bookingDetailsList)
            {   // Need to show the current user’s booking history by traversing the booking details list
                if (currentUser.UserID.Equals(booking.UserID))
                {
                    isUserAlreadyBooked = true;
                    Console.WriteLine($"BookingID : {booking.BookingID,-10}UserID : {booking.UserID,-10}Total Price : {booking.TotalPrice,-10}Date Of Booking : {booking.DateOfBooking.ToString("dd/MM/yyyy ")} Booking Status :{booking.BookingStatus}");
                }
            }
            if (isUserAlreadyBooked)
            {
                Console.Write("Which Booking you want to see ?\nEnter booking ID : ");
                string searchBookingID = Console.ReadLine().ToUpper();
                bool isValidBookingID = false;
                foreach (RoomSelection roomSelection in roomSelectionsList)
                {

                    if (roomSelection.BookingID.Equals(searchBookingID))
                    {
                        isValidBookingID = true;
                        Console.WriteLine($"Selection ID : {roomSelection.SelectionID}    Booking ID : {roomSelection.BookingID}    RoomID :{roomSelection.RoomID}    StaydingDate From : {roomSelection.StayingDateFrom.ToString("dd/MM/yyyy hh:mm tt")}   Staying Date To : {roomSelection.StayingDateTo.ToString("dd/MM/yyyy hh:mm tt")}     Price : {roomSelection.Price}   Number Of Days : {roomSelection.NumberOfDays}   BookingStatus : {roomSelection.BookingStatus}");
                    }
                }
                if (!isValidBookingID)
                {
                    Console.WriteLine("Invalid BookID. ple5se enter valid one.");
                }
            }
            else
            {
                Console.WriteLine("Still you not booked any room.");
            }

        }
        public static void WalletRecharge()
        {
            Console.WriteLine("Do you want to recharge your wallet ?  ");
            string userWish = Console.ReadLine().ToLower();
            if (userWish == "yes")
            {
                //get the amount to recharge
                Console.Write("Enter The Amount for recharge : ");
                double rechargeAmount = double.Parse(Console.ReadLine());
                //if valid rechargeAmount
                if (rechargeAmount > 0)
                {
                    //show the current balance of user
                    currentUser.WalletRecharge(rechargeAmount);
                    Console.WriteLine($"User Wallet balance : {currentUser.WalletBalance}");

                }
                else
                {
                    Console.WriteLine("Invalid Amount.Please  eneter valid amount. ");
                }
            }

        }

        public static void ShowWalletBalance()
        {
            // Display the user’s wallet balance.
            Console.WriteLine("Wallet Balance : " + currentUser.WalletBalance);
        }


    }
}

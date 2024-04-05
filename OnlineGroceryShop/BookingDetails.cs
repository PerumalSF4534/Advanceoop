using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGroceryShop
{
    public enum BookingStatus{Default,Booked,Cancelled,Initiated}
    public class BookingDetails
    {
        private static int s_bookingID=3000;
        public string BookingID { get; set; }
         public string CustomerID { get; set; }
         public double TotalPrice { get; set; }
         public DateTime DateOfBooking { get; set; }
        public BookingStatus BookingStatus { get; set; }

        public BookingDetails(string customerID,double totalPrice,DateTime dateOfBooking,BookingStatus bookingStatus)
        {
            BookingID="BID"+ ++s_bookingID;
            CustomerID=customerID;
            TotalPrice=totalPrice;
            DateOfBooking=dateOfBooking;
            BookingStatus=bookingStatus;
            
        }
         public BookingDetails(string booking)
        {
            string[] values=booking.Split(",");
            BookingID=values[0];
            s_bookingID=int.Parse(values[0].Remove(0,3));
            CustomerID=values[1];
            TotalPrice=double.Parse(values[2]);
            DateOfBooking=DateTime.ParseExact(values[3],"dd/MM/yyyy",null);
            BookingStatus=Enum.Parse<BookingStatus>(values[4]);
            
        }
    }
}
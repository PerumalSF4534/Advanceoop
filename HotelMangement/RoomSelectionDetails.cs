using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelMangement
{
    
    public class RoomSelection
    {
        private static int s_selectionID=1000;
        public string SelectionID { get; set; }
        public string BookingID { get; set; }
        public string  RoomID { get; set; }
        public DateTime StayingDateFrom { get; set; }
        public DateTime StayingDateTo { get; set; }
        public double Price { get; set; }
        public double NumberOfDays { get; set; }
        public BookingStatus BookingStatus { get; set; }

        public RoomSelection(string bookingID,string roomID, DateTime stayingDateFrom, DateTime stayingDateTo, double price,double numberOfDays,BookingStatus bookingStatus)
        {
            SelectionID="SID"+ ++s_selectionID;
            BookingID=bookingID;
            RoomID=roomID;
            StayingDateFrom=stayingDateFrom;
            StayingDateTo=stayingDateTo;
            Price=price;
            NumberOfDays=numberOfDays;
            BookingStatus=bookingStatus;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelMangement
{
    public enum RoomType { Select, Standard, Delux, Suit }
    public class RoomDetails
    {
        private static int s_roomID = 100;
        public string RoomID { get; set; }
        public RoomType RoomType { get; set; }
        public int NumberOfBed { get; set; }
        public double PricePerDay { get; set; }
        public RoomDetails(RoomType roomType, int numberOfBed, double pricePerDay)
        {
            RoomID = "RID" + ++s_roomID;
            RoomType = roomType;
            NumberOfBed = numberOfBed;
            PricePerDay = pricePerDay;
        }

    }
}
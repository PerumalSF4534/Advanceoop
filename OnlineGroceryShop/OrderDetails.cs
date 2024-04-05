using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGroceryShop
{
    public class OrderDetails
    {
        private static int s_orderID=4000;
        public string OrderID { get; set; }
        public string ProductID { get; set; }
        public string BookingID { get; set; }
        public double PurchaseCount { get; set; }
        public double PriceOfOrder { get; set; }

    public OrderDetails(string bookingID,string productID, double purchaseCount,double priceOfOrder)
    {
        OrderID="OID"+ ++s_orderID;
        BookingID=bookingID;
        ProductID=productID;
        PurchaseCount=purchaseCount;
        PriceOfOrder=priceOfOrder;
    }
    public OrderDetails(string order)
    {
        string[] values=order.Split(",");
        OrderID=values[0];
        s_orderID=int.Parse(values[0].Remove(0,3));
        BookingID=values[1];
        ProductID=values[2];
        PurchaseCount=double.Parse(values[3]);
        PriceOfOrder=double.Parse(values[4]);
    }

    }
}
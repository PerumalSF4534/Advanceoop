using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeteriaCardManagement
{
    public class CartItem
    {
        private static int s_itemID=100;
        public string ItemID { get; set; }
        public string OrderID { get; set; }
        public string FoodID { get; set; }  
        public double OrderPrice { get; set; }
        public double OrderQuantity { get; set; }

        public CartItem(string orderID,string foodID, double orderPrice,double orderQuantity)
        {
            ItemID="ITID"+ ++s_itemID;
            OrderID=orderID;
            FoodID=foodID;
            OrderPrice=orderPrice;
            OrderQuantity=orderQuantity;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMedicalStore
{
    public enum OrderStatus { Select, Purchased, Cancelled }
    public class OrderDetails
    {
        private static int s_orderID = 3000;
        public string OrderID { get; set; }
        public string UserID { get; set; }
        public string MedicineID { get; set; }
        public double MedicineCount { get; set; }
        public double TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus OrderStatus { get; set; }


        public OrderDetails(string userID,string medicineID,double medicineCount, double totalPrice, DateTime orderDate, OrderStatus orderStatus)
        {
            OrderID = "OID" + ++s_orderID;
             UserID=userID;
            MedicineID=medicineID;
            MedicineCount = medicineCount;
            TotalPrice = totalPrice;
            OrderDate = orderDate;
            OrderStatus = orderStatus;
        }
        public OrderDetails(string order)
        {
            string[] values=order.Split(",");
            OrderID = values[0];
            s_orderID=int.Parse(values[0].Remove(0,3));
             UserID=values[1];
            MedicineID=values[2];
            MedicineCount =double.Parse(values[3]);
            TotalPrice = double.Parse(values[4]);
            OrderDate = DateTime.ParseExact(values[5],"dd/MM/yyyy",null);
            OrderStatus = Enum.Parse<OrderStatus>(values[6]);
        }
    }
}
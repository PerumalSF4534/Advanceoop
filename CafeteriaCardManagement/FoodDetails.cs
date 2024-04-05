using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeteriaCardManagement
{
    public class FoodDetails
    {
        private static int s_foodID=100;
        public string FoodID { get; set; }
        public string FoodName { get; set; }
        public double FoodPrice { get; set; }
        public double AvailableQuantity { get; set; }   
         public FoodDetails(string foodName,double foodPrice,double availableQuantity)
         {
            FoodID="FID"+ ++s_foodID;
            FoodName=foodName;
            FoodPrice=foodPrice;
            AvailableQuantity=availableQuantity;
         }
          public FoodDetails(string foods)
         {
            string[] values=foods.Split(",");

            FoodID=values[0];
           // s_foodID=int.Parse(values[0].Remove(0,4));
            FoodName=values[1];
            FoodPrice=double.Parse(values[2]);
            AvailableQuantity=double.Parse(values[3]);
         }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGroceryShop
{
    public class ProductDetails
    {
        private static int s_productID=2000;
        public string ProductID { get; set; }
        public string ProdctName { get; set; }
        public double  QuantityAvailable { get; set; }
        public double PricePerQuantity { get; set; }

        public ProductDetails(string productName,double quantityAvailable,double pricePerQuantity)
        {
            ProductID="PID"+ ++s_productID;
            ProdctName=productName;
            QuantityAvailable=quantityAvailable;
            PricePerQuantity=pricePerQuantity;
        }
        public ProductDetails(string product)
        {
            string[] values=product.Split(",");

            ProductID=values[0];
            ProdctName=values[1];
            QuantityAvailable=double.Parse(values[2]);
            PricePerQuantity=double.Parse(values[3]);
        }
    }
}
using System;


namespace OnlineGroceryShop
{
    public class CustomBinarySearch
    {
        public static int BinarySearch(CustomList<CustomerDetails> customers, string searchElement)
        {
            
            int left = 0;
            int right = customers.Count - 1;
            int position = -1;
           
            while (left <= right)
            {
                int middle = left + (right - left) / 2;
                if (customers[middle].CustomerID.CompareTo(searchElement) == 0)
                {
                    
                    position = middle;
                    return position;
                }
                else if (customers[middle].CustomerID.CompareTo(searchElement) == 1)
                {
                    right = middle - 1;
                }
                else
                {
                    Console.WriteLine("o");
                    left = middle + 1;
                }
            }
            return position;

        }
       public static int BinarySearch(CustomList<BookingDetails> bookings, string searchBookingID)
        {
            int left = 0; 
            int right = bookings.Count - 1;
            int position=-1;
            while(left<=right)
            {
                int middle=left+(right-left)/2;
                if(bookings[middle].BookingID.CompareTo(searchBookingID)==0)
                {
                    position=middle;
                    return position;
                }
                else if(bookings[middle].BookingID.CompareTo(searchBookingID)==1)
                {
                    right=middle-1;
                }
                else{
                    left=middle+1;
                }
            }return position;



        }
     
    }
}
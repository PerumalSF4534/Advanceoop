using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMedicalStore
{
    public class UserDetails
    {
        private static int s_userID=1000;
        private  double _walletBalance;
        public string UserID { get; set; }
        public string UserName { get; set; }    
        public int Age { get; set; }
        public string  City { get; set; }
        public long PhoneNumber { get; set; }
        public double Balance { get; set; }
        public double WalletBalance { get{return _walletBalance;}}

        public UserDetails(string userName,int age,string city,long phoneNumber,double Balance)
        {
            UserID="UID"+ ++s_userID;
            UserName=userName;
            Age=age;
            City=city;
            PhoneNumber=phoneNumber;
            _walletBalance=Balance;

        }
        public UserDetails(string user1)
        {
            string [] values=user1.Split(",");
            UserID=values[0];
            s_userID=int.Parse(values[0].Remove(0,3));
            UserName=values[1];
            Age=int.Parse(values[2]);
            City=values[3];
            PhoneNumber=long.Parse(values[4]);
            _walletBalance=double.Parse(values[5]);

        }

        public void WalletRecharge(double amount)
        {
            _walletBalance+=amount;
        }
        public void DeductBalance(double amount)
        {
            _walletBalance-=amount;
        }
    }
}
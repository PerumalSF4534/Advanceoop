using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineDTHRecharge
{
    public class UserDetails
    {
        private static int s_userID=1000;
        private  double _walletBalance;
        public string UserID { get; set; }
        public string UserName { get; set; }
        public long MobileNumber { get; set; }
        public string EmailID { get; set; }
        public double WalletBalance { get{return _walletBalance;}  }

        public UserDetails(string userName,long mobileNumber,string emailID,double walletBalance)
        {
            UserID="UID"+ ++s_userID;
            UserName=userName;
            MobileNumber=mobileNumber;
            EmailID=emailID;
            _walletBalance=walletBalance;
        }
 public UserDetails(string user)
 {
    string[] values=user.Split(",");
            UserID=values[0];
            s_userID=int.Parse(values[0].Remove(0,3));
            UserName=values[1];
            MobileNumber=long.Parse(values[2]);
            EmailID=values[3];
            _walletBalance=double.Parse(values[4]);
        }
        public  void WalletRecharge(double amount)
        {
             _walletBalance+=amount;

        }
        public void DeductBalance(double amount)
        {
            _walletBalance-=amount;
        }

    }
}
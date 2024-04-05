using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelMangement
{
    public class UserRegistration:PersonalDetails
    {
        private static int s_userID=1000;
        private double _walletBalance;
        public string UserID { get; set; }
        public double WalletBalance { get{return _walletBalance;} }
        public UserRegistration(string userName,long mobileNumber,long aadharNumber,string address,FoodType foodType,Gender gender,double walletBalance):base(userName,mobileNumber,aadharNumber,address,foodType,gender)
        {
            UserID="SF"+ ++s_userID;
            _walletBalance=walletBalance;
        }
        public  void WalletRecharge(double rechargeAmount)
        {
            _walletBalance+=rechargeAmount;
        }
        public void DeductBalance(double amount)
        {
            _walletBalance-=amount;
        }
    }
}
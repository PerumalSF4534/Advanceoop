using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeteriaCardManagement
{
    public class UserDetails : PersonalDetails

    {
        private static int s_userID = 1000;
        private double _walletBalance;
        public string UserID { get; set; }
        public double WalletBalance { get { return _walletBalance; } }
        public string WorkStationNumber { get; set; }
        public UserDetails(string userName, string fatherName, long mobileNumber, string mailID, Gender gender, string workStationNumber, double balance)
        : base(userName, fatherName, mobileNumber, mailID, gender)
        {
            UserID = "SF" + ++s_userID;
            UserName = userName;
            FatherName = fatherName;
            MobileNumber = mobileNumber;
            MailID = mailID;
            Gender = gender;
            WorkStationNumber = workStationNumber;
            _walletBalance = balance;

        }
        public UserDetails(string user)
        {
            string[] values = user.Split(",");
            UserID = values[0];
            s_userID=int.Parse(values[0].Remove(0,2));
            UserName = values[1];
            FatherName = values[2];
            MobileNumber = long.Parse(values[3]);
            MailID = values[4];
            Gender = Enum.Parse<Gender>(values[5]);
            WorkStationNumber = values[6];
            _walletBalance = double.Parse(values[7]);

        }
        public void WalletRecharge(double amount)
        {

            _walletBalance += amount;
        }
        public void DeductBalance(double amount)
        {
            _walletBalance -= amount;
        }

    }
}
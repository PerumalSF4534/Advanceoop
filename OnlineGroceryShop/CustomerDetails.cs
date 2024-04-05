using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGroceryShop
{
    public enum Gender{Select,Male,Female}
    public class CustomerDetails:PersonalDetails
    {
       private static int  s_customerID= 1000;
       private  double _walletBalance;
        public double WalletBalance { get{return _walletBalance;} }
       public string CustomerID { get; set; }
       
        public CustomerDetails(double walletBalance,string name,string fatherName,Gender gender,long mobile,DateTime dob,string mailID):base(name, fatherName, gender, mobile, dob, mailID)
        {
            CustomerID="CID"+ ++s_customerID;
            _walletBalance=walletBalance;
           
        }
        public CustomerDetails(string customer)
        {
            string[] values=customer.Split(",");
            CustomerID=values[0];
            s_customerID=int.Parse(values[0].Remove(0,3));
            _walletBalance=double.Parse(values[1]);
            Name=values[2];
            FatherName=values[3];
            Gender=Enum.Parse<Gender>(values[4]);
            Mobile=long.Parse(values[5]);
            DOB=DateTime.ParseExact(values[6],"dd/MM/yyyy",null);
            MailID=values[7];
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
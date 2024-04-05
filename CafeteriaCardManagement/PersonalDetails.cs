using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeteriaCardManagement
{
     public enum Gender{Select,Male,Female,Transgender}
    public class PersonalDetails
    {
         public string UserName{get;set;}
       public string FatherName { get; set; }
       public Gender Gender { get; set; }
       public long MobileNumber { get; set; }   
       public string MailID { get; set; }
    
     public PersonalDetails(string userName,string fatherName,long mobile,string mailID,Gender gender)
        {
            UserName=userName;
            FatherName=fatherName;
            Gender=gender;
            MobileNumber=mobile;
            MailID=mailID;
        }
        public PersonalDetails()
        {
          
        }
}
}
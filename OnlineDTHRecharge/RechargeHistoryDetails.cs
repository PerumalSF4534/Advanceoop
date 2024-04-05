using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineDTHRecharge
{
    public class RechargeHistory
    {
        private static int s_rechargeID=100;
        public string RechargeID { get; set; }
        public string UserID{ get; set; }
        public string PackID { get; set; } 
        public DateTime RechargeDate { get; set; }
        public double RechargeAmount { get; set; }
        public DateTime ValidTill { get; set; }
        public double NoOfChannels { get; set; }
    public RechargeHistory(string userID,string packID,DateTime rechargeDate,double rechargeAmount,DateTime validTill,double noOfChannels)
    {
        RechargeID="RP"+ ++s_rechargeID;
        UserID=userID;
        PackID=packID;
        RechargeDate=rechargeDate;
        RechargeAmount=rechargeAmount;
        ValidTill=validTill;
        NoOfChannels=noOfChannels;
    }
     public RechargeHistory(string recharge)
    {
        string [] values=recharge.Split(",");

        RechargeID=values[0];
        s_rechargeID=int.Parse(values[0].Remove(0,2));
        UserID=values[1];
        PackID=values[2];
        RechargeDate=DateTime.ParseExact(values[3],"dd/MM/yyyy",null);
        RechargeAmount=double.Parse(values[4]);
        ValidTill=DateTime.ParseExact(values[5],"dd/MM/yyyy",null);
        NoOfChannels=double.Parse(values[6]);
    }
   
    }
}
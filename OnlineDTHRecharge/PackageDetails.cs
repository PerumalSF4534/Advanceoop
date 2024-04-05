using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineDTHRecharge
{
    public class PackageDetails
    {
        public string PackID { get; set; }
        public string PackName { get; set; }
        public double Price { get; set; }
        public double Validity { get; set; }
        public double NoOfChannels { get; set; } 
        public PackageDetails(string packID,string packName,double price,double validity,double noOfChannels)
        {
            PackID=packID;
            PackName=packName;
            Price=price;
            Validity=validity;
            NoOfChannels= noOfChannels;
        }
        public PackageDetails(string package)
        { string[] values=package.Split(",");
            PackID=values[0];
            PackName=values[1];
            Price=double.Parse(values[2]);
            Validity=double.Parse(values[3]);
            NoOfChannels= double.Parse(values[4]);
        }
    }
}
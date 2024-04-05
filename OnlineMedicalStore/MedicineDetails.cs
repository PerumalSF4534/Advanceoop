using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMedicalStore
{
    public class MedicineDetails
    {
        private static int s_medicineID=2000;
        public string MedicineID { get; }
        public string MedicineName { get; set; }
        public double AvailableCount { get; set; } 
        public DateTime DateOfExpiry { get; set; }
        public double Price { get; set; }

        public MedicineDetails(string medicineName,int availableCount,double price, DateTime dateOfExpiry)
        {
            MedicineID="MD"+ ++s_medicineID;
            MedicineName=medicineName;
            AvailableCount=availableCount;
            Price=price;
            DateOfExpiry=dateOfExpiry;
        }
         public MedicineDetails(string medicine)
        {
            string[] values=medicine.Split(",");
            s_medicineID=int.Parse(values[0].Remove(0,2));
            MedicineID=values[0];
            MedicineName=values[1];
            AvailableCount=int.Parse(values[2]);
            Price=double.Parse(values[2]);
            DateOfExpiry=DateTime.ParseExact(values[4],"dd/MM/yyyy",null);
        }
    }
}
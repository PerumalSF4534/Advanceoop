using System.IO;


namespace OnlineDTHRecharge
{
    public class FileHandling
    {
        public static void Create()
        {
        string path=@"C:\Users\PerumalKrishnan\OneDrive - Syncfusion\PracticeAssignmentCode\ConsoleAppilaction\OnlineDTHRecharge";
        // Create a Folder
       if(!Directory.Exists(path+"/OnlineDTHRecharge"))
       {
        Directory.CreateDirectory(path+"/OnlineDTHRecharge");
       }
       //Create File for RechargeHistoryDetails Details
            if (!File.Exists(path + "//OnlineDTHRecharge/RechargeHistoryDetails.csv"))
            {
                File.Create(path + "//OnlineDTHRecharge/RechargeHistoryDetails.csv").Close();
            }
            //Create file for PackageDetails details
            if (!File.Exists(path + "//OnlineDTHRecharge/PackageDetails.csv"))
            {
                File.Create(path + "//OnlineDTHRecharge/PackageDetails.csv").Close();
            }
            //create file for userdails
            if (!File.Exists(path + "//OnlineDTHRecharge/UserDetails.csv"))
            {
                File.Create(path + "//OnlineDTHRecharge/UserDetails.csv").Close();
            }

        }
         public static void WriteCSV()

        {
            string path = @"C:\Users\PerumalKrishnan\OneDrive - Syncfusion\PracticeAssignmentCode\ConsoleAppilaction\OnlineDTHRecharge";
            // Add userDetail to UserDetails.csv file
            string[] user = new string[Operation.userList.Count];
            for (int i = 0; i < Operation.userList.Count; i++)
            {
                user[i] = Operation.userList[i].UserID + "," + Operation.userList[i].UserName + "," + Operation.userList[i].MobileNumber + "," + Operation.userList[i].EmailID+ "," + Operation.userList[i].WalletBalance;
            }
            File.WriteAllLines(path + "/OnlineDTHRecharge/UserDetails.csv", user);
            //Add rechargehistory details to rechargehistorydetails.csv file
            string[]rechargehistory = new string[Operation.rechargeHistoryList.Count];
            for (int i = 0; i < Operation.rechargeHistoryList.Count; i++)
            {
               rechargehistory[i] = Operation.rechargeHistoryList[i].UserID + "," + Operation.rechargeHistoryList[i].RechargeDate + "," + Operation.rechargeHistoryList[i].RechargeAmount + "," + Operation.rechargeHistoryList[i].ValidTill + "," + Operation.rechargeHistoryList[i].NoOfChannels;
            }
            File.WriteAllLines(path + "/OnlineDTHRecharge/RechargeHistoryDetails.csv",rechargehistory);
            //Add package detail to packagedetails.csv file
            string[] package=new string[Operation.rechargeHistoryList.Count];
            for(int i=0;i<Operation.packageList.Count;i++)
            {
                package[i]=Operation.packageList[i].PackID+","+Operation.packageList[i].PackName+","+Operation.packageList[i].Price+","+Operation.packageList[i].Validity+","+Operation.rechargeHistoryList[i].NoOfChannels;
            }
            File.WriteAllLines(path + "/OnlineDTHRecharge/PackageDetails.csv",package);

        }
        public static void ReadFromCSV()
        {
            string path= @"C:\Users\PerumalKrishnan\OneDrive - Syncfusion\PracticeAssignmentCode\ConsoleAppilaction\OnlineDTHRecharge";
            string[] users=File.ReadAllLines(path+"/OnlineDTHRecharge/UserDetails.csv");
            foreach( string user in users)
        {
            UserDetails user1=new UserDetails( user);
            Operation.userList.Add(user1);
        }
        string[] packages=File.ReadAllLines(path +"/OnlineDTHRecharge/PackageDetails.csv");
        foreach(string package in packages)
        {
            PackageDetails package1=new PackageDetails(package);
            Operation.packageList.Add(package1);
        }
        string[] rechargeHistory=File.ReadAllLines(path +"/OnlineDTHRecharge/RechargeHistoryDetails.csv");
        foreach(string recharge in rechargeHistory)
        {
            RechargeHistory recharge1=new RechargeHistory(recharge);
            Operation.rechargeHistoryList.Add(recharge1);
        }
        }
         
    }
}
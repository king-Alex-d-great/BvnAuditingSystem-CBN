using System;

namespace CentralBankBvnSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var BvnAuditor = new BvnAuditor();
            BvnAuditor.BvnAuditorInterface();

            BvnAuditor.handleBvnAuditing += EventHandlers.CheckBvn;
            BvnAuditor.handleBvnEnrolmennt += EventHandlers.EnrolBvn;

            //BvnAuditor.CheckBvn(BvnAuditor.Classbvn);
            //BvnAuditor.EnrolBvn(BvnAuditor.newAccount);


            var LoginProcess = new LoginProcess();
            LoginProcess.RaiseAlarm += EventHandlers.raiseFireAlarm;
            // LoginProcess.SendEmail += EventHandlers.sendEmailToAdministrator;

            LoginProcess.raiseFireAlarm();
            //LoginProcess.sendEmailToAdministrator();
        }
    }
    class EventHandlers
    {
        public static void CheckBvn(object sender, int? bvn)
        {
            if (bvn != null)
            {
                Console.Clear();
                Console.WriteLine($"Your BVN is {bvn}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Your BVN is not set! \nIf you have a bvn please add it up \nIf you dont have one, Please enrol for it");

            }

        }

        public static void EnrolBvn(object sender, AccountService account)
        {
           var Newbvn = new Random();
            var num = (int?)Newbvn.Next(10000000, 99999999);
            Console.Clear();
            account.setBvn = num;
            

        }



        public  static void raiseFireAlarm()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nWARNING!");
            Console.WriteLine("\nWARNING!");
            Console.WriteLine("\nWARNING!");
            
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" \n\nYou are banned from using this or any banking system");
            sendEmailToAdministrator();
            var repetition = 10;
            for (int i = 0; i < repetition; i++)
            {
                Console.Beep(800, 250);
                Console.Beep(970, 250);
            }
            
        }

        public static void sendEmailToAdministrator()
        {
            Console.WriteLine("Email sent to Adminstrator : CBN");
        }

    }

}

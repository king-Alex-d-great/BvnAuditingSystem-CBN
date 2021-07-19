using System;
using System.Collections.Generic;
using System.Text;

namespace CentralBankBvnSystem
{
    class LoginProcess
    {
        public event handleAlerts RaiseAlarm;
       // public event handleAlerts SendEmail;

        public static void Login(AccountService newAccount)
        {
            string name;
            string password;
            var inputCount = 0;

           while ( true && inputCount < 3)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Please Login");
                Console.WriteLine("Enter your name");
                name = Console.ReadLine();
                Console.WriteLine("Enter your password");
                password = Console.ReadLine();

                if (name.ToLower() == newAccount.Name.ToLower() && name.ToLower() != "james" && name.ToLower() != "bill" && name.ToLower() != "jane" && password == newAccount.setPassword)
                {
                    var BvnAuditor = new BvnAuditor();
                    BvnAuditor.BvnAuditorInterfaceMain(newAccount);
                    break;
                }
                else if (name.ToLower() == "james" || name.ToLower() == "bill" || name.ToLower() == "jane")
                {
                    var LoginProcess = new LoginProcess();
                    LoginProcess.raiseFireAlarm();
                    break;
                } 
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\nError Alert");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Your login details are wrong\n");
                    Console.WriteLine($"You have {2 - inputCount} more chances \nBEFORE YOUR ACCOUNT GETS BLOCKED\n");
                    inputCount++;
                }
            }
            if (inputCount > 2)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nError Alert");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("your Account has been blocked ");
            }
        }

        public void raiseFireAlarm()
        {
            onRaiseAlarm();
        }

       /* public void sendEmailToAdministrator()
        {
            onSendEmail();
        }*/

        protected virtual void onRaiseAlarm()
        {
            RaiseAlarm?.Invoke();
        }

       /* protected virtual void onSendEmail()
        {
            SendEmail?.Invoke();
        }*/
    }
}

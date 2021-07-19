using System;

namespace CentralBankBvnSystem
{
    public delegate void handleAlerts();
    class BvnAuditor
    {
        public event EventHandler<int?> handleBvnAuditing;
        public event EventHandler<AccountService> handleBvnEnrolmennt;
        
        public static int? Classbvn;
       public static AccountService newAccount;

        public static void BvnAuditorInterface()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Welcome to Automated BVN Auditor\n\n ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Please Input your name\n");
            var name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                while (true)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\nError Alert");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("     Your name cannot be empty\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Please Input your name\n");
                    name = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(name))
                    {
                        break;
                    }
                }

            }

            try
            {
                Console.WriteLine("\nPlease enter your 8-digit BVN\n");
                int? bvn = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Please enter a four-character password\n");
                var password = Console.ReadLine();

                var FormData = new Register
                {
                    Name = name,
                    BVN = bvn,
                    Password = password,
                };

                Register(FormData);

            }
            catch (FormatException F)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You Did not Input anything\nContinue your Reg Process and set your BVN Later!\n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Please enter a four-character password\n");
                var password = Console.ReadLine();
                if (String.IsNullOrWhiteSpace(password) || password.Length != 4)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You did not put a password, your password has been set to 0000\n");
                }
                int? bvn = null;

                var FormData = new Register
                {
                    Name = name,
                    BVN = bvn,
                    Password = password,
                };

                Register(FormData);

            }

        }
        public void BvnAuditorInterfaceMain(AccountService account)
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            //Console.WriteLine($"Hello {account.Name}\n\n ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Please select an option\n");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("1 : Check BVN\n");
            Console.WriteLine("2 : Enrol for BVN\n");
            var userInput = Console.ReadLine();
            var inputCount = 0;

            while (true && inputCount != 3)
            {
                if (userInput == "1")
                {
                    CheckBvn(account.setBvn);
                    break;
                }
                else if (userInput == "2")
                {
                    //EnrolBvn(account);
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You put in an invalid option\n");
                    Console.WriteLine($"You have {2 - inputCount} more chances\n");
                    inputCount++;
                }

                if (inputCount > 2)
                {
                    Console.WriteLine("your Chances have been exhausted ");
                }

            }

        }

        public static void Register(Register model)
        {
            BvnAuditor.Classbvn = model.BVN;
            newAccount = new AccountService()
            {
                Name = model.Name,
                setBvn = model.BVN,
                setPassword = model.Password,
            };

            LoginProcess.Login(newAccount);
        }
        public void CheckBvn(int? bvn)
        {
           onCheckBvn(bvn);
        }

        public void EnrolBvn(AccountService account)
        {
           onEnrolBvn(account);
        }

        

        protected virtual void onCheckBvn(int? bvn)
        {
            handleBvnAuditing?.Invoke(this, bvn);
        }

        protected virtual void onEnrolBvn(AccountService account)
        {
            handleBvnEnrolmennt?.Invoke(this, account);
        }

        

    }
}

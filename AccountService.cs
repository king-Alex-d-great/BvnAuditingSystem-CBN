using System;

namespace CentralBankBvnSystem
{
    class AccountService
    {
        public string Name;
        string Password;
        int? BVN;

        public AccountService(string name, string password, int? bvn)
        {
            name = Name;
            bvn = setBvn;
            password = setPassword;
        }

        public AccountService()
        {

        }

        public string setPassword
        {
            get
            {
                return Password;
            }
            set
            {
                if (value.Length == 4)
                {
                    Password = value;
                }
                else if (string.IsNullOrWhiteSpace(value) || value.Length != 4)
                {
                    Password = "0000";
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\nError Alert");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("   Your password was NOT set to Four digits and  has Automatically been set to 0000\n");
                }
            }
        }

        public int? setBvn
        {
            get
            {
                return BVN;
            }

            set
            {
                if (value.ToString().Length == 8 && value != null)
                {
                    BVN = value;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Your Bvn has been successfully set to {value}");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\nError Alert");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("   Your BVN should be 8- digits, your input is incorrect and You will have to Login to reset it");
                    BVN = null;

                }
            }
        }
    }
}

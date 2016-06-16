using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAuth.Data;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter 1 to create new user, 2 to log in");
            string input = Console.ReadLine();
            if (input == "1")
            {
                Console.WriteLine("Enter username");
                string username = Console.ReadLine();
                Console.WriteLine("Enter password");
                string password = Console.ReadLine();
                var manager = new UserManager(Properties.Settings.Default.ConStr);
                manager.AddUser(username, password);
            }
            else
            {
                Console.WriteLine("Enter username");
                string username = Console.ReadLine();
                Console.WriteLine("Enter password");
                string password = Console.ReadLine();
                var manager = new UserManager(Properties.Settings.Default.ConStr);
                User user = manager.Login(username, password);
                if (user == null)
                {
                    Console.WriteLine("Invalid login...");
                }
                else
                {
                    Console.WriteLine("WOOHOO!!");
                }
            }

            Console.ReadKey(true);
        }
    }
}

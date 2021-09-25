using System;
using System.Linq;

namespace _05.Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string password = string.Empty;     // == empty string "";
            //string password = string.Join("", userName.Reverse());

            for (int i = username.Length - 1; i >= 0; i--)
            {
                password += username[i];
            }


            for (int i = 0; i < 4; i++)
            {
                string inputPassword = Console.ReadLine();

                if (inputPassword == password)
                {
                    Console.WriteLine($"User {username} logged in.");
                    break;
                }

                if (i == 3)
                {
                    Console.WriteLine($"User {username} blocked!");
                    break;
                }

                if (inputPassword != password)
                {
                    Console.WriteLine("Incorrect password. Try again.");
                }
            }
        }
    }
}
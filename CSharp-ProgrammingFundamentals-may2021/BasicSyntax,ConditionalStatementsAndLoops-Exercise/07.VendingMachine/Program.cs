using System;

namespace _07.VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();

             double money = 0;
            
            while (command != "Start")
            {
                double inputMoney = double.Parse(command);

                if (inputMoney == 0.1 || inputMoney == 0.2 || inputMoney == 0.5 || inputMoney == 1 || inputMoney == 2)
                {
                    money += inputMoney;
                }
                else
                {
                    Console.WriteLine($"Cannot accept {inputMoney}");
                }

                command = Console.ReadLine();
            }

            command = Console.ReadLine();

            while (command != "End")
            {
                double productPrice = 0;
               
                if (command == "Nuts")
                {
                    productPrice = 2.0;
                }
                else if (command == "Water")
                {
                    productPrice = 0.7;
                }
                else if (command == "Crisps")
                {
                    productPrice = 1.50;
                }
                else if (command == "Soda")
                {
                    productPrice = 0.80;
                }
                else if (command == "Coke")
                {
                    productPrice = 1.0;
                }
                else
                {
                    Console.WriteLine("Invalid product");
                    command = Console.ReadLine();
                    continue;
                }

                if (money >= productPrice)
                {
                    Console.WriteLine($"Purchased {command.ToLower()}");
                    money -= productPrice;
                }
                else
                {
                    Console.WriteLine("Sorry, not enough money");
                }

                command = Console.ReadLine();
            }
            Console.WriteLine($"Change: {money:f2}");
        }
    }
}

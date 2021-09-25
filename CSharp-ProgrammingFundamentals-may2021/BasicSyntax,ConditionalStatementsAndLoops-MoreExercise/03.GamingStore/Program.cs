using System;

namespace _03.GamingStore
{
    class Program
    {
        static void Main(string[] args)
        {
            double currentBalance = double.Parse(Console.ReadLine());

            string input = Console.ReadLine();
            double spendMoney = currentBalance;

            while (input != "Game Time")
            {
                if (input == "OutFall 4" || input == "RoverWatch Origins Edition")
                {
                    if (currentBalance >= 39.99)
                    {
                        currentBalance -= 39.99;
                        Console.WriteLine($"Bought {input}");
                    }
                    else if (currentBalance < 39.99 && currentBalance > 0)
                    {
                        Console.WriteLine("Too Expensive");
                    }
                }
                else if (input == "CS: OG")
                {
                    if (currentBalance >= 15.99)
                    {
                        currentBalance -= 15.99;
                        Console.WriteLine($"Bought {input}");
                    }
                    else if (currentBalance < 15.99 && currentBalance > 0)
                    {
                        Console.WriteLine("Too Expensive");
                    }
                }
                else if (input == "Zplinter Zell")
                {
                    if (currentBalance >= 19.99)
                    {
                        currentBalance -= 19.99;
                        Console.WriteLine($"Bought {input}");
                    }
                    else if (currentBalance < 19.99 && currentBalance > 0)
                    {
                        Console.WriteLine("Too Expensive");
                    }
                }
                else if (input == "Honored 2")
                {
                    if (currentBalance >= 59.99)
                    {
                        currentBalance -= 59.99;
                        Console.WriteLine($"Bought {input}");
                    }
                    else if (currentBalance < 59.99 && currentBalance > 0)
                    {
                        Console.WriteLine("Too Expensive");
                    }
                }
                else if (input == "RoverWatch")
                {
                    if (currentBalance >= 29.99)
                    {
                        currentBalance -= 29.99;
                        Console.WriteLine($"Bought {input}");
                    }
                    else if (currentBalance < 29.99 && currentBalance > 0)
                    {
                        Console.WriteLine("Too Expensive");
                    }
                }
                else if (input != "Game Time")
                {
                    Console.WriteLine("Not Found");
                }

                if (currentBalance <= 0)
                {
                    Console.WriteLine("Out of money!");
                    break;
                }

                input = Console.ReadLine();
            }

            if (currentBalance > 0)
            {
                Console.WriteLine($"Total spent: ${(spendMoney - currentBalance):f2}. Remaining: ${currentBalance:f2}");
            }
        }
    }
}

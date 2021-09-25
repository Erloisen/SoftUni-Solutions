using System;

namespace _06.BalancedBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            bool isOpend = false;

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                if (input == "(")
                {
                    if (isOpend)
                    {
                        Console.WriteLine("UNBALANCED");
                        return;
                    }
                    isOpend = true;
                }
                else if (input == ")")
                {
                    if (!isOpend)
                    {
                        Console.WriteLine("UNBALANCED");
                        return;
                    }

                    isOpend = false;
                }
            }
            Console.WriteLine(isOpend ? "UNBALANCED" : "BALANCED");
        }
    }
}

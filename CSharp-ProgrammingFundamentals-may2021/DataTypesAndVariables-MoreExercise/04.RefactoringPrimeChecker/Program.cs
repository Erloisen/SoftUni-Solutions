using System;

namespace _04.RefactoringPrimeChecker
{
    class Program
    {

        static void Main(string[] args)
        {
            int numbers = int.Parse(Console.ReadLine());

            for (int i = 2; i <= numbers; i++)
            {
                string prime = true.ToString().ToLower();

                for (int j = 2; j < i; j++)
                {
                    if (i % j == 0)
                    {
                        prime = false.ToString().ToLower();
                        break;
                    }
                }
                Console.WriteLine("{0} -> {1}", i, prime);
            }
        }
    }
}

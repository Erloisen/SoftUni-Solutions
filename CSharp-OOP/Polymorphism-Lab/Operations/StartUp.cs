using System;

namespace Operations
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            MathOperations mo = new MathOperations();
            Console.WriteLine(mo.Add(2, 3));
            Console.WriteLine(mo.Add(2.2, 3.3, 5.5));
            Console.WriteLine(mo.Add(2.2M, 3.3M, 4.4M));
        }
    }
}

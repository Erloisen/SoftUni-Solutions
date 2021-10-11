using System;

namespace GenericBoxOfString
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int counter = int.Parse(Console.ReadLine());
            for (int i = 0; i < counter; i++)
            {
                Box<int> box = new Box<int>(int.Parse(Console.ReadLine()));
                Console.WriteLine(box);
            }

        }
    }
}

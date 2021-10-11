using System;

namespace GenericCountMethodStrings
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int counter = int.Parse(Console.ReadLine());

            Box<double> box = new Box<double>();

            for (int i = 0; i < counter; i++)
            {
                double input = double.Parse(Console.ReadLine());

                box.Values.Add(input);
            }

            double targetItem = double.Parse(Console.ReadLine());
            double result = box.GreaterValuesThan(targetItem);

            Console.WriteLine(result);
        }
    }
}

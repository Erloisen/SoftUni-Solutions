using System;

namespace _11.RefactorVolumeOfPyramid
{
    class Program
    {
        static void Main(string[] args)
        {

            double lengt = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            double V = (lengt * width * height) / 3;

            Console.Write("Length: ");
            Console.Write("Width: ");
            Console.Write("Height: ");
            Console.Write($"Pyramid Volume: {V:f2}");

        }
    }
}
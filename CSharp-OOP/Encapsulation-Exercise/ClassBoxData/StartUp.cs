using System;

namespace ClassBoxData
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            try
            {
                Box box = new Box(length, width, height);

                Console.WriteLine($"Surface Area - {box.SurfaceAreaCalculation():F2}");
                Console.WriteLine($"Lateral Surface Area - {box.LateralSurfaceAreaCalculation():F2}");
                Console.WriteLine($"Volume - {box.VolumeCalculation():F2}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

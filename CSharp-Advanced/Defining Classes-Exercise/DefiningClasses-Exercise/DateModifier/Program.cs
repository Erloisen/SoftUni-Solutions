using System;

namespace DateModifier
{
    public class Program
    {
        static void Main(string[] args)
        {
            string startDateInput = Console.ReadLine();
            string endDateInput = Console.ReadLine();

            int days = DateModifier.CalculateDiffranceBetweenDays(startDateInput, endDateInput);

            Console.WriteLine(days);
        }
    }
}

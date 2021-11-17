using System;

namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] sites = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var smatrPhoneNumbers = new Smartphone();
            var stationaryPhone = new StationaryPhone();

            foreach (var number in numbers)
            {
                try
                {
                    if (number.Length == 10)
                    {
                        smatrPhoneNumbers.Call(number);
                    }
                    else if (number.Length == 7)
                    {
                        stationaryPhone.Call(number);
                    }
                    else
                    {
                        Console.WriteLine("Invalid number!");
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }

            foreach (var site in sites)
            {
                try
                {
                    smatrPhoneNumbers.Brows(site);
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}

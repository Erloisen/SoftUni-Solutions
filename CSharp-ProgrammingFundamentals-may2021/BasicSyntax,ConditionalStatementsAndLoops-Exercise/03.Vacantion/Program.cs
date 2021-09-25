using System;

namespace _03.Vacantion
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfPeople = int.Parse(Console.ReadLine());
            string groupType = Console.ReadLine();
            string day = Console.ReadLine();

            double pricePerDay = 0.0;

            switch (day)
            {
                case "Friday":
                    switch (groupType)
                    {
                        case "Students":
                            pricePerDay = 8.45;
                            break;
                        case "Business":
                            pricePerDay = 10.90;
                            break;
                        case "Regular":
                            pricePerDay = 15;
                            break;
                    }
                    break;
                case "Saturday":
                    switch (groupType)
                    {
                        case "Students":
                            pricePerDay = 9.80;
                            break;
                        case "Business":
                            pricePerDay = 15.60;
                            break;
                        case "Regular":
                            pricePerDay = 20;
                            break;
                    }
                    break;
                case "Sunday":
                    switch (groupType)
                    {
                        case "Students":
                            pricePerDay = 10.46;
                            break;
                        case "Business":
                            pricePerDay = 16;
                            break;
                        case "Regular":
                            pricePerDay = 22.50;
                            break;
                    }
                    break;
            }

            double currentAmount = numberOfPeople * pricePerDay;

            if (groupType == "Students" && numberOfPeople >= 30)
            {
                currentAmount *= 0.85;
            }

            if (groupType == "Business" && numberOfPeople >= 100)
            {
                currentAmount = (numberOfPeople - 10) * pricePerDay;
            }

            if (groupType == "Regular" && numberOfPeople >= 10 && numberOfPeople <= 20)
            {
                currentAmount *= 0.95;
            }

            Console.WriteLine($"Total price: {currentAmount:f2}");
        }
    }
}

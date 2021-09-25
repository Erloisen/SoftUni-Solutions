using System;

namespace _09.PadawanEquipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double amountOfMoney = double.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            double priceSingleSabre = double.Parse(Console.ReadLine());
            double priceSingleRobe = double.Parse(Console.ReadLine());
            double priceSingleBelt = double.Parse(Console.ReadLine());

            double freeBelts = students / 6;

            double neededEquipment = (priceSingleSabre * (Math.Ceiling(students * 1.1))) +
                (priceSingleRobe * students) +
                (priceSingleBelt * (students-freeBelts));

            if (amountOfMoney >= neededEquipment)
            {
                Console.WriteLine($"The money is enough - it would cost {neededEquipment:f2}lv.");
            }
            else
            {
                Console.WriteLine($"John will need {(neededEquipment - amountOfMoney):f2}lv more.");
            }
        }
    }
}

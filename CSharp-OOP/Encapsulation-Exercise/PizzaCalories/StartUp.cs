using System;

namespace PizzaCalories
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var pizzaName = Console.ReadLine().Split(' ')[1];
            var doughInfo = Console.ReadLine().Split(' ');
            string flour = doughInfo[1];
            string bakingTechnique = doughInfo[2];
            int doughWeight = int.Parse(doughInfo[3]);

            try
            {
                Dough dough = new Dough(flour, bakingTechnique, doughWeight);
                Pizza pizza = new Pizza(pizzaName, dough);

                string command = Console.ReadLine();
                while (command != "END")
                {
                    string[] comandInfo = command.Split(' ');
                    string toppingName = comandInfo[1];
                    int toppingWeight = int.Parse(comandInfo[2]);

                    Topping topping = new Topping(toppingName, toppingWeight);
                    pizza.AddTopping(topping);

                    command = Console.ReadLine();
                }

                Console.WriteLine($"{pizza.Name} - {pizza.GetCalories():F2} Calories.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

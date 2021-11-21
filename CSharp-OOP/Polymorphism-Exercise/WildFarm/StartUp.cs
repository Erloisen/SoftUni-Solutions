using System;
using System.Collections.Generic;

namespace WildFarm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string command = string.Empty;
            Queue<Animal> wildFarm = new Queue<Animal>();
            Animal animal = null;
            int counter = 0;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] commandInfo = command.Split();
                if (counter % 2 == 0)
                {
                    animal = CreateAnimal(animal, commandInfo);
                }
                else
                {
                    Food food = CreateFood(commandInfo);
                    FeedAnimal(animal, food);

                    wildFarm.Enqueue(animal);
                }

                counter++;
            }

            while (wildFarm.Count > 0)
            {
                Console.WriteLine(wildFarm.Dequeue().ToString());
            }
        }

        private static void FeedAnimal(Animal animal, Food food)
        {
            try
            {
                animal.Eat(food);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static Food CreateFood(string[] commandInfo)
        {
            string foodType = commandInfo[0];
            int foodQuantity = int.Parse(commandInfo[1]);
            Food food = null;

            switch (foodType)
            {
                case nameof(Fruit):
                    food = new Fruit(foodQuantity);
                    break;
                case nameof(Vegetable):
                    food = new Vegetable(foodQuantity);
                    break;
                case nameof(Meat):
                    food = new Meat(foodQuantity);
                    break;
                case nameof(Seeds):
                    food = new Seeds(foodQuantity);
                    break;
            }

            return food;
        }

        private static Animal CreateAnimal(Animal animal, string[] commandInfo)
        {
            string animalType = commandInfo[0];
            string animalName = commandInfo[1];
            double animalWeight = double.Parse(commandInfo[2]);
            switch (animalType)
            {
                case nameof(Cat):
                    string livingRegion = commandInfo[3];
                    string breed = commandInfo[4];
                    animal = new Cat(animalName, animalWeight, livingRegion, breed);
                    AskForFood(animal);
                    break;
                case nameof(Tiger):
                    livingRegion = commandInfo[3];
                    breed = commandInfo[4];
                    animal = new Tiger(animalName, animalWeight, livingRegion, breed);
                    AskForFood(animal);
                    break;
                case nameof(Mouse):
                    livingRegion = commandInfo[3];
                    animal = new Mouse(animalName, animalWeight, livingRegion);
                    AskForFood(animal);
                    break;
                case nameof(Dog):
                    livingRegion = commandInfo[3];
                    animal = new Dog(animalName, animalWeight, livingRegion);
                    AskForFood(animal);
                    break;
                case nameof(Owl):
                    double wingSize = double.Parse(commandInfo[3]);
                    animal = new Owl(animalName, animalWeight, wingSize);
                    AskForFood(animal);
                    break;
                case nameof(Hen):
                    wingSize = double.Parse(commandInfo[3]);
                    animal = new Hen(animalName, animalWeight, wingSize);
                    AskForFood(animal);
                    break;
            }

            return animal;
        }

        private static void AskForFood(Animal animal)
        {
            Console.WriteLine(animal.ProducingASound());
        }
    }
}

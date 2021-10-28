using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();
            string input = Console.ReadLine();

            while (input != "Beast!")
            {
                string[] info = Console.ReadLine().Split();

                string name = info[0];
                int age = int.Parse(info[1]);
                string gender = info[2];
                Animal currentAnimal = null;

                if (age > 0)
                {
                    switch (input)
                    {
                        case "Dog":
                            currentAnimal = new Dog(name, age, gender);
                            break;
                        case "Frog":
                            currentAnimal = new Frog(name, age, gender);
                            break;
                        case "Cat":
                            currentAnimal = new Cat(name, age, gender);
                            break;
                        case "Kittens":
                            currentAnimal = new Kitten(name, age);
                            break;
                        case "Tomcat":
                            currentAnimal = new Tomcat(name, age);
                            break;
                        default:
                            Console.WriteLine("Invalid input!");
                            break;
                    }

                    animals.Add(currentAnimal);
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }

                input = Console.ReadLine();
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal.ToString());
            }
        }
    }
}

using System;

namespace Farm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var dog = new Dog();
            dog.Bark();
            dog.Eat();

            var puppy = new Puppy();
            puppy.Eat();
            puppy.Bark();
            puppy.Weep();

            Cat cat = new Cat();
            cat.Eat();
            cat.Meow();
        }
    }
}

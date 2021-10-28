using System;

namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            StackOfStrings myStack = new StackOfStrings();
            Console.WriteLine(myStack.IsEmpty());
        }
    }
}

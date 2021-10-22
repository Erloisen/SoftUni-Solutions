using System;

namespace Stack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            MyStack<int> stack = new MyStack<int>();
            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] commands = input.Split(new[] { " ", ", "}, StringSplitOptions.RemoveEmptyEntries);
                switch (commands[0])
                {
                    case "Push":
                        for (int i = 1; i < commands.Length; i++)
                        {
                            stack.Push(int.Parse(commands[i]));
                        }
                        break;
                    case "Pop":
                        stack.Pop();
                        break;
                }
            }

            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }

            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
        }
    }
}

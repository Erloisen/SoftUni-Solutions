using System;
using System.Collections.Generic;

namespace _09.SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<string> undoes = new Stack<string>();
            undoes.Push(string.Empty);
            int numberOfOperations = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfOperations; i++)
            {
                string[] input = Console.ReadLine().Split(' ');
                string commandName = input[0];

                if (commandName == "1")
                {
                    string argument = input[1];
                    undoes.Push(undoes.Peek() + argument);
                }
                else if (commandName == "2")
                {
                    int argument = int.Parse(input[1]);
                    string currentLastLine = undoes.Peek();
                    undoes.Push(currentLastLine.Substring(0, currentLastLine.Length - argument));
                }
                else if (commandName == "3")
                {
                    int argument = int.Parse(input[1]);
                    string text = undoes.Peek();
                    Console.WriteLine(text[argument - 1]);
                }
                else if (commandName == "4" && undoes.Count > 1)
                {
                    undoes.Pop();
                }
            }
        }
    }
}
